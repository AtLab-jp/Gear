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
    public partial class Printf : Form
    {
        public int id;
        public int mode;
        public Printf()
        {
            InitializeComponent();
        }
        public string SendMode      //○○.Send◇◇の対応先。以下定型
        {
            set
            {
                mode = int.Parse(value);
                if(mode==1)
                {
                    textBox1.Enabled = true;
                    comboBox1.Enabled = false;
                    RadioButton1.Checked = true;
                }
                else if(mode==2)
                {
                    textBox1.Enabled = false;
                    comboBox1.Enabled = true;
                    RadioButton2.Checked = true;
                }
                else
                {
                    textBox1.Enabled = true;
                    comboBox1.Enabled = false;
                }
            }
            get
            {
                return "";          //役割不明
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
                        Printf説明.Text = "Enter Printf's content.";
                        RadioButton1.Text = "Display words";
                        RadioButton2.Text = "Display the value of variable";
                        CheckBox1.Text = "New line";
                        break;
                    case 1:
                        Printf説明.Text = "Printfの内容を入力してください。";
                        RadioButton1.Text = "文章を表示";
                        RadioButton2.Text = "変数の値を表示";
                        CheckBox1.Text = "改行";
                        break;
                }
            }
            get
            {
                return "";
            }
        }
        private void Printf_Load(object sender, EventArgs e)
        {
        }
        public string SendDataText1
        {
            set
            {
                textBox1.Text = "";
                comboBox1.Text = "";
                if (mode == 1)
                {
                    textBox1.Text = value;
                    textBox1.Enabled = true;
                    CheckBox1.Enabled = true;
                    comboBox1.Enabled = false;
                }
                if (mode == 2)
                {
                    comboBox1.Text = value;
                    textBox1.Enabled = false;
                    CheckBox1.Enabled = false;
                    comboBox1.Enabled = true;
                }
            }
            get
            {
                return "";
            }
        }
        public string SendDataCheck1
        {
            set
            {
                CheckBox1.Checked = bool.Parse(value);
            }
            get
            {
                return "";
            }
        }
        private void PrintfClosing(object sender, FormClosingEventArgs e)
        {
            Form1 fm = (Form1)this.Owner;
            if (fm != null)
            {
                fm.Receiveid = id.ToString();
                if(RadioButton1.Checked==true)
                {
                    fm.ReceiveDataText1 = textBox1.Text;
                    fm.ReceiveDataCheck1 = CheckBox1.Checked.ToString();
                    fm.ReceiveMode = 1.ToString();
                }
                else if(RadioButton2.Checked == true)
                {

                    fm.ReceiveDataText1 = comboBox1.Text;
                    fm.ReceiveDataCheck1 = CheckBox1.Checked.ToString();
                    fm.ReceiveMode = 2.ToString();
                }

            }
            e.Cancel = true;
            this.Visible = false;
        }

        private void Form_Activated(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            if (Form1.var_count > 0)
            {
                for (int i = 0; i < Form1.var_count; i++)
                {
                    comboBox1.Items.Add(Form1.var_contents[i]);
                }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioButton1.Checked == true)
            {
                textBox1.Enabled = true;
                comboBox1.Enabled = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

            if (RadioButton2.Checked == true)
            {
                textBox1.Enabled = false;
                comboBox1.Enabled = true;
            }
        }
    }
}
