using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AutoCoin
{
    public partial class MessageFlow : Form
    {
        public double Speed = 0.1;
        public MessageFlow()
        {
            InitializeComponent();
         
        }

        public MessageFlow(String Content )
        {
            InitializeComponent();
            lbContents.Text = Content;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Opacity = this.Opacity - Speed;
            if (this.Opacity <= 0)
            {
                this.Close();
            }
        }

        private void MessageFlow_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
