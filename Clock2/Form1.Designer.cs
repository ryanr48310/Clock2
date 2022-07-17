namespace Clock2
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
            this.components = new System.ComponentModel.Container();
            this.timeLab = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.dateLab = new System.Windows.Forms.Label();
            this.dayLab = new System.Windows.Forms.Label();
            this.curTempLab = new System.Windows.Forms.Label();
            this.highTempLab = new System.Windows.Forms.Label();
            this.lowTempLab = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timeLab
            // 
            this.timeLab.AutoSize = true;
            this.timeLab.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeLab.Location = new System.Drawing.Point(168, 40);
            this.timeLab.Name = "timeLab";
            this.timeLab.Size = new System.Drawing.Size(264, 55);
            this.timeLab.TabIndex = 0;
            this.timeLab.Text = "    00:00:00";
            this.timeLab.Click += new System.EventHandler(this.label1_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // dateLab
            // 
            this.dateLab.AutoSize = true;
            this.dateLab.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateLab.Location = new System.Drawing.Point(35, 199);
            this.dateLab.Name = "dateLab";
            this.dateLab.Size = new System.Drawing.Size(266, 55);
            this.dateLab.TabIndex = 1;
            this.dateLab.Text = "00/00/0000";
            // 
            // dayLab
            // 
            this.dayLab.AutoSize = true;
            this.dayLab.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dayLab.Location = new System.Drawing.Point(399, 199);
            this.dayLab.Name = "dayLab";
            this.dayLab.Size = new System.Drawing.Size(279, 55);
            this.dayLab.TabIndex = 2;
            this.dayLab.Text = "Wednesday";
            // 
            // curTempLab
            // 
            this.curTempLab.AutoSize = true;
            this.curTempLab.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.curTempLab.Location = new System.Drawing.Point(28, 25);
            this.curTempLab.Name = "curTempLab";
            this.curTempLab.Size = new System.Drawing.Size(97, 55);
            this.curTempLab.TabIndex = 3;
            this.curTempLab.Text = "00°";
            // 
            // highTempLab
            // 
            this.highTempLab.AutoSize = true;
            this.highTempLab.Location = new System.Drawing.Point(35, 80);
            this.highTempLab.Name = "highTempLab";
            this.highTempLab.Size = new System.Drawing.Size(51, 13);
            this.highTempLab.TabIndex = 4;
            this.highTempLab.Text = "High: 00°";
            // 
            // lowTempLab
            // 
            this.lowTempLab.AutoSize = true;
            this.lowTempLab.Location = new System.Drawing.Point(35, 104);
            this.lowTempLab.Name = "lowTempLab";
            this.lowTempLab.Size = new System.Drawing.Size(49, 13);
            this.lowTempLab.TabIndex = 5;
            this.lowTempLab.Text = "Low: 00°";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 287);
            this.Controls.Add(this.lowTempLab);
            this.Controls.Add(this.highTempLab);
            this.Controls.Add(this.curTempLab);
            this.Controls.Add(this.dayLab);
            this.Controls.Add(this.dateLab);
            this.Controls.Add(this.timeLab);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label timeLab;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label dateLab;
        private System.Windows.Forms.Label dayLab;
        private System.Windows.Forms.Label curTempLab;
        private System.Windows.Forms.Label highTempLab;
        private System.Windows.Forms.Label lowTempLab;
    }
}

