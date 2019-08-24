using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public string SendData
        {
            set
            {
                textBox1.Text = value;
                this.Height = textBox1.Lines.Length * 12 + 100;
            }
            get
            {
                return "";
            }
        }
        public string SendDataLanguage
        {
            set
            {
                switch (int.Parse(value))
                {
                    case 0:
                        this.Text = "Output codes";
                        break;
                    case 1:
                        this.Text = "コードの出力結果";
                        break;
                }
            }
            get
            {
                return "";
            }
        }

        private void Form2_Closing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Visible = false;
        }

    }
}
