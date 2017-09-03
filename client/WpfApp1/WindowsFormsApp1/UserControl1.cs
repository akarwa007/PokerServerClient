using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {

        }
       protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            int BORDER_SIZE = 5;
            Color clr = Color.Green;
            
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle,
                                            clr, BORDER_SIZE, ButtonBorderStyle.Inset,
                                            clr, BORDER_SIZE, ButtonBorderStyle.Inset,
                                            clr, BORDER_SIZE, ButtonBorderStyle.Inset,
                                            clr, BORDER_SIZE, ButtonBorderStyle.Inset);
        }
        
    }
}
