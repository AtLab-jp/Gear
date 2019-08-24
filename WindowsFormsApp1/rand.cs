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
    public partial class rand : Form
    {
        public int id;
        public rand()
        {
            InitializeComponent();
        }
        private void FormActivated(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            if (Form1.var_count > 0)
            {
                for (int i = 0; i < Form1.var_count; i++)
                {
                    if (Form1.var_class[i] == "int")
                    {
                        comboBox1.Items.Add(Form1.var_contents[i]);
                    }
                }
            }
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
                        label1.Text = "Choose a variable to substitute.";
                        label3.Text = "Designate the range of random numbers.";
                        break;
                    case 1:
                        label1.Text = "代入する変数を選択してください。";
                        label3.Text = "乱数の範囲を指定してください。";
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
        public string SendDataInt1
        {
            set
            {
                numericUpDown1.Value = int.Parse(value);
            }
            get
            {
                return "";
            }
        }
        public string SendDataInt2
        {
            set
            {
                numericUpDown2.Value = int.Parse(value);
            }
            get
            {
                return "";
            }
        }

        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            Form1 fm = (Form1)this.Owner;
            if (fm != null)
            {
                fm.Receiveid = id.ToString();
                fm.ReceiveDataText1 = comboBox1.Text;
                fm.ReceiveDataInt1 = numericUpDown1.Value.ToString();
                fm.ReceiveDataInt2 = numericUpDown2.Value.ToString();

            }
            e.Cancel = true;
            this.Visible = false;
        }
    }
}
