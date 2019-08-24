using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Controls;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Form4 : Form
    {
        private System.Windows.Forms.Label[] Labels;    //ピクチャーボックスの配列
        int Lines;
        public Form4()
        {
            InitializeComponent();
        }
        public string SendData
        {
            set
            {
                textBox1.Text = value;
                Lines = textBox1.Lines.Length;
                Console.Write(Lines);
                Form1.highlight = true;
                this.Height = 50 + Lines * 12;
            }
            get
            {
                return "";
            }
        }
        public string SendErase
        {
            set
            {
                for (int i = 0; i < Form1.Max * 2; i++)
                {
                    Labels[i].ForeColor = SystemColors.ControlText;
                }
            }
            get
            {
                return "";
            }
        }
        public string SendHighlight
        {
            set
            {
                Console.Write(value);
                Labels[int.Parse(value)].ForeColor = Color.Red;
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
                switch (int.Parse(value)) {
                    case 0:
                        this.Text = "Output codes";
                        break;
                    case 1:
                        this.Text = "コードの出力結果";
                        break;
                }
                Generate();
            }
            get
            {
                return "";
            }
        }
        private void Form4_Closing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Visible = false;
            Form1.highlight = false;
        }
        private void Form4_Load(object sender, EventArgs e)
        {
            this.Labels = new System.Windows.Forms.Label[Form1.Max * 2];
            for(int i=0;i<Form1.Max*2;i++)
            {
                this.Labels[i] = new System.Windows.Forms.Label();
                this.Labels[i].Top = i * 12;
                this.Labels[i].Left = 12;
                this.Labels[i].Height = 10;
                this.Labels[i].Width = 9999;
                this.Labels[i].Text = "";
                this.Controls.Add(this.Labels[i]);
                this.Labels[i].BringToFront();
            }
        }
        void Generate()
        {
            for (int i = 0; i < Form1.Max * 2; i++)
            {
                this.Labels[i].Location = new Point(0, i * 12);
                this.Labels[i].Text = "";
            }
            int c = 0;
            this.Labels[c++].Text = "#include <stdio.h>";
            int Win = 0;
            for (int i = 0; i < Form1.Max; i++)
            {
                if (Form1.IconElements[i].enable == true && Form1.IconElements[i].type == 9 && Win == 0)
                {
                    this.Labels[c++].Text = "#include <Windows.h>";
                    Win = 1;
                }
            }
            this.Labels[c++].Text = "";
            this.Labels[c++].Text = "int main(void)";
            this.Labels[c++].Text = "{";
            try
            {
                int Viewing = Form1.StartElements.connectto;
                int[] ifstack = new int[128];
                int[] now = new int[128];
                for (int i = 0; i < Form1.var_count; i++)
                {
                    if (Form1.var_class[i] == "char[256]") this.Labels[c].Text += "    " + "char" + " " + Form1.var_contents[i] + "[256]";
                    else this.Labels[c].Text += "    " + Form1.var_class[i] + " " + Form1.var_contents[i];
                    if (Form1.var_init[i] == true && Form1.var_class[i] == "char[256]") this.Labels[c++].Text += " = \"" + Form1.var_value[i] + "\";";
                    else this.Labels[c++].Text += " = " + Form1.var_value[i] + ";";
                    this.Labels[c].Text += "";
                }
                for (int i = 0; i < 128; i++) ifstack[i] = -1;
                int indent = 1;
                while (Viewing != -2)
                {
                    //Console.Write("0:" + ifstack[0] + " 1;" + ifstack[1] + Environment.NewLine);
                    if (Viewing == -1)
                    {
                        throw new FileNotFoundException();
                    }
                    else if (Form1.IconElements[Viewing].type == 1)//printf
                    {
                        for (int j = 0; j < indent; j++) this.Labels[c].Text += "    ";
                        this.Labels[c].Text += "printf(\"";
                        if (Form1.IconElements[Viewing].mode == 1)
                        {
                            this.Labels[c].Text += Form1.IconElements[Viewing].text1;
                            if (Form1.IconElements[Viewing].Check1 == true) this.Labels[c].Text += "\\n";
                            this.Labels[c++].Text += "\");";
                        }
                        else
                        {
                            int i;
                            int none = 0;
                            for (i = 0; (i < Form1.Max) && (Form1.var_contents[i] != Form1.IconElements[Viewing].text1); i++) { }
                            if (Form1.var_class[i] == "int")
                            {
                                this.Labels[c].Text += "%d";
                            }
                            else if (Form1.var_class[i] == "float")
                            {
                                this.Labels[c].Text += "%f";

                            }
                            else if (Form1.var_class[i] == "char[256]")
                            {
                                this.Labels[c].Text += "%s";

                            }
                            else if (Form1.var_class[i] == "bool")
                            {
                                this.Labels[c].Text += "%d";

                            }
                            else
                            {
                                none = 1;
                            }
                            if (Form1.IconElements[Viewing].Check1 == true) this.Labels[c].Text += "\\n";
                            if (none == 1) this.Labels[c++].Text += "\"" + Form1.IconElements[Viewing].text1 + ");";
                            else this.Labels[c++].Text += "\"," + Form1.IconElements[Viewing].text1 + ");";

                        }
                        Viewing = Form1.IconElements[Viewing].connectto;
                    }
                    else if (Form1.IconElements[Viewing].type == 2)
                    {
                        int i;
                        for (i = 0; ifstack[i] != -1; i++) { }
                        ifstack[i] = Viewing;
                        for (int j = 0; j < indent; j++) this.Labels[c].Text += "    ";
                        this.Labels[c].Text += "if(";
                        this.Labels[c].Text += Form1.IconElements[Viewing].text1;
                        if (Form1.IconElements[Viewing].number1 == 1) this.Labels[c].Text += ">";
                        if (Form1.IconElements[Viewing].number1 == 2) this.Labels[c].Text += "==";
                        if (Form1.IconElements[Viewing].number1 == 4) this.Labels[c].Text += "<";
                        if (Form1.IconElements[Viewing].number1 == 3) this.Labels[c].Text += ">=";
                        if (Form1.IconElements[Viewing].number1 == 6) this.Labels[c].Text += "<=";
                        this.Labels[c].Text += Form1.IconElements[Viewing].text2;
                        this.Labels[c++].Text += ")";
                        for (int j = 0; j < indent; j++) this.Labels[c].Text += "    ";
                        this.Labels[c++].Text += "{";
                        indent++;
                        now[i] = 0;
                        Viewing = Form1.IconElements[Viewing].connectto;
                    }
                    else if (Form1.IconElements[Viewing].type == 3)
                    {
                        int i;
                        for (i = 0; ifstack[i] != -1; i++) { }
                        i--;
                        if (now[i] == 0)
                        {
                            if (Form1.IconElements[ifstack[i]].connectto2 != -1)
                            {
                                indent--;
                                for (int j = 0; j < indent; j++) this.Labels[c].Text += "    ";
                                this.Labels[c++].Text += "}";
                                for (int j = 0; j < indent; j++) this.Labels[c].Text += "    ";
                                this.Labels[c++].Text += "else";
                                for (int j = 0; j < indent; j++) this.Labels[c].Text += "    ";
                                this.Labels[c++].Text += "{";
                                Viewing = Form1.IconElements[ifstack[i]].connectto2;
                                indent++;
                                now[i] = 1;
                            }
                            else
                            {
                                indent--;
                                for (int j = 0; j < indent; j++) this.Labels[c].Text += "    ";
                                this.Labels[c++].Text += "}";
                                now[i] = 0;
                                Viewing = Form1.IconElements[Viewing].connectto;
                                ifstack[i] = -1;
                            }
                        }
                        else
                        {
                            indent--;
                            for (int j = 0; j < indent; j++) this.Labels[c].Text += "    ";
                            this.Labels[c++].Text += "}";
                            now[i] = 0;
                            Viewing = Form1.IconElements[Viewing].connectto;
                            ifstack[i] = -1;
                        }
                    }
                    else if (Form1.IconElements[Viewing].type == 4)
                    {
                        for (int j = 0; j < indent; j++) this.Labels[c].Text += "    ";
                        this.Labels[c].Text += "scanf(\"";
                        int i;
                        for (i = 0; (i < Form1.Max) && (Form1.var_contents[i] != Form1.IconElements[Viewing].text1); i++) { }
                        if (Form1.var_class[i] == "int")
                        {
                            this.Labels[c].Text += "%d";
                        }
                        else if (Form1.var_class[i] == "float")
                        {
                            this.Labels[c].Text += "%f";

                        }
                        else if (Form1.var_class[i] == "char[256]")
                        {
                            this.Labels[c].Text += "%s";

                        }
                        else if (Form1.var_class[i] == "bool")
                        {
                            this.Labels[c].Text += "%d";

                        }
                        this.Labels[c++].Text += "\",&" + Form1.IconElements[Viewing].text1 + ");";
                        Viewing = Form1.IconElements[Viewing].connectto;
                    }
                    else if (Form1.IconElements[Viewing].type == 5)
                    {
                        for (int j = 0; j < indent; j++) this.Labels[c].Text += "    ";
                        this.Labels[c++].Text += "for(int i = 0; i<" + Form1.IconElements[Viewing].number1 + "; i++)";
                        for (int j = 0; j < indent; j++) this.Labels[c].Text += "    ";
                        this.Labels[c++].Text +="{";
                        indent++;
                        Viewing = Form1.IconElements[Viewing].connectto;
                    }
                    else if (Form1.IconElements[Viewing].type == 6)
                    {
                        indent--;
                        for (int j = 0; j < indent; j++) this.Labels[c].Text += "    ";
                        this.Labels[c++].Text += "}" ;
                        Viewing = Form1.IconElements[Viewing].connectto;
                    }
                    else if (Form1.IconElements[Viewing].type == 7)
                    {
                        for (int j = 0; j < indent; j++) this.Labels[c].Text += "    ";
                        this.Labels[c].Text += "while(";
                        this.Labels[c].Text += Form1.IconElements[Viewing].text1;
                        if (Form1.IconElements[Viewing].number1 == 1) this.Labels[c].Text += ">";
                        if (Form1.IconElements[Viewing].number1 == 2) this.Labels[c].Text += "==";
                        if (Form1.IconElements[Viewing].number1 == 4) this.Labels[c].Text += "<";
                        if (Form1.IconElements[Viewing].number1 == 3) this.Labels[c].Text += ">=";
                        if (Form1.IconElements[Viewing].number1 == 6) this.Labels[c].Text += "<=";
                        this.Labels[c].Text += Form1.IconElements[Viewing].text2;
                        this.Labels[c++].Text += ")";
                        for (int j = 0; j < indent; j++) this.Labels[c].Text += "    ";
                        this.Labels[c++].Text += "{";
                        indent++;
                        Viewing = Form1.IconElements[Viewing].connectto;
                    }
                    else if (Form1.IconElements[Viewing].type == 8)
                    {
                        for (int j = 0; j < indent; j++) this.Labels[c].Text += "    ";
                        this.Labels[c++].Text += "getchar();";
                        Viewing = Form1.IconElements[Viewing].connectto;
                    }
                    else if (Form1.IconElements[Viewing].type == 9)
                    {
                        for (int j = 0; j < indent; j++) this.Labels[c].Text += "    ";
                        this.Labels[c++].Text += "Sleep(" + Form1.IconElements[Viewing].number1 + ");" + Environment.NewLine;
                        Viewing = Form1.IconElements[Viewing].connectto;
                    }
                    else if (Form1.IconElements[Viewing].type == 10)
                    {
                        for (int j = 0; j < indent; j++) this.Labels[c].Text += "    ";
                        this.Labels[c++].Text += Form1.IconElements[Viewing].text1 + "=" + Form1.IconElements[Viewing].text2 + ";" + Environment.NewLine;
                        Viewing = Form1.IconElements[Viewing].connectto;
                    }
                    else if (Form1.IconElements[Viewing].type == 11)
                    {
                        for (int j = 0; j < indent; j++) this.Labels[c].Text += "    ";
                        this.Labels[c++].Text += "while(getchar()!='" + Form1.IconElements[Viewing].text1 + "'){}" + Environment.NewLine;
                        Viewing = Form1.IconElements[Viewing].connectto;
                    }
                    else
                    {
                        Viewing = Form1.IconElements[Viewing].connectto;
                    }
                }
                this.Labels[c++].Text += "}";
            }
            catch
            {

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Labels[2].ForeColor = Color.Red;
        }
    }
}
