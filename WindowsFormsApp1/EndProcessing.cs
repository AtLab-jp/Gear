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
    public partial class EndProcessing : Form
    {
        public int id;
        int Language;
        public EndProcessing()
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
                Language = int.Parse(value);
                Console.Write(Language);
                if (Language == 0)
                {
                    this.Text = "End condition";
                    label1.Text = "Choose Characters to end.";
                }
                if (Language == 1)
                {
                    this.Text = "終了処理";
                    label1.Text = "終了時に入力する文字を選択してください";
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
        private void EndClosing(object sender, FormClosingEventArgs e)
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
    }
}
