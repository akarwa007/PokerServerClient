using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Server
{
    public  class TableManager : ITableList
    {
        private static TableManager _instance = new TableManager();
        //private List<ITable> _tables = new List<ITable>();
        private ObservableCollection<Table> _tables = new ObservableCollection<Table>();
        private Dictionary<string, Table> _tableDict = new Dictionary<string, Table>();
        private TableManager()
        {
            _tables.CollectionChanged += _tables_CollectionChanged;
           
        }

        private void _tables_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                foreach(Table t in e.NewItems)
                {
                    _tableDict[t.TableNo] = t;
                }
            }
        }
        public Table GetTable(string TableNo)
        {
            if (_tableDict.ContainsKey(TableNo))
                return _tableDict[TableNo];
            return null;
        }
        public static TableManager Instance
        {
            get
            {
                return _instance;
            }
        }
        public void CreateTable(short capacity)
        {
            Table t = new Table(10, "Texas Holdem", "No Limit", "2-5", 200, 500,MessageFactory.SendTableUpdateMessage);
           _tables.Add(t);
            
            _tables.Add(new Table(10, "Texas Holdem", "Limit", "1-2", 200, 500, MessageFactory.SendTableUpdateMessage));
            _tables.Add(new Table(10, "Texas Holdem", "Limit", "3-6", 200, 500, MessageFactory.SendTableUpdateMessage));
            _tables.Add(new Table(10, "Texas Holdem", "Limit", "4-8", 200, 500, MessageFactory.SendTableUpdateMessage));
            _tables.Add(new Table(10, "Omaha", "Hi Low", "1-2", 200, 500, MessageFactory.SendTableUpdateMessage));
            _tables.Add(new Table(10, "Omaha", "Hi Low", "2-5", 200, 500, MessageFactory.SendTableUpdateMessage));
            _tables.Add(new Table(10, "Omaha", "Hi Low", "2-5", 200, 500, MessageFactory.SendTableUpdateMessage));
            _tables.Add(new Table(10, "Omaha", "Hi Low", "2-5", 200, 500, MessageFactory.SendTableUpdateMessage));
        }
       public  IEnumerable<ITable> GetRunningTables()
        {
            return _tables;
        }
    }
    public interface ITableList
    {
       // List<ITable> GetRunningTables();
        IEnumerable<ITable> GetRunningTables();
    }
}
