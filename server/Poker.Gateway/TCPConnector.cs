using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Threading;
using System.IO;
using Poker.Shared;
using Poker.Common;

namespace Poker.Gateway
{
    public class TCPConnector
    {
        private bool listen = true;
        TcpListener listener = null;
        private object  lock_for_pokerusercreaion = new object();

        private MessageProcessor _MP = new MessageProcessor();
        
        private Action<Message> _funcStream;
        private Action<TcpClient> _func1;
        private createpokeruser_callback _callback_createpokeruser;

        public TCPConnector(Action<Message> func, Action<TcpClient> func1 ,  createpokeruser_callback callback1)
        {
            _funcStream = func;
            _func1 = func1;
            _callback_createpokeruser = callback1;
        }
        public void start()
        {
            Thread t = new Thread(startasync);
            t.Start();
        }
        public void stop()
        {
            this.listen = false;
            // Do a dummy connection to the listener to unblock it. 
            TcpClient client = new TcpClient("localhost", 8113);

        }
        public void cleanup_client(TcpClient client)
        {
            
        }
      
        private void startasync()
        {
            System.Net.IPAddress ipAddress = System.Net.IPAddress.Parse("0.0.0.0");
            listener = new TcpListener(ipAddress,8113);
            listener.Start(100);
            _funcStream(new Message("Server Started Successfully",MessageType.GeneralPurpose));
            while (listen)
            {
                TcpClient client = listener.AcceptTcpClient();
                
                forknewthread(client);
                Console.WriteLine("client connected");
            }
            if (listener != null)
                listener.Stop();
            _funcStream(new Message("Stopping the listening",MessageType.GeneralPurpose));
            Console.WriteLine("Stopping the listening");
        }
        private void forknewthread(TcpClient client)
        {
            _funcStream(new Message("Incoming new client request", MessageType.GeneralPurpose));

            //create a pokeruser 
            lock (lock_for_pokerusercreaion)
            {
                _callback_createpokeruser(client, _funcStream, "", "");
            }
        }
        
    }
}
