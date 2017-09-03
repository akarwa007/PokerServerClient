using Poker.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Client.Support
{
    public class ViewModel_Table : BaseViewModel
    {
        public string GameName {get; set;}
        public string GameValue {get; set;}
        public string TableNo { get; set; }
        public int DealerPosition { get; set; }

        private ViewModel_Card _flop1, _flop2, _flop3, _turn, _river;
        private ViewModel_Card blank = new ViewModel_Card();
        private Tuple<ViewModel_Card, ViewModel_Card, ViewModel_Card, ViewModel_Card, ViewModel_Card> _board;
        // public List<Tuple<short,string,decimal>> listTable = new List<Tuple<short,string,decimal>>(); // seatno, playername,chipcount
        public ViewModel_Table(string UserName, IUserServices service)
        {
            base.UserName = UserName;
            base.UserServices = service;
            _flop1 = new ViewModel_Card();
            _flop2 = new ViewModel_Card();
            _flop3 = new ViewModel_Card();
            _turn = new ViewModel_Card();
            _river = new ViewModel_Card();
            _board = new Tuple<ViewModel_Card, ViewModel_Card, ViewModel_Card, ViewModel_Card, ViewModel_Card>(new ViewModel_Card(), new ViewModel_Card(), new ViewModel_Card(), new ViewModel_Card(), new ViewModel_Card());
;        }
        public ViewModel_Table()
        {
            _flop1 = new ViewModel_Card();
            _flop2 = new ViewModel_Card();
            _flop3 = new ViewModel_Card();
            _turn = new ViewModel_Card();
            _river = new ViewModel_Card();
            _board = new Tuple<ViewModel_Card, ViewModel_Card, ViewModel_Card, ViewModel_Card, ViewModel_Card>(new ViewModel_Card(), new ViewModel_Card(), new ViewModel_Card(), new ViewModel_Card(), new ViewModel_Card());
            ;
        }
        public void CopyFrom(ViewModel_Table vm_table)
        {
            _flop1.CopyFrom(vm_table.Flop1);
            _flop2.CopyFrom(vm_table.Flop2);
            _flop3.CopyFrom(vm_table.Flop3);
            _turn.CopyFrom(vm_table.Turn);
            _river.CopyFrom(vm_table.River);
            _board = vm_table.Board;
            this.UserName = vm_table.UserName;
           //ListOfSeats = vm_table.ListOfSeats; // shouldn't this be a copy too ???
           foreach(var seat in ListOfSeats)
           {
                seat.CopyFrom(vm_table.ListOfSeats.Find(x => x.SeatNo == seat.SeatNo));
           }

        }
        public List<ViewModel_Seat> ListOfSeats
        {
            get;
            set;  
        }
        public Tuple<ViewModel_Card, ViewModel_Card, ViewModel_Card, ViewModel_Card, ViewModel_Card> Board
        {
            get
            {
                return _board;
            }
            set
            {
                _board = value;
            }
        }
        public ViewModel_Card Flop1
        {
            get
            {
                if (Board != null)
                {
                    _flop1.CopyFrom(Board.Item1);
                }
                if (_flop1 == null)
                    return blank;
                return _flop1;
            }
            set
            {
                _flop1 = value;
            }
           
        }
        public ViewModel_Card Flop2
        {
            get
            {
                if (Board != null)
                {
                    _flop2.CopyFrom(Board.Item2);
                }
                if (_flop2 == null)
                    return blank;
                return _flop2;
            }
            set
            {
                _flop2 = value;
            }
        }
        public ViewModel_Card Flop3
        {
            get
            {
                if (Board != null)
                {
                    _flop3.CopyFrom(Board.Item3);
                }
                if (_flop3 == null)
                    return blank;
                return _flop3;
            }
            set
            {
                _flop3 = value;
            }
        }

        public ViewModel_Card Turn
        {
            get
            {
                if (Board != null)
                {
                    _turn.CopyFrom(Board.Item4);
                }
                if (_turn == null)
                    return blank;
                return _turn;
            }
            set
            {
                _turn = value;
            }
        }
        public ViewModel_Card River
        {
            get
            {
                if (Board != null)
                {
                    _river.CopyFrom(Board.Item5);
                }
                if (_river == null)
                    return blank;
                return _river;
            }
            set
            {
                _river = value;
            }
        }
        public ViewModel_Seat get_VM_Seat(short seatno)
        {
            foreach(ViewModel_Seat vm_seat in ListOfSeats)
            {
                if (vm_seat.SeatNo == seatno)
                {
                    vm_seat.CurrentUserName = this.UserName;
                    vm_seat.UserServices = this.UserServices;
                    return vm_seat;
                }
            }
            return null;
        }
        public decimal getSmallBlindAmount()
        {
            decimal amt = 0;
            if ((GameValue != null) && (GameValue != ""))
            {
                amt = Convert.ToDecimal(GameValue.Split('-')[0]);
            }
            return amt;
        }
        public decimal getBigBlindAmount()
        {
            decimal amt = 0;
            if ((GameValue != null) && (GameValue != ""))
            {
                amt = Convert.ToDecimal(GameValue.Split('-')[1]);
            }
            return amt;
        }


    }
}
