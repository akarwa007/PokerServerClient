using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
namespace Poker.Server.ClientView
{
    public class CasinoView
    {
        private List<TableView> _list = new List<TableView>();
        private static CasinoView _instance = new CasinoView();
        private CasinoView()
        {
            refresh();
        }
        private void refresh()
        {
            TableManager t = TableManager.Instance;
            _list.Clear();
            foreach (var x in t.GetRunningTables())
            {
                _list.Add(new TableView((Table)x));
            }
        }
        public static CasinoView Instance
        {
            get
            {
                if (_instance != null)
                    _instance.refresh();
                return _instance;
            }
        }
        public List<TableView> ListOfTables
        {
            get
            {
                return _list;
            }
        }
        public static string Serialize()
        {
            
            String jsonString = JsonConvert.SerializeObject(CasinoView.Instance);
            return jsonString;
        }
    }
}
