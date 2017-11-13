namespace ImageProcessing
{
    partial class HistogramForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.histogramOriginPictureBox = new System.Windows.Forms.PictureBox();
            this.histogramResultPictureBox = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.histogramOriginPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.histogramResultPictureBox)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // histogramOriginPictureBox
            // 
            this.histogramOriginPictureBox.BackColor = System.Drawing.Color.White;
            this.histogramOriginPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.histogramOriginPictureBox.Location = new System.Drawing.Point(0, 0);
            this.histogramOriginPictureBox.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.histogramOriginPictureBox.Name = "histogramOriginPictureBox";
            this.histogramOriginPictureBox.Size = new System.Drawing.Size(140, 261);
            this.histogramOriginPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.histogramOriginPictureBox.TabIndex = 0;
            this.histogramOriginPictureBox.TabStop = false;
            // 
            // histogramResultPictureBox
            // 
            this.histogramResultPictureBox.BackColor = System.Drawing.Color.White;
            this.histogramResultPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.histogramResultPictureBox.Location = new System.Drawing.Point(144, 0);
            this.histogramResultPictureBox.Margin = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.histogramResultPictureBox.Name = "histogramResultPictureBox";
            this.histogramResultPictureBox.Size = new System.Drawing.Size(140, 261);
            this.histogramResultPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.histogramResultPictureBox.TabIndex = 0;
            this.histogramResultPictureBox.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.histogramResultPictureBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.histogramOriginPictureBox, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(284, 261);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // HistogramForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "HistogramForm";
            this.Text = "Histogram";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HistogramForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.histogramOriginPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.histogramResultPictureBox)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox histogramOriginPictureBox;
        private System.Windows.Forms.PictureBox histogramResultPictureBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}