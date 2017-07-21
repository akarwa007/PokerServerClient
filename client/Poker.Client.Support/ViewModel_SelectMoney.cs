using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Client.Support
{
    public class ViewModel_SelectMoney : BaseViewModel
    {
        public ViewModel_SelectMoney()
        {

        }
        public decimal TotalMoney
        {
            get;set;
        }
        public decimal AvailableMoney
        {
            get; set;
        }
        public decimal SelectedMoney
        {
            get; set;
        }
    }
}
