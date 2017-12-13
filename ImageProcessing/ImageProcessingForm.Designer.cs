namespace ImageProcessing
{
    partial class ImageProcessingForm
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.histogramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.histogramEqualizationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.separatedRGBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allChannelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CLAHEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageAdjustToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.originPictureBox = new System.Windows.Forms.PictureBox();
            this.resultPictureBox = new System.Windows.Forms.PictureBox();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.fixWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OriginResultSplitContainer = new System.Windows.Forms.SplitContainer();
            this.onlyShowOriginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.onlyShowResultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showBothToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.originPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OriginResultSplitContainer)).BeginInit();
            this.OriginResultSplitContainer.Panel1.SuspendLayout();
            this.OriginResultSplitContainer.Panel2.SuspendLayout();
            this.OriginResultSplitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.toolToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(584, 25);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(39, 21);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fixWindowToolStripMenuItem,
            this.histogramToolStripMenuItem,
            this.onlyShowOriginToolStripMenuItem,
            this.onlyShowResultToolStripMenuItem,
            this.showBothToolStripMenuItem});
            this.viewToolStripMenuItem.Enabled = false;
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(47, 21);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // histogramToolStripMenuItem
            // 
            this.histogramToolStripMenuItem.Name = "histogramToolStripMenuItem";
            this.histogramToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.histogramToolStripMenuItem.Text = "Histogram";
            this.histogramToolStripMenuItem.Click += new System.EventHandler(this.HistogramToolStripMenuItem_Click);
            // 
            // toolToolStripMenuItem
            // 
            this.toolToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.histogramEqualizationToolStripMenuItem,
            this.CLAHEToolStripMenuItem,
            this.imageAdjustToolStripMenuItem});
            this.toolToolStripMenuItem.Enabled = false;
            this.toolToolStripMenuItem.Name = "toolToolStripMenuItem";
            this.toolToolStripMenuItem.Size = new System.Drawing.Size(46, 21);
            this.toolToolStripMenuItem.Text = "&Tool";
            // 
            // histogramEqualizationToolStripMenuItem
            // 
            this.histogramEqualizationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.separatedRGBToolStripMenuItem,
            this.allChannelsToolStripMenuItem});
            this.histogramEqualizationToolStripMenuItem.Name = "histogramEqualizationToolStripMenuItem";
            this.histogramEqualizationToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.histogramEqualizationToolStripMenuItem.Text = "Histogram Equalization";
            // 
            // separatedRGBToolStripMenuItem
            // 
            this.separatedRGBToolStripMenuItem.Name = "separatedRGBToolStripMenuItem";
            this.separatedRGBToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.separatedRGBToolStripMenuItem.Text = "Separated RGB";
            this.separatedRGBToolStripMenuItem.Click += new System.EventHandler(this.separatedRGBToolStripMenuItem_Click);
            // 
            // allChannelsToolStripMenuItem
            // 
            this.allChannelsToolStripMenuItem.Name = "allChannelsToolStripMenuItem";
            this.allChannelsToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.allChannelsToolStripMenuItem.Text = "All channels";
            this.allChannelsToolStripMenuItem.Click += new System.EventHandler(this.allChannelsToolStripMenuItem_Click);
            // 
            // CLAHEToolStripMenuItem
            // 
            this.CLAHEToolStripMenuItem.Name = "CLAHEToolStripMenuItem";
            this.CLAHEToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.CLAHEToolStripMenuItem.Text = "CLAHE";
            this.CLAHEToolStripMenuItem.Click += new System.EventHandler(this.CLAHEToolStripMenuItem_Click);
            // 
            // imageAdjustToolStripMenuItem
            // 
            this.imageAdjustToolStripMenuItem.Name = "imageAdjustToolStripMenuItem";
            this.imageAdjustToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.imageAdjustToolStripMenuItem.Text = "Image Adjust";
            this.imageAdjustToolStripMenuItem.Click += new System.EventHandler(this.imageAdjustToolStripMenuItem_Click);
            // 
            // originPictureBox
            // 
            this.originPictureBox.BackColor = System.Drawing.SystemColors.Control;
            this.originPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.originPictureBox.Enabled = false;
            this.originPictureBox.Location = new System.Drawing.Point(0, 0);
            this.originPictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.originPictureBox.Name = "originPictureBox";
            this.originPictureBox.Size = new System.Drawing.Size(292, 286);
            this.originPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.originPictureBox.TabIndex = 1;
            this.originPictureBox.TabStop = false;
            // 
            // resultPictureBox
            // 
            this.resultPictureBox.BackColor = System.Drawing.SystemColors.Control;
            this.resultPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultPictureBox.Location = new System.Drawing.Point(0, 0);
            this.resultPictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.resultPictureBox.Name = "resultPictureBox";
            this.resultPictureBox.Size = new System.Drawing.Size(288, 286);
            this.resultPictureBox.TabIndex = 2;
            this.resultPictureBox.TabStop = false;
            this.resultPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.resultPictureBox_MouseDown);
            this.resultPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.resultPictureBox_MouseMove);
            this.resultPictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.resultPictureBox_MouseUp);
            // 
            // fixWindowToolStripMenuItem
            // 
            this.fixWindowToolStripMenuItem.Name = "fixWindowToolStripMenuItem";
            this.fixWindowToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.fixWindowToolStripMenuItem.Text = "Fix window";
            this.fixWindowToolStripMenuItem.Click += new System.EventHandler(this.fixWindowToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.OriginResultSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OriginResultSplitContainer.Location = new System.Drawing.Point(0, 25);
            this.OriginResultSplitContainer.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.OriginResultSplitContainer.Panel1.Controls.Add(this.originPictureBox);
            // 
            // splitContainer1.Panel2
            // 
            this.OriginResultSplitContainer.Panel2.Controls.Add(this.resultPictureBox);
            this.OriginResultSplitContainer.Size = new System.Drawing.Size(584, 286);
            this.OriginResultSplitContainer.SplitterDistance = 292;
            this.OriginResultSplitContainer.TabIndex = 3;
            // 
            // onlyShowOriginToolStripMenuItem
            // 
            this.onlyShowOriginToolStripMenuItem.Name = "onlyShowOriginToolStripMenuItem";
            this.onlyShowOriginToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.onlyShowOriginToolStripMenuItem.Text = "Only show origin";
            this.onlyShowOriginToolStripMenuItem.Click += new System.EventHandler(this.onlyShowOriginToolStripMenuItem_Click);
            // 
            // onlyShowResultToolStripMenuItem
            // 
            this.onlyShowResultToolStripMenuItem.Name = "onlyShowResultToolStripMenuItem";
            this.onlyShowResultToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.onlyShowResultToolStripMenuItem.Text = "Only show result";
            this.onlyShowResultToolStripMenuItem.Click += new System.EventHandler(this.onlyShowResultToolStripMenuItem_Click);
            // 
            // showBothToolStripMenuItem
            // 
            this.showBothToolStripMenuItem.Name = "showBothToolStripMenuItem";
            this.showBothToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.showBothToolStripMenuItem.Text = "Show both";
            this.showBothToolStripMenuItem.Click += new System.EventHandler(this.showBothToolStripMenuItem_Click);
            // 
            // ImageProcessingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 311);
            this.Controls.Add(this.OriginResultSplitContainer);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(300, 175);
            this.Name = "ImageProcessingForm";
            this.Text = "ImageProcessing";
            this.SizeChanged += new System.EventHandler(this.ImageProcessingForm_SizeChanged);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.originPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.OriginResultSplitContainer.Panel1.ResumeLayout(false);
            this.OriginResultSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.OriginResultSplitContainer)).EndInit();
            this.OriginResultSplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem histogramToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem histogramEqualizationToolStripMenuItem;
        private System.Windows.Forms.PictureBox originPictureBox;
        private System.Windows.Forms.PictureBox resultPictureBox;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CLAHEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem separatedRGBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allChannelsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageAdjustToolStripMenuItem;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.ToolStripMenuItem fixWindowToolStripMenuItem;
        private System.Windows.Forms.SplitContainer OriginResultSplitContainer;
        private System.Windows.Forms.ToolStripMenuItem onlyShowOriginToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem onlyShowResultToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showBothToolStripMenuItem;
    }
}

