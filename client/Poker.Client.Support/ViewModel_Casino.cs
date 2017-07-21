using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using Poker.Shared;

namespace Poker.Client.Support
{
    public class ViewModel_Casino  : BaseViewModel
    {
        private List<ViewModel_Table> _list = new List<ViewModel_Table>();
      
        public ViewModel_Casino(string UserName,IUserServices userservices)
        {
            base.UserName = UserName;
            base.UserServices = userservices;
        }
        public ViewModel_Casino()
        {
            
        }
        public void CopyFrom(ViewModel_Casino casino)
        {
            foreach(ViewModel_Table table in casino.ListOfTables)
            {
                var tablex = this.ListOfTables.Find(y => y.TableNo == table.TableNo);
                if (tablex != null)
                {
                    tablex.CopyFrom(table);
                }
                else
                {
                    this.ListOfTables.Add(table);
                }
            }
            this.BankBalance = casino.BankBalance;
            
        }
        public ViewModel_SelectMoney BankBalance
        {
            get;
            set;
        }
        public List<ViewModel_Table> ListOfTables
        {
            get
            {
                return _list;
            }
        }
        public void Replace(ViewModel_Table vm)
        {
            string tableno = vm.TableNo;
            ViewModel_Table toupdate = _list.Find(x => x.TableNo == tableno);
            if (toupdate != null)
            {
                toupdate.CopyFrom(vm);
            }

        }
        public ViewModel_Table GetLatest(ViewModel_Table vm)
        {
            if (vm == null)
                return vm;
            var fresh = _list.Find(x => x.TableNo == vm.TableNo);
            if (fresh != null)
                return fresh;
            return null;
        }
        public ViewModel_Table GetVMTable(string tableno)
        {
            var fresh = _list.Find(x => x.TableNo == tableno);
            if (fresh != null)
                return fresh;
            return null;
        }

    }
}
