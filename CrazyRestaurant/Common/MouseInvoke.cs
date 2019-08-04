using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CrazyRestaurant.Common
{
    public class MouseInvoke
    {
        [DllImport("user32.dll")]
        private static extern void mouse_event(int flags, int dX, int dY, int buttons, int extraInfo);

        private static readonly int MOUSEEVENTF_MOVE = 0x0001;//模拟鼠标移动
        private static readonly int MOUSEEVENTF_LEFTDOWN = 0x0002;//模拟鼠标左键按下
        private static readonly int MOUSEEVENTF_LEFTUP = 0x0004;//模拟鼠标左键抬起
        private static readonly int MOUSEEVENTF_RIGHTDOWN = 0x0008; //模拟鼠标右键按下 
        private static readonly int MOUSEEVENTF_RIGHTUP = 0x0010; //模拟鼠标右键抬起 
        private static readonly int MOUSEEVENTF_MIDDLEDOWN = 0x0020; //模拟鼠标中键按下 
        private static readonly int MOUSEEVENTF_MIDDLEUP = 0x0040;// 模拟鼠标中键抬起
        private static readonly int MOUSEEVENTF_WHEEL = 0x0800;// 模拟鼠标中键抬起 
        private static readonly int MOUSEEVENTF_ABSOLUTE = 0x8000;//鼠标绝对位置   

        public static void Move(int x, int y)
        {
            int dx = x * 0xffff / Screen.PrimaryScreen.Bounds.Width;
            int dy = y * 0xffff / Screen.PrimaryScreen.Bounds.Height;
            mouse_event(MOUSEEVENTF_MOVE | MOUSEEVENTF_ABSOLUTE, dx, dy, 0, 0);
        }

        public static void Click()
        {
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
        }

        public static void Wheel(int delta)
        {
            mouse_event(MOUSEEVENTF_WHEEL, 0, 0, delta * 120, 0);
        }
    }
}
