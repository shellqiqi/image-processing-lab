namespace ImageProcessing
{
    partial class ImageAdjustForm
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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.exitButton = new System.Windows.Forms.Button();
            this.executeButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.splitLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lowInNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.highInNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.lowOutNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.highOutNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.gammaNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lowInNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.highInNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lowOutNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.highOutNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gammaNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.exitButton, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.executeButton, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 282);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(286, 56);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // exitButton
            // 
            this.exitButton.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.exitButton.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.exitButton.Location = new System.Drawing.Point(163, 13);
            this.exitButton.Margin = new System.Windows.Forms.Padding(20, 10, 3, 10);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 30);
            this.exitButton.TabIndex = 4;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // executeButton
            // 
            this.executeButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.executeButton.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.executeButton.Location = new System.Drawing.Point(48, 13);
            this.executeButton.Margin = new System.Windows.Forms.Padding(3, 10, 20, 10);
            this.executeButton.Name = "executeButton";
            this.executeButton.Size = new System.Drawing.Size(75, 30);
            this.executeButton.TabIndex = 3;
            this.executeButton.Text = "Execute";
            this.executeButton.UseVisualStyleBackColor = true;
            this.executeButton.Click += new System.EventHandler(this.executeButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.splitLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lowInNumericUpDown, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.highInNumericUpDown, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lowOutNumericUpDown, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.highOutNumericUpDown, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.gammaNumericUpDown, 1, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(286, 282);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // splitLabel
            // 
            this.splitLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.splitLabel.AutoSize = true;
            this.splitLabel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.splitLabel.Location = new System.Drawing.Point(80, 13);
            this.splitLabel.Margin = new System.Windows.Forms.Padding(10);
            this.splitLabel.Name = "splitLabel";
            this.splitLabel.Size = new System.Drawing.Size(53, 20);
            this.splitLabel.TabIndex = 1;
            this.splitLabel.Text = "Low in";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(74, 59);
            this.label1.Margin = new System.Windows.Forms.Padding(10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "High in";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(70, 105);
            this.label2.Margin = new System.Windows.Forms.Padding(10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Low out";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(64, 151);
            this.label3.Margin = new System.Windows.Forms.Padding(10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "High out";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(72, 197);
            this.label4.Margin = new System.Windows.Forms.Padding(10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "Gamma";
            // 
            // lowInNumericUpDown
            // 
            this.lowInNumericUpDown.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lowInNumericUpDown.DecimalPlaces = 3;
            this.lowInNumericUpDown.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lowInNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.lowInNumericUpDown.Location = new System.Drawing.Point(153, 10);
            this.lowInNumericUpDown.Margin = new System.Windows.Forms.Padding(10);
            this.lowInNumericUpDown.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.lowInNumericUpDown.Name = "lowInNumericUpDown";
            this.lowInNumericUpDown.Size = new System.Drawing.Size(120, 26);
            this.lowInNumericUpDown.TabIndex = 2;
            // 
            // highInNumericUpDown
            // 
            this.highInNumericUpDown.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.highInNumericUpDown.DecimalPlaces = 3;
            this.highInNumericUpDown.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.highInNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.highInNumericUpDown.Location = new System.Drawing.Point(153, 56);
            this.highInNumericUpDown.Margin = new System.Windows.Forms.Padding(10);
            this.highInNumericUpDown.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.highInNumericUpDown.Name = "highInNumericUpDown";
            this.highInNumericUpDown.Size = new System.Drawing.Size(120, 26);
            this.highInNumericUpDown.TabIndex = 2;
            this.highInNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lowOutNumericUpDown
            // 
            this.lowOutNumericUpDown.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lowOutNumericUpDown.DecimalPlaces = 3;
            this.lowOutNumericUpDown.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lowOutNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.lowOutNumericUpDown.Location = new System.Drawing.Point(153, 102);
            this.lowOutNumericUpDown.Margin = new System.Windows.Forms.Padding(10);
            this.lowOutNumericUpDown.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.lowOutNumericUpDown.Name = "lowOutNumericUpDown";
            this.lowOutNumericUpDown.Size = new System.Drawing.Size(120, 26);
            this.lowOutNumericUpDown.TabIndex = 2;
            // 
            // highOutNumericUpDown
            // 
            this.highOutNumericUpDown.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.highOutNumericUpDown.DecimalPlaces = 3;
            this.highOutNumericUpDown.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.highOutNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.highOutNumericUpDown.Location = new System.Drawing.Point(153, 148);
            this.highOutNumericUpDown.Margin = new System.Windows.Forms.Padding(10);
            this.highOutNumericUpDown.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.highOutNumericUpDown.Name = "highOutNumericUpDown";
            this.highOutNumericUpDown.Size = new System.Drawing.Size(120, 26);
            this.highOutNumericUpDown.TabIndex = 2;
            this.highOutNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // gammaNumericUpDown
            // 
            this.gammaNumericUpDown.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.gammaNumericUpDown.DecimalPlaces = 3;
            this.gammaNumericUpDown.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gammaNumericUpDown.Location = new System.Drawing.Point(153, 194);
            this.gammaNumericUpDown.Margin = new System.Windows.Forms.Padding(10);
            this.gammaNumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.gammaNumericUpDown.Name = "gammaNumericUpDown";
            this.gammaNumericUpDown.Size = new System.Drawing.Size(120, 26);
            this.gammaNumericUpDown.TabIndex = 2;
            this.gammaNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // ImageAdjustForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 338);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ImageAdjustForm";
            this.Text = "IA config";
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lowInNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.highInNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lowOutNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.highOutNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gammaNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button executeButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label splitLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown lowInNumericUpDown;
        private System.Windows.Forms.NumericUpDown highInNumericUpDown;
        private System.Windows.Forms.NumericUpDown lowOutNumericUpDown;
        private System.Windows.Forms.NumericUpDown highOutNumericUpDown;
        private System.Windows.Forms.NumericUpDown gammaNumericUpDown;
    }
}