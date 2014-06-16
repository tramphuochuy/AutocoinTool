using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net;
using System.Reflection;

namespace AutoCoin
{
    public partial class Coin : UserControl
    {
        public string CoinName = "";
        public string URL = "";
        public string Link = "";
        public string UserCode = "";
        public string WorkerName = "";
        public string Pass = "";
        public Main M = null;
        public int AutoRestart = 0;
        public int UseAddress = 0;
        public int UseMaxDiff = 0;

    

        public string ALGO = "SCRYPT";

        public decimal MaxDiff = 16;
        public int MaxReject = 20;
        public int MaxSecond = 50;
        public string Remark = "";
        public string API = "";
        public string RootAPI = "";

        public int isSelected = 0;
        public float FlagCredit = 0;
      

        public Coin()
        {
            InitializeComponent();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                ALGO = "SCRYPT";
                AutoRestart = btnRestart.Checked == true ? 1 : 0;
                UseAddress = btnUseAddress.Checked == true ? 1 : 0;
                UseMaxDiff = chkUsemaxdiff.Checked == true ? 1 : 0;

                ALGO = chkX11.Checked == true ? "X11" : ALGO;
                ALGO = chkX13.Checked == true ? "X13" : ALGO;
                ALGO = chkGRO.Checked == true ? "GROESTL" : ALGO;
                ALGO = chkVERT.Checked == true ? "NFACTOR" : ALGO;
                ALGO = chkTALK.Checked == true ? "TALK" : ALGO;

                MaxDiff = DBase.DecimalReturn(edtMaxDiff.Text);
                MaxReject = DBase.IntReturn(edtMaxReject.Value);
                MaxSecond = DBase.IntReturn(edtMaxLastAccept.Value);
                int kq = DStatic.CoinDetailUpdate(UserCode, CoinName, edtURL.Text, edtUsername.Text, edtPassword.Text, AutoRestart, UseAddress, UseMaxDiff, MaxDiff, MaxReject, MaxSecond, 0, 0, 0, 0, ALGO);
                if (kq > 0)
                {
                   DBase.ShowMessage("Saved!",500);

                   ReloadOne();
                }

                else MessageBox.Show("Error !");
            }
            catch (Exception ex) { }


        
        }

        private void Coin_Load(object sender, EventArgs e)
        {
            try
            {
               
   
                btnCheck.Text = CoinName;
                edtURL.Text = URL;
                edtUsername.Text = WorkerName;
                edtPassword.Text = Pass;
                btnRestart.Checked = AutoRestart == 1 ? true : false;
                chkUsemaxdiff.Checked = UseMaxDiff == 1 ? true : false;

                chkX11.Checked = ALGO == "X11" ? true : false;
                chkX13.Checked = ALGO == "X13" ? true : false;
                chkGRO.Checked = ALGO == "GROESTL" ? true : false;
                chkVERT.Checked = ALGO == "NFACTOR" ? true : false;
                chkTALK.Checked = ALGO == "TALK" ? true : false;

                //chkSJ4.Checked = UseSJ4 == 1 ? true : false;

                edtMaxDiff.Text = MaxDiff.ToString();
                edtMaxReject.Value = MaxReject;
                edtMaxLastAccept.Value = MaxSecond;
               
                if (AutoRestart == 1) btnRestart.Checked = true; else btnRestart.Checked = false;
                if (UseAddress == 1) btnUseAddress.Checked = true; else btnUseAddress.Checked = false;

                
                if (Link != "")
                {
                    btnLink.BackColor = Color.LightBlue;
                }
                else btnLink.BackColor = Color.Gray;

                if (isSelected == 1)
                {
                    btnCheck.Checked = true;
                    btnCheck.Font = new System.Drawing.Font(btnCheck.Font.FontFamily, btnCheck.Font.Size, FontStyle.Bold);
                    edtLastPrice.BackColor = edtPassword.BackColor = edtUsername.BackColor = edtURL.BackColor = Color.Honeydew;
                    BorderStyle = BorderStyle.FixedSingle;
                    BackColor = Color.LightSeaGreen;
                }


            }
            catch (Exception ex) { }

            try
            {
                if ( Remark == "")
                {
                    if (ALGO == "SCRYPT") Remark = "Pink";
                    if (ALGO == "X11") Remark = "LightBlue";
                    if (ALGO == "X13") Remark = "LightGreen";
                    if (ALGO == "GROESTL") Remark = "LightGreen";
                    if (ALGO == "NFACTOR") Remark = "LightGreen";
                    if (ALGO == "TALK") Remark = "LightGreen";
                }
                if ( isSelected == 0)
                {
                 panColor.BackColor =  Color.FromName(Remark);
                 //panColor2.BackColor = Color.FromName(Remark);
                 
                 //PanColor3.BackColor = Color.FromName(Remark);
               //  btnCheck.BackColor = Color.FromName(Remark);
                }

            }
            catch (Exception ex) { DBase.ShowMessage(ex.ToString(), 1000); }
        }

        public void ReloadOne()
        {
            try
            {
                DataTable dt = DStatic.CoinList_One(UserCode, CoinName);
                DataRow dr = dt.Rows[0];
                CoinName = DBase.StringReturn(dr["COIN"]);
                WorkerName = DBase.StringReturn(dr["USERNAME"]);
                Link = DBase.StringReturn(dr["LINK"]);
                Pass = DBase.StringReturn(dr["PASSWORD"]);
                AutoRestart = DBase.IntReturn(dr["AUTORESTART"]);
                UseMaxDiff = DBase.IntReturn(dr["USEMAXDIFF"]);

                ALGO = DBase.StringReturn(dr["ALGO"]);

                UseAddress = DBase.IntReturn(dr["USEADDRESS"]);
                URL = DBase.StringReturn(dr["URL"]);
                MaxDiff = DBase.DecimalReturn(dr["MAXDIFF"]);
                MaxReject = DBase.IntReturn(dr["MAXREJECT"]);
                MaxSecond = DBase.IntReturn(dr["MAXSECOND"]);
                Remark = DBase.StringReturn(dr["REMARK"]);
                API = DBase.StringReturn(dr["API"]);
                FlagCredit = DBase.FloatReturn(dr["FLAGCREDIT"]);
            }
            catch (Exception ex) { 
             //   MessageBox.Show(ex.ToString());
            }

            Coin_Load(null, null);
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            try
            {

                if (MessageBox.Show("Change Coin ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                {
                    M.Startup = 0;
                    DStatic.CoinSelectUpdate(UserCode, btnCheck.Text);
                    M.btnStart.PerformClick();
                }
                else
                {

                   
                }
            }
            catch (Exception ex) { }
          
        }

        private void DELETE(object sender, EventArgs e)
        {
            if (MessageBox.Show("Delete ?","", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                int kq = DStatic.CoinDetailDelete(UserCode, CoinName);
                if (kq > 0)
                {
                    DBase.ShowMessage("Deleted! , Refresh to clear deleted Coin! ", 700);
                    edtURL.Visible = edtUsername.Visible = edtPassword.Visible = false;
                    
                }

                else MessageBox.Show("Error !");
            }

           
        }

        private void RUNTEST(object sender, EventArgs e)
        {
            try
            {
                foreach (Process p in Process.GetProcesses())
                {

                    string processname = p.ProcessName;
                    if (processname == "cmd")
                    {
                        try
                        {
                            p.Kill();
                        }
                        catch (Exception ex)
                        { //MessageBox.Show(ex.ToString()); 
                        }
                    }

                }

                foreach (Process P in Process.GetProcesses())
                {

                    if (P.ProcessName.ToString().ToLower() == M.excuteDevice)
                    {
                        P.Kill();
                    }

                }
                M.TestOnly(CoinName);
            }
            catch (Exception ex) { }
        }

        private void LINK(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(Link);
            }
            catch (Exception ex) { }
        }

        private void EditLink(object sender, EventArgs e)
        {
            try
            {
                LinkEdit L = new LinkEdit();
                L.Link = Link;
                L.Usercode = UserCode;
                L.CoinName = CoinName;
                L.ShowDialog();
                if (L.res == 1) M.LoadCoins();
            }
            catch (Exception ex) { };
          
        }

        private void RemarkColor_Click(object sender, EventArgs e)
        {
            try
            {
                ToolStripMenuItem T = (ToolStripMenuItem)sender;
                string text = T.Text;
                Remark = text;
                int i = DStatic.CoinDetailUpdate_Remark(UserCode,CoinName,T.Text);
            }
            catch (Exception ex) { }

            Coin_Load(null, null);
        }

        private void EDIT_API(object sender, EventArgs e)
        {
            try
            {
                APIEdit L = new APIEdit();
                L.API = API;
                L.Usercode = UserCode;
                L.CoinName = CoinName;
                L.ShowDialog();
                if (L.res == 1) M.LoadCoins();
            }
            catch (Exception ex) { };
        }

        private void chkSJ4_Click(object sender, EventArgs e)
        {
            CheckBox c = (CheckBox)sender;

            if (chkX11.Name == c.Name)
            {
                chkX13.Checked = chkGRO.Checked = chkVERT.Checked = chkTALK.Checked = false;
            }

            if (chkX13.Name == c.Name)
            {
                chkX11.Checked = chkGRO.Checked = chkVERT.Checked = chkTALK.Checked = false;
            }

            if (chkGRO.Name == c.Name)
            {
                chkX13.Checked = chkX11.Checked = chkVERT.Checked = chkTALK.Checked = false;
            }

            if (chkVERT.Name == c.Name)
            {
                chkX13.Checked = chkGRO.Checked = chkX11.Checked = chkTALK.Checked = false;
            }

            if (chkTALK.Name == c.Name)
            {
               chkX11.Checked=  chkX13.Checked = chkGRO.Checked = chkVERT.Checked = false;
            }


        }

    }
}
