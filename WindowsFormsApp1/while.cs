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
    public partial class While : Form
    {
        public Form1 formMain;
        public int check;
        public int id;
        public int mode;
        public While()
        {
            InitializeComponent();
        }
        public string SendMode
        {
            set
            {
                mode = int.Parse(value);
                if (mode == 0)
                {
                    textBox1.Enabled = true;
                    comboBox1.Enabled = false;
                    textBox2.Enabled = true;
                    comboBox2.Enabled = false;
                    radioButton1.Checked = true;
                    radioButton3.Checked = true;
                }
                else if (mode == 1)
                {
                    textBox1.Enabled = true;
                    comboBox1.Enabled = false;
                    textBox2.Enabled = false;
                    comboBox2.Enabled = true;
                    radioButton1.Checked = true;
                    radioButton4.Checked = true;
                }
                else if (mode == 2)
                {
                    textBox1.Enabled = false;
                    comboBox1.Enabled = true;
                    textBox2.Enabled = true;
                    comboBox2.Enabled = false;
                    radioButton2.Checked = true;
                    radioButton3.Checked = true;
                }
                else if (mode == 3)
                {
                    textBox1.Enabled = false;
                    comboBox1.Enabled = true;
                    textBox2.Enabled = false;
                    comboBox2.Enabled = true;
                    radioButton2.Checked = true;
                    radioButton4.Checked = true;
                }
                else
                {
                    textBox1.Enabled = true;
                    comboBox1.Enabled = false;
                    textBox2.Enabled = true;
                    comboBox2.Enabled = false;
                }
            }
            get
            {
                return "";
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
        public string SendDataText1
        {
            set
            {
                textBox1.Text = value;
            }
            get
            {
                return "";
            }
        }
        public string SendDataText2
        {
            set
            {
                textBox2.Text = value;
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
                check = int.Parse(value);
                Console.Write(check);
                this.checkBox1.Checked = false;
                this.checkBox2.Checked = false;
                this.checkBox3.Checked = false;
                if (check >= 4)
                {
                    this.checkBox3.Checked = true;
                    check -= 4;
                }
                if (check >= 2)
                {
                    this.checkBox2.Checked = true;
                    check -= 2;
                }
                if (check >= 1)
                {
                    this.checkBox1.Checked = true;
                    check -= 1;
                }
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
                        If説明.Text = "Enter While's content.";
                        radioButton1.Text = "Value";
                        radioButton3.Text = "Value";
                        radioButton2.Text = "Variable";
                        radioButton4.Text = "Variable";
                        break;
                    case 1:
                        If説明.Text = "Whileの内容を入力してください。";
                        radioButton1.Text = "値";
                        radioButton3.Text = "値";
                        radioButton2.Text = "変数";
                        radioButton4.Text = "変数";
                        break;
                }
            }
            get
            {
                return "";
            }
        }

        private void While_Load(object sender, EventArgs e)
        {
        }

        private void WhileClosnig(object sender, FormClosingEventArgs e)
        {
            int m = 0;
            check = 0;
            if (this.checkBox1.Checked == true) check += 1;
            if (this.checkBox2.Checked == true) check += 2;
            if (this.checkBox3.Checked == true) check += 4;
            Form1 fm = (Form1)this.Owner;
            if (fm != null)
            {
                fm.Receiveid = id.ToString();
                if (radioButton1.Checked == true)
                {
                    fm.ReceiveDataText1 = textBox1.Text;
                }
                else
                {
                    fm.ReceiveDataText1 = comboBox1.Text;
                    m += 2;
                }
                if (radioButton3.Checked == true)
                {
                    fm.ReceiveDataText2 = textBox2.Text;
                }
                else
                {
                    fm.ReceiveDataText2 = comboBox2.Text;
                    m += 1;
                }
                fm.ReceiveDataInt1 = check.ToString();
                fm.ReceiveMode = m.ToString();
                fm.Receiveid = id.ToString();
            }
            e.Cancel = true;
            this.Visible = false;
        }

        private void FormActivated(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            if (Form1.var_count > 0)
            {
                for (int i = 0; i < Form1.var_count; i++)
                {
                    comboBox1.Items.Add(Form1.var_contents[i]);
                    comboBox2.Items.Add(Form1.var_contents[i]);
                }
            }
        }

        private void Checked_Changed(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                textBox1.Enabled = true;
                comboBox1.Enabled = false;
            }
            else
            {
                textBox1.Enabled = false;
                comboBox1.Enabled = true;
            }
            if (radioButton3.Checked == true)
            {
                textBox2.Enabled = true;
                comboBox2.Enabled = false;
            }
            else
            {
                textBox2.Enabled = false;
                comboBox2.Enabled = true;
            }
        }
    }
}
