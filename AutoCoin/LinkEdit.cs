using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AutoCoin
{
    public partial class LinkEdit : Form
    {
        public string Link = "";
        public string Usercode = "";
        public string CoinName = "";
        public int res = 0;
        public LinkEdit()
        {
            InitializeComponent();
        }

        private void LinkEdit_Load(object sender, EventArgs e)
        {
            edtLink.Text = Link;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           int kq = DStatic.CoinDetailUpdate_Link(Usercode, CoinName, edtLink.Text);
           if (kq > 0)
           {
               res = 1;

               this.Close();

           }
           else DBase.ShowMessage("Cant' update!..",500);
        }
    }
}
