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
using Newtonsoft.Json;

namespace Poker.Client.Support.Views
{
    public partial class View_Casino : UserControl
    {
        ViewModel_Casino _casinoModel;
        ViewModel_Table _detailPanelModel;
        View_Table _currentViewTable;
        Dictionary<string, View_Table> _cache_ViewTables = new Dictionary<string, View_Table>();
        public event JoinedTableHandler JoinedTableEvent;
        public event ReceiveBetHandler ReceiveBetEvent;
        Dictionary<string, Action<Shared.Message>> CardEvent = new Dictionary<string, Action<Shared.Message>>();
        Dictionary<string, Action<Shared.Message>> BetEvent = new Dictionary<string, Action<Shared.Message>>();
        public View_Casino()
        {
            this.DoubleBuffered = true;
            InitializeComponent();
           
        }
        private void init()
        {
            // do databindings

            if (this.txtPlayerProfile.DataBindings.Count == 0)
            {
                Binding be = new Binding("Text", _casinoModel, "BankBalance");
                be.ControlUpdateMode = ControlUpdateMode.OnPropertyChanged;
                this.txtPlayerProfile.DataBindings.Add(be);
            }
        }
       public string UserName
        {
            get;set;
        }
        public void UpdateModel(ViewModel_Casino model)
        {
            // _casinoModel = model;
            if (_casinoModel == null)
                _casinoModel = model;
            else
               _casinoModel.CopyFrom(model);

            refresh();
        }
        private void refresh()
        {
            ClearTreeView();
            init();
            var groups = _casinoModel.ListOfTables.GroupBy(x => x.GameName, x => new { x.GameValue, x });
            foreach (var j in groups)
            {
                TreeNode node = new TreeNode(j.Key.ToString());
                foreach (var k in j.ToList())
                {
                    TreeNode t = new TreeNode(k.GameValue);
                    t.Tag = k.x;
                    node.Nodes.Add(t);
                }
                AddTreeNodes(node);
            }
        }
        public void TableUpdateMessage(Poker.Shared.Message message)
        {
            if (message.MessageType == MessageType.TableUpdate)
            {
                ViewModel_Table vm_table = JsonConvert.DeserializeObject<ViewModel_Table>(message.Content);
                vm_table.UserName = this.UserName;
                if (_casinoModel != null)
                {
                    _casinoModel.Replace(vm_table);
                }
                Console.WriteLine("Recevied table update message for TableNo -- " + vm_table.TableNo);
                if ((_detailPanelModel != null) && (_detailPanelModel.TableNo == vm_table.TableNo))
                {
                    SetDetailPanel(vm_table.TableNo);
                }
            }
        }
        private void PlayeActionMessage(Poker.Shared.Message message)
        {

        }
        private void CardEventMessage(Poker.Shared.Message message)
        {
            string[] arr = message.Content.Split(':');
            string tableno = arr[0];
            lock (this.CardEvent)
            {
                this.CardEvent[tableno].Invoke(message);
            }
        }
        private void BetEventMessage(Poker.Shared.Message message)
        {
            string[] arr = message.Content.Split(':');
            string tableno = arr[0];
            lock (this.BetEvent)
            {
                this.BetEvent[tableno].Invoke(message);
            }
        }
        public void ProcessMessage(Poker.Shared.Message m)
        {
            if (m.MessageType == MessageType.CasinoUpdate)
                CasinoUpdateMessage(m);
            else if (m.MessageType == MessageType.PlayerBankBalance)
                PlayerBankBalanceMessage(m);
            else if (m.MessageType == MessageType.TableUpdate)
                TableUpdateMessage(m);
            else if (m.MessageType == MessageType.PlayerActionRequestBet)
                BetEventMessage(m);
            else if (m.MessageType == MessageType.TableSendHoleCards)
                CardEventMessage(m);
            else if (m.MessageType == MessageType.TableSendFlop)
                CardEventMessage(m);
            else if (m.MessageType == MessageType.TableSendTurn)
                CardEventMessage(m);
            else if (m.MessageType == MessageType.TableSendRiver)
                CardEventMessage(m);
        }
        private void ClearTreeView()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(ClearTreeView));
            }
            this.treeView1.Nodes.Clear();
        }
        private void AddTreeNodes(TreeNode node)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<TreeNode>(AddTreeNodes), new object[] { node });
                return;
            }
            this.treeView1.Nodes.Add(node);
        }
        private void CasinoUpdateMessage(Poker.Shared.Message message)
        {
            if (message.MessageType == MessageType.CasinoUpdate)
            {
                ViewModel_Casino vm = JsonConvert.DeserializeObject<ViewModel_Casino>(message.Content);
                this.UpdateModel(vm);
            }
        }
        private void PlayerBankBalanceMessage(Poker.Shared.Message message)
        {
            if (message.MessageType == MessageType.PlayerBankBalance)
            {
                decimal balance = Convert.ToDecimal(message.Content);
                this._casinoModel.BankBalance = balance;
              
            }
        }
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Action == TreeViewAction.Unknown)
                return;
            ViewModel_Table vm = (ViewModel_Table)e.Node.Tag;
            ViewModel_Table latest = _casinoModel.GetLatest(vm);
            if (vm == null)
                return;
            SetDetailPanel(latest.TableNo);
        }
        private View_Table GetViewTable(string tableno)
        {
            View_Table vt;
            ViewModel_Table vm = _casinoModel.GetVMTable(tableno);
            if (this._cache_ViewTables.ContainsKey(tableno))
            {
                vt = _cache_ViewTables[tableno];
                vt.SetViewModel(vm);
            }
            else
            {
                vt = new View_Table(vm);
                vt.JoinedTableEvent += Vt_JoinedTableEvent;
                vt.ReceiveBetEvent += Vt_ReceiveBetEvent;
                lock (this.CardEvent)
                {
                    this.CardEvent[vm.TableNo] = new Action<Shared.Message>(vt.ProcessMessage);
                }
                lock (this.BetEvent)
                {
                    this.BetEvent[vm.TableNo] = new Action<Shared.Message>(vt.ProcessMessage);
                }
               
                vt.Visible = false;
                vt.Height = splitContainer1.Panel2.Height;
                vt.Width = splitContainer1.Panel2.Width;
                splitContainer1.Invoke(new Action(() => splitContainer1.Panel2.Controls.Add(vt)));
                _cache_ViewTables[tableno] = vt;
            }
            return vt; 
        }
        private void SetDetailPanel(string tableno)
        {
            this.Invoke((MethodInvoker)delegate
            {
                //vm.UserName = this.UserName;
                View_Table vt = GetViewTable(tableno);

                if (_currentViewTable != null)
                {
                    _currentViewTable.Visible = false;
                }
                _currentViewTable = vt;
                _currentViewTable.Visible = true;
                _currentViewTable.Invalidate();
                _currentViewTable.Update();
                _currentViewTable.repaint();

                _detailPanelModel = _casinoModel.GetVMTable(tableno);
            });
        }
        private void SetDetailPanelOld(ViewModel_Table vm)
        {
            vm.UserName = this.UserName;
            View_Table vt = new View_Table(vm);
            vt.JoinedTableEvent += Vt_JoinedTableEvent;
            vt.ReceiveBetEvent += Vt_ReceiveBetEvent;
            lock (this.CardEvent)
            {
                this.CardEvent[vm.TableNo] = new Action<Shared.Message>(vt.ProcessMessage);
            }
            lock(this.BetEvent)
            {
                this.BetEvent[vm.TableNo] = new Action<Shared.Message>(vt.ProcessMessage);
            }
            vt.SuspendLayout();
            vt.Height = splitContainer1.Panel2.Height;
            vt.Width = splitContainer1.Panel2.Width;
         
            splitContainer1.Invoke(new Action(() => splitContainer1.Panel2.Controls.Clear()));
            splitContainer1.Invoke(new Action(() => splitContainer1.Panel2.Controls.Add(vt)));

            vt.PerformLayout();
            _detailPanelModel = vm;
            
            //_cache_ViewTables[vm.TableNo] = vt;
          
        }

        private void Vt_JoinedTableEvent(string TableNo, short SeatNo, decimal ChipCounts)
        {
            if (JoinedTableEvent != null)
                JoinedTableEvent.Invoke(TableNo, SeatNo, ChipCounts);
        }
        private void Vt_ReceiveBetEvent(string TableNo, decimal ChipCounts)
        {
            if (ReceiveBetEvent != null)
                ReceiveBetEvent.Invoke(TableNo, ChipCounts);
        }

        private void splitContainer1_Panel2_SizeChanged(object sender, EventArgs e)
        {
            Panel p = (Panel)sender;
            if (p.Controls.Count > 0)
            {
                if (p.Controls[0] is Views.View_Table)
                {
                    View_Table vt = (View_Table)p.Controls[0];
                    vt.Height = p.Height;
                    vt.Width = p.Width;
                }
            }
        }

        private void splitContainer1_Panel2_DoubleClick(object sender, EventArgs e)
        {
           
            
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtPlayerProfile_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
