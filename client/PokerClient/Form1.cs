using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace PokerClient
{
    public partial class Form1 : Form
    {
        Dictionary<TcpClient, Queue<string>> _read_to_send_queue = new Dictionary<TcpClient, Queue<string>>();
        private object _locker_queue = new object();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TcpClient client = new TcpClient("localhost",8113);
           // client.Connect("localhost",8113);
            if (client.Connected)
              forknewthread(this.textBox1,client);
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            TcpClient client = new TcpClient("localhost",8113);
           // client.Connect("localhost",8113);
            if (client.Connected)
              forknewthread(this.textBox2,client);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            TcpClient client = new TcpClient("localhost",8113);
           // client.Connect("localhost",8113);
            if (client.Connected)
              forknewthread(this.textBox3,client);
        
        }
         private void forknewthread(TextBox txtbox , TcpClient client)
        {
            Thread readerthread = new Thread(
               () => func_reader(txtbox,client));
           
            readerthread.Start();

            Thread writerthread = new Thread(
              () => func_writer(txtbox,client));
          
            writerthread.Start();
        }
      
        private void func_reader(TextBox txtbox ,TcpClient client)
        {
            NetworkStream ns = client.GetStream();
            StreamReader sr = new StreamReader(ns);
            while (client.Connected)
            {
                String message = sr.ReadToEnd();
                AppendTextBox(this.textBox1,message);
               
            }

        }
        public void AppendTextBox(TextBox txtbox ,    string value)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<TextBox,string>(AppendTextBox), new object[] {txtbox,value});
                return;
            }
            txtbox.Text += value;
        }
        private void func_writer(TextBox txtbox , TcpClient client)
        {
            NetworkStream ns = client.GetStream();
            StreamWriter sw = new StreamWriter(ns);
            Queue<string> _queue = null;
            lock (_locker_queue)
            {
                if (!_read_to_send_queue.ContainsKey(client))
                {
                    _queue = new Queue<string>();
                    _read_to_send_queue.Add(client, _queue);
                }
                else
                {
                    _queue = _read_to_send_queue[client];
                }
            }
            while (client.Connected)
            {
                lock (_queue)
                {
                    while (_queue.Count == 0)
                    {
                        Monitor.Wait(_queue);
                    }
                    while (_queue.Count > 0)
                    {
                        string message = _queue.Dequeue();
                        //message += Environment.NewLine;
                        sw.WriteLine(message);
                        sw.Flush();
                       // sw.Write(message);
                    }
                }
            }

           
        }

        private void btnSubmit1_Click(object sender, EventArgs e)
        {
           
           Queue<string> queue =  _read_to_send_queue.ElementAt(0).Value;
           lock (queue)
           {
               queue.Enqueue(this.textBox1.Text);
               Monitor.PulseAll(queue);
           }
               
           
        }

        private void btbSubmit2_Click(object sender, EventArgs e)
        {
            lock (_locker_queue)
            {
                Queue<string> queue = _read_to_send_queue.ElementAt(1).Value;
                queue.Enqueue(this.textBox2.Text);
            }
        }

        private void btnSubmit3_Click(object sender, EventArgs e)
        {
            lock (_locker_queue)
            {
                Queue<string> queue = _read_to_send_queue.ElementAt(2).Value;
                queue.Enqueue(this.textBox3.Text);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

      

      
    
    }
}
