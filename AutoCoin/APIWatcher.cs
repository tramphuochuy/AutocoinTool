using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AutoCoin
{
    public partial class APIWatcher : Form
    {
        BackgroundWorker BG = new BackgroundWorker();
        public int Running = 0;
        public APIWatcher()
        {
            InitializeComponent();
            this.BG.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_DoWork);
            this.BG.WorkerReportsProgress = true;
            this.BG.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgw_RunWorkerCompleted);
            
        }

        private void APIWatcher_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Running == 0)
            {

                BG.RunWorkerAsync();
            }
        }

       


         private void bgw_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                try
                {
                    DStatic.DownloadString("https://www.nicehash.com/api?method=stats.global.current");
                }
                catch (Exception ex) { }

            }
            catch (Exception x)
            {
              
            }

        }
         private void bgw_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
         {

         }
    }
}
