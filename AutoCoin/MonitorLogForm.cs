using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace AutoCoin
{
    public partial class MonitorLogForm : Form
    {
        public string UserCode = "";
        public string Worker = "";

        public MonitorLogForm(string usercode , string worker)
        {
         
            InitializeComponent();
            UserCode = usercode;
            Worker = worker;
        }

        private void MonitorLogForm_Load(object sender, EventArgs e)
        {
            MonitorLog M = new MonitorLog();
            M.Worker = Worker;
            M.UserCode = UserCode;
            this.Controls.Add(M);
           
        }
    }
}
