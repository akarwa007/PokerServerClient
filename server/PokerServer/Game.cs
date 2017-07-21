using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Server
{
    public class Game
    {
        private Deck _deck;
      
        private Tuple<Card, Card, Card> _flop;
        private Card _turn;
        private Card _river;
        private Tuple<Card, Card, Card, Card, Card> _board;
        
        private decimal _minStartingChipsPerPlayer;
        private decimal _maxStartingChipsPerPlayer;
        private decimal _potSize = 0;
        private decimal _minCallingbBetSize = 10;  // these are sent to the user when requesting action
        private decimal _maxRaisingBettingSize = -1; // these are sent to the user when requesting action , -1 means its a no limit game and raise can be all of players money on the table

        private string _gameState = "NotStarted"; // valid values "Starting" , "Ended" , "InProgress" , "NotStarted"
        public Game(decimal minChips, decimal maxChips)
        {
            if (minChips < 0)
                throw new Exception("Min chips per person cannot be negative");
            _minStartingChipsPerPlayer = minChips;
            _maxStartingChipsPerPlayer = maxChips;
            initialize();
        }
        public void initialize()
        {
            _deck = Deck.GetShuffledDeck();
            _board = new Tuple<Card, Card, Card, Card, Card>(new Card(), new Card(), new Card(), new Card(), new Card());
            _flop = new Tuple<Card, Card, Card>(new Card(), new Card(), new Card());
            _turn = new Card();
            _river = new Card();
        }
        public   Tuple<Card,Card> DealPlayerHand()
        {
            Card card1 = _deck.GetNext();
            Card card2 = _deck.GetNext();
            Tuple<Card,Card> hand = new Tuple<Card,Card>(card1,card2);
         

            return hand;
        }
        public Tuple<Card, Card, Card> GetFlop()
        {
            if (_flop.Item1.IsCardBlank())
            { 
            // burn a card
            Card burn = _deck.GetNext();
            Card card1 = _deck.GetNext();
            Card card2 = _deck.GetNext();
            Card card3 = _deck.GetNext();

           _flop = new Tuple<Card, Card, Card>(card1, card2, card3);
            
           }
           return _flop;
           
        }

        public Card GetTurn()
        {
            if (_turn.IsCardBlank())
            {
                Card burn = _deck.GetNext();
               _turn = _deck.GetNext();
               
            }
            return _turn;
        }
        public Card GetRiver()
        {
            if (_river.IsCardBlank())
            {
                Card burn = _deck.GetNext();
                _river = _deck.GetNext();
               
                _board = new Tuple<Card, Card, Card, Card, Card>(_flop.Item1, _flop.Item2, _flop.Item3, _turn, _river);
            }
            return _river;
        }
        public Tuple<Card, Card, Card, Card, Card> GetBoard()
        {
            // error checking , cannot call board until the river had been dealt.
            return _board;
        }
        public string GameState()
        {
            return _gameState;
        }
        public void SetGameState(string state)
        {
            _gameState = state;
        }
        public Tuple<Card,Card,Card> Flop
        {
            get
            {
                return _flop;
            }
           
        }
        public Card Turn
        {
            get
            {
                return _turn;
            }

        }
        public Card River
        {
            get
            {
                return _river;
            }

        }
        public decimal AddToPot(decimal amount)
        {
            if (amount < 0)
                throw new Exception("Pot amount cannot be negative");
            _potSize += amount;
            return _potSize;
        }
        public decimal PotSize
        {
            get
            {
                return _potSize;
            }
        }
        public decimal MinCallingBetSize
        {
            get { return _minCallingbBetSize; }
            set { _minCallingbBetSize = value; }
        }
        public decimal MaxRaisingBetSize
        {
            get { return _maxRaisingBettingSize; }
            set { _maxRaisingBettingSize = value; }
        }
    }
}
