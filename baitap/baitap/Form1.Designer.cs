namespace baitap
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
            this.bt01 = new System.Windows.Forms.Button();
            this.bt02 = new System.Windows.Forms.Button();
            this.bt03 = new System.Windows.Forms.Button();
            this.bt04 = new System.Windows.Forms.Button();
            this.bt05 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bt01
            // 
            this.bt01.Location = new System.Drawing.Point(40, 50);
            this.bt01.Name = "bt01";
            this.bt01.Size = new System.Drawing.Size(141, 76);
            this.bt01.TabIndex = 0;
            this.bt01.Text = "Bài 01";
            this.bt01.UseVisualStyleBackColor = true;
            this.bt01.Click += new System.EventHandler(this.bt01_Click);
            // 
            // bt02
            // 
            this.bt02.Location = new System.Drawing.Point(214, 50);
            this.bt02.Name = "bt02";
            this.bt02.Size = new System.Drawing.Size(141, 76);
            this.bt02.TabIndex = 0;
            this.bt02.Text = "Bài02";
            this.bt02.UseVisualStyleBackColor = true;
            this.bt02.Click += new System.EventHandler(this.bt02_Click);
            // 
            // bt03
            // 
            this.bt03.Location = new System.Drawing.Point(391, 50);
            this.bt03.Name = "bt03";
            this.bt03.Size = new System.Drawing.Size(141, 76);
            this.bt03.TabIndex = 0;
            this.bt03.Text = "Bài03";
            this.bt03.UseVisualStyleBackColor = true;
            this.bt03.Click += new System.EventHandler(this.bt03_Click);
            // 
            // bt04
            // 
            this.bt04.Location = new System.Drawing.Point(583, 50);
            this.bt04.Name = "bt04";
            this.bt04.Size = new System.Drawing.Size(141, 76);
            this.bt04.TabIndex = 0;
            this.bt04.Text = "Bài04";
            this.bt04.UseVisualStyleBackColor = true;
            this.bt04.Click += new System.EventHandler(this.bt04_Click);
            // 
            // bt05
            // 
            this.bt05.Location = new System.Drawing.Point(765, 50);
            this.bt05.Name = "bt05";
            this.bt05.Size = new System.Drawing.Size(141, 76);
            this.bt05.TabIndex = 0;
            this.bt05.Text = "Bài05";
            this.bt05.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 462);
            this.Controls.Add(this.bt05);
            this.Controls.Add(this.bt04);
            this.Controls.Add(this.bt03);
            this.Controls.Add(this.bt02);
            this.Controls.Add(this.bt01);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bt01;
        private System.Windows.Forms.Button bt02;
        private System.Windows.Forms.Button bt03;
        private System.Windows.Forms.Button bt04;
        private System.Windows.Forms.Button bt05;
    }
}

