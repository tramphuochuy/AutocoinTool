using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AutoCoin
{
    public partial class APIMonitor : Form
    {
        BackgroundWorker count = new BackgroundWorker();
        string result = "";
        string command = "";
        public APIMonitor()
        {
            InitializeComponent();
            this.count.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_DoWork);
            this.count.WorkerReportsProgress = true;
            this.count.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgw_RunWorkerCompleted);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {

                command = edtCommand.Text;
                    count.RunWorkerAsync();
                

            }
            catch (Exception ex) { }
        }
        //  BGW
        private void bgw_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {

                ApiWorker A = new ApiWorker("127.0.0.1", 4028);
                result = Environment.NewLine + A.Request(command);
               
            }
            catch (Exception x)
            {
                // MessageBox.Show(x.ToString());
            }

        }
        private void bgw_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {

            edtResult.Text = result;
            //MessageBox.Show(result);
        }
        public void dowork(int i)
        {

        }

        private void APIMonitor_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }
    }
}
