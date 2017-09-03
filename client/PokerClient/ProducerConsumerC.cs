using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Net.Sockets;
using Poker.Shared;


namespace PokerClient
{
    public class ProducerConsumerC
    {
         object lockIncoming = new object();
         object lockOutgoing = new object();

        Queue<Message> queueIncoming = new Queue<Message>();
        Queue<Message> queueOutgoing = new Queue<Message>();

        MessageProcessor _MP = new MessageProcessor();
        MessageFactory _messageFactory;
        TcpClient _client;
        PokerUserC _pokerUser;
        Thread ProduceIncomingThread;
        Thread ConsumeIncomingThread;
        Thread ConsumeOutgoingThread;

        bool StayConnected = true;

        public ProducerConsumerC(PokerClientContext context)
        {
            _client = context.PokerUser.TcpClient;
            _pokerUser = context.PokerUser;
            _messageFactory = context.MessageFactory;
            init();
        }
        internal void reinit(TcpClient client)
        {
            // if all existing threads are dead then 
            StayConnected = false;
            int maxwait = 10; // 10 secs 
            while (true)
            {
                if ((!ProduceIncomingThread.IsAlive) && (!ConsumeIncomingThread.IsAlive) && (!ConsumeOutgoingThread.IsAlive))
                {
                    init();
                    break;
                }
                Thread.Sleep(1000);
                maxwait--;
                if (maxwait == 0)
                {
                    Console.WriteLine("Something is wrong, unable to abort all client threads, force aborting all threads");
                    ProduceIncomingThread.Abort();
                    ConsumeIncomingThread.Abort();
                    ConsumeOutgoingThread.Abort();

                    break;
                }
            }
            _client = client;
            lockIncoming = new object();
            lockOutgoing = new object();
            StayConnected = true;
            init();
            Thread.Sleep(5000);
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
            //essentially dequeue message from queueOutgoing and write to the networkstream
            NetworkStream ns = client.GetStream();
            StreamWriter sw = new StreamWriter(ns);

            while (client.Connected && StayConnected)
            {
				if (!this._pokerUser.ServerReady)
				{
					Thread.Sleep(50);
					continue;
				}

                lock (lockOutgoing)
                {
                    while (queueOutgoing.Count == 0)
                    {
                        Monitor.Wait(lockOutgoing);
                    }
                    while (queueOutgoing.Count > 0)
                    {
                        Message message = queueOutgoing.Dequeue();
                        message.UserName = this._pokerUser.UserName;
                        try
                        {
                            sw.WriteLine(message.Serialize());
                            sw.Flush();
                            Console.WriteLine("Flushed: " + message.MessageType);
                        }
                        catch (System.IO.IOException e)
                        {
                            // this means socket is closed. 
                            // cleanup_client(client);
                            //_func1(client);
                            client.Close();
                        }
                        catch (Exception e1)
                        {
                            client.Close();
                        }

                    }
                }
            }
        }
        private void func_produceincoming(TcpClient client)
        {
            // essentially read the message from networkstream and produce into the queueIncoming
            NetworkStream ns = client.GetStream();
            StreamReader reader = new StreamReader(ns);

            while (client.Connected & StayConnected)
            {
                try
                {
                    Message _message;
                    //while ((line = reader.ReadLine()) != null)
                    while ((_message = MessageProcessor.Process(reader)) != null)
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

        }
        private void func_consumeincoming(TcpClient client)
        {
            //essentially dequeue from the queueIncoming
            while (client.Connected && StayConnected)
            {
                Message m = ConsumeIncoming();
                _messageFactory.ProcessMessage(m);
            }
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
       
    }
}
