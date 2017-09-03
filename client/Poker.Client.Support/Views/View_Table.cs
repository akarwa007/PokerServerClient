using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Poker.Shared;
using Poker.Shared.Utils;
using System.Threading;

namespace Poker.Client.Support.Views
{
    public partial class View_Table : UserControl
    {
        ViewModel_Table _vm_table = null;
        public event JoinedTableHandler JoinedTableEvent;
        public event ReceiveBetHandler ReceiveBetEvent;
        public  readonly ManualResetEvent threadSync = new ManualResetEvent(true);
        public short simulatePlayerAction = -1; // seatno of the player from where the action was received , the player that just acted


        View_Card VCard_flop1, VCard_flop2, VCard_flop3, VCard_turn, VCard_river;
        Label lflop1, lflop2, lflop3, lturn, lriver;
        short myseat = -1; // means not occupying any seat
        Dictionary<short, View_Seat> Dict_View_Seats = new Dictionary<short, View_Seat>();

        
        public View_Table(ViewModel_Table vm_table)
        {     
            _vm_table = vm_table;
            this.DoubleBuffered = true;
            InitializeComponent();
        }
        public void SetViewModel(ViewModel_Table vm)
        {
            _vm_table.CopyFrom(vm);
        }
        private void View_Table_Paint(object sender, PaintEventArgs e)
        {
          

        }
        public void repaint()
        {
            Task.Run(() =>
            {
                Thread.Sleep(10);
                threadSync.WaitOne();
                if (this.InvokeRequired)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        foreach(Control ctrl in this.Controls)
                        {
                            ctrl.Dispose();
                        }
                        this.Controls.Clear();
                        RenderControls();
                    });
                }
                else
                {
                    foreach (Control ctrl in this.Controls)
                    {
                        ctrl.Dispose();
                    }
                    this.Controls.Clear();
                    RenderControls();
                }
            });
        }
        public string UserName
        {
            get
            {
                return _vm_table.UserName;
            }
            set { }
        }
        private void resizehere(object sender, EventArgs e)
        {
            Control ctrl = (Control)sender;
            int xChange = 1, yChange = 1;
         
        }
        private void RenderControls()
        {
            int x, y;

            int y1 = this.Height;
            int x1 = this.Width;

            int seatwidth = x1 / 13;
            int seatheight = y1 / 6;

            x = seatwidth;
            y = seatheight;

            if (_vm_table != null)
            {
                int delta_width = seatwidth / 4;
                int delta_shift = seatwidth / 2;
                
                this.VCard_flop1 = new View_Card(_vm_table.Flop1);
                this.VCard_flop1.Size = new Size(this.Width / 13, this.Height / 6);
                int seatloc_1_x = delta_shift + seatwidth * 3;
                this.VCard_flop1.Location = new Point(seatloc_1_x, y1/2 - seatheight/2);
                this.Controls.Add(VCard_flop1);

                
                this.VCard_flop2 = new View_Card(_vm_table.Flop2);
                this.VCard_flop2.Size = new Size(this.Width / 13, this.Height / 6);
                int seatloc_2_x = seatloc_1_x + seatwidth + delta_width;
                this.VCard_flop2.Location = new Point(seatloc_2_x, y1 / 2 - seatheight / 2);
                this.Controls.Add(VCard_flop2);

                this.VCard_flop3 = new View_Card(_vm_table.Flop3);
                this.VCard_flop3.Size = new Size(this.Width / 13, this.Height / 6);
                int seatloc_3_x = seatloc_2_x + seatwidth + delta_width;
                this.VCard_flop3.Location = new Point(seatloc_3_x, y1 / 2 - seatheight / 2);
                this.Controls.Add(VCard_flop3);

                this.VCard_turn = new View_Card(_vm_table.Turn);
                this.VCard_turn.Size = new Size(this.Width / 13, this.Height / 6);
                int seatloc_4_x = seatloc_3_x + seatwidth + delta_width;
                this.VCard_turn.Location = new Point(seatloc_4_x, y1 / 2 - seatheight / 2);
                this.Controls.Add(VCard_turn);

                this.VCard_river = new View_Card(_vm_table.River);
                this.VCard_river.Size = new Size(this.Width / 13, this.Height / 6);
                int seatloc_5_x = seatloc_4_x + seatwidth + delta_width;
                this.VCard_river.Location = new Point(seatloc_5_x, y1 / 2 - seatheight / 2);
                this.Controls.Add(VCard_river);

                int yy = y1 / 2 - seatheight / 2 + seatheight + seatheight/6;
                lflop1 = new Label();
                lflop1.Text = "flop";
                lflop1.Width = seatwidth;
                lflop1.TextAlign = ContentAlignment.MiddleCenter;
                lflop1.Location = new Point(seatloc_1_x, yy);
                this.Controls.Add(lflop1);

                lflop2 = new Label();
                lflop2.Text = "flop";
                lflop2.Width = seatwidth;
                lflop2.TextAlign = ContentAlignment.MiddleCenter;
                lflop2.Location = new Point(seatloc_2_x, yy);
                this.Controls.Add(lflop2);

                lflop3 = new Label();
                lflop3.Text = "flop";
                lflop3.Width = seatwidth;
                lflop3.TextAlign = ContentAlignment.MiddleCenter;
                lflop3.Location = new Point(seatloc_3_x, yy);
                this.Controls.Add(lflop3);

                lturn = new Label();
                lturn.Text = "turn";
                lturn.Width = seatwidth;
                lturn.TextAlign = ContentAlignment.MiddleCenter;
                lturn.Location = new Point(seatloc_4_x, yy);
                this.Controls.Add(lturn);

                lriver = new Label();
                lriver.Text = "river";
                lriver.Width = seatwidth;
                lriver.TextAlign = ContentAlignment.MiddleCenter;
                lriver.Location = new Point(seatloc_5_x, yy);
                this.Controls.Add(lriver);

                Label l1, l2, l3;
                l1 = new Label();
                l2 = new Label();
                l3 = new Label();

                l1.Text = _vm_table.GameName;
                l2.Text = _vm_table.GameValue;
              

                l1.Width = this.Width;
                l1.TextAlign = ContentAlignment.MiddleCenter;
                l1.Font = new Font("Arial", 24, FontStyle.Bold);
                l1.Location = new Point(0, 0);
                l1.Size = new Size(this.Width, seatheight);
                

                l3.Text = _vm_table.TableNo;
                l3.Width = this.Width;
                l3.TextAlign = ContentAlignment.MiddleCenter;
                l3.Font = new Font("Arial", 24, FontStyle.Bold);
                l3.Location = new Point(0, y1-seatheight);
                l3.Size = new Size(this.Width, seatheight);
               

            

                this.Controls.Add(l1);
               // this.Controls.Add(l2);
                this.Controls.Add(l3);
            }
            
            short seatno = 2;
            View_Seat seat1 = null;
            
            
            ViewModel_Seat vm_seat = _vm_table.get_VM_Seat(seatno);
            int count = 10;
          
            while (count > 6)
            {
                x = x + seatwidth * 2;
                //y = y + 10;
                vm_seat = _vm_table.get_VM_Seat(seatno);
                seat1 = new View_Seat(vm_seat);
                Dict_View_Seats[seatno] = seat1;
                seat1.JoinedTableEvent += Seat_JoinedTableEvent;
                seat1.ReceiveBetEvent += Seat_ReceiveBetEvent;
                seat1.Size = new Size(seatwidth, seatheight);
                seat1.Location = new Point(x, y);
                this.Controls.Add(seat1);
                count--;
                seatno++;
            }
            x = seatwidth;
            y = y1 - seatheight*2;
            seatno = 10;
            while (count > 2)
            {
                x = x + seatwidth * 2;
                //y = y + 10;

                vm_seat = _vm_table.get_VM_Seat(seatno);
                seat1 = new View_Seat(vm_seat);
                Dict_View_Seats[seatno] = seat1;
                seat1.JoinedTableEvent += Seat_JoinedTableEvent;
                seat1.ReceiveBetEvent += Seat_ReceiveBetEvent;
                seat1.Size = new Size(seatwidth, seatheight);
                seat1.Location = new Point(x, y);
                this.Controls.Add(seat1);
                count--;
                seatno--;
            }
            x = 0;
            y = y1 / 2 - seatheight/2;
            seatno = 1;
            this.SuspendLayout();
            while (count > 1)
            {
                x = x + x1 / 12;
                //y = y + 10;
                vm_seat = _vm_table.get_VM_Seat(seatno);
                seat1 = new View_Seat(vm_seat);
                Dict_View_Seats[seatno] = seat1;
                seat1.JoinedTableEvent += Seat_JoinedTableEvent;
                seat1.ReceiveBetEvent += Seat_ReceiveBetEvent;
                seat1.Size = new Size(seatwidth, seatheight);
                seat1.Location = new Point(x, y);
                this.Controls.Add(seat1);
                count--;
            }
            seatno = 6;
            while (count > 0)
            {
                //x = x + x1 / 12;
                y = seat1.Location.Y;
                vm_seat = _vm_table.get_VM_Seat(seatno);
                seat1 = new View_Seat(vm_seat);
                Dict_View_Seats[seatno] = seat1;
                seat1.JoinedTableEvent += Seat_JoinedTableEvent;
                seat1.ReceiveBetEvent += Seat_ReceiveBetEvent;
                seat1.Size = new Size(seatwidth, seatheight);
                seat1.Location = new Point(x1 - 2 * x1 / 10, y);
                this.Controls.Add(seat1);
                count--;
                seatno++;
            }
           
            this.ResumeLayout();
        }
        private short MySeatNo        
        {
           get
            {
                var y = _vm_table.ListOfSeats.Find(x => x.UserName == this.UserName);
                if (y != null)
                    return y.SeatNo;
                else
                    return -1;
            }
        }
        private void Seat_JoinedTableEvent(string TableNo, short SeatNo, decimal ChipCounts)
        {
            myseat = SeatNo;
            if (JoinedTableEvent != null)
                JoinedTableEvent.Invoke(TableNo, SeatNo, ChipCounts);
        }
        private void Seat_ReceiveBetEvent(string TableNo, decimal ChipCounts)
        {
            if (ReceiveBetEvent != null)
                ReceiveBetEvent.Invoke(TableNo, ChipCounts);
        }
        public void ProcessMessage(Poker.Shared.Message message)
        {
            if (message == null)
                return;
            switch(message.MessageType)
            {
                case MessageType.TableSendHoleCards:
                    OnReceiveHoleCards(PConvert.ToHoleCards(message));
                    break;
                case MessageType.TableSendFlop:
                    OnReceiveFlop(PConvert.ToFlop(message));
                    break;
                case MessageType.TableSendTurn:
                    OnReceiveTurn(PConvert.ToSingleCard(message));
                    break;
                case MessageType.TableSendRiver:
                    OnReceiveRiver(PConvert.ToSingleCard(message));
                    break;
                case MessageType.PlayerActionRequestBet:
                    OnReceiveRequestBet(message);
                    break;
                case MessageType.PlayerAction:
                    OnReceivePlayerAction(message);
                    break;
                case MessageType.GameUpdate:
                    string[] state = message.Content.Split(':');
                    if (state[0] == "Starting")
                         OnReceiveGameStart(Convert.ToInt16(state[1]));
                    if (state[0] == "Ending")
                        OnReceiveGameEnd();
                    break;
                default:
                    throw new Exception("Not sure what message is this");
            }
        }
        public void OnReceiveGameStart(short dealerposition)
        {
            if (MySeatNo > 0)
            {
                // Need to change this to assign to the view model of the seat rather than the view of the seat.
               // Dict_View_Seats[MySeatNo].Assign_HoleCards(null);
                ViewModel_Seat  vm_seat = _vm_table.get_VM_Seat(MySeatNo);
                if (vm_seat.HoleCard_1 != null)
                    vm_seat.HoleCard_1.Dispose();
                if (vm_seat.HoleCard_2 != null)
                    vm_seat.HoleCard_2.Dispose();
                vm_seat.HoleCard_1 = View_Deck.Instance.GetBackCard();
                vm_seat.HoleCard_2 = View_Deck.Instance.GetBackCard();
                Dict_View_Seats[MySeatNo].repaint();
               
            }
            Console.WriteLine("OnReceiveGameStart ");
        }

        private void View_Table_DragEnter(object sender, DragEventArgs e)
        {
            string s = "";
        }

        private void View_Table_MouseDown(object sender, MouseEventArgs e)
        {
            string s = "";
            TableLayoutPanel parent = (TableLayoutPanel)((View_Table)sender).Parent;
            parent.DoDragDrop(sender, DragDropEffects.Move);
        }

        public void OnReceiveGameEnd()
        {

        }
        public void OnReceiveHoleCards(Tuple<A_Card, A_Card> holecards)
        {
            if (MySeatNo > 0)
            {
                // Need to change this to assign to the view model of the seat rather than the view of the seat.
                //Dict_View_Seats[MySeatNo].Assign_HoleCards(holecards);
                ViewModel_Seat vm_seat = _vm_table.get_VM_Seat(MySeatNo);
                vm_seat.HoleCard_1 = View_Deck.Instance.GetCard(holecards.Item1);
                vm_seat.HoleCard_2 = View_Deck.Instance.GetCard(holecards.Item2);
                Dict_View_Seats[MySeatNo].repaint();
                this.Invoke((MethodInvoker)delegate
                {
                    Dict_View_Seats[MySeatNo].Invalidate();
                    Dict_View_Seats[MySeatNo].Update();
                    this.Invalidate(true);
                    this.Update();
                });
                Console.WriteLine("OnReceiveHoleCards for  " + this.UserName + holecards.ToString());
            }
            Console.WriteLine("OnReceiveHoleCards " + holecards.ToString());
        }
        public void OnReceiveFlop(Tuple<A_Card,A_Card,A_Card> flop)
        {
            this._vm_table.Flop1.Update(flop.Item1);
            this._vm_table.Flop2.Update(flop.Item2);
            this._vm_table.Flop3.Update(flop.Item3);
            this._vm_table.Board.Item1.Update(flop.Item1);
            this._vm_table.Board.Item2.Update(flop.Item2);
            this._vm_table.Board.Item3.Update(flop.Item3);
            /*
            this.Invoke((MethodInvoker)delegate
            {
                this.VCard_flop1.Invalidate();
                this.VCard_flop2.Invalidate();
                this.VCard_flop3.Invalidate();
                this.Invalidate(true);
                this.Update();
            });
            */
            Console.WriteLine("OnReceiveFlop " + flop.ToString());
        }
        public void OnReceiveTurn(A_Card turn)
        {
            this._vm_table.Turn.Update(turn);
            this._vm_table.Board.Item4.Update(turn);
            /*
            this.Invoke((MethodInvoker)delegate
            {
                this.VCard_turn.Invalidate();
                this.Invalidate(true);
                this.Update();
            });
            */
           
           
            Console.WriteLine("OnReceiveTurn " + turn.ToString());
        }
        public void OnReceiveRiver(A_Card river)
        {
            this._vm_table.River.Update(river);
            this._vm_table.Board.Item5.Update(river);
            /*
            this.Invoke((MethodInvoker)delegate
            {
                this.VCard_river.Invalidate();
            
                this.Update();
            });
            */
            Console.WriteLine("OnReceiveRiver " + river.ToString());
        }
        public void OnReceiveRequestBet(Shared.Message m)
        {    
            if (MySeatNo > 0)
            {
                // Need to change this to assign to the view model of the seat rather than the view of the seat.
                //Dict_View_Seats[MySeatNo].SimulateRequestBet(m.Content);
                ViewModel_BetCollection vm_bc = new ViewModel_BetCollection();
                vm_bc.AvailableMoney = _vm_table.get_VM_Seat(MySeatNo).ChipCounts;
                string[] arr = m.Content.Split(':');
                string tableno = arr[0];
                decimal potsize = Convert.ToDecimal(arr[1]);
                decimal currentbet = Convert.ToDecimal(arr[2]);
                decimal maxraisebet = Convert.ToDecimal(arr[3]);
                decimal minbet = this._vm_table.getBigBlindAmount();
                string comment = arr[4];
                vm_bc.CurrentBet = currentbet;
                vm_bc.PotValue = potsize;
                vm_bc.MinBetAllowed = Math.Max(minbet, currentbet);
                vm_bc.UserName = this.UserName;
                decimal betmade = 0;
                this.Invoke((MethodInvoker)delegate
                {
                    using (Dialogs.BetCollectorControl x1 = new Dialogs.BetCollectorControl(vm_bc))
                    {
                        x1.StartPosition = FormStartPosition.Manual;
                        x1.ShowInTaskbar = false;
                        x1.Location = this.PointToScreen(Point.Empty);
                        x1.MaximizeBox = false;
                        x1.MinimizeBox = false;
                        DialogResult result = x1.ShowDialog(this);

                        if (result == DialogResult.Cancel)
                            betmade = -1;
                        else
                            betmade = x1.getModel().BetChoosen;
                    }
                });
                this.ReceiveBetEvent.Invoke(this._vm_table.TableNo, betmade);
                Console.WriteLine("OnReceiveRequestBet " + m.Content);
            }
            
            //Console.WriteLine("OnReceiveRequestBet " + m.Content);
        }
        public void OnReceivePlayerAction(Shared.Message m)
        {
            //if (MySeatNo > 0)
            {
                string[] arr = m.Content.Split(':');
                string tableno = arr[0];
                short seatno = Convert.ToInt16(arr[1]);
                string action = arr[2];
                // Need to change this to assign to the view model of the seat rather than the view of the seat.
                this.simulatePlayerAction = seatno;
                Dict_View_Seats[seatno].SimulatePlayerAction(action);
            }
            Console.WriteLine("OnReceivePlayerAction " + m.Content);
        }


        private void View_Table_Load(object sender, EventArgs e)
        {
            try
            {
                RenderControls();
            }
            catch(Exception e1)
            {
                Console.WriteLine(e1.Message);
            }
        }

        private void View_Table_SizeChanged(object sender, EventArgs e)
        {
            resizehere(sender, e);
           //repaint();

        }

     
    }
}
