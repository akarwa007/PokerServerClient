using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Poker.Shared;

namespace Poker.Server
{
    public class Player
    {
        private static object _synchronize = new object();
        private decimal _chipcount = 0;
        private Tuple<Card, Card> _holecards;
        private bool _playerStillInHand = false;
        public bool _playerplayedingame = false;
        private Table _table;
        private PokerUser _pokeruser;
        public event Action<Player,Poker.Shared.Message> PlayerAction;
        public Player(PokerUser pokeruser, Table table, decimal chipCount)
        {
            _table = table;
            _chipcount = chipCount;
            _pokeruser = pokeruser;
            initialize();
        }
        private void initialize()
        {
            PlayerAction += MessageFactory.SendMessageToPlayer;
        }
      
        public PokerUser PokerUser
        {
            get
            {
                return _pokeruser;
            }
        }
        public string UserName
        {
            get
            {
                return _pokeruser == null ? "Empty" : _pokeruser.UserName;
            }
        }
        public decimal ChipCount
        {
            get
            {
                return _chipcount;
            }
        }
        public string  serialize()
        {
            var string1 = "";
            return string1;
        }
        private void RaiseEvent(Poker.Shared.Message message)
        {
            PlayerAction?.Invoke(this, message);
        }
        public void ResetForGameStart()
        {
            _holecards = null;
            _playerStillInHand = false;

        }
        public void AssignDealerButton(int seatno)
        {
          
            Message message = new Message("DealerButtonPosition", MessageType.DealerButtonPosition);
            message.Content = _table.TableNo + ":";
            message.Content +=  seatno;

            RaiseEvent(message);
        }
        public void AssignHoleCards(Tuple<Card,Card> holecards)
        {
            _holecards = holecards;
            _playerStillInHand = true;
            _playerplayedingame = true;
            //Create the PlayerActionAssignHoleCards message
            Message message = new Message("HoleCards", MessageType.TableSendHoleCards);
            message.Content = _table.TableNo + ":";
            message.Content += holecards.Item1.Rank + ":" + holecards.Item1.Suit + ":" ;
            message.Content += holecards.Item2.Rank + ":" + holecards.Item2.Suit;

            RaiseEvent(message);
        }
        public bool InHand
        {
            get
            {
                return _playerStillInHand;
            }
        }
        public void FoldHand()
        {
            _playerStillInHand = false;
        }
        public void Bet(decimal betamount)
        {
            RemoveMoney(betamount);
        }
        public void AddMoney(decimal money)
        {
            lock (Player._synchronize)
            {
                if (money < 0)
                    throw new Exception("Money cannot be negative");
                this._chipcount += money;
            }
        }
        public void RemoveMoney(decimal money)
        {
            lock (Player._synchronize)
            {
                if (money > this._chipcount)
                    throw new Exception("Money to remove is more than chip count");
                this._chipcount -= money;
            }
        }
        public static bool operator==(Player lhs, Player rhs)
        {
            if (System.Object.ReferenceEquals(lhs, rhs))
                return true;
            if (((object)lhs == null) || ((object)rhs == null))
                return false;
            if ((lhs.UserName == "Empty") || (lhs.UserName == "") || (rhs.UserName == "Empty") || (rhs.UserName == ""))
                return false;
            if (lhs.UserName == rhs.UserName)
                return true;

            return false;
        }
        public static bool operator !=(Player lhs, Player rhs)
        {
            return !(lhs == rhs);
        }
        public override bool Equals(object obj)
        {

            if (obj is Player)
            {

                Player other = (Player)obj;
                if (other.UserName == "Empty")
                    return false;
                if (this.UserName == other.UserName)
                    return true;
            }
            return false;
        }
    }
}
