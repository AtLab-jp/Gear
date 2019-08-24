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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        public string SendDataLanguage
        {
            set
            {
                switch (int.Parse(value))
                {
                    case 0:
                        this.Text = "Controlling Variable";
                        label1.Text = "・Variable Name";
                        label7.Text = "・Type";
                        label4.Text = "・Initial Value";
                        label2.Text = "・Type";
                        label6.Text = "・Variable Name";
                        label5.Text = "・Initial Value";
                        button1.Text = "Add";
                        button2.Text = "Delete";
                        break;
                    case 1:
                        label1.Text = "・変数名";
                        label7.Text = "・型";
                        label4.Text = "・初期値";
                        label2.Text = "・型";
                        label6.Text = "・変数名";
                        label5.Text = "・初期値";
                        button1.Text = "追加";
                        button2.Text = "削除";
                        break;
                }
            }
            get
            {
                return "";
            }
        }

        private void Fm3Closing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Visible = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true) textBox2.Enabled = true;
            else                           textBox2.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if(textBox1.Text!="")
                {
                    if (comboBox1.Text != "")
                    {
                        bool eq = true;
                        for (int i = 0; i < Form1.var_count; i++) if (Form1.var_contents[i] == textBox1.Text) eq = false;

                        if (eq==false)
                        {
                            MessageBox.Show("同じ名前の変数があります",
                            "エラー",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        }
                        else
                        {
                            bool addable = true;
                            if (comboBox1.Text == "整数値")
                                Form1.var_class[Form1.var_count] = "int";
                            else if (comboBox1.Text == "小数値")
                                Form1.var_class[Form1.var_count] = "float";
                            else if (comboBox1.Text == "文字")
                                Form1.var_class[Form1.var_count] = "char";
                            else if (comboBox1.Text == "文字列")
                                Form1.var_class[Form1.var_count] = "char[256]";
                            else if (comboBox1.Text == "真偽値")
                                Form1.var_class[Form1.var_count] = "bool";
                            else addable = false;
                            if(addable==true)
                            {
                                Form1.var_contents[Form1.var_count] = textBox1.Text;
                                if (checkBox1.Checked == true)
                                {
                                    Form1.var_value[Form1.var_count] = textBox2.Text;
                                    Form1.var_init[Form1.var_count] = true;
                                }
                                else Form1.var_init[Form1.var_count] = false;
                                string str = "";
                                if (Form1.var_class[Form1.var_count] == "int")
                                    str += "整数値";
                                else if (Form1.var_class[Form1.var_count] == "float")
                                    str += "小数値";
                                else if (Form1.var_class[Form1.var_count] == "char")
                                    str += "文字";
                                else if (Form1.var_class[Form1.var_count] == "char[256]")
                                    str += "文字列";
                                else if (Form1.var_class[Form1.var_count] == "bool")
                                    str += "真偽値";
                                if (checkBox1.Checked == true)
                                {
                                    if (Form1.var_contents[Form1.var_count].Length < 10) listBox1.Items.Add(str + "\t\t" + Form1.var_contents[Form1.var_count] + "\t\t" + Form1.var_value[Form1.var_count]);
                                    else listBox1.Items.Add(str + "\t\t" + Form1.var_contents[Form1.var_count] + "\t" + Form1.var_value[Form1.var_count]);
                                }
                                else
                                {
                                    if (Form1.var_contents[Form1.var_count].Length < 10) listBox1.Items.Add(str + "\t\t" + Form1.var_contents[Form1.var_count]);
                                    else listBox1.Items.Add(str + "\t\t" + Form1.var_contents[Form1.var_count] + "\t");
                                }
                                Form1.var_count++;
                            }
                            else
                            {
                                MessageBox.Show("変数の種類を選択してください",
                                "エラー",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("変数の種類を選択してください",
                        "エラー",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("変数名を入力してください",
                    "エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
            catch
            {

            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            if (Form1.var_count > 0)
            {
                for (int i = 0; i < Form1.var_count; i++)
                {
                    string str = "";
                    if (Form1.var_class[i] == "int")
                        str += "整数値";
                    else if (Form1.var_class[i] == "float")
                        str += "小数値";
                    else if (Form1.var_class[i] == "char")
                        str += "文字";
                    else if (Form1.var_class[i] == "char[256]")
                        str += "文字列";
                    else if (Form1.var_class[i] == "bool")
                        str += "真偽値";
                    if (Form1.var_init[i] == true)
                    {
                        if (Form1.var_contents[i].Length < 10) listBox1.Items.Add(str + "\t\t" + Form1.var_contents[i] + "\t\t" + Form1.var_value[i]);
                        else listBox1.Items.Add(str + "\t\t" + Form1.var_contents[i] + "\t" + Form1.var_value[i]);
                    }
                    else
                    {
                        if (Form1.var_contents[i].Length < 10) listBox1.Items.Add(str + "\t\t" + Form1.var_contents[i]);
                        else listBox1.Items.Add(str + "\t\t" + Form1.var_contents[i] + "\t");
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int sel = listBox1.SelectedIndex;
                listBox1.Items.RemoveAt(sel);
                Console.Write(sel);
                for(int i = sel;i<Form1.var_count;i++)
                {
                    Form1.var_contents[i] = Form1.var_contents[i + 1];
                    Form1.var_class[i] = Form1.var_class[i + 1];
                    Form1.var_value[i] = Form1.var_value[i + 1];
                }
                Form1.var_count--;
            }
            catch
            {

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Size = new Size(350, 258);
            listBox1.Top = 140;

        }
    }
}
