using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button2.FlatStyle = FlatStyle.Flat;
            button2.FlatAppearance.BorderSize = 2;
            SoftBlink(this.button2, "sdf", Color.FromArgb(30, 30, 30), Color.Red, 2000, true);

            this.userControl11.BorderStyle = BorderStyle.FixedSingle;
            
        }
        private async void SoftBlink(Button ctrl, string swap, Color c1, Color c2, short CycleTime_ms, bool BkClr)
        {
            var sw = new Stopwatch();
            sw.Start();
            short halfCycle = (short)Math.Round(CycleTime_ms * 0.5);
            Color clr = Color.White;
            while (true)
            {
                await Task.Delay(500);
                if (clr == Color.White)
                {
                    clr = Color.Black;
                    ctrl.FlatAppearance.BorderColor = clr;
                 }else
                {
                    clr = Color.White;
                    ctrl.FlatAppearance.BorderColor = clr;
                }
                
            }
           
        }
    }
}
