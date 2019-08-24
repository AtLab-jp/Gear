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
    public partial class Sub : Form
    {
        public int id;
        public Sub()
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
                        label1.Text = "Choose a variable to substitute.";
                        label2.Text = "Enter the content.";
                        label3.Text = "List of variables available";
                        this.Text = "Substitution";
                        break;
                    case 1:
                        label1.Text = "代入する変数を選択してください。";
                        label2.Text = "代入する内容を入力してください。";
                        label3.Text = "使用可能な変数一覧";
                        this.Text = "代入";
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
        public string SendDataText2
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
        private void SubstitutionClose(object sender, FormClosingEventArgs e)
        {
            Form1 fm = (Form1)this.Owner;
            if (fm != null)
            {
                fm.Receiveid = id.ToString();
                fm.ReceiveDataText1 = comboBox1.Text;
                fm.ReceiveDataText2 = textBox1.Text;

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
                    if(Form1.var_class[i]!="char[256]"&& Form1.var_class[i] != "bool")
                    {
                        comboBox1.Items.Add(Form1.var_contents[i]);
                        comboBox2.Items.Add(Form1.var_contents[i]);
                    }
                }
            }
        }

        private void Selected(object sender, EventArgs e)
        {
            textBox1.Text += comboBox2.Text;
        }
    }
}
