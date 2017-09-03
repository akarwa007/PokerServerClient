using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Poker.Client.Support.Dialogs
{
    public partial class BetCollectorControl : Form
    {
        ViewModel_BetCollection _vm;
        int multiplier = 1;
        int counter = 0;
       
        public BetCollectorControl(ViewModel_BetCollection vm)
        {
            _vm = vm;
            multiplier = 1;
            multiplier = _vm.CurrentBet < 1 ? 100 : 1; 
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            // Remove the control box so the form will only display client area.
            this.ControlBox = false;
            init();
            HandleCreated += BetCollectorControl_HandleCreated;
        }

        private void BetCollectorControl_HandleCreated(object sender, EventArgs e)
        {
            SimulateRequestBet1();
        }

        private void init()
        {
            trackBar1.Minimum = (int)_vm.CurrentBet*multiplier;
            trackBar1.Maximum = (int)_vm.AvailableMoney*multiplier;
            txtBetAmount.Text = _vm.MinBetAllowed.ToString();
            labelUserName.Text = this._vm.UserName;
            _vm.setBetChoosen(-1);
            //SimulateRequestBet1();
        }
        private void BetCollectorControl_Load(object sender, EventArgs e)
        {

        }

        private void btnFold_Click(object sender, EventArgs e)
        {
            _vm.setBetChoosen(-1);
            this.txtBetAmount.Text = _vm.BetChoosen.ToString();
            this.DialogResult = DialogResult.OK;
        }

        private void btnCall_Click(object sender, EventArgs e)
        {
            _vm.setBetChoosen(_vm.CurrentBet);
            this.txtBetAmount.Text = _vm.BetChoosen.ToString();
            this.DialogResult = DialogResult.OK;
        }

        private void btnRaiseTo_Click(object sender, EventArgs e)
        {
            decimal amt = 0;
            if (this.txtBetAmount.Text == "")
                amt = 0;
            else
                amt = Convert.ToDecimal(this.txtBetAmount.Text);
            _vm.setBetChoosen(amt);
            this.txtBetAmount.Text = _vm.BetChoosen.ToString();
            this.DialogResult = DialogResult.OK;
        }

        private void btn3BB_Click(object sender, EventArgs e)
        {

        }

        private void btnPot_Click(object sender, EventArgs e)
        {
            _vm.setBetChoosen(_vm.PotValue);
            this.txtBetAmount.Text = _vm.BetChoosen.ToString();
            
        }

        private void btnMax_Click(object sender, EventArgs e)
        {
            _vm.setBetChoosen(_vm.AvailableMoney);
            this.txtBetAmount.Text = _vm.BetChoosen.ToString();
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            _vm.setBetChoosen(_vm.MinBetAllowed);
            this.txtBetAmount.Text = _vm.BetChoosen.ToString();
        }
        public ViewModel_BetCollection getModel()
        {
            return _vm;
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            TrackBar t = (TrackBar)sender;
            decimal bet = Convert.ToDecimal(t.Value / multiplier);
            _vm.setBetChoosen(bet);
            this.txtBetAmount.Text = _vm.BetChoosen.ToString();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }
        
        public void SimulateRequestBet1()
        {
            //Console.WriteLine("Inside SimulateRequest for " + this._vm_seat.UserName + " for " + comment);
            
            if (!this.IsHandleCreated)
            {
                Console.WriteLine("While simulating requst bet , handle is not created");
                return;
            }
            this.Invoke((MethodInvoker)delegate
            {
                counter = 50;

               
                timer1.Enabled = true;
                timer1.Interval = 200;
                timer1.Start();
                //Views.View_Table vt = (Views.View_Table)this.Parent;
                //vt.threadSync.Reset();

            });
            
            Console.WriteLine("Done with SimulateRequestBet function call");
        }
        private void timer1_Tick(object sender, EventArgs e)
        {

            //Console.WriteLine("Inside timer1 for " + this._vm_seat.UserName);
            if (timer1.Enabled)
            {
                counter--;
                this.labelCounter.Text = counter.ToString();
                if (counter <= 0)
                {
                    try
                    {
                        StopTimer();
                    }
                    catch (Exception e1)
                    {
                        Console.WriteLine("Exception inside StopTime " + e1.Message);
                    }
                }
            }
        }
        private void StopTimer()
        {
            this.Invoke((MethodInvoker)delegate
            {
                if (timer1.Enabled == false)
                    return;

                timer1.Stop();
                timer1.Enabled = false;

                this.labelCounter.Text = "";
                
                //Views.View_Table vt = (Views.View_Table)this.Parent;
                //vt.threadSync.Set();
            });
            this.DialogResult = DialogResult.OK;
        }

       
    }
}
