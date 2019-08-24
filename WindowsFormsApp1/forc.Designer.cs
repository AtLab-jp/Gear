namespace WindowsFormsApp1
{
    partial class For
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
            this.For説明 = new System.Windows.Forms.Label();
            this.For入力 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // For説明
            // 
            this.For説明.AutoSize = true;
            this.For説明.Location = new System.Drawing.Point(12, 9);
            this.For説明.Name = "For説明";
            this.For説明.Size = new System.Drawing.Size(172, 12);
            this.For説明.TabIndex = 3;
            this.For説明.Text = "Forの実行回数を入力してください。";
            // 
            // For入力
            // 
            this.For入力.AutoSize = true;
            this.For入力.Location = new System.Drawing.Point(12, 41);
            this.For入力.Name = "For入力";
            this.For入力.Size = new System.Drawing.Size(59, 12);
            this.For入力.TabIndex = 4;
            this.For入力.Text = "実行回数：";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(23, 66);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 19);
            this.numericUpDown1.TabIndex = 5;
            // 
            // For
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 97);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.For入力);
            this.Controls.Add(this.For説明);
            this.Name = "For";
            this.Text = "For";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.For_Closing);
            this.Load += new System.EventHandler(this.For_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label For説明;
        private System.Windows.Forms.Label For入力;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
    }
}