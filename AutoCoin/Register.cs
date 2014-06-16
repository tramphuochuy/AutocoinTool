using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AutoCoin
{
    public partial class Register : Form
    {
        public string Username = "";
        public string password = "";
        public Register()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Username = edtUserCode.Text;
            password = edtPass.Text;
            int kq = DStatic.UserAdd(edtUserCode.Text, edtPass.Text, "LTC");
            if (kq > 0)
            {
                MessageBox.Show("Saved !");
                DStatic.CoinAdd(edtUserCode.Text, "LTC", "stratum+tcp://coinotron.com:3334", "workername", "pass", "https://coinotron.com/coinotron/AccountServlet?action=logon","SCRYPT");
                DStatic.CoinAdd(edtUserCode.Text, "VOOT", "stratum+tcp://opc-stratum.pool.mn:7845", "workername", "pass", "http://voot.pool.mn/index.php?page=login", "X11");
                DStatic.CoinAdd(edtUserCode.Text, "BOST", "stratum+tcp://boost.monsterhash.me:3333 ", "workername", "pass", "http://voot.pool.mn/index.php?page=login", "X13");
             
                this.Close();

            }

            else MessageBox.Show("Can't Add , may be exist username!");
        }
    }
}
