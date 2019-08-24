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
    public partial class Sleep : Form
    {
        public int id;
        public Sleep()
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
                numericUpDown1.Value = int.Parse(value);
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
                        label1.Text = "Enter the time to stop the action.(Unit:ms)";
                        break;
                    case 1:
                        label1.Text = "動作を止める時間を入力してください。(単位はms)";
                        break;
                }
            }
            get
            {
                return "";
            }
        }

        private void Sleep_Load(object sender, EventArgs e)
        {

        }

        private void SleepClosing(object sender, FormClosingEventArgs e)
        {
            Form1 fm = (Form1)this.Owner;
            fm.Receiveid = id.ToString();
            fm.ReceiveDataInt1 = numericUpDown1.Value.ToString();
            e.Cancel = true;
            this.Visible = false;
        }
    }
}
