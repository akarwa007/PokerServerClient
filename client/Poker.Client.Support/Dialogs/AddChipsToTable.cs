using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Poker.Client.Support.Dialogs
{
    public partial class AddChipsToTable : Form
    {
        private ViewModel_SelectMoney _vm = null;
        public AddChipsToTable(ViewModel_SelectMoney vm)
        {
            _vm = vm;
            InitializeComponent();
        }

        private void AddChipsToTable_Load(object sender, EventArgs e)
        {
            refresh();
        }
        public void updateModel(ViewModel_SelectMoney vm)
        {
            _vm = vm;
            refresh();
        }
        private void refresh()
        {
            if (_vm != null)
            {
                this.lblTotalMoneyValue.Text = _vm.TotalMoney.ToString();
                this.lblAvailableMoneyValue.Text = _vm.AvailableMoney.ToString();
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this._vm.SelectedMoney = Convert.ToDecimal(this.txtSelectedAmountValue.Text);
        }
        public ViewModel_SelectMoney getModel()
        {
            return _vm;
        }
        
    }
}
