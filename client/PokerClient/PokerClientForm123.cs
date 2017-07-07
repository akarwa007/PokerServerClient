using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Poker.Client.Support;
using Poker.Client.Support.Views;
using Poker.Shared;

namespace PokerClient
{
    public partial class PokerClientForm : Form
    {
        public PokerClientForm()
        {
            InitializeComponent();
        }

        private void PokerClientForm_Load(object sender, EventArgs e)
        {
            ViewModel_Table vm_table = new ViewModel_Table();
            View_Table v_table = new View_Table(vm_table);
            this.Dock = DockStyle.Fill;
            this.AutoSize = false;
            v_table.Dock = DockStyle.Fill;
            v_table.AutoSize = false;
            this.Controls.Add(v_table);
        }

        private void view_Table1_Load(object sender, EventArgs e)
        {

        }
    }
}
