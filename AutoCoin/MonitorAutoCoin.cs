using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace AutoCoin
{
    public partial class MonitorAutoCoin : Form
    {

        public double Speed = 0.07;
        public int isClose = 0;
        int OnTop = 1;
        int On = 0;

        public MonitorAutoCoin()
        {
            InitializeComponent();
         
        }

        private void MonitorAutoCoin_Load(object sender, EventArgs e)
        {
            timer1.Start();
            if (On == 1)
            {
                M.usercode = "tramphuochuy";
                M.ContextMenuStrip = null;
                M.dgv.ContextMenuStrip = null;
                this.TopMost = OnTop == 1 ? true : false;
                notifyIcon1.Visible = true;
                M.panel1.Height = 0;
                M.panFoot.Height = 0;

                foreach (DataGridViewColumn C in M.dgv.Columns)
                {
                    C.Visible = false;
                    if (C.HeaderText == "Coin" | C.HeaderText == "Accepts" | C.HeaderText == "Workers" | C.HeaderText == "Time" | C.HeaderText == "Temp" | C.HeaderText == "Teamviewer" | C.HeaderText == "IP")
                    {
                        C.Visible = true;
                    }
                }

                M.isEnableAPI = 0;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            CheckProcess_RunIfNoExist();
            CheckProcess_StopIfNotResponding();
        }

        private void Opacity_Click(object sender, EventArgs e)
        {
            try
            {
                ToolStripMenuItem T = (ToolStripMenuItem)sender;
                double opacity = DBase.DoubleReturn(T.Text)/100;
                this.Opacity = opacity;
            }
            catch (Exception ex)
            {
            }
        }

        Point mouseDownPoint = new Point();
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDownPoint = new Point(e.X, e.Y);
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDownPoint = Point.Empty;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDownPoint.IsEmpty)
                return;
            Form f = sender as Form;
            f.Location = new Point(f.Location.X + (e.X - mouseDownPoint.X), f.Location.Y + (e.Y - mouseDownPoint.Y));
        }

        private void alwaysOnTopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OnTop = OnTop == 1 ? 0 : 1;

            this.TopMost = OnTop == 1 ? true : false;
        }


        //Notify
        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.Show();
                this.Activate();
                this.WindowState = FormWindowState.Normal;
            }

            else if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {

            }
        }

        private void MonitorAutoCoin_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (isClose == 0)
            //{
            //    this.WindowState = FormWindowState.Minimized;
            //    e.Cancel = true;
            //}
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isClose = 1;
            this.Close();
        }

        private void AUTOCOIN(object sender, EventArgs e)
        {
          
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closeToolStripMenuItem_Click(null, null);
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            timer1.Stop();
        }

        private void contextMenuStrip1_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            timer1.Start();

        }


        //Monitor
        public void CheckProcess_RunIfNoExist()
        {
            try
            {
                Process[] P = Process.GetProcesses();
                int kq = 0;
                foreach (Process p in P)
                {
                    string pname = p.ProcessName;
                    if (pname.ToUpper() == "AUTOCOIN")
                    {
                        kq++;
                    }
                }

                
                System.Diagnostics.Process.Start("Autocoin.exe");

               




            }
            catch (Exception ex) { }
        }

        public void CheckProcess_StopIfNotResponding()
        {
            try
            {
                Process[] P = Process.GetProcesses();
                int kq = 0;
                foreach (Process p in P)
                {
                    string pname = p.ProcessName;
                    if ((pname.ToUpper() == "AUTOCOIN"  && p.Responding == false) )
                    {
                        p.Kill();
                    }
                }
            }
            catch (Exception ex) { }

        }

        private void enableMonitorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            On = On == 1 ? 0 : 1;
            if (On == 1)
            {
                MonitorAutoCoin_Load(null, null);
            }

            M.Dispose();
          
        }
    }
}
