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
    public partial class Debug : Form
    {
        public Debug()
        {
            InitializeComponent();
        }
        private void Debug_Closing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.OP = 0;
            Properties.Settings.Default.Save();
            this.Visible = false;
        }
    }
}
