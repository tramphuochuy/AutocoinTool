using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Net;
using System.Threading;

namespace AutoCoin
{
    public partial class MonitorPanel : UserControl
    {
        WakeUpOnLan W = new WakeUpOnLan();
        public int isShowAll = 0;
        DataTable dtList = new DataTable();
        public string usercode = "tramphuochuy";
        public decimal TotalHashRate = 0;
        
        public decimal APIHashRate = 0;
        public decimal APICredit = 0;
        public int APITimeFromLastBlock = 0;
        Dictionary<string, List<string>> APIWorkerLists = new Dictionary<string,List<string>>();

        public string APIPercent = "";
        public string APIShareRate = "";
      
        public int PauseTimer = 0;
        public int Freeze = 0;
        public double flagCoin = 0;
        public string Coin = "";
        public DateTime CreditChangeDate = DateTime.Now;
        decimal DiffCredit = 0;

        string API = "";
        string RootAPI = "";
        string FunctionAPI = "";

        public int isEnableAPI = 0;
        public int isEnableAM = 0;

        public int isBusy = 0;
        public int isTestedAPI = 0;

        public string APIRES = "";
        public string APIWORKERS = "";
        public float FlagCredit = 0;
        public Main M = null;

        BackgroundWorker BG = new BackgroundWorker();


        public int playCredit = 0;
        public int playAlarm = 0;

        public MonitorPanel()
        {
            InitializeComponent();
            this.BG.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_DoWork);
            this.BG.WorkerReportsProgress = true;
            this.BG.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgw_RunWorkerCompleted);
        }

        //  BGW
        decimal APICredit2 = 0;
        string APICredit2String = "";
        private void bgw_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                try
                {
                    //if (isTestedAPI == 0)
                    //{
                    //    TestAPI(API);
                    //    isTestedAPI = 1;
                    //}

                    
                    
                    Interval++;

                    //if (Interval % 5 == 0 && playCredit == 1)
                    //{
                    //    DBase.PlayWav("Credit.wav");
                    
                    //    playCredit = 0;
                    //}

                    

                    if (Interval % 3 == 0 && playAlarm == 1)
                    {
                        DBase.PlayWav("Alarm.wav");
                       // DBase.PlayMp3("Alarm.mp3");
                        playAlarm = 0;
                      //  M.TopMost = false;
                    }

               
                    
                  
                    

                    APICredit2 = APICredit;
                    APICredit2String = "";
                    try
                    {
                        if (isShowAll == 1)
                        {
                            dtList = DStatic.MonitorList_All();
                        }
                        else
                        {
                            dtList = DStatic.MonitorList(usercode, Coin);
                        }

                    
                        
                        TotalHashRate = DBase.DecimalReturn(dtList.Compute("Sum(RATE)", string.Empty));
                    }
                    catch (Exception ex) { }

                   
                    try
                    {

                        if ((isEnableAPI == 1 && Interval % 15 == 0 ) | Interval == 2)
                        {
                            try
                            {
                                APIRES = DownloadString(API);
                                String T1 = DBase.StringReturn(DBase.JSONSub(APIRES, "\"hashrate\":"));
                                APIHashRate = DBase.DecimalReturn(T1);
                                String T2 = DBase.StringReturn(DBase.JSONSub(APIRES, "\"Credit\":"));
                                APICredit2 = DBase.ToDecimal(T2, ".", ",") - (decimal)FlagCredit;


                                APIRES = DownloadString(DBase.JSON_FunctionFromAnyAPI(API, "gettimesincelastblock"));
                                APITimeFromLastBlock = DBase.IntReturn(DBase.JSONSub(APIRES, "\"data\":", "}}"));

                              

                                APIRES = DownloadString(DBase.JSON_FunctionFromAnyAPI(API, "getdashboarddata"));
                                APIPercent = DBase.StringReturn(DBase.JSONSub(APIRES, "\"progress\":", "}"));
                                APIShareRate = DBase.StringReturn(DBase.JSONSub(APIRES, "\"sharerate\":\"", "\",\"")); 

                                APIWORKERS = DownloadString(DBase.JSON_FunctionFromAnyAPI(API, "getuserworkers"));



                            }
                            catch (Exception ex)
                            {
                                string s = "";
                            }
                        }

                    }
                    catch (Exception x)
                    {
                       
                        // MessageBox.Show(x.ToString());
                    }



                    
                   
                
                }
                catch (Exception ex) { }

            }
            catch (Exception x)
            {
             //   MessageBox.Show(x.ToString());
            }

        }
        private void bgw_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (isEnableAPI == 1)
                {
                    for (int i = 0; i < dtList.Rows.Count; i++)
                    {
                        try
                        {

                            DataRow dr = dtList.Rows[i];
                            string cWorker = DBase.StringReturn(dr["WORKER"]);
                            string Block = DBase.JSONSub(APIWORKERS, cWorker, "}");

                            String value1 = DBase.JSONSub(Block, "\"hashrate\":", ",");
                            String value2 = DBase.JSONSub(Block, "difficulty\":", true);


                            dtList.Rows[i]["APIDIFF"] = value2;
                            dtList.Rows[i]["APISPEED"] = value1 + " Kh/s";
                            decimal APIHashRate = DBase.DecimalReturn(dtList.Rows[i]["APISPEED"].ToString().Replace(" Kh/s", ""));
                            String T = DBase.StringReturn(dtList.Rows[i]["SPEED"]);
                            decimal HashRate = DBase.DecimalReturn(T.Replace(" KH/s", ""));
                            dtList.Rows[i]["HASHPOWER"] = Math.Round(DBase.DecimalReturn(APIHashRate / HashRate) * 100, 1).ToString() + " %";

                        }
                        catch (Exception ex)
                        {
                            string s = ex.ToString();
                        }
                    }

                } //end if

                

                try
                {
                    int rowindex = dgv.SelectedCells[0].OwningRow.Index;
                    int colindex = dgv.SelectedCells[0].OwningColumn.Index;

                    if (PauseTimer == 0 && Freeze == 0) dgv.DataSource = dtList;
                    dgv.Rows[rowindex].Selected = true;
                    dgv.Columns[colindex].Selected = true;
                }
                catch (Exception ex) { }

                this.Height = panel1.Height + (dgv.Rows.Count * 25) + 28 + panFoot.Height + 10;

                if (isEnableAPI == 1)
                {
                    if (APICredit2 != APICredit && APICredit != 0)
                    {
                        RefreshColor();
                        playCredit = 1;
                        CreditChangeDate = DateTime.Now;
                        DiffCredit = Math.Round(APICredit2 - APICredit, 3);
                        if (APICredit == 0) DiffCredit = 0;
                    }
                    APICredit = APICredit2;

                    if (TotalHashRate > 0)
                    {
                        lbTotalHashRate.Text = APIHashRate.ToString() + " Kh/s ( " + (Math.Round(APIHashRate * 100 / TotalHashRate, 2)).ToString() + "%  x " + TotalHashRate.ToString() + " ) " +  dtList.Rows.Count.ToString();
                    }
                    lbCredit.Text = "Credits : " + Math.Round(APICredit2, 3).ToString() + " Coins " + " | +" + DiffCredit.ToString() + " / " + APITimeFromLastBlock.ToString() + "s" + " | " + APIPercent + "%";
                }
            }
            catch (Exception ex) { }
            finally
            {
                if (isEnableAPI == 0 && !lbTotalHashRate.Text.Contains("API"))
                {
                    //lbTotalHashRate.Text = "API is not available ... " + TotalHashRate.ToString() + " kh/s ( " + dtList.Rows.Count.ToString() + " Pcs )" ;
                    lbTotalHashRate.Text = usercode.ToString() + " - " + TotalHashRate.ToString() + " kh/s ( " + dtList.Rows.Count.ToString() + " Pcs )" ;
                  
                    //APISPEED.DefaultCellStyle.BackColor = Color.LightGray;
                    //APISPEED.DefaultCellStyle.BackColor = Color.LightGray;
                    //HASHPOWER.DefaultCellStyle.BackColor = Color.LightGray;
                    //APIDIFF.DefaultCellStyle.BackColor = Color.LightGray;

                }
                if (PauseTimer == 0 && Freeze == 0) dgv.DataSource = dtList;
               // dgv.AutoResizeColumns();
                isBusy = 0;
            }

        }


        public void RefreshColor()
        {
            C.BackColor = lbTotalHashRate.ForeColor = lbCredit.ForeColor = DBase.RandomColor_Dark();
            C.cmsCurrentColor.Text = C.BackColor.Name.ToString();
        }
        private void MonitorPanel_Load(object sender, EventArgs e)
        {

            if (isEnableAM == 1 && usercode == "tramphuochuy2")
            {
                isShowAll = 1;
            }

            if (isEnableAPI == 1 && usercode =="tramphuochuy2")
            {
                APIDIFF.Visible = APISPEED.Visible = HASHPOWER.Visible = true;
            }
            else
            {
                APIDIFF.Visible = APISPEED.Visible = HASHPOWER.Visible = false;
            }

            timer1.Start();
            edtUsercode.Text = usercode;
            C.ContextMenuStrip = cmsMenu;
            
            C.btnCheck.Checked = true;
            try
            {
                //this.BackColor = lbCredit.BackColor = lbTotalHashRate.BackColor = C.BackColor = panel1.BackColor = panFoot.BackColor =dgv.BackgroundColor = DBase.RandomColor_Dark() ;
              
                dgv.AutoGenerateColumns = false;


                DataTable dtInfo = DStatic.CoinInfo(usercode);
                
              
                
                Coin = DBase.StringReturn(dtInfo.Rows[0]["COIN"]);
                DataTable dtDetail = DStatic.CoinInfo_DetailConfig(usercode, Coin);
              
                C.UserCode = usercode;
                C.CoinName = Coin;
                C.ReloadOne();
                C.cmsCurrentColor.Text = C.BackColor.Name.ToString();
                FlagCredit = C.FlagCredit;
               
                API = DBase.StringReturn(dtDetail.Rows[0]["API"]);

                
                dtList = DStatic.MonitorList(usercode, Coin);

                if (isShowAll == 1) dtList = DStatic.MonitorList_All();


                

                dgv.DataSource = dtList;

                lbTotalHashRate.Text = usercode.ToString() + " - " + TotalHashRate.ToString() + " kh/s ( " + dtList.Rows.Count.ToString() + " Pcs )";
                  
                this.Height = panel1.Height + (dgv.Rows.Count * 25) + 28 + panFoot.Height + 10;


            }
            catch (Exception ex) { }

            RefreshColor();
            dgv.AutoResizeColumns();

            try
            {
                lbTotalHashRate.Text = APIHashRate.ToString() + " Kh/s ( " + (Math.Round(APIHashRate * 100 / TotalHashRate, 2)).ToString() + "%  x " + TotalHashRate.ToString() + " ) " + dtList.Rows.Count.ToString();
            }
            catch (Exception ex)
            {

            }

            this.dgv.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellValueChanged);
            
        }

        int Interval = 0;

        private void Tick(object sender, EventArgs e)
        {
            edtUsercode.Text = usercode + " [" + (isEnableAPI==1?"ON":"OFF" ) +"]";
            try
            {
                if (isBusy == 1)
                {
                    
                    return;
                }
                isBusy = 1;
                BG.RunWorkerAsync();
            }
            catch (Exception ex) { }
           
        }

        private void dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

            try
            {
                if (dgv.Columns[e.ColumnIndex].DataPropertyName == "WORKER_SUBIFX")
                {
                    e.CellStyle.BackColor = Color.HotPink;
                    e.CellStyle.Font = new Font(e.CellStyle.Font.FontFamily, 13, FontStyle.Bold);
                }
            }
            catch (Exception ex) { }

            try
            {
                if (dgv.Columns[e.ColumnIndex].DataPropertyName == "GPUSTATS")
                {
                    
                    string value = DBase.StringReturn(dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                    string[] sa = value.ToString().Split(',');
                    int MaxTemp = DBase.IntReturn(sa[0]);
                    foreach (string s in sa)
                    {
                        if (DBase.IntReturn(s) > MaxTemp)
                        {
                            MaxTemp = DBase.IntReturn(s);
                        }
                    }

                    if (MaxTemp <=65)
                    {

                        e.CellStyle.BackColor = Color.Green;

                    }

                    else if (MaxTemp > 65 && MaxTemp < 75)
                    {
                        e.CellStyle.BackColor = Color.LightGreen;
                    }

                    else if (MaxTemp >= 75 && MaxTemp < 80)
                    {
                        
                        e.CellStyle.BackColor = Color.Yellow;

                    }

                    else if (MaxTemp >= 80 && MaxTemp < 85)
                    {
                        e.CellStyle.BackColor = Color.Pink;

                    }

                    else if (MaxTemp >= 85 && MaxTemp < 90)
                    {
                        e.CellStyle.BackColor = Color.Tomato;

                    }

                    else if (MaxTemp >= 90)
                    {
                        e.CellStyle.BackColor = Color.Red;

                    }

                   

                }
            }
            catch (Exception ex) { }


            try
            {
                if (dgv.Columns[e.ColumnIndex].DataPropertyName == "SPEED")
                {
                    int value = DBase.IntReturn(dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Split(' ')[0]);
                    if (value == 0)
                    {

                        e.CellStyle.BackColor = Color.LightYellow;

                    }

                    else if (value > 0 && value < 1000)
                    {
                        e.CellStyle.BackColor = Color.LavenderBlush;

                    }
                    else if (value >= 1000 && value < 1400)
                    {
                        e.CellStyle.BackColor = Color.Honeydew;

                    }

                    else if (value >= 1400 && value < 1600)
                    {
                        e.CellStyle.BackColor = Color.LightGreen;

                    }
                    
                    else if (value >= 1600 && value < 2000)
                    {
                        e.CellStyle.BackColor = Color.PowderBlue;

                    }

                    else if (value >= 2000 && value < 2600)
                    {
                        e.CellStyle.BackColor = Color.HotPink;
                        e.CellStyle.Font = new Font(e.CellStyle.Font.FontFamily, 9, FontStyle.Bold);

                    }

                    else if (value >= 2600 && value <= 3000)
                    {
                        e.CellStyle.BackColor = Color.Orange;
                        e.CellStyle.Font = new Font(e.CellStyle.Font.FontFamily, 9, FontStyle.Bold);

                    }
                    else if (value >= 3000 && value < 6000)
                    {
                        e.CellStyle.BackColor = Color.DarkOrange;
                        e.CellStyle.Font = new Font(e.CellStyle.Font.FontFamily, 12, FontStyle.Bold);

                    }

                    else if (value >= 6000 && value < 7000)
                    {
                        e.CellStyle.BackColor = Color.DarkOliveGreen;
                        e.CellStyle.Font = new Font(e.CellStyle.Font.FontFamily, 12, FontStyle.Bold);

                    }

                    else if (value >= 7000 && value < 8800)
                    {
                        e.CellStyle.BackColor = Color.PowderBlue;
                        e.CellStyle.Font = new Font(e.CellStyle.Font.FontFamily, 12, FontStyle.Bold);

                    }

                    else if (value >= 8800 && value < 11000)
                    {
                        e.CellStyle.BackColor = Color.HotPink;
                        e.CellStyle.Font = new Font(e.CellStyle.Font.FontFamily, 12, FontStyle.Bold);

                    }

                    else if (value >= 11000 && value < 14500)
                    {
                        e.CellStyle.BackColor = Color.Orange;
                        e.CellStyle.Font = new Font(e.CellStyle.Font.FontFamily, 12, FontStyle.Bold);

                    }

                    else if (value >= 14500 && value < 17500)
                    {
                        e.CellStyle.BackColor = Color.DarkMagenta;
                        e.CellStyle.Font = new Font(e.CellStyle.Font.FontFamily, 12, FontStyle.Bold);

                    }

                    else if (value >= 17500)
                    {
                        e.CellStyle.BackColor = Color.Maroon;
                        e.CellStyle.Font = new Font(e.CellStyle.Font.FontFamily, 12, FontStyle.Bold);

                    }

                }
            }
            catch (Exception ex) { }

            try
            {
                if (dgv.Columns[e.ColumnIndex].DataPropertyName == "APISPEED")
                {
                    int value = DBase.IntReturn(dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Split(' ')[0]);
                    if (value == 0)
                    {

                        

                    }

                    else if (value > 0 && value < 1000)
                    {
                        e.CellStyle.BackColor = Color.LightYellow;

                    }
                    else if (value >= 1000 && value < 1500)
                    {
                        e.CellStyle.BackColor = Color.LightYellow;

                    }

                    else if (value >= 1500 && value < 3000)
                    {
                        e.CellStyle.BackColor = Color.LightYellow;

                    }

                    else if (value >= 3000 && value < 6000 )
                    {
                        e.CellStyle.BackColor = Color.Honeydew;
                        

                    }

                    else if (value >= 6000 && value < 9000)
                    {
                        e.CellStyle.BackColor = Color.LightGreen;

                    }

                        else if (value >= 9000 && value < 15000)
                    {
                        e.CellStyle.BackColor = Color.LightGreen;

                    }
                    else if (value >= 15000 && value < 20000)
                    {
                        e.CellStyle.BackColor = Color.PowderBlue;

                    }
                    else if (value >= 15000 && value < 20000)
                    {
                        e.CellStyle.BackColor = Color.Pink;

                    }

                    else if (value >= 20000 && value < 30000)
                    {
                        e.CellStyle.BackColor = Color.HotPink;

                    }

                    else if (value >= 30000 && value < 40000)
                    {
                        e.CellStyle.BackColor = Color.Orange;
                        e.CellStyle.Font = new Font(e.CellStyle.Font.FontFamily, 10, FontStyle.Bold);
                    }

                    else if (  value >= 40000)
                    {
                        e.CellStyle.BackColor = Color.OrangeRed;
                        e.CellStyle.Font = new Font(e.CellStyle.Font.FontFamily, 11, FontStyle.Bold);

                    }


                }
            }
            catch (Exception ex) { }


            try
            {
                if (dgv.Columns[e.ColumnIndex].DataPropertyName == "ACCEPTS")
                {
                    int value = DBase.IntReturn(dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                    if (value == 0)
                    {
                        
                        e.CellStyle.BackColor = Color.LightYellow;

                    }

                    else if (value > 0 && value < 25)
                    {
                        e.CellStyle.BackColor = Color.Honeydew;

                    }
                    else if (value >= 25 && value < 50)
                    {
                        e.CellStyle.BackColor = Color.Honeydew;

                    }

                    else if (value >= 50 && value < 75)
                    {
                        e.CellStyle.BackColor = Color.Honeydew;

                    }

                    else if (value >= 75)
                    {
                        e.CellStyle.BackColor = Color.LightGreen;
                       // e.CellStyle.Font = new Font(e.CellStyle.Font.FontFamily, e.CellStyle.Font.Size, FontStyle.Bold);

                    }

                    else if (value >= 100)
                    {
                        e.CellStyle.BackColor = Color.Green;
                       // e.CellStyle.Font = new Font(e.CellStyle.Font.FontFamily, e.CellStyle.Font.Size, FontStyle.Bold);

                    }

                }
            }
            catch (Exception ex) { }

            try
            {
                if (dgv.Columns[e.ColumnIndex].DataPropertyName == "ACCEPTS_PLUS")
                {
                    string v  = DBase.StringReturn(dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                    v = v.Replace("+ ", "");
                    int value = DBase.IntReturn(v);
                    if (value == 0)
                    {

                        e.CellStyle.BackColor = Color.LightYellow;

                    }

                    else if (value > 0 && value < 4)
                    {
                        e.CellStyle.BackColor = Color.Honeydew;

                    }
                    else if (value >= 4 && value < 9)
                    {
                        e.CellStyle.BackColor = Color.GreenYellow;

                    }

                    else if (value >= 9 && value < 15)
                    {
                        e.CellStyle.BackColor = Color.PowderBlue;

                    }

                    else if (value >= 15)
                    {
                        e.CellStyle.BackColor = Color.PaleGoldenrod;
                       
                    }

                   
                }
            }
            catch (Exception ex) { }




            //HashPower
            try
            {
                if (dgv.Columns[e.ColumnIndex].DataPropertyName == "HASHPOWER")
                {
                    int value = DBase.IntReturn(  (dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Split(' '))[0]  );
                    if (value == 0)
                    {
                      //  e.CellStyle.BackColor = Color.LightYellow;

                    }

                    else if (value > 0 && value < 100)
                    {
                        e.CellStyle.BackColor = Color.LavenderBlush;

                    }
                    else if (value >= 100 && value < 250)
                    {
                        e.CellStyle.BackColor = Color.Honeydew;

                    }

                    else if (value >= 250 && value < 500)
                    {
                        e.CellStyle.BackColor = Color.LightGreen;

                    }

                    else if (value >= 500 && value < 700)
                    {
                        e.CellStyle.BackColor = Color.LawnGreen;
                        //e.CellStyle.Font = new Font(e.CellStyle.Font.FontFamily, e.CellStyle.Font.Size, FontStyle.Bold);

                    }

                 
                    else if (value >= 700 &&  value < 900 )
                    {
                        e.CellStyle.BackColor = Color.PowderBlue;
                       
                        // e.CellStyle.Font = new Font(e.CellStyle.Font.FontFamily, e.CellStyle.Font.Size, FontStyle.Bold);

                    }

                    else if (value >= 900 && value < 1000)
                    {
                        e.CellStyle.BackColor = Color.PowderBlue;
                      //  e.CellStyle.Font = new Font(e.CellStyle.Font.FontFamily, e.CellStyle.Font.Size, FontStyle.Bold);

                    }


                    else if (value >= 1000 && value < 2000)
                    {
                        e.CellStyle.BackColor = Color.HotPink;
                       // e.CellStyle.Font = new Font(e.CellStyle.Font.FontFamily, 9 , FontStyle.Bold);

                    }

                    else if (value >= 2000)
                    {
                        e.CellStyle.BackColor = Color.OrangeRed;
                      //  e.CellStyle.Font = new Font(e.CellStyle.Font.FontFamily, 10, FontStyle.Bold);

                    }

                }
            }
            catch (Exception ex) { }

            ////LAT

            try
            {


                if (dgv.Columns[e.ColumnIndex].DataPropertyName == "LAT")
                {
                    DateTime value = DBase.DatetimeReturn(dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                    DateTime servertime = DBase.DatetimeReturn(dgv.Rows[e.RowIndex].Cells[dgv.Columns["SERVERTIME"].Index].Value);
                    String Worker = DBase.StringReturn(dgv.Rows[e.RowIndex].Cells[dgv.Columns["WORKER"].Index].Value);
                    double diffSecond = (servertime - value).TotalSeconds;
                    if (diffSecond > 20 )
                    {
                        e.CellStyle.BackColor = Color.Magenta;

                    }

                    if ((servertime - value).TotalSeconds >= 200)
                    {
                       
                        e.CellStyle.BackColor = Color.Red;
                        if ( Worker != "") playAlarm = 1;

                    }

                }
            }
            catch (Exception ex) { }

            // Time
            try
            {


                if (dgv.Columns[e.ColumnIndex].DataPropertyName == "CDATETIME")
                {
                    DateTime value = DBase.DatetimeReturn(dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                    DateTime servertime = DBase.DatetimeReturn(dgv.Rows[e.RowIndex].Cells[dgv.Columns["SERVERTIME"].Index].Value);
                    String Worker = DBase.StringReturn(dgv.Rows[e.RowIndex].Cells[dgv.Columns["WORKER"].Index].Value);
                    double diffSecond = (servertime - value).TotalSeconds ;
                    if (diffSecond > 10 && diffSecond < 20)
                    {
                        e.CellStyle.BackColor = Color.LavenderBlush;
                    }

                    else if ((servertime - value).TotalSeconds >= 40 )
                    {
                        dgv.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
                        e.CellStyle.BackColor = Color.Red;
                        if ( Worker != "" ) playAlarm = 1;
                    }

                }
            }
            catch (Exception ex) { }
         

        }

        private void dgv_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
            
                    
               
                if (dgv.Columns[e.ColumnIndex].DataPropertyName == "CONFIG")
                {
                    string PCID = DBase.StringReturn(dgv.Rows[e.RowIndex].Cells["PCID"].Value);
                   
                    string value = DBase.StringReturn(dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                    string FIELD  = DBase.StringReturn(dgv.Rows[e.RowIndex].Cells["ALGO"].Value);
                    int kq = DStatic.ConfigUpdate(PCID, FIELD, value);
                    if (kq > 0) DBase.ShowMessage("Saved", 300);
                    else DBase.ShowMessage("Cant'...", 300);

                    string worker = DBase.StringReturn(dgv.Rows[e.RowIndex].Cells["WORKER"].Value);
                    string cusercode = DBase.StringReturn(dgv.Rows[e.RowIndex].Cells["UCODE"].Value);
                
                    int i = DStatic.MonitorCommand(cusercode, worker, "CONFIG");
                }
            }
            catch (Exception ex)
            {
              //  MessageBox.Show(ex.ToString());
            }
        }


        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
            try
            {
                if (dgv.Columns[e.ColumnIndex].Name == "TEAMVIEWER")
                {
                    string ID = DBase.StringReturn( dgv.Rows[e.RowIndex].Cells["TEAMVIEWERID"].Value);
                    string PASS = DBase.StringReturn(dgv.Rows[e.RowIndex].Cells["TEAMVIEWERPASSWORD"].Value);
                    if (PASS == "") PASS = "asdasdaaa";
                
                        //start button

                        if (Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE").Contains("64"))
                        {
                            string path = @"c:\Program Files (x86)\Teamviewer\"; //specify starting folder location for searching
                            string searchPattern = "TeamViewer.exe*"; //what do you want to search for?

                            DirectoryInfo di = new DirectoryInfo(path);

                            FileInfo[] files =
                                di.GetFiles(searchPattern, SearchOption.AllDirectories);

                            foreach (FileInfo file in files)
                            {
                            //    MessageBox.Show("1");
                                string tvE = (file.FullName.ToString()); //takes found file and references full file path

                                ProcessStartInfo startInfo = new ProcessStartInfo();
                                startInfo.CreateNoWindow = false;
                                startInfo.UseShellExecute = false;
                                startInfo.FileName = tvE;
                                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                                startInfo.Arguments = "-i " + ID.Replace(" ", "") + " --Password " + PASS;
                                System.Diagnostics.Process.Start(startInfo);
                            }

                          //  MessageBox.Show("2");
                        }
                        else
                        {
                            string path = @"c:\Program Files\Teamviewer\"; //specify starting folder location for searching
                            string searchPattern = "TeamViewer.exe*"; //what do you want to search for?

                            DirectoryInfo di = new DirectoryInfo(path);

                            FileInfo[] files =
                                di.GetFiles(searchPattern, SearchOption.AllDirectories);

                            foreach (FileInfo file in files)
                            {
                                string tvE = (file.FullName.ToString()); //takes found file and references full file path

                                ProcessStartInfo startInfo = new ProcessStartInfo();
                                startInfo.CreateNoWindow = false;
                                startInfo.UseShellExecute = false;
                                startInfo.FileName = tvE;
                                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                                startInfo.Arguments = "-i " + ID.Replace(" ", "") + " --Password " + PASS;
                                System.Diagnostics.Process.Start(startInfo);
                            }
                        }
                    }

            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.ToString());
            }

            if (dgv.Columns[e.ColumnIndex].Name == "IP")
                {
                    string ID = DBase.StringReturn( dgv.Rows[e.RowIndex].Cells["IP"].Value);
                    string PASS = DBase.StringReturn(dgv.Rows[e.RowIndex].Cells["TEAMVIEWERPASSWORD"].Value);
                    if (PASS == "") PASS = "asdasd";
                
                        //start button

                        if (Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE").Contains("64"))
                        {
                            string path = @"c:\Program Files (x86)\Teamviewer\"; //specify starting folder location for searching
                            string searchPattern = "TeamViewer.exe*"; //what do you want to search for?

                            DirectoryInfo di = new DirectoryInfo(path);

                            FileInfo[] files =
                                di.GetFiles(searchPattern, SearchOption.AllDirectories);

                            foreach (FileInfo file in files)
                            {
                            //    MessageBox.Show("1");
                                string tvE = (file.FullName.ToString()); //takes found file and references full file path

                                ProcessStartInfo startInfo = new ProcessStartInfo();
                                startInfo.CreateNoWindow = false;
                                startInfo.UseShellExecute = false;
                                startInfo.FileName = tvE;
                                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                                startInfo.Arguments = "-i " + ID.Replace(" ", "") + " --Password " + PASS;
                                System.Diagnostics.Process.Start(startInfo);
                            }

                          //  MessageBox.Show("2");
                        }
                        else
                        {
                            string path = @"c:\Program Files\Teamviewer\"; //specify starting folder location for searching
                            string searchPattern = "TeamViewer.exe*"; //what do you want to search for?

                            DirectoryInfo di = new DirectoryInfo(path);

                            FileInfo[] files =
                                di.GetFiles(searchPattern, SearchOption.AllDirectories);

                            foreach (FileInfo file in files)
                            {
                                string tvE = (file.FullName.ToString()); //takes found file and references full file path

                                ProcessStartInfo startInfo = new ProcessStartInfo();
                                startInfo.CreateNoWindow = false;
                                startInfo.UseShellExecute = false;
                                startInfo.FileName = tvE;
                                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                                startInfo.Arguments = "-i " + ID.Replace(" ", "") + " --Password " + PASS;
                                System.Diagnostics.Process.Start(startInfo);
                            }
                        }
                    }


            if (dgv.Columns[e.ColumnIndex].Name == "MAC")
            {
                string MAC = DBase.StringReturn(dgv.Rows[e.RowIndex].Cells["MAC"].Value);
                MAC = DStatic.PC_MacRemoveSplash(MAC);
                W.WakeFunction(MAC);
            }


            try
            {
                if (dgv.Columns[e.ColumnIndex].Name == "STO")
                {
                    string worker = DBase.StringReturn(dgv.Rows[e.RowIndex].Cells["WORKER"].Value);
                    string cusercode = DBase.StringReturn(dgv.Rows[e.RowIndex].Cells["UCODE"].Value);
                
                    int i = DStatic.MonitorCommand(cusercode, worker, "STOP");
                    if (i > 0)
                    {
                       // DHuy.ShowMessage("STOP command sent to worker [" + worker + "]",600);
                    }
                    else
                    {
                        DStatic.ShowMessage("Can't send command , try again later!",600);
                    }
                }

            }
            catch (Exception ex)
            { }

            try
            {
                if (dgv.Columns[e.ColumnIndex].Name == "MONITORDATA")
                {
                    string worker = DBase.StringReturn(dgv.Rows[e.RowIndex].Cells["WORKER"].Value);
                    string cusercode = DBase.StringReturn(dgv.Rows[e.RowIndex].Cells["UCODE"].Value);
                 
                    int i = DStatic.MonitorCommand(cusercode, worker, "MONITORDATA");
                    if (i > 0)
                    {
                      //  DHuy.ShowMessage("MONITOR ON/OFF command sent to worker [" + worker + "]",700);
                    }
                    else
                    {
                        DStatic.ShowMessage("Can't send command , try again later!", 600);
                    }
                }

            }
            catch (Exception ex)
            { }


            try
            {
                if (dgv.Columns[e.ColumnIndex].Name == "RPC")
                {
                    string worker = DBase.StringReturn(dgv.Rows[e.RowIndex].Cells["WORKER"].Value);
                    string cusercode = DBase.StringReturn(dgv.Rows[e.RowIndex].Cells["UCODE"].Value);
                    
                    int i = DStatic.MonitorCommand(cusercode, worker, "RESTART");
                    if (i > 0)
                    {
                      //  DHuy.ShowMessage("RESTART command sent to worker [" + worker + "]", 600);
                    }
                    else
                    {
                        DStatic.ShowMessage("Can't send command , try again later!", 600);
                    }
                }

            }
            catch (Exception ex)
            { }

            try
            {
                if (dgv.Columns[e.ColumnIndex].Name == "STA")
                {
                    string worker = DBase.StringReturn(dgv.Rows[e.RowIndex].Cells["WORKER"].Value);
                    string cusercode = DBase.StringReturn(dgv.Rows[e.RowIndex].Cells["UCODE"].Value);
                    
                    int i = DStatic.MonitorCommand(cusercode, worker, "START");
                    if (i > 0)
                    {
                        DStatic.ShowMessage("START command sent to worker [" + worker + "]", 600);
                    }
                    else
                    {
                        DStatic.ShowMessage("Can't send command , try again later!", 600);
                    }
                }

            }
            catch (Exception ex)
            { }

            try
            {
                if (dgv.Columns[e.ColumnIndex].Name == "RTV")
                {
                    string worker = DBase.StringReturn(dgv.Rows[e.RowIndex].Cells["WORKER"].Value);
                    string cusercode = DBase.StringReturn(dgv.Rows[e.RowIndex].Cells["UCODE"].Value);
                   
                    int i = DStatic.MonitorCommand(cusercode, worker, "Restart TV");
                    if (i > 0)
                    {
                        DStatic.ShowMessage("RESTART.TEAMVIEWER command sent to worker [" + worker + "]", 800);
                    }
                    else
                    {
                        DStatic.ShowMessage("Can't send command , try again later!", 600);
                    }
                }

            }
            catch (Exception ex)
            { }
        }


        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            cmsLog.PerformClick();
        }


        private void cmsResetStats_Click(object sender, EventArgs e)
        {
            try
            {
                int i = DStatic.MonitorCommand_AllWorker(usercode, "RESET STATS");
                if (i > 0)
                {
                    DStatic.ShowMessage("Reset All Stats command sent to all worker", 600);
                }
                else
                {
                    DStatic.ShowMessage("Can't send command , try again later!", 600);
                }
            }
            catch (Exception ex) { }

        }

        private void cmsRestartAllSameTime_Click(object sender, EventArgs e)
        {
            try
            {
                int i = DStatic.MonitorCommand_AllWorker(usercode, "START");
                if (i > 0)
                {
                    DStatic.ShowMessage("Reset All Stats command sent to all worker", 600);
                }
                else
                {
                    DStatic.ShowMessage("Can't send command , try again later!", 600);
                }
            }
            catch (Exception ex) { }
        }


        private void cmsRestartAll_Click(object sender, EventArgs e)
        {
            try
            {
                int i = DStatic.MonitorCommand_AllWorker(usercode, "RESTART");
                if (i > 0)
                {
                    DStatic.ShowMessage("RESTART command sent to all worker", 600);
                }
                else
                {
                    DStatic.ShowMessage("Can't send command , try again later!", 600);
                }
            }
            catch (Exception ex) { }

        }

        private void cmsClearMonitor_Click(object sender, EventArgs e)
        {
            try
            {
                DStatic.MonitorTruncate();
            }

            catch (Exception ex) { }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
               
                string worker = DBase.StringReturn(dgv.SelectedCells[0].OwningRow.Cells["WORKER"].Value);
           
                int i =  DStatic.MonitorDelete(usercode,worker);
                if (i > 0)
                {
                    DBase.ShowMessage("Deleted " + worker + " !", 300);
                }

                else
                {
                    DBase.ShowMessage("Can't Delete...", 300);
                }
            }
            catch (Exception) { }
        }

        private void lbTotalHashRate_Click(object sender, EventArgs e)
        {
            try
            {
                isEnableAPI = isEnableAPI == 1 ? 0 : 1;
                if (isEnableAPI == 1) DBase.ShowMessage("Enable API Monitor", 400);
                else DBase.ShowMessage("Disable API Monitor", 400);
                isBusy = 0;
              
            }
            catch (Exception ex) { }

            if (isEnableAPI == 1)
            {
                APIDIFF.Visible = APISPEED.Visible = HASHPOWER.Visible = true;
            }
            else
            {
                APIDIFF.Visible = APISPEED.Visible = HASHPOWER.Visible = false;
            }
        }

        private void clearListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow dr in dgv.Rows)
                {
                    try
                    {
                        string worker = DBase.StringReturn(dr.Cells["WORKER"].Value);

                        int i = DStatic.MonitorDelete(usercode, worker);
                        if (i > 0)
                        {
                            DBase.ShowMessage("Deleted all monitor data !", 300);
                        }

                        else
                        {
                            DBase.ShowMessage("Can't Delete...", 300);
                        }
                    }
                    catch (Exception ex) { }
                }
            }
            catch (Exception) { }
        }

        private void disableAPIMonitorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isEnableAPI = isEnableAPI == 0 ? 1 : 0;
           
        }

       
        // TEST API
        public int TestAPI(String API)
        {

            int kq = 0;

            if (isEnableAPI == 0) return 0;
            try
            {
                Stopwatch sw = new Stopwatch();

                Thread t = new Thread(delegate()
                {
                    try
                    {
                        sw.Start();
                       
                          
                            APIRES = DownloadString(API);
                       
                    }
                    catch { }
                });

                t.IsBackground = true;
                t.Start();

                while (sw.ElapsedMilliseconds < 5000) { }

                if (APIRES != "")
                {
                    isEnableAPI = 1;
                    kq = 1;
                }
                else isEnableAPI = 0;

            }
            catch (Exception ex)
            {

            }

            finally
            {
                isTestedAPI = 1;
            }
            return kq;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem T = (ToolStripMenuItem)sender;
            int i = DBase.IntReturn( T.Text) * 1000;
            timer1.Interval = i;
        }

        private void dgv_DragDrop(object sender, DragEventArgs e)
        {
           // MessageBox.Show("ok");
        }

        private void cmsCopy_Click(object sender, EventArgs e)
        {
            try
            {
                DBase.StringCopyBuffer.Clear();
                foreach ( DataGridViewCell dc in dgv.SelectedCells)
                {
                    string worker1 = DBase.StringReturn(dgv.Rows[dc.OwningRow.Index].Cells["WORKER"].Value);
                    string usercode1 = usercode;
                    DBase.StringCopyBuffer.Add(usercode1 + "," + worker1);
                }
                DBase.ShowMessage("Copyed..",300);
            }
            catch (Exception ex)
            {

            }
        }

        private void cmsPaste_Click(object sender, EventArgs e)
        {
            try
            {
                foreach ( string StringBuffer in DBase.StringCopyBuffer )
                {


                    string usercode1 = StringBuffer.Split(',')[0];
                    string worker1 = StringBuffer.Split(',')[1];

                    // MOVE@tramphuochuy,tramphuochuy.7@tramphuochuy2
                    int i = DStatic.MonitorCommand(usercode1, worker1, "MOVE@" + usercode);
                }
  
            }
            catch (Exception ex)
            {

            }
        }


        //test

        public string DownloadString(string uri)
        {
            string result = null;
            int status = 0 ;
            HttpWebResponse response = null;
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;

                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(uri);
                // augment the request here: headers (Referer, User-Agent, etc)
                //     CookieContainer, Accept, etc.
                response = (HttpWebResponse)request.GetResponse();
                Encoding responseEncoding = Encoding.GetEncoding(response.CharacterSet);
                using (StreamReader sr = new StreamReader(response.GetResponseStream(), responseEncoding))
                {
                    result = sr.ReadToEnd();
                }
                status = (int)response.StatusCode;
            }
            catch (WebException wexc1)
            {
                // any statusCode other than 200 gets caught here
                if (wexc1.Status == WebExceptionStatus.ProtocolError)
                {
                    // can also get the decription: 
                    //  ((HttpWebResponse)wexc1.Response).StatusDescription;
                    status = (int)((HttpWebResponse)wexc1.Response).StatusCode;
                }
            }
            finally
            {
                if (response != null)
                    response.Close();
            }
            return result;
        }

        private void edtUsercode_Click(object sender, EventArgs e)
        {

        }

        private void cmsFlagCreditOK_Click(object sender, EventArgs e)
        {
           int kq=   DStatic.CoinDetailUpdate_FlagCredit(usercode,Coin,DBase.FloatReturn(edtFlagCredit.Text) );
            if ( kq > 0) 
            {
              DBase.ShowMessage("Flaged",300);
            }
        }

        private void CHANGE_COIN(object sender, EventArgs e)
        {
            CoinChoose C = new CoinChoose();
            C.usercode = usercode;
            C.ShowDialog();
            if (C.res == 1)
            {
                if (MessageBox.Show("Change Coin ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                {
                    int kq =  DStatic.CoinSelectUpdate(usercode,C.CoinSelected);
                    if (kq > 0)
                    {
                        cmsRefresh.PerformClick();
                    }

                }
                else
                {


                }

            }

        }

        private void addCoinsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Add_Coin A = new Add_Coin();
                A.usercode = usercode;
                A.Show();
            }
            catch (Exception ex) { }
        }

        private void cmsUpdateAll_Click(object sender, EventArgs e)
        {
            String MD5Sever = DStatic.MD5Server("Autocoin.exe");
            DStatic.ProfileVersionUpdate(usercode, MD5Sever);
        }

        private void cmsUpdateAllEx_Click(object sender, EventArgs e)
        {
            try
            {
                int i = DStatic.MonitorCommand_AllWorker(usercode, "UPDATEEX");
            }
            catch (Exception ex) { }
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            MonitorPanel_Load(null,null);
        }

        private void cmsMenu_Opening(object sender, CancelEventArgs e)
        {
            PauseTimer = 1;

        }

        private void cmsMenu_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            PauseTimer = 0;
        }

       

        private void cmsFlagZero_Click(object sender, EventArgs e)
        {
            if (APICredit > 0)
            {
                int kq = DStatic.CoinDetailUpdate_FlagCredit(usercode, Coin, (float)APICredit);
                if (kq > 0)
                {
                    DBase.ShowMessage("Flaged Credit Reset to 0", 300);
                }
            }

            else
            {
                MessageBox.Show("Enable & Credit > 0 to continue");
            }
        }

        private void cmsFlagReset_Click(object sender, EventArgs e)
        {
             if (APICredit > 0)
            {
                int kq = DStatic.CoinDetailUpdate_FlagCredit(usercode, Coin, 0);
                if (kq > 0)
                {
                    DBase.ShowMessage("Flaged Removed", 300);
                }
                else
                {
                     DBase.ShowMessage("Can't Flag", 300);
                }
            }

            else
            {
                MessageBox.Show("Enable & Credit > 0 to continue");
            }
        
        }

        private void CopyTeamviewer(object sender, EventArgs e)
        {
            string ID = DBase.StringReturn(dgv.SelectedCells[0].OwningRow.Cells["TEAMVIEWERID"].Value);
            Clipboard.SetText(ID);
            
        }

        private void CopyMAC(object sender, EventArgs e)
        {
            string ID = DBase.StringReturn(dgv.SelectedCells[0].OwningRow.Cells["MAC"].Value);
            Clipboard.SetText(ID);

        }

        private void cmsLog_Click(object sender, EventArgs e)
        {
            try
            {
                string worker = DBase.StringReturn(dgv.SelectedCells[0].OwningRow.Cells["WORKER"].Value);
                MonitorLogForm M = new MonitorLogForm(usercode,worker);
             
                M.Show();
            }
            catch(Exception ex){}
        }

        private void AMode_Click(object sender, EventArgs e)
        {
            if (usercode == "tramphuochuy2")
            {
                isShowAll = isShowAll == 0 ? 1 : 0;
                cmsRefresh.PerformClick();
            }
        }

        private void DeleteAMode_Click(object sender, EventArgs e)
        {
            int i = DStatic.MonitorDelete_All();
        }



    
        private void cmsCopyText_Click(object sender, EventArgs e)
        {
            string ID = DBase.StringReturn(dgv.SelectedCells[0].Value);
            Clipboard.SetText(ID);
        }

        private void freezeToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Freeze = Freeze == 0 ? 1 : 0;
        }

        private void COMMAND_Click(object sender, EventArgs e)
        {
            try
            {
                        ToolStripMenuItem T = (ToolStripMenuItem) sender;
                        string command = T.Text;
                        foreach ( DataGridViewCell C in  dgv.SelectedCells )
                        {
                            string worker = DBase.StringReturn(dgv.Rows[C.RowIndex].Cells["WORKER"].Value);
                            string cusercode = DBase.StringReturn(dgv.Rows[C.RowIndex].Cells["UCODE"].Value);
                           
                            int i = DStatic.MonitorCommand(cusercode, worker, command);
                            if (i > 0)
                            {
                                //  DHuy.ShowMessage("RESTART command sent to worker [" + worker + "]", 600);
                            }
                            else
                            {
                               // DHuy.ShowMessage("Can't send command , try again later!", 600);
                            }
                        }
            }
            catch (Exception ex)
            { 
            
            
            }


        }


        
    }
}
