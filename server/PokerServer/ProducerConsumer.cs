using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Net.Sockets;
using Poker.Shared;
using Poker.Common;


namespace Poker.Server
{
    public class ProducerConsumer
    {
        readonly object lockIncoming = new object();
        readonly object lockOutgoing = new object();
        // readonly object lockConsumeIncoming = new object();

        Queue<Message> queueIncoming = new Queue<Message>();
        Queue<Message> queueOutgoing = new Queue<Message>();

        MessageProcessor _MP = new MessageProcessor();
        
        TcpClient _client;
        PokerUser _pokerUser;
        Thread ProduceIncomingThread;
        Thread ConsumeIncomingThread;
        Thread ConsumeOutgoingThread;

        public RecieveMessageDelegate ReceieveMessageHandler = null; // probably needs a property
        
        //private Action<String> _funcStream;
        public ProducerConsumer(TcpClient client, PokerUser user)
        {
            _client = client;
            _pokerUser = user;
            init();
        }
        private void init()
        {
           
            ProduceIncomingThread = new Thread(
               () => func_produceincoming(_client));

            ProduceIncomingThread.Name = "ProduceIncomingThread";
            ProduceIncomingThread.Start();

            ConsumeIncomingThread = new Thread(
            () => func_consumeincoming(_client));

            ConsumeIncomingThread.Name = "ConsumeIncomingThread";
            ConsumeIncomingThread.Start();

            ConsumeOutgoingThread = new Thread(
              () => func_consumeoutgoing(_client));

            ConsumeOutgoingThread.Name = "ConsumeOutgoingThread";
            ConsumeOutgoingThread.Start();
        }
        private void func_consumeoutgoing(TcpClient client)
        {
            Console.WriteLine("Started with func_consumeoutgoing");
            //essentially dequeue message from queueOutgoing and write to the networkstream
            NetworkStream ns = client.GetStream();
            StreamWriter sw = new StreamWriter(ns);
           
            while (client.Connected)
            {
                lock (lockOutgoing)
                {
                    while (queueOutgoing.Count == 0)
                    {
                        Monitor.Wait(lockOutgoing);
                    }
                    while (queueOutgoing.Count > 0)
                    {
                        Message message = queueOutgoing.Dequeue();
                        try
                        {
                            sw.WriteLine(message.Serialize());
                            sw.Flush();
                            //Console.WriteLine(message.MessageType + ": sent to " + this._pokerUser.UserName);
                            log(message);
                        }
                        catch (System.IO.IOException e)
                        {
                            // this means socket is closed. 
                            // cleanup_client(client);
                            //_func1(client);
                            client.Close();
                        }
                        catch(Exception e1)
                        {
                            client.Close();
                        }

                    }
                }
            }
            Console.WriteLine("Finished with func_consumeoutgoing");
        }
        private void func_produceincoming(TcpClient client)
        {
            Console.WriteLine("Started with func_produceincoming");
            // essentially read the message from networkstream and produce into the queueIncoming
            NetworkStream ns = client.GetStream();
            StreamReader reader = new StreamReader(ns);
           
            while (client.Connected)
            {
                try
                {
                    Message _message;
                    //while ((line = reader.ReadLine()) != null)
                    while ((_message = _MP.Process(reader)) != null)
                    {
                        // Console.WriteLine(line);
                        if (_message == null)
                        {
                            // client has disconnected.
                            client.Close();
                            // cleanup_client(client);
                      
                            break;
                        }
                        ProduceIncoming(_message);
                    
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            Console.WriteLine("Finished with func_produceincoming");
        }
        private void func_consumeincoming(TcpClient client)
        {
            Console.WriteLine("Started with func_consumeincoming");
            //essentially dequeue from the queueIncoming
            while (client.Connected)
            {
                Message m = ConsumeIncoming();
                m.UserName = this._pokerUser.UserName;
             
                // fire all callbacks waiting on these messages.
                if (ReceieveMessageHandler != null)
                {
                    ReceieveMessageHandler.Invoke(m);
                    Console.WriteLine(m.MessageType + ": received from  " + this._pokerUser.UserName);
                }
            
            }
            Console.WriteLine("Finished with func_consumeincoming");
        }
    
        public void ProduceIncoming(Message o)
        {
            lock (lockIncoming)
            {
                queueIncoming.Enqueue(o);

                // We always need to pulse, even if the queue wasn't
                // empty before. Otherwise, if we add several items
                // in quick succession, we may only pulse once, waking
                // a single thread up, even if there are multiple threads
                // waiting for items.            
                Monitor.PulseAll(lockIncoming);
            }
        }
        public void ProduceOutgoing(Message o)
        {
            lock (lockOutgoing)
            {
                queueOutgoing.Enqueue(o);

                // We always need to pulse, even if the queue wasn't
                // empty before. Otherwise, if we add several items
                // in quick succession, we may only pulse once, waking
                // a single thread up, even if there are multiple threads
                // waiting for items.            
                Monitor.PulseAll(lockOutgoing);
            }
        }

        public Message ConsumeIncoming()
        {
            lock (lockIncoming)
            {
                // If the queue is empty, wait for an item to be added
                // Note that this is a while loop, as we may be pulsed
                // but not wake up before another thread has come in and
                // consumed the newly added object. In that case, we'll
                // have to wait for another pulse.
                while (queueIncoming.Count == 0)
                {
                    // This releases listLock, only reacquiring it
                    // after being woken up by a call to Pulse
                    Monitor.Wait(lockIncoming);
                }
                return queueIncoming.Dequeue();
            }
        }
        public Message ConsumeOutgoing()
        {
            lock (lockOutgoing)
            {
                // If the queue is empty, wait for an item to be added
                // Note that this is a while loop, as we may be pulsed
                // but not wake up before another thread has come in and
                // consumed the newly added object. In that case, we'll
                // have to wait for another pulse.
                while (queueOutgoing.Count == 0)
                {
                    // This releases listLock, only reacquiring it
                    // after being woken up by a call to Pulse
                    Monitor.Wait(lockOutgoing);
                }
                return queueOutgoing.Dequeue();
            }
        }
        private void log(Message message)
        {
            if (message.MessageType == MessageType.PlayerActionRequestBet)
                Console.WriteLine(message.MessageType + "--" + this._pokerUser.UserName + "--" + message.Content);
            else
                Console.WriteLine(message.MessageType + " sent to " + this._pokerUser.UserName);
        }
    }
}
