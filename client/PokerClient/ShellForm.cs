using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PokerClient
{
    public partial class ShellForm : Form
    {
        public ShellForm()
        {
            InitializeComponent();
            this.ClientSize = new System.Drawing.Size(1000, 600);
        }

        private void ShellForm_Load(object sender, EventArgs e)
        {
            //this.TransparencyKey = Color.FromArgb(255, 192, 192);
        }

        private void ShellForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}
