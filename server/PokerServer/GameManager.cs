using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Poker.Server
{
    public class GameManager
    {
        private AutoResetEvent event1 = new AutoResetEvent(true);
        private Game _game;
        private Table _table;
        private bool _GameInPogress = false;
        private bool _GameStopFlag = false;
       
        
        public GameManager(Game game, Table table)
        {
            _game = game;
            _table = table;
            _table.TableUpdatedEvent += _table_TableUpdatedEvent;
        }
        public GameManager(Table table)
        {
            _game = new Game(100,500);
            _table = table;
            _table.TableUpdatedEvent += _table_TableUpdatedEvent;
        }

        private void _table_TableUpdatedEvent(Table table)
        {
            Start();
        }
        public void StartStopAsync()
        {
            Task.Run(() =>
            {
                if (!_GameStopFlag)
                    Stop();
                else
                    Start();
            });
        }
        public void Stop()
        {
            _GameStopFlag = true;
        }
        private void Start()
        {
            if (!((_table.SeatedPlayerCount() >= 2) && (!_GameInPogress)))
                return;
               
            if ((_game == null) || (_table == null))
                throw new Exception("Table or Game cannot be null");
            _GameInPogress = true;
            _GameStopFlag = false;

            _table.SetDealerPosition();
            //deal hole cards to seated players
            int playercount = _table.SeatedPlayerCount();
            int gamecount = 10;
            int timespan = 8000; // 10 secs
            while ((gamecount > 0) && (!_GameStopFlag)) // game loop
            {
                gamecount--;
                _game.initialize();
                _table.ResetForGameStart();
               
                // initialize the player , resetting the folded hand state
                // Also consolidate who all players are in the game. Anybody who is not dealt a hole card should not be asked for betting

                _game.SetGameState("Starting");
                MessageFactory.SendGameUpdateMessage(_table); // this is sent to reset the board and holecards of the clients
                MessageFactory.SendTableUpdateMessage(_table);
                Thread.Sleep(5000); // deliberately delay to give client time to process.
                playercount = _table.SeatedPlayerCount();
                while (playercount > 0)
                {
                    Player player = _table.GetNextPlayer();
                    player.AssignDealerButton(0);
                    player.AssignHoleCards(_game.DealPlayerHand());
                    playercount--;
                }
                // do bet collecting round 
                _table.ResetToUTG();
                playercount = _table.PlayingPlayerCount();
                while (playercount > 0)
                {
                    Player player = _table.GetNextPlayer();
                    if (player.InHand)
                    {
                        lock (_table.SynchronizeGame)
                        {
                            MessageFactory.RequestAction(_table, player, "preflop");
                            Monitor.Wait(_table.SynchronizeGame, timespan);
                        }
                    }
                    playercount--;
                }

                // deal the flop 
                Tuple<Card, Card, Card> flop = _game.GetFlop();
                MessageFactory.SendFlop(_table, flop);

                // do bet collecting round

                _table.ResetToSmallBlind();
                playercount = _table.PlayingPlayerCount();
                while (playercount > 0)
                {
                    Player player = _table.GetNextPlayer();
                    if (player.InHand)
                    {
                        lock (_table.SynchronizeGame)
                        {
                            MessageFactory.RequestAction(_table, player, "postflop");
                            Monitor.Wait(_table.SynchronizeGame, timespan);
                        }
                    }
                    playercount--;
                }
                //deal the turn 
                Card turn = _game.GetTurn();
                MessageFactory.SendTurn(_table, turn);

                // do bet collecting round

                _table.ResetToSmallBlind();
                playercount = _table.PlayingPlayerCount();
                while (playercount > 0)
                {
                    Player player = _table.GetNextPlayer();
                    if (player.InHand)
                    {
                        lock (_table.SynchronizeGame)
                        {
                            MessageFactory.RequestAction(_table, player, "postturn");
                            Monitor.Wait(_table.SynchronizeGame, timespan);
                        }
                    }
                    playercount--;
                }

                // deal the river
                Card river = _game.GetRiver();
                MessageFactory.SendRiver(_table, river);

                // do the bet collecting round

                _table.ResetToSmallBlind();
                playercount = _table.PlayingPlayerCount();
                while (playercount > 0)
                {
                    Player player = _table.GetNextPlayer();
                    if (player.InHand)
                    {
                        lock (_table.SynchronizeGame)
                        {
                            MessageFactory.RequestAction(_table, player, "postriver");
                            Monitor.Wait(_table.SynchronizeGame, timespan);
                        }
                    }
                    playercount--;
                }
                // announce the winner
               _game.SetGameState("Ending");
                MessageFactory.SendGameUpdateMessage(_table);
                _GameInPogress = false;
                _table.AdvanceDealerPosition();
            }// end of game loop
        }
    }
}
