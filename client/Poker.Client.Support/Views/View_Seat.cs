using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Threading;
using System.Windows.Forms;
using Poker.Shared;
using System.Diagnostics;

namespace Poker.Client.Support.Views
{
    public partial class View_Seat : UserControl
    {
        private ViewModel_Seat _vm_seat = null;
        Label labelChipsCount;
        Button btnFold;
        Button btnCall;
        Button btnRaise;
        Button btnDealer;
        
        Color _panelswapcolor = Color.Salmon;
        Color origColor;
        int counter = 0;
        public event JoinedTableHandler JoinedTableEvent;
        public event ReceiveBetHandler ReceiveBetEvent;

        //BindingSource _bindingSource = new BindingSource();
        public View_Seat(ViewModel_Seat seat)
        {
            this._vm_seat = seat;
            this.labelChipsCount = new Label();
            this.btnFold = new Button();
            this.btnCall = new Button();
            this.btnRaise = new Button();
            this.btnDealer = new Button();
      
            this.DoubleBuffered = true;
           

            InitializeComponent();
        }
        private void View_Seat_Load(object sender, EventArgs e)
        {
            if (_vm_seat != null)
            {
                
                labelChipsCount.Text = _vm_seat.UserName.ToString(); // add username , then switch to chipcounts
                //labelChipsCount.Text = _vm_seat.SeatNo.ToString();
                if (_vm_seat.UserName != "Empty")
                {
                    this.btnJoinLeave.Enabled = false;
                    this.btnJoinLeave.BackColor = Color.Red;
                    this.btnJoinLeave.Text = _vm_seat.ChipCounts.ToString();
                }
                if (_vm_seat.UserName == this._vm_seat.CurrentUserName)
                {
                    this.btnJoinLeave.Enabled = true;
                    this.btnJoinLeave.BackColor = Color.Lime;
                    this._vm_seat.Joined = true;
                    this.btnJoinLeave.Text = "Leave";
                }
                // Add the two hidden buttons for "Fold" , "Continue"
                this.btnJoinLeave.DataBindings.Add("Text", _vm_seat, "JoinValue");
                btnFold.Text = "Fold";
                btnCall.Text = "Call";
                btnRaise.Text = "Raise";
                btnDealer.Text = " D ";
                btnFold.Font = new Font(btnFold.Font.FontFamily, 6);
                btnCall.Font = new Font(btnFold.Font.FontFamily, 6);
                btnRaise.Font = new Font(btnFold.Font.FontFamily, 6);
                btnDealer.Font = new Font(btnFold.Font.FontFamily, 6);


                btnFold.Size = new Size(this.btnJoinLeave.Width, this.btnJoinLeave.Height);
                btnFold.Location = new Point(this.Left-this.Width, this.Top+this.Height);
                btnCall.Size = new Size(this.btnJoinLeave.Width, this.btnJoinLeave.Height);
                btnCall.Location = new Point(this.btnFold.Left + this.btnFold.Width, this.Top + this.Height);
                btnRaise.Size = new Size(this.btnJoinLeave.Width, this.btnJoinLeave.Height);
                btnRaise.Location = new Point(this.btnCall.Left + this.btnCall.Width, this.Top + this.Height);
                btnDealer.Size = new Size(this.btnJoinLeave.Width/2, this.btnJoinLeave.Height);
                btnDealer.Location = new Point(this.Left, this.Top + this.Height);

                bool visible = true;
                btnFold.BackColor = Color.LightGreen;
                btnFold.Visible = visible;
                btnCall.BackColor = Color.Green;
                btnCall.Visible = visible;
                btnRaise.BackColor = Color.LightGreen;
                btnRaise.Visible = visible;
                btnDealer.BackColor = Color.White;
                btnDealer.Visible = this._vm_seat.IsDealer;

                this.Parent.Controls.Add(this.btnDealer);
                btnDealer.BringToFront();
                   
                if (_vm_seat.SeatNo == 100) //test code , to be deleted eventually
               {
                    this.Parent.Controls.Add(this.btnFold);
                    this.Parent.Controls.Add(this.btnCall);
                    this.Parent.Controls.Add(this.btnRaise);

                    btnFold.BringToFront();
                    btnCall.BringToFront();
                    btnRaise.BringToFront();
               }

                labelChipsCount.Dock = DockStyle.Bottom;
                labelChipsCount.Font = new Font("Arial", 6, FontStyle.Bold);
                //labelChipsCount.Height = 12;



                labelChipsCount.TextAlign = ContentAlignment.BottomCenter;
                this.splitContainer2.Panel2.Controls.Add(labelChipsCount);
                
                this.splitContainer2.SplitterDistance = this.splitContainer2.Height - 10;
                //this.splitContainer2.Dock = DockStyle.Fill;
                this.splitContainer3.Dock = DockStyle.Fill;
            }
        }
        public void SimulateRequestBet(string content)
        {
            string[] arr = content.Split(':');
            string tableno = arr[0];
            decimal potsize = Convert.ToDecimal(arr[1]);
            decimal currentbet = Convert.ToDecimal(arr[2]);
            decimal maxraisebet = Convert.ToDecimal(arr[3]);
            string comment = arr[4];

            {
                // Flash the seat with a time ticker
                this.origColor = this.splitContainer2.Panel2.BackColor;
                //Console.WriteLine("Inside SimulateRequest for " + this._vm_seat.UserName + " for " + comment);
                if (!this.IsHandleCreated)
                {
                    Console.WriteLine("While simulating requst bet , handle is not created");
                    return;
                }
                this.Invoke((MethodInvoker)delegate
                {
                    counter = 50;

                    //Dialogs.BetCollectorControl ctrl = new Dialogs.BetCollectorControl();
                    //this.Parent.Controls.Add(ctrl);
                    //ctrl.Dock = DockStyle.Bottom;

                    timer1.Enabled = true;
                    timer1.Interval = 200;
                    timer1.Start();
                    View_Table vt = (View_Table)this.Parent;
                    vt.threadSync.Reset();

                });
            }
            Console.WriteLine("Done with SimulateRequestBet function call");
        }
        public void SimulateRequestBet1(string content)
        {
            string[] arr = content.Split(':');
            string tableno = arr[0];
            decimal potsize = Convert.ToDecimal(arr[1]);
            decimal currentbet = Convert.ToDecimal(arr[2]);
            decimal maxraisebet = Convert.ToDecimal(arr[3]);
            string comment = arr[4];

            {
                // Flash the seat with a time ticker
                this.origColor = this.splitContainer2.Panel2.BackColor;
                //Console.WriteLine("Inside SimulateRequest for " + this._vm_seat.UserName + " for " + comment);
                if (!this.IsHandleCreated)
                {
                    Console.WriteLine("While simulating requst bet , handle is not created");
                    return;
                }
                this.Invoke((MethodInvoker)delegate
                {
                    counter = 50;

                    if (!this.Parent.Controls.Contains(this.btnFold))
                    {
                        this.Parent.Controls.Add(this.btnFold);
                        this.Parent.Controls.Add(this.btnCall);
                        this.Parent.Controls.Add(this.btnRaise);

                        btnFold.BringToFront();
                        btnCall.BringToFront();
                        btnRaise.BringToFront();
                    }

                    this.btnCall.Visible = true;
                    this.btnFold.Visible = true;
                    this.btnRaise.Visible = true;
                    this.btnCall.Text = "Call " + currentbet.ToString();
                    this.btnRaise.Text = "Raise " + maxraisebet.ToString();

                    timer1.Enabled = true;
                    timer1.Interval = 200;
                    timer1.Start();
                    View_Table vt = (View_Table)this.Parent;
                    vt.threadSync.Reset();

                });
            }
            Console.WriteLine("Done with SimulateRequestBet function call");
        }
        private void timer1_Tick(object sender, EventArgs e)
        {

            //Console.WriteLine("Inside timer1 for " + this._vm_seat.UserName);
            if (timer1.Enabled)
            {
                counter--;
                this.labelChipsCount.Text = counter.ToString();
                
                this.btnCall.Visible = true;
                this.btnFold.Visible = true;
                this.btnRaise.Visible = true;
              
                if (counter <= 0)
                {
                    try
                    {
                        StopTimer();
                    }
                    catch(Exception e1)
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

                this.labelChipsCount.Text = this._vm_seat.UserName;

                this.btnCall.Visible = false;
                this.btnFold.Visible = false;
                this.btnRaise.Visible = false;

                this.btnCall.Text = "Call";
                this.btnRaise.Text = "Raise";

                if (this.Parent.Controls.Contains(this.btnFold))
                {
                    this.Parent.Controls.Remove(this.btnCall);
                    this.Parent.Controls.Remove(this.btnFold);
                    this.Parent.Controls.Remove(this.btnRaise);
                }
                View_Table vt = (View_Table)this.Parent;
                vt.threadSync.Set();
            });
        }
        public void SimulatePlayerAction(string action)
        {

            //Console.WriteLine("Inside SimulateRequest for " + this._vm_seat.UserName + " for " + comment);
            if (!this.IsHandleCreated)
            {
                Console.WriteLine("While simulating player action , handle is not created");
                return;
            }
            this.Invoke((MethodInvoker)delegate
            {
                
                //Blink(action);
                SoftBlink(this.labelChipsCount, action, Color.FromArgb(30, 30, 30), Color.Red, 2000, false);
            });
            
            Console.WriteLine("Done with SimulatePlayerAction function call");

        }
        private async void Blink(string swap)
        {
            string swapped = this.labelChipsCount.Text;
            View_Table vt = (View_Table)this.Parent;
            while (vt.simulatePlayerAction == this._vm_seat.SeatNo)
            {
                await Task.Delay(50);
                this.labelChipsCount.Text = this.labelChipsCount.Text == swapped ? swap : swapped;
            }
        }
        private async void SoftBlink(Control ctrl, string swap, Color c1, Color c2, short CycleTime_ms, bool BkClr)
        {
            var sw = new Stopwatch(); sw.Start();
            short halfCycle = (short)Math.Round(CycleTime_ms * 0.5);
            View_Table vt = (View_Table)this.Parent;
            string swapped = this.labelChipsCount.Text;
            Color origColor = this.labelChipsCount.BackColor;
            while (vt.simulatePlayerAction == this._vm_seat.SeatNo)
            {
                await Task.Delay(500);
                var n = sw.ElapsedMilliseconds % CycleTime_ms;
                var per = (double)Math.Abs(n - halfCycle) / halfCycle;
                var red = (short)Math.Round((c2.R - c1.R) * per) + c1.R;
                var grn = (short)Math.Round((c2.G - c1.G) * per) + c1.G;
                var blw = (short)Math.Round((c2.B - c1.B) * per) + c1.B;
                var clr = Color.FromArgb(red, grn, blw);
                if (BkClr) ctrl.BackColor = clr; else ctrl.ForeColor = clr;
                this.labelChipsCount.Text = this.labelChipsCount.Text == swapped ? swap : swapped;
            }
            this.labelChipsCount.Text = swapped;
            this.labelChipsCount.BackColor = origColor;
        }
     
        private void btnJoinLeave_Click(object sender, EventArgs e)
        {// this button click flips the Joined boolean property. 
                 
            if (_vm_seat.Joined)
            {
                _vm_seat.Joined = false;
                this.labelChipsCount.Text = "Empty";
               // this.btnJoinLeave.Text = "Join";
                // Leaving the table
                if (JoinedTableEvent != null)
                {
                    JoinedTableEvent.Invoke(this._vm_seat.TableNo, this._vm_seat.SeatNo, -1); // sending negative chipcount to indicate leaving
                }
            }
            else
            {
                ViewModel_SelectMoney x = new ViewModel_SelectMoney();
                x.TotalMoney = this._vm_seat.UserServices.GetPlayerProfile(this._vm_seat.CurrentUserName).TotalMoneyAvailable;
                x.AvailableMoney = x.TotalMoney - this._vm_seat.UserServices.GetPlayerProfile(this._vm_seat.CurrentUserName).MoneyInPlay;
                decimal selectedmoney = 0;

                using (Dialogs.AddChipsToTable x1 = new Dialogs.AddChipsToTable(x))
                {
                    x1.StartPosition = FormStartPosition.Manual;
                    x1.ShowInTaskbar = false;
                    x1.Location = this.Parent.PointToScreen(Point.Empty);
                    x1.MaximizeBox = false;
                    x1.MinimizeBox = false;
                    DialogResult result =   x1.ShowDialog(this);

                    if (result == DialogResult.Cancel)
                        return;
                    else
                        selectedmoney = x1.getModel().SelectedMoney;


                }


                _vm_seat.Joined = true;
                this.labelChipsCount.Text = this._vm_seat.CurrentUserName;
               // this.btnJoinLeave.Text = "Leave";
                if (JoinedTableEvent != null)
                {
                    JoinedTableEvent.Invoke(this._vm_seat.TableNo, this._vm_seat.SeatNo, selectedmoney);
                }
            }
        }
        private void splitContainer3_Panel1_Paint(object sender, PaintEventArgs e)
        {
            Control c = (Control)sender;
            if (this._vm_seat.HoleCard_1 != null)
                e.Graphics.DrawImage(this._vm_seat.HoleCard_1, 0, 0 ,c.Width, c.Height);
            else
                e.Graphics.DrawImage(View_Deck.Instance.GetBackCard(), 0, 0, c.Width, c.Height);
        }

        private void splitContainer3_Panel2_Paint(object sender, PaintEventArgs e)
        {
            Control c = (Control)sender;
            if (this._vm_seat.HoleCard_1 != null)
                e.Graphics.DrawImage(this._vm_seat.HoleCard_2, 0, 0, c.Width, c.Height);
            else
                e.Graphics.DrawImage(View_Deck.Instance.GetBackCard(), 0, 0, c.Width, c.Height);
        }
        private void btn_repaint123()
        {
            labelChipsCount.Text = _vm_seat.UserName.ToString(); // add username , then switch to chipcounts

            if (_vm_seat.UserName != "Empty")
            {
                this.btnJoinLeave.Enabled = false;
                this.btnJoinLeave.BackColor = Color.Red;
                this.btnJoinLeave.Text = _vm_seat.ChipCounts.ToString();
            }
            if (_vm_seat.UserName == this._vm_seat.CurrentUserName)
            {
                this.btnJoinLeave.Enabled = true;
                this.btnJoinLeave.BackColor = Color.Lime;
                this._vm_seat.Joined = true;
                this.btnJoinLeave.Text = "Leave";
            }
        }
        public void repaint()
        {
            this.splitContainer3.Panel1.Invalidate();
            this.splitContainer3.Panel2.Invalidate();
            //this.btnJoinLeave.Invalidate();
            this.Invalidate();
            this.Invoke((MethodInvoker)delegate
            {
                this.Update();
            });
              
         }
      

    }

}
