using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AutoCoin
{
    public partial class Configions : Form
    {

        public string key = "";
      
        public string usercode ;
        public string CoinSelected = "";
        public DataTable dt = new DataTable();
        public int res = 0;

        public Configions()
        {
            InitializeComponent();
        }


        private void edtKey_TextChanged(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    key = edtKey.Text;
                    DataTable tempTable = new DataTable();

                    this.dgv.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellValueChanged);

                    try
                    {
                        DataRow[] drs = dt.Select("PCID like '%" + key + "%'");

                        if (drs.Count() > 0)
                        {
                            tempTable = drs.CopyToDataTable();
                            dgv.DataSource = tempTable;
                            dgv.AutoResizeRows();

                        }

                        else
                        {
                            dgv.DataSource = new DataTable() ;
                            dgv.AutoResizeRows();

                        }
                    }
                    catch (Exception ex) {  }

                    this.dgv.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellValueChanged);

                }
                catch (Exception ex) { }

            }
            catch (Exception ex)
            {

            }
        }

        private void CONFIGION_Load(object sender, EventArgs e)
        {
            cmsRefresh.PerformClick();
               
        }

        private void cmsCopyCoins_Click(object sender, EventArgs e)
        {
            try
            {


                string URL = DBase.StringReturn(dgv.SelectedCells[0].OwningRow.Cells["URL"].Value);
                Clipboard.SetText(URL);
            }
            catch (Exception ex) { }
        }

        private void cmsDelete_Click(object sender, EventArgs e)
        {
            try
            {

                long ID = DBase.IntReturn(dgv.SelectedCells[0].OwningRow.Cells["ID"].Value);
                int k = DStatic.ConfigDelete(ID);
                if (k > 0) cmsRefresh.PerformClick();
               
            }
            catch (Exception ex) { }

        }

        private void cmsRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                this.dgv.CellValueChanged -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellValueChanged);


                dt = DStatic.ConfigList();
                dgv.DataSource = dt;
                dgv.AutoResizeRows();

                this.dgv.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellValueChanged);

            }
            catch (Exception ex) { }
        }

        private void dgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                long ID = DBase.LongReturn(dgv.Rows[e.RowIndex].Cells["ID"].Value);
                string value = DBase.StringReturn(dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                string FIELD = DBase.StringReturn(dgv.Columns[e.ColumnIndex].DataPropertyName);
                int kq = DStatic.ConfigUpdate(ID, FIELD, value);
                if (kq > 0) DBase.ShowMessage("Saved", 300);
                else DBase.ShowMessage("Cant'...", 300);
            }
            catch (Exception ex)
            { }
        }


    }
}
