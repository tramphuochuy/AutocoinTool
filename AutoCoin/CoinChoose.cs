using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace AutoCoin
{
    public partial class CoinChoose : Form
    {
        public string usercode ;
        public string CoinSelected = "";
        public DataTable dt = new DataTable();
        public int res = 0;



        public CoinChoose()
        {
            InitializeComponent();
            dgv.AutoGenerateColumns = false;
        }

        private void edtKey_TextChanged(object sender, EventArgs e)
        {
            try
            {


            }
            catch (Exception ex)
            {

            }
        }

        private void CoinChoose_Load(object sender, EventArgs e)
        {
            dt = DStatic.CoinList(usercode);
            dgv.DataSource = dt;
               
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                CoinSelected = DBase.StringReturn(dgv.SelectedRows[0].Cells["COIN"].Value);
                if (CoinSelected != "")
                {
                    res = 1;
                    this.Close();
                }
            }
            catch (Exception ex) { }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void cmsCopyCoins_Click(object sender, EventArgs e)
        {
            try
            {

                
                string URL = DBase.StringReturn(dgv.SelectedRows[0].Cells["URL"].Value);
                Clipboard.SetText(URL);
            }
            catch (Exception ex) { }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

               try
            {

                CoinSelected = DBase.StringReturn(dgv.SelectedRows[0].Cells["COIN"].Value);
                DStatic.CoinDetailDelete(usercode, CoinSelected);
                CoinChoose_Load(null, null);
            }
            catch (Exception ex) { }



         
        }
    }
}
