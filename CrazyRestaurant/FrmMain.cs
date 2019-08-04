using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Imaging.Filters;
using CrazyRestaurant.Common;
using CrazyRestaurant.Properties;

namespace CrazyRestaurant
{
    public partial class FrmMain : Form
    {

        Rectangle rectMain;
        Dictionary<string, Bitmap> dicTemplate = new Dictionary<string, Bitmap>();

        Hotkey hotKey;
        Dictionary<int, Keys> dicKeys = new Dictionary<int, Keys>();
        bool inRun = false;

        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            RefreshState();
            var unit = GraphicsUnit.Pixel;
            dicTemplate.Add("fish", Resources.fish.Clone(Resources.fish.GetBounds(ref unit), PixelFormat.Format8bppIndexed));
            hotKey = new Hotkey(this.Handle);
            dicKeys[hotKey.RegisterHotkey(Keys.Home, Hotkey.KeyFlags.MOD_NONE)] = Keys.Home;
            dicKeys[hotKey.RegisterHotkey(Keys.End, Hotkey.KeyFlags.MOD_NONE)] = Keys.End;
            dicKeys[hotKey.RegisterHotkey(Keys.X, Hotkey.KeyFlags.MOD_ALT)] = Keys.X;
            hotKey.OnHotkey += new HotkeyEventHandler(hotKey_OnHotkey);
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    if (inRun)
                    {
                        SetStepState(1);
                        Ads();
                        SetStepState(2);
                        Serve();
                        SetStepState(3);
                        FishHole();
                        SetStepState(4);
                        PickFish();
                    }
                    Thread.Sleep(1000);
                }
            });
        }

        void RefreshState()
        {
            if (inRun)
            {
                this.labState.Image = Resources.Run;
                this.labState.Text = "Running...";
            }
            else
            {
                this.labState.Image = Resources.Stop;
                this.labState.Text = "Waiting for start...";
                SetStepState(0);
            }
        }

        void SetStepState(int step)
        {
            this.Invoke(new Action(() =>
            {
                foreach (Label lab in this.plStep.Controls)
                {
                    if (Convert.ToInt32(lab.Tag) == step)
                        lab.BackColor = Color.Gray;
                    else
                        lab.BackColor = Color.Transparent;
                }
            }));
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            hotKey.UnregisterHotkeys();
        }

        void hotKey_OnHotkey(int hotKeyID)
        {
            switch (dicKeys[hotKeyID])
            {
                case Keys.Home:
                    {
                        AppInvoke.Init();
                        rectMain = AppInvoke.Rectangle;
                        lastMovePosition = rectMain.Location;
                        this.picModify.Height = rectMain.Height * this.picModify.Width / rectMain.Width;
                        inRun = true;
                        RefreshState();
                    }
                    break;
                case Keys.End:
                    {
                        inRun = false;
                        RefreshState();
                    }
                    break;
                case Keys.X:
                    {
                        this.labPos.Text = $"{MousePosition.X - rectMain.X},{ MousePosition.Y - rectMain.Y }";
                    }
                    break;
            }
        }

        Point lastMovePosition = Point.Empty;
        void SimulateMove(int x, int y, int r)
        {
            x += new Random(BitConverter.ToInt32(Guid.NewGuid().ToByteArray(), 0)).Next(-1 * r, r);
            y += new Random(BitConverter.ToInt32(Guid.NewGuid().ToByteArray(), 0)).Next(-1 * r, r);
            int xl = rectMain.X + x - lastMovePosition.X, yl = rectMain.Y + y - lastMovePosition.Y;
            int sl = Convert.ToInt32(Math.Sqrt(Math.Pow(xl, 2) + Math.Pow(yl, 2)));
            for (int i = 0; i < sl; i++)
            {
                MouseInvoke.Move(lastMovePosition.X + i * xl / sl, lastMovePosition.Y + i * yl / sl);
                Thread.Sleep(1);
            }
            lastMovePosition.X = rectMain.X + x;
            lastMovePosition.Y = rectMain.Y + y;
        }

        private void MoveAndClick(int x, int y, int r = 5)
        {
            SimulateMove(x, y, r);
            MouseInvoke.Click();
        }

        private void Ads()
        {
            for (int j = 0; j < 14; j++)
            {
                MoveAndClick(350, 648, 10);
                Thread.Sleep(240);
            }
        }

        private void Serve()
        {
            MoveAndClick(147, 261);
            MoveAndClick(237, 262);
            MoveAndClick(326, 261);
            MoveAndClick(151, 378);
            MoveAndClick(236, 377);
            MoveAndClick(326, 376);
        }

        private void FishHole()
        {
            MoveAndClick(58, 285);
            MoveAndClick(253, 309);
            MoveAndClick(176, 520);
            MoveAndClick(168, 593);
            MoveAndClick(162, 311);
            MoveAndClick(341, 425);
        }

        private void PickFish()
        {
            var bmp = new Bitmap(AppInvoke.GetImage());
            var bmpShow = bmp.Clone() as Image;
            var g = Graphics.FromImage(bmpShow);
            //灰度化
            bmp = Grayscale.CommonAlgorithms.BT709.Apply(bmp);
            //反色
            new Invert().ApplyInPlace(bmp);
            //二值化
            new Threshold(120).ApplyInPlace(bmp);
            //保存模板以用于识别
            //bmp.Save("template.bmp");
            var matchArray = new AForge.Imaging.ExhaustiveTemplateMatching(0.8f).ProcessImage(bmp, dicTemplate["fish"]);
            foreach (var m in matchArray)
            {
                g.FillRectangle(Brushes.Red, m.Rectangle);
                MoveAndClick(m.Rectangle.X + m.Rectangle.Width / 2, m.Rectangle.Y + m.Rectangle.Height / 2, 0);
            }
            this.Invoke(new Action(() =>
            {
                this.picModify.Image = bmpShow;
            }));
        }
    }
}

