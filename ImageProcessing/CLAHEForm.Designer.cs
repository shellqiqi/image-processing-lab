namespace ImageProcessing
{
    partial class CLAHEForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.splitNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.executeButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.splitLabel = new System.Windows.Forms.Label();
            this.limitLabel = new System.Windows.Forms.Label();
            this.limitNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.separateRGBLabel = new System.Windows.Forms.Label();
            this.separateRGBCheckBox = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.limitNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.splitNumericUpDown, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.executeButton, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.exitButton, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.splitLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.limitLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.limitNumericUpDown, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.separateRGBLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.separateRGBCheckBox, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(284, 261);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // splitNumericUpDown
            // 
            this.splitNumericUpDown.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.splitNumericUpDown.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.splitNumericUpDown.Location = new System.Drawing.Point(154, 10);
            this.splitNumericUpDown.Margin = new System.Windows.Forms.Padding(10);
            this.splitNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.splitNumericUpDown.Name = "splitNumericUpDown";
            this.splitNumericUpDown.Size = new System.Drawing.Size(120, 26);
            this.splitNumericUpDown.TabIndex = 1;
            this.splitNumericUpDown.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // executeButton
            // 
            this.executeButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.executeButton.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.executeButton.Location = new System.Drawing.Point(49, 221);
            this.executeButton.Margin = new System.Windows.Forms.Padding(3, 10, 20, 10);
            this.executeButton.Name = "executeButton";
            this.executeButton.Size = new System.Drawing.Size(75, 30);
            this.executeButton.TabIndex = 2;
            this.executeButton.Text = "Execute";
            this.executeButton.UseVisualStyleBackColor = true;
            this.executeButton.Click += new System.EventHandler(this.executeButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.exitButton.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.exitButton.Location = new System.Drawing.Point(164, 221);
            this.exitButton.Margin = new System.Windows.Forms.Padding(20, 10, 3, 10);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 30);
            this.exitButton.TabIndex = 3;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // splitLabel
            // 
            this.splitLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.splitLabel.AutoSize = true;
            this.splitLabel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.splitLabel.Location = new System.Drawing.Point(52, 13);
            this.splitLabel.Margin = new System.Windows.Forms.Padding(10);
            this.splitLabel.Name = "splitLabel";
            this.splitLabel.Size = new System.Drawing.Size(82, 20);
            this.splitLabel.TabIndex = 0;
            this.splitLabel.Text = "Split count";
            // 
            // limitLabel
            // 
            this.limitLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.limitLabel.AutoSize = true;
            this.limitLabel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.limitLabel.Location = new System.Drawing.Point(35, 59);
            this.limitLabel.Margin = new System.Windows.Forms.Padding(10);
            this.limitLabel.Name = "limitLabel";
            this.limitLabel.Size = new System.Drawing.Size(99, 20);
            this.limitLabel.TabIndex = 0;
            this.limitLabel.Text = "Contrast limit";
            // 
            // limitNumericUpDown
            // 
            this.limitNumericUpDown.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.limitNumericUpDown.DecimalPlaces = 2;
            this.limitNumericUpDown.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.limitNumericUpDown.Location = new System.Drawing.Point(154, 56);
            this.limitNumericUpDown.Margin = new System.Windows.Forms.Padding(10);
            this.limitNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.limitNumericUpDown.Name = "limitNumericUpDown";
            this.limitNumericUpDown.Size = new System.Drawing.Size(120, 26);
            this.limitNumericUpDown.TabIndex = 1;
            this.limitNumericUpDown.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            // 
            // separateRGBLabel
            // 
            this.separateRGBLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.separateRGBLabel.AutoSize = true;
            this.separateRGBLabel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.separateRGBLabel.Location = new System.Drawing.Point(34, 104);
            this.separateRGBLabel.Margin = new System.Windows.Forms.Padding(10);
            this.separateRGBLabel.Name = "separateRGBLabel";
            this.separateRGBLabel.Size = new System.Drawing.Size(100, 20);
            this.separateRGBLabel.TabIndex = 0;
            this.separateRGBLabel.Text = "Separate RGB";
            // 
            // separateRGBCheckBox
            // 
            this.separateRGBCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.separateRGBCheckBox.AutoSize = true;
            this.separateRGBCheckBox.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.separateRGBCheckBox.Location = new System.Drawing.Point(154, 102);
            this.separateRGBCheckBox.Margin = new System.Windows.Forms.Padding(10);
            this.separateRGBCheckBox.Name = "separateRGBCheckBox";
            this.separateRGBCheckBox.Size = new System.Drawing.Size(48, 24);
            this.separateRGBCheckBox.TabIndex = 4;
            this.separateRGBCheckBox.Text = "No";
            this.separateRGBCheckBox.UseVisualStyleBackColor = true;
            this.separateRGBCheckBox.CheckedChanged += new System.EventHandler(this.separateRGBCheckBox_CheckedChanged);
            // 
            // CLAHEForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(300, 300);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "CLAHEForm";
            this.Text = "CLAHE config";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.limitNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label splitLabel;
        private System.Windows.Forms.NumericUpDown splitNumericUpDown;
        private System.Windows.Forms.Button executeButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Label limitLabel;
        private System.Windows.Forms.NumericUpDown limitNumericUpDown;
        private System.Windows.Forms.Label separateRGBLabel;
        private System.Windows.Forms.CheckBox separateRGBCheckBox;
    }
}