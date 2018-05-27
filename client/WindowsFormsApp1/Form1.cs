using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Poker.Client.Support.ViewModel_BetCollection vm = new Poker.Client.Support.ViewModel_BetCollection();
            ManualResetEvent threadsync = new ManualResetEvent(false);

            // this.Controls.Remove(betctrl);
            Task.Factory.StartNew(() =>
            {
                this.Invoke((MethodInvoker)delegate
                {
                    Poker.Client.Support.Dialogs.BetCollectorControl betctrl = new Poker.Client.Support.Dialogs.BetCollectorControl(vm, threadsync);
                    this.Controls.Add(betctrl);
                });
                threadsync.WaitOne();
                Console.WriteLine("Done 123");
            }
            );
            Console.WriteLine("Done");
        }
    }
}
