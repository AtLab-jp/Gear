namespace WindowsFormsApp1
{
    partial class Printf
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Printf説明 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.RadioButton1 = new System.Windows.Forms.RadioButton();
            this.RadioButton2 = new System.Windows.Forms.RadioButton();
            this.CheckBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(14, 52);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(285, 19);
            this.textBox1.TabIndex = 0;
            // 
            // Printf説明
            // 
            this.Printf説明.AutoSize = true;
            this.Printf説明.Location = new System.Drawing.Point(12, 9);
            this.Printf説明.Name = "Printf説明";
            this.Printf説明.Size = new System.Drawing.Size(159, 12);
            this.Printf説明.TabIndex = 1;
            this.Printf説明.Text = "Printfの内容を入力してください。";
            // 
            // comboBox1
            // 
            this.comboBox1.Enabled = false;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(14, 99);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 2;
            // 
            // RadioButton1
            // 
            this.RadioButton1.AutoSize = true;
            this.RadioButton1.Checked = true;
            this.RadioButton1.Location = new System.Drawing.Point(14, 34);
            this.RadioButton1.Name = "RadioButton1";
            this.RadioButton1.Size = new System.Drawing.Size(80, 16);
            this.RadioButton1.TabIndex = 3;
            this.RadioButton1.TabStop = true;
            this.RadioButton1.Text = "文章を表示";
            this.RadioButton1.UseVisualStyleBackColor = true;
            this.RadioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // RadioButton2
            // 
            this.RadioButton2.AutoSize = true;
            this.RadioButton2.Location = new System.Drawing.Point(14, 77);
            this.RadioButton2.Name = "RadioButton2";
            this.RadioButton2.Size = new System.Drawing.Size(102, 16);
            this.RadioButton2.TabIndex = 4;
            this.RadioButton2.TabStop = true;
            this.RadioButton2.Text = "変数の値を表示";
            this.RadioButton2.UseVisualStyleBackColor = true;
            this.RadioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // CheckBox1
            // 
            this.CheckBox1.AutoSize = true;
            this.CheckBox1.Location = new System.Drawing.Point(214, 141);
            this.CheckBox1.Name = "CheckBox1";
            this.CheckBox1.Size = new System.Drawing.Size(48, 16);
            this.CheckBox1.TabIndex = 5;
            this.CheckBox1.Text = "改行";
            this.CheckBox1.UseVisualStyleBackColor = true;
            // 
            // Printf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 169);
            this.Controls.Add(this.CheckBox1);
            this.Controls.Add(this.RadioButton2);
            this.Controls.Add(this.RadioButton1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.Printf説明);
            this.Controls.Add(this.textBox1);
            this.Name = "Printf";
            this.Text = "Printf";
            this.Activated += new System.EventHandler(this.Form_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PrintfClosing);
            this.Load += new System.EventHandler(this.Printf_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label Printf説明;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.RadioButton RadioButton1;
        private System.Windows.Forms.RadioButton RadioButton2;
        private System.Windows.Forms.CheckBox CheckBox1;
    }
}