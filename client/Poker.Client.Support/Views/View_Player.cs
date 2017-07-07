using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Poker.Client.Support.Views
{
    public partial class View_Player : UserControl
    {
        private ViewModel_Player _vm_player = null;
        public View_Player(ViewModel_Player vm_player)
        {
            _vm_player = vm_player;
            InitializeComponent();
        }

        private void View_Player_Load(object sender, EventArgs e)
        {

        }
    }
}
