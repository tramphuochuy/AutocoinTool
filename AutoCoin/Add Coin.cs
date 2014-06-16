using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AutoCoin
{
    public partial class Add_Coin : Form
    {
        public string usercode = "";
        public int res = 0;
        public string COINNAME = "";

        public string ALGO = "SCRYPT";
        public Add_Coin()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            ALGO = chkX11.Checked == true ? "X11" : ALGO;
            ALGO = chkX13.Checked == true ? "X13" : ALGO;
            ALGO = chkGRO.Checked == true ? "GROESTL" : ALGO;


            string COIN = edtCoin.Text;
            COINNAME = COIN;
            string URL = edtURL.Text;
            string USERNAME = edtUserName.Text;
            string PASS = edtPass.Text;
           int i =   DStatic.CoinAdd(usercode,COIN,URL,USERNAME,PASS,"",ALGO);
           if (i > 0)
           {
               MessageBox.Show("Sucessfuly!");
               res = 1;
               this.Close();
           }

           else
           {
                MessageBox.Show("Save Fail!");
           }
        }

        private void chkSJ4_Click(object sender, EventArgs e)
        {
            CheckBox c = (CheckBox)sender;

            if (chkX11.Name == c.Name)
            {
                chkX13.Checked = chkGRO.Checked = chkVERT.Checked  = false;
            }

            if (chkX13.Name == c.Name)
            {
                chkX11.Checked = chkGRO.Checked = chkVERT.Checked = false;
            }

            if (chkGRO.Name == c.Name)
            {
                chkX13.Checked = chkX11.Checked = chkVERT.Checked  = false;
            }

            if (chkVERT.Name == c.Name)
            {
                chkX13.Checked = chkGRO.Checked = chkX11.Checked = false;
            }

           


        }

    }
}
