using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Client.Support
{
    public class ViewModel_Seat : BaseViewModel
    {
        public ViewModel_Seat(string UserName)
        {
            base.UserName = UserName;
        }
        public ViewModel_Seat()
        {
         
        }
        public void CopyFrom(ViewModel_Seat seat)
        {
            this.SeatNo = seat.SeatNo;
            this.TableNo = seat.TableNo;
            this.ChipCounts = seat.ChipCounts;
            this.UserName = seat.UserName;
            this.CurrentUserName = seat.CurrentUserName;
            this.Joined = seat.Joined;
            this.IsDealer = seat.IsDealer;
        }
        public string JoinValue
        {
            get
            {
                if (!Joined)
                    return "Join";
                else
                {
                    if (this.UserName == this.CurrentUserName)
                        return "Leave";
                    else
                        return this.ChipCounts.ToString();
                }
            }
        }
        public short SeatNo
        {
            get;set;
        }
        public string TableNo
        {
            get;set;
        }
        public decimal ChipCounts
        {
            get;set;
        }
        public new string UserName
        {
            get;set;
        }
        public  string CurrentUserName
        {
            get; set;
        }
        public Bitmap HoleCard_1
        {
            get;set;
        }
        public Bitmap HoleCard_2
        {
            get;set;
        }
        public bool Joined
        {
            get;set;
        }
        public bool IsDealer
        {
            get;set;
        }

    }
}
