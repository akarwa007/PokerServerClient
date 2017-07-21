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
        public System.Windows.Forms.TableLayoutPanel GetPanel()
        {
            return this.tableLayoutPanel1;
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

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
