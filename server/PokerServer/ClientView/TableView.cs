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
    public class TableView
    {
        public string GameName {get; set;}
        public string GameValue {get; set;}
        public string TableNo { get; set; }
        public int DealerPosition { get; set; }
       // private List<Tuple<short,string,decimal>> listTable = new List<Tuple<short,string,decimal>>(); // seatno, playername,chipcount
        private List<SeatView> listSeats = new List<SeatView>();
        private Tuple<CardView, CardView, CardView, CardView, CardView> _board;
        public TableView(Table table)
        {
            GameName = table.GameName;
            GameValue = table.GameValue;
            TableNo = table.TableNo;
            DealerPosition = table.DealerPosition;
            foreach (var x in table.Seats)
            {
                //Tuple<short, string, decimal> t = new Tuple<short, string, decimal>(x.Key.SeatNumber,  x.Value.UserName, x.Value.ChipCount);
                //listTable.Add(t);
                SeatView sv = new SeatView(x.Key);
                listSeats.Add(sv);
            }
            // get the board too
            _board = new Tuple<CardView, CardView, CardView, CardView, CardView>(new CardView(table.Flop.Item1), new CardView(table.Flop.Item2), new CardView(table.Flop.Item3), new CardView(table.Turn), new CardView(table.River));


        }
        public Tuple<CardView,CardView, CardView, CardView, CardView> Board
        {
            get
            {
                return _board;
            }
        }
        public List<SeatView> ListOfSeats
        {
            get
            {
                return listSeats;

            }
        }
        public string Serialize()
        {
            String jsonString = JsonConvert.SerializeObject(this);
            return jsonString;
        }
    }
}
