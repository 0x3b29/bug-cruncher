namespace ImageCruncher
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbPosX = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbPosY = new System.Windows.Forms.TextBox();
            this.nudDeltaR = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.nudDeltaG = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.nudDeltaB = new System.Windows.Forms.NumericUpDown();
            this.nudMinWidth = new System.Windows.Forms.NumericUpDown();
            this.nudMaxWidth = new System.Windows.Forms.NumericUpDown();
            this.nudMinHeight = new System.Windows.Forms.NumericUpDown();
            this.nudMaxHeight = new System.Windows.Forms.NumericUpDown();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudDeltaR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDeltaG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDeltaB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1406, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(165, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Find them bugs";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1407, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "MinWidth";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1497, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "MaxWidth";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1497, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "MaxHeight";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1407, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "MinHeight";
            // 
            // tbPosX
            // 
            this.tbPosX.Location = new System.Drawing.Point(1410, 163);
            this.tbPosX.Name = "tbPosX";
            this.tbPosX.Size = new System.Drawing.Size(71, 20);
            this.tbPosX.TabIndex = 10;
            this.tbPosX.Text = "10";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1407, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Start Pos X";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1497, 147);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Start Pos Y";
            // 
            // tbPosY
            // 
            this.tbPosY.Location = new System.Drawing.Point(1500, 163);
            this.tbPosY.Name = "tbPosY";
            this.tbPosY.Size = new System.Drawing.Size(71, 20);
            this.tbPosY.TabIndex = 12;
            this.tbPosY.Text = "10";
            // 
            // nudDeltaR
            // 
            this.nudDeltaR.Location = new System.Drawing.Point(1410, 248);
            this.nudDeltaR.Name = "nudDeltaR";
            this.nudDeltaR.Size = new System.Drawing.Size(71, 20);
            this.nudDeltaR.TabIndex = 14;
            this.nudDeltaR.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1407, 232);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Max Delta R";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1407, 280);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Max Delta G";
            // 
            // nudDeltaG
            // 
            this.nudDeltaG.Location = new System.Drawing.Point(1410, 296);
            this.nudDeltaG.Name = "nudDeltaG";
            this.nudDeltaG.Size = new System.Drawing.Size(71, 20);
            this.nudDeltaG.TabIndex = 16;
            this.nudDeltaG.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1407, 332);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Max Delta B";
            // 
            // nudDeltaB
            // 
            this.nudDeltaB.Location = new System.Drawing.Point(1410, 348);
            this.nudDeltaB.Name = "nudDeltaB";
            this.nudDeltaB.Size = new System.Drawing.Size(71, 20);
            this.nudDeltaB.TabIndex = 18;
            this.nudDeltaB.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // nudMinWidth
            // 
            this.nudMinWidth.DecimalPlaces = 1;
            this.nudMinWidth.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nudMinWidth.Location = new System.Drawing.Point(1410, 58);
            this.nudMinWidth.Name = "nudMinWidth";
            this.nudMinWidth.Size = new System.Drawing.Size(71, 20);
            this.nudMinWidth.TabIndex = 20;
            this.nudMinWidth.Value = new decimal(new int[] {
            15,
            0,
            0,
            65536});
            // 
            // nudMaxWidth
            // 
            this.nudMaxWidth.DecimalPlaces = 1;
            this.nudMaxWidth.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nudMaxWidth.Location = new System.Drawing.Point(1500, 58);
            this.nudMaxWidth.Name = "nudMaxWidth";
            this.nudMaxWidth.Size = new System.Drawing.Size(71, 20);
            this.nudMaxWidth.TabIndex = 21;
            this.nudMaxWidth.Value = new decimal(new int[] {
            75,
            0,
            0,
            65536});
            // 
            // nudMinHeight
            // 
            this.nudMinHeight.DecimalPlaces = 1;
            this.nudMinHeight.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nudMinHeight.Location = new System.Drawing.Point(1410, 100);
            this.nudMinHeight.Name = "nudMinHeight";
            this.nudMinHeight.Size = new System.Drawing.Size(71, 20);
            this.nudMinHeight.TabIndex = 22;
            this.nudMinHeight.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // nudMaxHeight
            // 
            this.nudMaxHeight.DecimalPlaces = 1;
            this.nudMaxHeight.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nudMaxHeight.Location = new System.Drawing.Point(1500, 100);
            this.nudMaxHeight.Name = "nudMaxHeight";
            this.nudMaxHeight.Size = new System.Drawing.Size(71, 20);
            this.nudMaxHeight.TabIndex = 23;
            this.nudMaxHeight.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(0, 855);
            this.progressBar1.Maximum = 1000;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1583, 21);
            this.progressBar1.TabIndex = 24;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1388, 824);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 25;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1583, 876);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.nudMaxHeight);
            this.Controls.Add(this.nudMinHeight);
            this.Controls.Add(this.nudMaxWidth);
            this.Controls.Add(this.nudMinWidth);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.nudDeltaB);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.nudDeltaG);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.nudDeltaR);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbPosY);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbPosX);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Debugger";
            ((System.ComponentModel.ISupportInitialize)(this.nudDeltaR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDeltaG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDeltaB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbPosX;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbPosY;
        private System.Windows.Forms.NumericUpDown nudDeltaR;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nudDeltaG;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown nudDeltaB;
        private System.Windows.Forms.NumericUpDown nudMinWidth;
        private System.Windows.Forms.NumericUpDown nudMaxWidth;
        private System.Windows.Forms.NumericUpDown nudMinHeight;
        private System.Windows.Forms.NumericUpDown nudMaxHeight;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

