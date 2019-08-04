namespace CrazyRestaurant
{
    partial class FrmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.labState = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.labPos = new System.Windows.Forms.ToolStripStatusLabel();
            this.picModify = new System.Windows.Forms.PictureBox();
            this.plStep = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picModify)).BeginInit();
            this.plStep.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labState,
            this.toolStripStatusLabel1,
            this.labPos});
            this.statusStrip1.Location = new System.Drawing.Point(0, 363);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusStrip1.Size = new System.Drawing.Size(318, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // labState
            // 
            this.labState.Name = "labState";
            this.labState.Size = new System.Drawing.Size(55, 17);
            this.labState.Text = "Initialize";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(227, 17);
            this.toolStripStatusLabel1.Spring = true;
            // 
            // labPos
            // 
            this.labPos.Name = "labPos";
            this.labPos.Size = new System.Drawing.Size(25, 17);
            this.labPos.Text = "0,0";
            // 
            // picModify
            // 
            this.picModify.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picModify.Location = new System.Drawing.Point(9, 10);
            this.picModify.Margin = new System.Windows.Forms.Padding(2);
            this.picModify.Name = "picModify";
            this.picModify.Size = new System.Drawing.Size(195, 347);
            this.picModify.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picModify.TabIndex = 4;
            this.picModify.TabStop = false;
            // 
            // plStep
            // 
            this.plStep.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.plStep.Controls.Add(this.label4);
            this.plStep.Controls.Add(this.label3);
            this.plStep.Controls.Add(this.label2);
            this.plStep.Controls.Add(this.label1);
            this.plStep.Location = new System.Drawing.Point(209, 10);
            this.plStep.Name = "plStep";
            this.plStep.Size = new System.Drawing.Size(97, 347);
            this.plStep.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Location = new System.Drawing.Point(0, 258);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 86);
            this.label4.TabIndex = 3;
            this.label4.Tag = "4";
            this.label4.Text = "PickFish";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(0, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 86);
            this.label3.TabIndex = 2;
            this.label3.Tag = "3";
            this.label3.Text = "FishHole";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 86);
            this.label2.TabIndex = 1;
            this.label2.Tag = "2";
            this.label2.Text = "Serve";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 86);
            this.label1.TabIndex = 0;
            this.label1.Tag = "1";
            this.label1.Text = "Ads";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 385);
            this.Controls.Add(this.plStep);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.picModify);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CrazyRestaurant";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picModify)).EndInit();
            this.plStep.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox picModify;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel labState;
        private System.Windows.Forms.ToolStripStatusLabel labPos;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Panel plStep;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}

