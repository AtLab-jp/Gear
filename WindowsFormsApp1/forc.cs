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
    public partial class For : Form
    {
        int Language;
        public int id;
        public int n;
        public For()
        {
            InitializeComponent();
        }
        public string Sendid
        {
            set
            {
                id = int.Parse(value);
            }
            get
            {
                return "";
            }
        }
        public string SendDataInt1
        {
            set
            {
                n = int.Parse(value);
                numericUpDown1.Value = n;
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
                Language = int.Parse(value);
                if (Language == 0)
                {
                    For説明.Text = "Enter the number of executios.";
                    For入力.Text = "Number of executions";
                }
                if (Language == 1)
                {
                    For説明.Text = "Forの実行回数を入力してください。";
                    For入力.Text = "実行回数：";
                }
            }
            get
            {
                return "";
            }
        }
        private void For_Load(object sender, EventArgs e)
        {
        }

        private void For_Closing(object sender, FormClosingEventArgs e)
        {
            Form1 fm = (Form1)this.Owner;
            fm.Receiveid = id.ToString();
            fm.ReceiveDataInt1 = numericUpDown1.Value.ToString();
            e.Cancel = true;
            this.Visible = false;
        }
    }
}
