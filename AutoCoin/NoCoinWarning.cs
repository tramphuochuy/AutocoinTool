using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace AutoCoin
{
    public partial class NoCoinWarning : UserControl
    {
        public NoCoinWarning()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Guide G = new Guide();
            G.Show();
        }
    }
}
