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
    public partial class getchar : Form
    {
        public int id;
        public getchar()
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
        public string SendDataLanguage
        {
            set
            {
                switch (int.Parse(value))
                {
                    case 0:
                        label1.Text = "Choose a variable to substitute the value.";
                        break;
                    case 1:
                        label1.Text = "値を代入する変数を選択してください。";
                        break;
                }
            }
            get
            {
                return "";
            }
        }
        public string SendDataText1
        {
            set
            {
                comboBox1.Text = value;
            }
            get
            {
                return "";
            }
        }

        private void getchar_Closing(object sender, FormClosingEventArgs e)
        {
            Form1 fm = (Form1)this.Owner;
            if (fm != null)
            {
                fm.Receiveid = id.ToString();
                fm.ReceiveDataText1 = comboBox1.Text;
            }
            e.Cancel = true;
            this.Visible = false;
        }

        private void FormActivated(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            if (Form1.var_count > 0)
            {
                for (int i = 0; i < Form1.var_count; i++)
                {
                    if (Form1.var_class[i] == "char")
                    {
                        comboBox1.Items.Add(Form1.var_contents[i]);
                    }
                }
            }
        }
    }
}
