using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net.Sockets;
using Poker.Shared;
using Poker.Gateway;
using Poker.Common;


namespace Poker.Server
{
    public partial class Form1 : Form
    {
        private object _locker = new object();
        private bool _ServerStarted = false;
        TCPConnector conn = null;
        Dictionary<string,AsyncCallback> _listOfCallbacks = new Dictionary<string,AsyncCallback>();
        System.Timers.Timer _timer = new System.Timers.Timer(10);
        public Form1()
        {
            
            _timer.Elapsed += _timer_Elapsed;
            
            TableManager.Instance.CreateTable(10);
            InitializeComponent();
            this.textBox2.Text = "0";
           // _timer.Start();
        }

        private void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            update1();
        }
        private void cleanup_a_client(TcpClient client)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<TcpClient>(cleanup_a_client),new object[] { client});
            }
            else
            {
                this.conn.cleanup_client(client);
            }
        }
        private void update1()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(update1));
            }
            else
            {
                this.textBox2.Text = (Convert.ToInt32(this.textBox2.Text) + 1).ToString();
            }
        }

        private bool ServerStarted
        {
            get
            {
                return _ServerStarted;
            }
            set
            {
                _ServerStarted = value;
                if (_ServerStarted)
                    this.btnStartServer1.Text = "Stop Server";
                else
                    this.btnStartServer1.Text = "Start Server";

            }
        }
        private void Form1_Load_1(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            //Table t = new Table(4);
            Deck d = Deck.GetShuffledDeck();
            Tuple<Card, Card, Card, Card, Card> hand = new Tuple<Card, Card, Card, Card, Card>(
                                                        new Card(Suit.Diamond,Rank.Nine),
                                                        new Card(Suit.Club,Rank.Nine),
                                                        new Card(Suit.Spade,Rank.Nine),
                                                        new Card(Suit.Club,Rank.Jack),
                                                        new Card(Suit.Heart,Rank.Jack)
                                                        );

            Tuple<Card, Card, Card, Card, Card> hand1 = new Tuple<Card, Card, Card, Card, Card>(
                                            new Card(Suit.Diamond, Rank.Ace),
                                            new Card(Suit.Club, Rank.King),
                                            new Card(Suit.Club, Rank.Queen),
                                            new Card(Suit.Club, Rank.Jack),
                                            new Card(Suit.Club, Rank.Ten)
                                            );

            Tuple<Card, Card, Card, Card, Card> hand2 = new Tuple<Card, Card, Card, Card, Card>(
                                     new Card(Suit.Diamond, Rank.Ace),
                                     new Card(Suit.Club, Rank.Two),
                                     new Card(Suit.Club, Rank.Three),
                                     new Card(Suit.Club, Rank.Four),
                                     new Card(Suit.Club, Rank.Five)
                                     );
            HandRankings h = new HandRankings(hand);
             h = new HandRankings(hand);
             h = new HandRankings(hand);
            Console.WriteLine(d.serialize());
            AllPokerHands aa = new AllPokerHands();
            aa.init();
          
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnStartServer1_Click(object sender, EventArgs e)
        {  
            createpokeruser_callback callback1  = new createpokeruser_callback(PokerUserFactory.Instance.CreatePlayer);
            // _listOfCallbacks.Add("createpokeruser",
            if (!this.ServerStarted)
            {// Start the Server
                conn = new TCPConnector(new Action<Poker.Shared.Message>(AppendTextBox), new Action<TcpClient>(cleanup_a_client), callback1);
                conn.start();
                
                this.ServerStarted = true;
            }
            else
            {// Stop the server
                if (conn != null)
                {
                    conn.stop();
                    this.ServerStarted = false;
                }

            }
        }
        public void AppendTextBox(Poker.Shared.Message value)
        {
          
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action<Poker.Shared.Message>(AppendTextBox), new object[] { value });
                    return;
                }
               // this.textBox1.Text += value;
                this.textBox1.AppendText(value.UserName + " : " + value.MessageType + ":" +  value.Content);
                this.textBox1.AppendText(Environment.NewLine);
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btSendCasinoUpdate_Click(object sender, EventArgs e)
        {
            MessageFactory.SendCasinoMessage();

        }

        private void btnViewClients_Click(object sender, EventArgs e)
        {
            // list the poker clients connected to the server
            // will have ability to disconnect a client too. 
            dataGridView_Clients.Rows.Clear();
            dataGridView_Clients.Columns.Clear();
            dataGridView_Clients.Columns.Add("UserName", "UserName");
            dataGridView_Clients.Columns.Add("TotalChips", "TotalChips");
            dataGridView_Clients.Columns.Add("ChipsAvailable", "ChipsAvailable");
            List<PokerUser> users = PokerUserFactory.GetListPokerUsers();
            foreach(PokerUser user in users)
            {
                dataGridView_Clients.Rows.Add(new object[] {user.UserName,user.TotalChips,user.ChipsAvailable });
            }
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
                Environment.Exit(0);
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnViewTables_Click(object sender, EventArgs e)
        {
            // list the poker clients connected to the server
            // will have ability to disconnect a client too. 
            dataGridView_Tables.Rows.Clear();
            dataGridView_Tables.Columns.Clear();
            dataGridView_Tables.Columns.Add("TableNo", "TableNo");
            dataGridView_Tables.Columns.Add("PlayerCount", "PlayerCount");
            dataGridView_Tables.Columns.Add("StartGame", "StartGame");
            IEnumerable<ITable> tables = TableManager.Instance.GetRunningTables();
            int rowindex = 0;
            foreach (ITable table in tables)
            {
                Table t = (Table)table;
              
                dataGridView_Tables.Rows.Add(new object[] { t.TableNo, t.SeatedPlayerCount() ,"Start"});
                Button bt = new Button();
                bt.Text = "Start the Game";
                //dataGridView_Tables.Controls.Add(bt);
                //bt.Location = this.dataGridView_Tables.GetCellDisplayRectangle(2,rowindex, true).Location;
                //bt.Size = this.dataGridView_Tables.GetCellDisplayRectangle(2,rowindex, true).Size;

                DataGridViewButtonCell buttonCell = new DataGridViewButtonCell();
                
                this.dataGridView_Tables[2,rowindex] = buttonCell;
                this.dataGridView_Tables[2,rowindex].Value = "Start the Game";


                rowindex++;
            }
        }

        private void dataGridView_Tables_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string s = "";
            if (e.ColumnIndex == 2)
            {
                string tableno = dataGridView_Tables[0, e.RowIndex].Value.ToString();
                TableManager.Instance.GetTable(tableno).StartStopGame();
            }

        }
    }
}
