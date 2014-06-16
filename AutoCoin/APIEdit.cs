using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AutoCoin
{
    public partial class APIEdit : Form
    {
        public string API = "";
        public string Usercode = "";
        public string CoinName = "";
        public int res = 0;
        public APIEdit()
        {
            InitializeComponent();
        }

        private void LinkEdit_Load(object sender, EventArgs e)
        {
            edtAPI.Text = API;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           int kq = DStatic.CoinDetailUpdate_API(Usercode, CoinName, edtAPI.Text);
           if (kq > 0)
           {
               res = 1;
               this.Close();

           }
           else DBase.ShowMessage("Cant' update!..",500);
        }
    }
}
