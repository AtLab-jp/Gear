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
    public partial class Pass : Form
    {
        public Pass()
        {
            InitializeComponent();
        }
        private void Pass_Closing(object sender, FormClosingEventArgs e)
        {
            Form1 fm = (Form1)this.Owner;
            fm.ReceivePass = textBox1.Text;
            e.Cancel = true;
            this.Visible = false;
        }
    }
}
