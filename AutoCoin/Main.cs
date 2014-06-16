using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Net;
using Microsoft.Win32;
using System.Threading;
using System.IO.Compression;

namespace AutoCoin
{
    public partial class Main : Form
    {
        DataTable dt = new DataTable();
        DataTable dtDetail = new DataTable();
        DataTable dtCoins = new DataTable();
        DateTime RSS = DateTime.Now;
        int isReseting = 0;
        double RSSTime = 0;
        string cgminerversion = "";
        public int SendCommand = 0;
        public string RequestResult = "";
        
        int CurrentDiff = 0;
        
        public int StartWithLiteMode = 0;
        public int StartDetecterWhenOpen = 0;
        public int EnableAPIInMonitorMode = 0;
        public int EnableAMInMonitorMode = 0;
        public int TimerInterval = 3000;

        public int TimeResetLimit = 15;
        public string PCName = System.Environment.MachineName;
        public string PCID = System.Environment.MachineName;
        public string PCMAC = "";

        public int PinShare = 0;
        public int MaxPinShare = 0;


        public string IP = "";
        int IsStop = 0;
        double Time2Kill = 0;

        int continueTimer = 1 ;
        int CgminerRestarting = 1;

        String currentCoin = "";
        String currentWorker = "";
        String currentURL = "";
        string path = "";
        string Usercode = "";
        string UserPassword = "1";
        string cmd = "";
        public int Startup = 1;
        Process currentCoinProcess = null;
        int currentCoinProcessID = 0;
        string currentCoinProcessName = "";
        StreamReader sr = null;
        StreamReader sr2 = null;
        Process[] PList;
        string CurrentVersion = "";
        public string excuteDevice = "cgminer";
        public int interval = 0;
        public int AutoRestart = 0;
        public int AutoRestart_Seconds = 120;
        String APIString = "";
        public int UseAddress = 0;
        public string MD5 = "";
        BackgroundWorker BG = new BackgroundWorker();
        public Decimal PoolDiff = 0;
        public decimal MaxDiff = 16;
        public int ForceRestart = 0;
        int UseMaxDiff = 1;
        int KillProcess = 1;
        int Reject = 0;
        int MaxReject = 20;
        int IsShowCoin = 0;
        int IsLockConfig = 0;
        int ConfigIndex = 0;
        
       

        string TeamviewerID = "";
        string TeamviewerPass = "";

        DateTime AcceptedDate = DateTime.Now;
        DateTime CurrentAcceptedDate = DateTime.Now;
        public int Accepted = 0;
        public int TotalAccept = 0;
        public int TotalAcceptBuffer = 0;
        public int CurrentAccepted = 0;
        public int MaxLastAcceptedSeconds = 50;

        int KillCount = 0;
        int AcceptKillCount = 0;
        int AcceptKillCount_Restart = 0;
       
        int RestartCount = 0;
        int RejectKillCount = 0;
        int ForceKillCount = 0;
        
        int ShowMonitor = 0;
        int ShowMonitor2 = 0;
        int ShowMonitor3 = 0;
        int ShowMonitor4 = 0;
        int ShowMonitor5 = 0;
        int ShowMonitor6 = 0;
        int ShowMonitor7 = 0;

        int MonitorIntervalValue = 2;

        int ForceUpdate = 0;
        string ProfileVersion = "";
        float speedMh = 0;

        string TeamviwerID = "";

        string STATS = "";

        public int MonitorData = 1;

        public string GPUSTATS_TEMP = "" , GPUSTATS_MH = "";

        int StartWhenStarApp = 1;

      
       

        public string ALGO = "SCRYPT";

        DataTable dtServer = new DataTable();


        WakeUpOnLan W = new WakeUpOnLan();

        int PoolAPICount = 0;
        int PoolConfigCount = 0;

        public Main()
        {
            InitializeComponent();
            this.BG.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_DoWork);
            this.BG.WorkerReportsProgress = true;
            this.BG.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgw_RunWorkerCompleted);
            //DBase.SetTime(DHuy.GetServerTime());
        }

        private void bgw_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                try
                {
                    dtServer = DStatic.CoinInfo(Usercode, UserPassword);
                    ForceUpdate = DBase.IntReturn(dt.Rows[0]["FORCEUPDATE"]);
                }
                catch (Exception ex) { }

            }
            catch (Exception x)
            {
              
            }

        }
        private void bgw_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {

            try
            {
                lbForceUpdate.Text = "| Force Update : " + (ForceUpdate == 1 ? "Yes" : "No");

                if (dtServer.Rows.Count == 0)
                {
                    this.Text = "Can't get Account & Coin info | " + timer1.Interval.ToString();
                    continueTimer = 1;
                  

                }

                else
                {
                    dt = dtServer;
                    if (!this.Text.Contains(Usercode) && IsStop == 0 )
                    {

                        this.Text = Usercode + " - Miner - " + edtWorkerSubFix.Text + " ( " + MD5.Substring(MD5.Length-5,5)  + " ) ";
                        START_Click(null, null);
                    }
                }

                String ServerCoin = DBase.StringReturn(dt.Rows[0]["COIN"]);


                dtDetail = DStatic.CoinInfo_DetailConfig(Usercode, ServerCoin);
               
                int AuRes1 = DBase.IntReturn(dtDetail.Rows[0]["AUTORESTART"]);

                UseMaxDiff = DBase.IntReturn(dtDetail.Rows[0]["USEMAXDIFF"]);

                if (Usercode == "tramphuochuy5")
                {
                    UseMaxDiff = 1;
                }

                ALGO = DBase.StringReturn(dtDetail.Rows[0]["ALGO"]);
    

                MaxDiff = DBase.DecimalReturn(dtDetail.Rows[0]["MAXDIFF"]);
                MaxReject = DBase.IntReturn(dtDetail.Rows[0]["MAXREJECT"]);
                MaxLastAcceptedSeconds = DBase.IntReturn(dtDetail.Rows[0]["MAXSECOND"]);

                lbUseMaxDiff.Text = "| Use MaxDiff : " + (UseMaxDiff == 1 ? "Yes" : "No");
                if (ForceRestart == 1) AutoRestart = 1;

                try
                {
                    UseAddress = DBase.IntReturn(dtDetail.Rows[0]["USEADDRESS"]);
                }
                catch (Exception ex) { }


                if (currentCoin != ServerCoin)
                {

                    AutoRestart = AuRes1;
                    btnStart.PerformClick();

                }
            }
            catch (Exception ex) { }

            try
            {
                interval = interval + DBase.IntReturn(timer1.Interval / 1000);
                if (AutoRestart == 1) lbAuto.Text = (AutoRestart_Seconds - interval).ToString();
                if (interval > AutoRestart_Seconds && AutoRestart == 1)
                {
                    ForceKillCount++;
                    btnStart.PerformClick();
                    interval = 0;

                }
            }
            catch (Exception ex) { }

            //FORCE UPdATE
            try
            {
                profileUpdateInveteval++;
                if (profileUpdateInveteval > 5)
                {
                    profileUpdateInveteval = 0;
                    try
                    {

                        ProfileVersion = DBase.StringReturn(dt.Rows[0]["PROFILEVERSION"]);
                        String MD5Server = DStatic.MD5Server("Autocoin.exe");
                        if (ForceUpdate == 1)
                        {
                            if (MD5 != MD5Server && ProfileVersion == MD5Server)
                            {
                                cmsUpdate.PerformClick();
                            }

                        }
                    }
                    catch (Exception ex) { }

                    //Command exucute
                    try
                    {

                        DataTable dtm = DStatic.MonitorInfo(Usercode, currentWorker);
                        string Command = DBase.StringReturn(dtm.Rows[0]["COMMAND"]);

                        if (Command == "STOP")
                        {
                            DStatic.MonitorCommand(Usercode, currentWorker, "");
                            btnStop.PerformClick();
                            DStatic.ShowMessage("Performed " + Command + " command ! ", 600);
                        }

                        if (Command == "RESTART")
                        {
                            DStatic.MonitorCommand(Usercode, currentWorker, "");
                            DStatic.ShowMessage("Performed " + Command + " command ! ", 600);
                            try
                            {
                                ProcessStartInfo proc = new ProcessStartInfo();
                                proc.WindowStyle = ProcessWindowStyle.Hidden;
                                proc.FileName = "cmd";
                                proc.Arguments = "/C shutdown -f -r -t 0";
                                Process.Start(proc);
                            }
                            catch (Exception ex) { }

                        }

                        if (Command == "TVE")
                        {
                            DStatic.MonitorCommand(Usercode, currentWorker, "");
                            DStatic.ShowMessage("Performed " + Command + " command ! ", 600);
                            try
                            {
                                try
                                {
                                    foreach (Process P in Process.GetProcesses())
                                    {

                                        if (P.ProcessName.ToString().ToLower() == excuteDevice || P.ProcessName.ToString().ToLower() == "Teamviewer" || P.ProcessName.ToString().ToLower() == "Teamviewer")
                                        {
                                            P.Kill();
                                        }

                                    }
                                }
                                catch (Exception ex) { }
                            }
                            catch (Exception ex) { }

                        }


                        if (Command == "START")
                        {
                            DStatic.MonitorCommand(Usercode, currentWorker, "");
                            btnStart.PerformClick();
                            DStatic.ShowMessage("Performed " + Command + " command ! ", 600);


                        }

                        if (Command == "LOCK")
                        {
                            DStatic.MonitorCommand(Usercode, currentWorker, "");
                            btnStart.PerformClick();
                            DStatic.ShowMessage("Performed " + Command + " command ! ", 600);


                        }



                        if (Command.Contains("MOVE@"))
                        {
                            string usercodewillmove =DBase.StringReturn( Command.Split('@')[1]);
                            string oldusercode = Usercode;
                            string oldworker = currentWorker;
                            MOVING(usercodewillmove);
                            DStatic.MonitorDelete(oldusercode, oldworker);
                         
                            btnStart.PerformClick();
                            DStatic.ShowMessage("Performed " + Command + " command ! ", 600);
                            btnLockConfig.PerformClick();


                        }

                        if (Command.Contains("CONFIG"))
                        {
                            DStatic.MonitorCommand(Usercode, currentWorker, "");
                            try
                            {
                                string[] ConfigAll = DStatic.Config_Get(PCID).Split(';');

                                Usercode = ConfigAll[0];
                                edtWorkerSubFix.Text = ConfigAll[1];

                                edtConfigSCRYPT.Text = ConfigAll[2];
                                edtConfigX11.Text = ConfigAll[3];
                                edtConfigX13.Text = ConfigAll[4];
                                edtConfigGROESTL.Text = ConfigAll[5];
                            }

                            catch (Exception ex)
                            {

                            }
                            btnStart.PerformClick();
                            
                            DStatic.ShowMessage("Performed " + Command + " command ! ", 600);
                      


                        }



                        if (Command == "RESET STATS")
                        {
                            AcceptKillCount = 0;
                            AcceptKillCount_Restart = 0;
                            RejectKillCount = 0;
                            RestartCount = 0;
                            ForceKillCount = 0;
                            KillCount = 0;
                            TotalAcceptBuffer = 0;
                            DStatic.MonitorCommand(Usercode, currentWorker, "");
                            DStatic.ShowMessage("Performed " + Command + " command ! ", 600);
                        }
                       
                        if (Command == "MONITORDATA")
                        {
                            DStatic.MonitorCommand(Usercode, currentWorker, "");
                            MonitorData = MonitorData == 1 ? 0 : 1;
                            DStatic.MonitorDataUpdate(Usercode, currentWorker, MonitorData == 1 ? "Yes" : "No");
                            UpdateIni();
                            UpdateButton();
                            DStatic.ShowMessage("Performed " + Command + " command ! ", 600);


                        }


                        if (Command == "UPDATEEX")
                        {
                            DStatic.MonitorCommand(Usercode, currentWorker, "");

                            UPDATEEX(null,null);
                            
                            UpdateIni();
                            UpdateButton();
                            DStatic.ShowMessage("Performed " + Command + " command ! ", 600);


                        }

                        if (Command == "Restart TV")
                        {
                            //start button

                            try
                            {
                                try
                                {

                                    foreach (Process P in Process.GetProcesses())
                                    {

                                        if (P.ProcessName.ToString().ToLower().Contains("teamviewer"))
                                        {
                                            P.Kill();
                                        }


                                    }
                                }
                                catch (Exception ex) { }

                                if (Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE").Contains("64"))
                                {
                                    string path = @"c:\Program Files (x86)\Teamviewer\"; //specify starting folder location for searching
                                    string searchPattern = "teamviewer.exe*"; //what do you want to search for?

                                    DirectoryInfo di = new DirectoryInfo(path);

                                    FileInfo[] files =
                                        di.GetFiles(searchPattern, SearchOption.AllDirectories);

                                    foreach (FileInfo file in files)
                                    {
                                        string tvE = (file.FullName.ToString()); //takes found file and references full file path
                                        System.Diagnostics.Process.Start(tvE);

                                    }
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
                                        System.Diagnostics.Process.Start(tvE);
                                    }
                                }
                            }
                            catch (Exception ex) { }
                            DStatic.MonitorCommand(Usercode, currentWorker, "");
                            DStatic.ShowMessage("Performed " + Command + " command ! ", 600);
                        } // end if R.teamviewer


                    }
                    catch (Exception ex) { }
                }
            }
            catch (Exception ex) { }

            finally
            {

                continueTimer = 1;
            }
        }

        int profileUpdateInveteval = 1;

      
        public void UpdateIni()
        {
            try
            {
                File.SetAttributes("AutoCoin.ini", FileAttributes.Normal);
            }
            catch(Exception ex){}

            try
            {
                if (Usercode == "" | edtWorkerSubFix.Text == "" | edtConfigSCRYPT.Text == "") return;

                System.IO.File.WriteAllText("AutoCoin.ini", Usercode + ";" + edtWorkerSubFix.Text + ";"
                    + edtConfigSCRYPT.Text + ";" + UserPassword + ";" + edtAutoReset.Value.ToString() + ";"
                    + UseMaxDiff.ToString() + ";" + KillProcess.ToString() + ";" + ForceRestart.ToString()
                    + ";" + edtMaxReject.Value.ToString() + ";" + "RemoveEdtMaxDiff" + ";"
                    + IsShowCoin.ToString() + ";" + IsLockConfig.ToString() + ";" + ConfigIndex.ToString()
                    + ";" + edtMaxLastAccept.Value.ToString()
                    + ";" + ShowMonitor.ToString() + ";" + ShowMonitor2.ToString()
                    + ";" + ShowMonitor3.ToString()

                    + ";" + MonitorData.ToString() + ";" + StartWhenStarApp.ToString()
                    + ";" + StartWithLiteMode.ToString() + ";" + EnableAPIInMonitorMode.ToString()
                    + ";" + StartDetecterWhenOpen.ToString()
                    + ";" + TimerInterval.ToString()
                    + ";" + TimeResetLimit.ToString()
                    + ";" + ShowMonitor4.ToString()
                    + ";" + edtConfigX11.Text
                    + ";" + ShowMonitor5.ToString()
                    + ";" + ShowMonitor6.ToString()
                    + ";" + ShowMonitor7.ToString()
                    + ";" + EnableAMInMonitorMode.ToString()
                    + ";" +edtConfigGROESTL.Text
                   

                    )
                    ;

            }
            catch (Exception ex)
            { }

            finally
            {
                try
                {
                    File.SetAttributes("AutoCoin.ini", FileAttributes.ReadOnly);
                }
                catch (Exception ex) { }
            }


        
            



        }

        //LOAD
        private void Main_Load(object sender, EventArgs e)
        {

            PCID = PCName + " - " + System.Environment.UserName + " - " + System.Environment.OSVersion + "-"+ DStatic.GetProcessorID();
            //PCMAC = DHuy.PC_GetMacAddress();
            //PCMAC = DHuy.PC_MacFillSplash(PCMAC);
            //Load teamviwerid
            try
            {
                sr = File.OpenText("AutoCoinConfig.ini");
                string line = sr.ReadToEnd();
                String[] SS = line.Split(';');
                TeamviewerPass = SS[4].ToString();
                sr.Dispose();
            }
            catch (Exception ex)
            {
                if (sr != null)
                    sr.Dispose();
            }


            try
            {
                FileInfo exeFile = new FileInfo("AutoCoin.exe");
                if (exeFile.Exists)
                {
                    DateTime info = exeFile.LastWriteTime;
                    CurrentVersion = "Updated " + exeFile.LastWriteTime.Day.ToString() + "/" + exeFile.LastWriteTime.Month + " " + exeFile.LastWriteTime.Hour.ToString() + ":" + exeFile.LastWriteTime.Minute.ToString();
                    this.Text += "" + CurrentVersion;
                    MD5 = DStatic.ComputeMD5(exeFile.FullName);
                }
            }
            catch (Exception ex) { }



            string Ini = "";
            try
            {
                sr = File.OpenText("AutoCoin.ini");
                Ini = sr.ReadToEnd();
                sr.Dispose();
            }
            catch (Exception ex)
            {
                if (sr != null)
                    sr.Dispose();
            }



            try
            {
                try
                {
                    string[] ConfigAll = DStatic.Config_Get(PCID).Split(';');

                    Usercode = ConfigAll[0];
                    edtWorkerSubFix.Text = ConfigAll[1];

                    edtConfigSCRYPT.Text = ConfigAll[2];
                    edtConfigX11.Text = ConfigAll[3];
                    edtConfigGROESTL.Text = ConfigAll[5];
                    edtConfigX13.Text = ConfigAll[4];
                }

                catch (Exception ex)
                {

                }


                String[] SS = Ini.Split(';');







                UserPassword = SS[3].ToString();
                edtAutoReset.Value = DBase.IntReturn(SS[4].ToString());
                UseMaxDiff = DBase.IntReturn(SS[5].ToString());
                btnUseMaxDiff.Checked = UseMaxDiff == 1 ? true : false;

                KillProcess = DBase.IntReturn(SS[6].ToString());
                btnKillProcess.Checked = KillProcess == 1 ? true : false;

                ForceRestart = DBase.IntReturn(SS[7].ToString());
                btnForceRestart.Checked = ForceRestart == 1 ? true : false;

                MaxReject = DBase.IntReturn(SS[8].ToString());
                edtMaxReject.Value = MaxReject;

                MaxDiff = DBase.DecimalReturn(SS[9].ToString());
                //edtMaxDiff.Value = MaxDiff;

                IsShowCoin = DBase.IntReturn(SS[10].ToString());

                IsLockConfig = 0; // DBase.IntReturn(SS[11].ToString());



                ConfigIndex = DBase.IntReturn(SS[12].ToString());


                // MaxLastAcceptedSeconds = DBase.IntReturn(SS[13].ToString());
                edtMaxLastAccept.Value = DBase.IntReturn(MaxLastAcceptedSeconds);

                ShowMonitor = DBase.IntReturn(SS[14].ToString());
                ShowMonitor2 = DBase.IntReturn(SS[15].ToString());
                ShowMonitor3 = DBase.IntReturn(SS[16].ToString());

                String MonitorDataString = "";
                try
                {
                    MonitorDataString = DBase.StringReturn(SS[17].ToString());

                    if (MonitorDataString == "") MonitorData = 1;
                    else MonitorData = DBase.IntReturn(MonitorDataString);


                }
                catch (Exception ex) { }

                try
                {
                    if (SS[18] != null) { StartWhenStarApp = DBase.IntReturn(SS[18].ToString()); }
                }
                catch (Exception ex) { StartWhenStarApp = 1; }

                try
                {
                    if (SS[19] != null) { StartWithLiteMode = DBase.IntReturn(SS[19].ToString()); }
                }
                catch (Exception ex) { StartWithLiteMode = 0; }



                try
                {
                    if (SS[20] != null) { EnableAPIInMonitorMode = DBase.IntReturn(SS[20].ToString()); }
                }
                catch (Exception ex) { EnableAPIInMonitorMode = 0; }

                try
                {
                    if (SS[21] != null) { StartDetecterWhenOpen = DBase.IntReturn(SS[21].ToString()); }
                }
                catch (Exception ex) { StartDetecterWhenOpen = 0; }

                try
                {
                    if (SS[22] != null) { TimerInterval = DBase.IntReturn(SS[22].ToString()); }
                }
                catch (Exception ex) { TimerInterval = 3000; }

                try
                {
                    if (SS[23] != null) { TimeResetLimit = 30; }
                }
                catch (Exception ex) { TimeResetLimit = 30; }

                ShowMonitor4 = DBase.IntReturn(SS[24].ToString());

                //if (edtConfig.Text == "") edtConfigSJ.Text = SS[2].ToString();
                //if ( edtConfigSJ.Text == "") edtConfigSJ.Text = SS[25].ToString();

                ShowMonitor5 = DBase.IntReturn(SS[26].ToString());
                ShowMonitor6 = DBase.IntReturn(SS[27].ToString());
                ShowMonitor7 = DBase.IntReturn(SS[28].ToString());

                try
                {
                    if (SS[29] != null) { EnableAMInMonitorMode = DBase.IntReturn(SS[29].ToString()); }
                }
                catch (Exception ex) { EnableAMInMonitorMode = 0; }



                UpdateButtonConfig();

            }
            catch (Exception ex) { }

            //Load configusermonitor
            try
            {
                sr = File.OpenText("AutoCoinConfig.ini");
                string line = sr.ReadToEnd();
                String[] SS = line.Split(';');
                string mo2 = "    " + SS[5].ToString();
                string mo3 = "    " + SS[6].ToString();
                string mo4 = "    " + SS[7].ToString();
                string mo5 = "    " + SS[8].ToString();
                string mo6 = "    " + SS[9].ToString();
                string mo7 = "    " + SS[10].ToString();

                //string subs = Usercode.Substring(btnShowMonitor.Text.Length - 4, 4);
                //btnShowMonitor.Text = subs;
                btnMonitor2.Text = mo2.Substring(mo2.Length - 4, 4);
                btnMonitor3.Text = mo3.Substring(mo3.Length - 4, 4);
                btnMonitor4.Text = mo4.Substring(mo4.Length - 4, 4);
                btnMonitor5.Text = mo5.Substring(mo5.Length - 4, 4);
                btnMonitor6.Text = mo6.Substring(mo6.Length - 4, 4);
                btnMonitor7.Text = mo7.Substring(mo7.Length - 4, 4);



                sr.Dispose();
            }
            catch (Exception ex)
            {
                if (sr != null)
                    sr.Dispose();
            }


            try
            {
                try
                {
                    timer1.Interval = TimerInterval;
                    if (edtWorkerSubFix.Text == "")
                    {
                        edtWorkerSubFix.Text = PCName;

                    }
                    //MessageBox.Show(Usercode);
                    //if (Usercode.Replace(" ", "") == "" || Usercode.Length > 20)
                    //{

                    //    Usercode = "";
                    //}
                    //  MessageBox.Show(Usercode);
                    timer1.Start();
                    btnStart.PerformClick();

                }
                catch (Exception ex) { }
                UpdateButton();
            }

            catch (Exception ex) { }

            if (StartWhenStarApp == 0) btnStop.PerformClick();

            //Load teamviwerid
            try
            {
                if (StartDetecterWhenOpen == 1)
                {
                    System.Diagnostics.Process.Start("DetecterKill.exe");
                }
            }
            catch (Exception ex)
            {

            }

            UpdateButton();
        }



        private void START_Click(object sender, EventArgs e)
        {
            MinizimeInterval = 0;
            SendCommand = 0;
            try
            {
                try
                {
                    IP = DBase.GetIP();
                }
                catch (Exception ex) { }

                Reject = 0;
                CgminerRestarting = 1;
                IsStop = 0;
                Accepted = 0;
                PinShare = 0;
                AcceptedDate = DateTime.Now;
                UpdateIni();

                AutoRestart_Seconds = DBase.IntReturn(edtAutoReset.Value == 0 ? 999999 : edtAutoReset.Value);
                
             
                interval = 0;
                

                PList = Process.GetProcesses();
                foreach (Process p in PList)
                {

                    string processname = p.ProcessName;
                    if (processname == "cmd" || processname.ToLower() == "WerFault".ToLower())
                    {
                        try
                        {
                            p.Kill();
                        }
                        catch (Exception ex)
                        {// MessageBox.Show(ex.ToString()); 
                        }
                    }

                }

                foreach (Process P in Process.GetProcesses())
                {
                    if (P.ProcessName.ToString().ToLower() == excuteDevice || P.ProcessName.ToString().ToLower() == "conhost")
                    {
                        P.Kill();
                    }
                }


                Startup = 0;

                if (Usercode.Replace(" ","") == "") Usercode = "";
                dt = DStatic.CoinInfo(Usercode, UserPassword);
                if (dt.Rows.Count <= 0)
                {

                    DStatic.ShowMessage("Can't get info from Usercode : " + Usercode + " | Password : " + UserPassword, 700);

                    return;

                }
                currentCoin = DBase.StringReturn(dt.Rows[0]["COIN"]);
                dtDetail = DStatic.CoinInfo_DetailConfig(Usercode, currentCoin);
                if (dtDetail.Rows.Count <= 0)
                {
                    LoadCoins();
                    return;

                }
                string URL = DBase.StringReturn(dtDetail.Rows[0]["URL"]);
                UseAddress = DBase.IntReturn(dtDetail.Rows[0]["USEADDRESS"]);
                
                ALGO = DBase.StringReturn(dtDetail.Rows[0]["ALGO"]);
              
                edtURL.Text = URL;
                currentURL = URL;
                string UserName = DBase.StringReturn(dtDetail.Rows[0]["USERNAME"]);
                

                currentWorker = UserName + "." + edtWorkerSubFix.Text;

                if (UseAddress == 0)
                {
                    UserName = UserName + "." + edtWorkerSubFix.Text;
                }

                TeamviewerID = DStatic.GetTeamviewerID();
                this.Text = Usercode + " - Miner - " + edtWorkerSubFix.Text + " ( " + MD5.Substring(MD5.Length - 5, 5) + " ) ";
                cmsUpdate.Text = "Update ( " + CurrentVersion + " )";
                string Pass = DBase.StringReturn(dtDetail.Rows[0]["PASSWORD"]);


                string Config = edtConfigSCRYPT.Text;

                if (ALGO == "X11")
                {
                    Config = edtConfigX11.Text;
                }

                if (ALGO == "X13")
                {
                    Config = edtConfigX13.Text;
                }

                if (ALGO == "GROESTL")
                {
                    Config = edtConfigX13.Text;
                }

                //-o http://gld.minepool.net:3333 -u tramphuochuy.7 -p asdasd --scrypt 


                string[] URLS = URL.Split(',');
                PoolConfigCount = URLS.Length;

                URL = "";
                for (int i = 0; i < URLS.Length;i++ )
                {
                    string u = URLS[i];

                    if (ALGO == "X11")
                    {
                        URL = URL + "   -o " + u + " -u " + UserName + " -p " + Pass + " ";  
                    }
                    else URL = URL + "   -o " + u + " -u " + UserName + " -p " + Pass + "  ";   

                }

                    cmd = Config + "  " + URL + "    --api-listen   --api-allow W:127.0.0.1 --api-port 4028";


                //edtConfigSum.Text = cmd;

                if (ALGO == "X11")
                {
                    path = Application.StartupPath + "\\SGMINER\\AutoCoin.bat";
                }

                else if (ALGO == "X13")
                {
                    path = Application.StartupPath + "\\X13\\AutoCoin.bat";
                }
                else if (ALGO == "GROESTL")
                {
                    path = Application.StartupPath + "\\SGMINER\\AutoCoin.bat";
                }

                else if (ALGO == "NFACTOR")
                {
                    path = Application.StartupPath + "\\NFACTOR\\AutoCoin.bat";
                }


                else 
                {
                    path = Application.StartupPath + "\\CGMINER\\AutoCoin.bat";
                }


                string folderPath = Application.StartupPath;
                
                if (ALGO == "X11")
                {
                    folderPath = Application.StartupPath + "\\SGMINER";
                }

                else if (ALGO == "X13")
                {
                    folderPath = Application.StartupPath + "\\X13";
                }

                else if (ALGO == "GROESTL")
                {
                    folderPath = Application.StartupPath + "\\SGMINER";
                }

                else if (ALGO == "NFACTOR")
                {
                    folderPath = Application.StartupPath + "\\NFACTOR";
                }

                else
                    folderPath = Application.StartupPath + "\\CGMINER";
                

                cmd = "cd " + folderPath + Environment.NewLine + cmd;


                //cmd = "setx GPU_MAX_ALLOC_PERCENT 100" + Environment.NewLine + cmd ;

                try
                {
                    System.IO.File.WriteAllText(path, cmd);
                }
                catch (Exception ex) 
                { // MessageBox.Show(ex.ToString()); 
                }

                try
                {
                    //MessageBox.Show(cmd);
                    if (cmd.Contains("cgminer") )
                    {
                       // MessageBox.Show("cot");
                       // MessageBox.Show(path);



                        currentCoinProcess = System.Diagnostics.Process.Start(path);
                      
                        currentCoinProcessID = currentCoinProcess.Id;
                        currentCoinProcessName = currentCoinProcess.ProcessName;
                    }
                    else if ( !cmd.Contains("cgminer") && edtConfigSCRYPT.Text != "")
                    {
                       // MessageBox.Show("no");
                        btnStop.PerformClick();
                    }
                }
                catch (Exception ex) {
                    
                   // MessageBox.Show(ex.ToString());
                
                }


               
                    LoadCoins();
                
            }
            catch (Exception ex)
            {
              // MessageBox.Show(ex.ToString());
            }

            try
            {
                timer1.Start();
            }
            catch (Exception ex) { }

            UpdateButton();
        }

        private void STOP(object sender, EventArgs e)
        {
            timer1.Stop();
            this.Text = this.Text + " | STOPED + ( " + MD5.Substring(MD5.Length-5,5) + " ) " + Usercode ;
            IsStop = 1;
            try
            {
                foreach (Process P in Process.GetProcesses())
                {

                    if (P.ProcessName.ToString().ToLower() == excuteDevice || P.ProcessName.ToString().ToLower() == "conhost" || P.ProcessName.ToString().ToLower() == "cmd")
                    {
                        P.Kill();
                    }

                }
            }
            catch (Exception ex) { }
            timer1.Start();
        }

        int CheckProcessInterval = 1;
        int MonitorInterval = 5;
        int MinizimeInterval = 0;
        int GetAPIInterval = 1;

        //TIMER
        private void TIMER_Tick(object sender, EventArgs e)
        {
            try
            {
                if (edtConfigSCRYPT.Text == "")
                {
                    try
                    {
                        string ConfigAllString = DStatic.Config_Get(PCID);

                        if (ConfigAllString == "NO CONFIG")
                        {
                            Usercode = "test";
                            edtConfigSCRYPT.Text = "cgminer --scrypt   -I 13 -g 2 -w 256 --lookup-gap 2 --shaders 2048  --gpu-fan 100 ";
                            edtConfigX11.Text = "cgminer -k x11mod   -I 19 -g 2 -w 256 --lookup-gap 2 --shaders 2048  --gpu-fan 100";
                            edtConfigX13.Text = "cgminer -k x13mod   -I 19 -g 2 -w 256 --lookup-gap 2 --shaders 2048  --gpu-fan 100";
                            
                            btnStart.PerformClick();
                        
                        }

                        else 
                        {

                            string[] ConfigAll = ConfigAllString.Split(';');

                            try
                            {
                                Usercode = ConfigAll[0];

                                edtWorkerSubFix.Text = ConfigAll[1];

                                edtConfigSCRYPT.Text = ConfigAll[2];
                                edtConfigX11.Text = ConfigAll[3];
                                edtConfigGROESTL.Text = ConfigAll[4];
                                edtConfigX13.Text = ConfigAll[5];
                            }
                            catch (Exception ex) { }

                        }
                    }

                    catch (Exception ex)
                    {

                    }
                }
            }
            catch (Exception ex) { }

            MinizimeInterval++;


            Time2Kill = MaxLastAcceptedSeconds - (DateTime.Now - AcceptedDate).TotalSeconds;
            

            if (IsStop == 0) lbTime2Kill.Text = "| T2K :" + Time2Kill.ToString() + " | RSTing : " +  (CgminerRestarting == 1 ? "Yes" : "No")  ;
            
            if (Time2Kill <= 0 && IsStop == 0 )
            {
                if (CgminerRestarting == 1) AcceptKillCount_Restart++;
                else AcceptKillCount++;

                btnStart.PerformClick();
                CgminerRestarting = 1;
            }



            if (continueTimer == 0) return;


            continueTimer = 0;

            lbTime.Text = DateTime.Now.ToString("hh:mm:ss");
            try
            {
                
                CheckProcessInterval++;
                if (CheckProcessInterval % 3 == 0 && IsStop == 0)
                {
                    CheckProcess_RunIfNoExist("CGMINER");
                    CheckProcess_StopIfNotResponding("CGMINER");

                    CheckProcessInterval = 1;
                }
            }
            catch (Exception ex) { }

            if ( IsStop == 1 ) this.Text =  Usercode + " | STOPED ( " + MD5 + " ) ";

            //edtMaxDiff.Value = MaxDiff;
            edtMaxReject.Value = MaxReject;
            edtMaxLastAccept.Value = MaxLastAcceptedSeconds;

            try
            {
                try
                {
                    if ( IsStop==0)
                    {
                        ApiWorker A = new ApiWorker("127.0.0.1", 4028);

                        string api = Environment.NewLine + A.Request("stats");
                        string splitChar = "Max Diff=";

                        cgminerversion = DBase.JSONSub(api, "Description=", "|");

                        api = DBase.JSONSub(api, splitChar, ",Min Diff");// api.Substring(api.IndexOf(splitChar) + splitChar.Length, 3);
                        PoolDiff = DBase.DecimalReturn(api);
                        if (PoolDiff != MaxDiff && PoolDiff != 0 && PoolDiff > MaxDiff && UseMaxDiff == 1)
                        {

                            PoolDiff = 0;
                            if (KillProcess == 1)
                            {
                                KillCount++;
                                Reject = 0;
                                AcceptedDate = DateTime.Now;
                                TotalAcceptBuffer = TotalAcceptBuffer + Accepted;
                                Accepted = 0;
                                btnStart.PerformClick();
                                CgminerRestarting = 1;
                            }
                            else
                            {
                                PinShare++;
                                if (PinShare >= MaxPinShare)
                                {
                                    RestartCount++;
                                    Reject = 0;
                                    TotalAcceptBuffer = TotalAcceptBuffer + Accepted;
                                    Accepted = 0;
                                    AcceptedDate = DateTime.Now;
                                    A.Request("restart");
                                    //btnStart.PerformClick();
                                    CgminerRestarting = 1;
                                    PinShare = 0;
                                    RSS = DateTime.Now;
                                    isReseting = 1;
                                }

                            }
                        }
                        api = Environment.NewLine + A.Request("summary");
                        splitChar = "Rejected=";
                        string r = api.Substring(api.IndexOf(splitChar) + splitChar.Length, 2);
                        r = DBase.JSONSub(api,splitChar, ",");
                        Reject = DBase.IntReturn(r);

                        if (Reject > MaxReject)
                        {
                            Reject = 0;
                            RejectKillCount++;
                            AcceptedDate = DateTime.Now;
                            TotalAcceptBuffer = TotalAcceptBuffer + Accepted;
                            Accepted = 0;
                            //A.Request("restart");
                            btnStart.PerformClick();
                            PinShare = 0;
                            CgminerRestarting = 1;
                        }

                        try
                        {
                            splitChar = "Accepted=";
                           // r = api.Substring(api.IndexOf(splitChar) + splitChar.Length, 2);

                            r = DBase.JSONSub(api, splitChar, ",");
                            CurrentAccepted = DBase.IntReturn(r);

                            if (CurrentAccepted != Accepted && CurrentAccepted > 0)
                            {
                                Accepted = CurrentAccepted;
                                CgminerRestarting = 0;
                                AcceptedDate = DateTime.Now;

                                lbLastAcceptDate.Text = "| LA : " + AcceptedDate.ToString("hh:mm:ss");
                                if (isReseting == 1)
                                {
                                    isReseting = 0;
                                    RSSTime = (AcceptedDate - RSS).TotalSeconds;
                                }
                            }

                            //MHS av=
                            splitChar = "MHS av=";

                            r = DBase.JSONSub(api, splitChar, ",");// api.Substring(api.IndexOf(splitChar) + splitChar.Length, 4).Replace(",", "").Replace(".", "");
                            speedMh = DBase.IntReturn( DBase.FloatReturn(r) * 1000 ) ;
                            
                        }
                        catch (Exception ex) { }

                        //DEVS STATUS=S,When=1388739859,Code=9,Msg=1 GPU(s) - 0 ASC(s) - 0 PGA(s) - ,Description=cgminer 3.2.0|GPU=0,Enabled=Y,Status=Alive,Temperature=94.00,Fan Speed=1537,Fan Percent=36,GPU Clock=635,Memory Clock=1250,GPU Voltage=0.000,GPU Activity=100,Powertune=10,MHS av=0.47,MHS 5s=0.33,Accepted=3,Rejected=0,Hardware Errors=0,Utility=35.43,Intensity=13,Last Share Pool=0,Last Share Time=1388739854,Total MH=2.4084,Diff1 Work=29,Difficulty Accepted=48.00000000,Difficulty Rejected=0.00000000,Last Share Difficulty=16.00000000,Last Valid Work=1388739859|
                        api = A.Request("devs");
                       

                        String apiTemp = DBase.JSONSub(api, "|", true);

                        int w = 0;
                        while (apiTemp.Length > 10)
                        {
                            String temp = DBase.ToDecimal(DBase.JSONSub(apiTemp, "Temperature=", ","), ".", "").ToString();
                            temp = DBase.IntReturn(temp).ToString();
                            if (w == 0)
                            {
                                GPUSTATS_TEMP = temp;
                            }

                            else
                            {
                                GPUSTATS_TEMP = GPUSTATS_TEMP +","+ temp;
                            }

                            apiTemp = DBase.JSONSub(apiTemp, "|", true);
                            w++;

                        }


                        String apiMhz = DBase.JSONSub(api, "|", true);

                       
                        w = 0;
                        while (apiMhz.Length > 10)
                        {
                            string temp = DBase.JSONSub(apiMhz, "MHS 5s=", ",");
                        //    MessageBox.Show(temp);
                            temp = (DBase.ToDecimal(temp, ".", "") * 1000).ToString();
                           // MessageBox.Show(temp);
                            temp = DBase.IntReturn(temp).ToString();
                            if (w == 0)
                            {
                                GPUSTATS_MH = temp;
                            }

                            else
                            {
                                GPUSTATS_MH = GPUSTATS_MH + "," + temp;
                            }

                            apiMhz = DBase.JSONSub(apiMhz, "|", true);
                            w++;

                        }

                     // Remove Pool when use X11

                        if (ALGO == "X11" && SendCommand == 0)
                        {
                           
                            
                            api = A.Request("pools");
                            PoolAPICount = DBase.IntReturn(DBase.JSONSub(api, "Msg=", " "));

                            if (PoolAPICount > PoolConfigCount)
                            {
                              
                               RequestResult = A.Request("switchpool|1");
                               RequestResult =  A.Request("removepool|0");
                            }

                            api = A.Request("pools");
                            PoolAPICount = DBase.IntReturn(DBase.JSONSub(api, "Msg=", " "));

                            if (PoolAPICount == PoolConfigCount)
                            {
                                SendCommand = 1;
                                DBase.ShowMessage("Pool 0 removed ! ", 400);

                            }

                            else
                            {
                                DBase.ShowMessage("Can't Remove Pool " , 400);
                            }
                        }
                    }

                }
                catch (Exception ex) { }

              

              
            }
            catch (Exception ex) { }

        
            //Monitor
            try
            {
                 MonitorInterval++;
                 Time2Kill = MaxLastAcceptedSeconds - (DateTime.Now - AcceptedDate).TotalSeconds;
                 Time2Kill =Math.Round((double)Time2Kill,2);
                if (MonitorInterval%MonitorIntervalValue == 0 && edtWorkerSubFix.Text != "0" && MonitorData==1)
                {
                    
                    string versionMD5 = cgminerversion  + "-" + PCName + "-" + MD5.Substring(MD5.Length - 6, 6);
                    if (cgminerversion == "")
                    {
                        versionMD5 = "Restarting";
                        
                    }

                    string MonitorConfig = edtConfigSCRYPT.Text ;

                    if (ALGO == "X11")
                    {
                        MonitorConfig = edtConfigX11.Text;
                    }
                    else if (ALGO == "X13")
                    {
                        MonitorConfig = edtConfigX13.Text;
                    }

                    else if (ALGO == "GROESTL")
                    {
                        MonitorConfig = edtConfigX13.Text;
                    }

                    else if (ALGO == "NFACTOR")
                    {
                        MonitorConfig = edtConfigGROESTL.Text;
                    }

                    if (Usercode != "" && currentWorker != "")
                    {

                        DStatic.MonitorAdd(Usercode, currentCoin, currentURL, currentWorker, Accepted, "Monitored", versionMD5, speedMh.ToString() + " KH/s", TeamviewerID, TeamviewerPass, MaxDiff, MaxReject, MaxLastAcceptedSeconds, STATS, MonitorData, DBase.IntReturn(RSSTime).ToString(), IP, GPUSTATS_TEMP, Time2Kill.ToString(), TotalAcceptBuffer + Accepted, GPUSTATS_MH, PoolDiff, MonitorConfig, PCID, PCMAC, edtWorkerSubFix.Text, ALGO);

                    }
                  }
            }

            catch (Exception ex) {
               // MessageBox.Show(ex.ToString());
            }

            try
            {
                if ((DateTime.Now - AcceptedDate).TotalSeconds > MaxLastAcceptedSeconds && Accepted > 0 && IsStop==0 )
                {
                    if (CgminerRestarting == 0)
                    {
                        TotalAcceptBuffer = TotalAcceptBuffer + Accepted;
                        Accepted = 0;
                        if (CgminerRestarting == 1) AcceptKillCount_Restart++;
                        else AcceptKillCount++;
                        AcceptedDate = DateTime.Now;
                        btnStart.PerformClick();
                        CgminerRestarting = 1;
                    }
                    else
                    {
                        if ((DateTime.Now - AcceptedDate).TotalSeconds > 30)
                        {
                            TotalAcceptBuffer = TotalAcceptBuffer + Accepted;
                            Accepted = 0;
                            if (CgminerRestarting == 1) AcceptKillCount_Restart++;
                            else AcceptKillCount++;
                            AcceptedDate = DateTime.Now;
                            btnStart.PerformClick();
                            CgminerRestarting = 1;
                        }
                    }
                }


            }
            catch (Exception ex) { }

            STATS = KillCount.ToString() + " DK-" + RejectKillCount.ToString() + " RJ-" + AcceptKillCount.ToString() + " AK-" + AcceptKillCount_Restart +" AKR" ;
            lbStat.Text = "| Stats : " + STATS;
            lbMaxDiff.Text = "| MaxDiff : " + MaxDiff.ToString();
            lbMaxReject.Text = "| MaxReject : " + MaxReject.ToString();
            lbMonitorData.Text = MonitorData == 1 ? "| Monitor Data :Yes" : "| Monitor Data :No - " + DBase.JSONSub( DStatic.constring,",",";") ;
            lbPoolDiff.Text = "| Pool Diff : " + PoolDiff + "/" + MaxDiff.ToString(); ;
            lbReject.Text = "| Rejected : " + Reject.ToString() + "/" + MaxReject.ToString();
            lbAccepted.Text = "| Accepted : " + CurrentAccepted.ToString() + "/"+ (TotalAcceptBuffer + CurrentAccepted).ToString() ;
            lbSpeed.Text = speedMh.ToString() + " Kh/s";

            try
            {
                BG.RunWorkerAsync();
            }
            catch (Exception ex) { };
            
                 
        }

        public void UpdateAutoRestart()
        {
            try
            {
                dt = DStatic.CoinInfo(Usercode, UserPassword);
                String ServerCoin = DBase.StringReturn(dt.Rows[0]["COIN"]);
                dtDetail = DStatic.CoinInfo_DetailConfig(Usercode, ServerCoin);
                int AuRes0 = DBase.IntReturn(dt.Rows[0]["AUTORESTART"]);
                int AuRes1 = DBase.IntReturn(dtDetail.Rows[0]["AUTORESTART"]);
                if (ForceRestart == 1) AuRes1 = 1;
                AutoRestart = AuRes1;

                lbAuto.Text = "AutoReset Times ( Second )";

                btnSave.Enabled = edtAutoReset.Enabled = (AuRes1 == 1 ? true : false);
            }
            catch (Exception ex) { }

        }

        
       
        public void LoadCoins()
        {
          
            try
            {
                panContent.Controls.Clear();
                dtCoins = DStatic.CoinList(Usercode);
                panContent.Visible = false;

                if (Usercode.ToUpper() == "TEST")
                {
                    NoCoinWarning N = new NoCoinWarning();
                    panContent.Controls.Add(N);
                    panContent.Visible = true;
                }

                if (dtCoins.Rows.Count == 0)
                {
                    if (Usercode == "")
                    {
                       
                        //NoCoinWarning N = new NoCoinWarning();
                        //panContent.Controls.Add(N);
                        //panContent.Visible = true;
                    }

                    return;

                }
                foreach (DataRow dr in dtCoins.Rows)
                {
                    Coin C = new Coin();
                    C.M = this;
                    C.CoinName = DBase.StringReturn(dr["COIN"]);
                    C.WorkerName = DBase.StringReturn(dr["USERNAME"]);
                    C.Link = DBase.StringReturn(dr["LINK"]);
                    C.Pass = DBase.StringReturn(dr["PASSWORD"]);
                    C.AutoRestart = DBase.IntReturn(dr["AUTORESTART"]);
                    C.UseMaxDiff = DBase.IntReturn(dr["USEMAXDIFF"]);
                    C.UseAddress = DBase.IntReturn(dr["USEADDRESS"]);
                    C.URL = DBase.StringReturn(dr["URL"]);
                    C.MaxDiff = DBase.DecimalReturn(dr["MAXDIFF"]);
                    C.MaxReject = DBase.IntReturn(dr["MAXREJECT"]);
                    C.MaxSecond = DBase.IntReturn(dr["MAXSECOND"]);
                    C.Remark = DBase.StringReturn(dr["REMARK"]);
                    C.UserCode = Usercode;
                    C.API = DBase.StringReturn(dr["API"]);
                   
                    C.ALGO = DBase.StringReturn(dr["ALGO"]);
                    if (C.CoinName == currentCoin)
                    {
                        C.isSelected = 1;
                        if ( ShowMonitor == 0 ) panContent.Controls.Add(C);
                        break;

                    }
                    else C.btnCheck.Checked = false;

                   


                }


                foreach (DataRow dr in dtCoins.Rows)
                {
                    Coin C = new Coin();
                    C.M = this;
                    C.CoinName = DBase.StringReturn(dr["COIN"]);
                    C.WorkerName = DBase.StringReturn(dr["USERNAME"]);
                    C.Link = DBase.StringReturn(dr["LINK"]);
                    C.Pass = DBase.StringReturn(dr["PASSWORD"]);
                    C.UseMaxDiff = DBase.IntReturn(dr["USEMAXDIFF"]);
                    C.AutoRestart = DBase.IntReturn(dr["AUTORESTART"]);
                    C.UseAddress = DBase.IntReturn(dr["USEADDRESS"]);
                    C.MaxDiff = DBase.DecimalReturn(dr["MAXDIFF"]);
                    C.MaxReject = DBase.IntReturn(dr["MAXREJECT"]);
                    C.MaxSecond = DBase.IntReturn(dr["MAXSECOND"]);
                    C.Remark = DBase.StringReturn(dr["REMARK"]);


                    C.API = DBase.StringReturn(dr["API"]);
                    
                    C.ALGO = DBase.StringReturn(dr["ALGO"]);
                 

                    if (C.CoinName == currentCoin)
                    {
                        continue;

                    }
                    else C.btnCheck.Checked = false;

                
                    C.URL = DBase.StringReturn(dr["URL"]);
                    C.UserCode = Usercode;
                    if (IsShowCoin == 1)
                    {
                        panContent.Controls.Add(C);
                    }


                }

                UpdateAutoRestart();

                //Price
                try
                {
                    //  count.RunWorkerAsync();
                }
                catch (Exception ex)
                {

                }

                if (IsShowCoin == 0 && ShowMonitor == 1)
                {


                        MonitorPanel M = new MonitorPanel();
                        M.Width = panContent.Width - 10;
                        M.isEnableAPI = EnableAPIInMonitorMode;
                        M.isEnableAM= EnableAMInMonitorMode;
                        M.usercode = Usercode;
                        M.M = this;
                        panContent.Controls.Add(M);
                        String UserMonitor = "    " + Usercode;
                        //btnShowMonitor.Text = UserMonitor.Substring(UserMonitor.Length - 4, 4);
                   

                        if (ShowMonitor2==1)
                        {
                            String UserMonitor2 = "";

                            try
                            {
                                sr = File.OpenText("AutoCoinConfig.ini");
                                string line = sr.ReadToEnd();
                                String[] SS = line.Split(';');
                                UserMonitor2 = SS[5].ToString();
                                sr.Dispose();
                            }
                            catch (Exception ex)
                            {
                                if (sr != null)
                                    sr.Dispose();
                            }

                            if (UserMonitor2 != "")
                            {
                                
                                MonitorPanel M2 = new MonitorPanel();
                                M2.isEnableAPI = EnableAPIInMonitorMode;
                                
                                M2.Width = panContent.Width - 10;
                                M2.usercode = UserMonitor2;
                                UserMonitor2 = "    " + UserMonitor2;
                                M2.M = this;
                                btnMonitor2.Text = UserMonitor2.Substring(UserMonitor2.Length - 4, 4);
                                panContent.Controls.Add(M2);

                            }

                        }

                        if (ShowMonitor3 == 1)
                        {
                            String UserMonitor3 = "";

                            try
                            {
                                sr = File.OpenText("AutoCoinConfig.ini");
                                string line = sr.ReadToEnd();
                                String[] SS = line.Split(';');
                                UserMonitor3 = SS[6].ToString();
                                sr.Dispose();
                            }
                            catch (Exception ex)
                            {
                                if (sr != null)
                                    sr.Dispose();
                            }

                            if (UserMonitor3 != "")
                            {
                                MonitorPanel M3 = new MonitorPanel();
                                M3.isEnableAPI = EnableAPIInMonitorMode;
                                M3.Width = panContent.Width - 10;
                                M3.usercode = UserMonitor3;
                                UserMonitor3 = "    " + UserMonitor3;
                                M3.M = this;
                                btnMonitor3.Text = UserMonitor3.Substring(UserMonitor3.Length - 4, 4);

                                panContent.Controls.Add(M3);

                            }

                        }

                        if (ShowMonitor4 == 1)
                        {
                            String UserMonitor4 = "";

                            try
                            {
                                sr = File.OpenText("AutoCoinConfig.ini");
                                string line = sr.ReadToEnd();
                                String[] SS = line.Split(';');
                                UserMonitor4 = SS[7].ToString();
                                sr.Dispose();
                            }
                            catch (Exception ex)
                            {
                                if (sr != null)
                                    sr.Dispose();
                            }

                            if (UserMonitor4 != "")
                            {

                                MonitorPanel M4 = new MonitorPanel();
                                M4.isEnableAPI = EnableAPIInMonitorMode;
                                M4.Width = panContent.Width - 10;
                                M4.usercode = UserMonitor4;
                                UserMonitor4 = "    " + UserMonitor4;
                                M4.M = this;
                                btnMonitor4.Text = UserMonitor4.Substring(UserMonitor4.Length - 4, 4);
                                panContent.Controls.Add(M4);

                            }

                        }

                        if (ShowMonitor5 == 1)
                        {
                            String UserMonitor5 = "";

                            try
                            {
                                sr = File.OpenText("AutoCoinConfig.ini");
                                string line = sr.ReadToEnd();
                                String[] SS = line.Split(';');
                                UserMonitor5 = SS[8].ToString();
                                sr.Dispose();
                            }
                            catch (Exception ex)
                            {
                                if (sr != null)
                                    sr.Dispose();
                            }

                            if (UserMonitor5 != "")
                            {

                                MonitorPanel M5 = new MonitorPanel();
                                M5.isEnableAPI = EnableAPIInMonitorMode;
                                M5.Width = panContent.Width - 10;
                                M5.usercode = UserMonitor5;
                                UserMonitor5 = "    " + UserMonitor5;
                                M5.M = this;
                                btnMonitor5.Text = UserMonitor5.Substring(UserMonitor5.Length-4,4);
                                panContent.Controls.Add(M5);

                            }

                        }

                        if (ShowMonitor6 == 1)
                        {
                            String UserMonitor6 = "";

                            try
                            {
                                sr = File.OpenText("AutoCoinConfig.ini");
                                string line = sr.ReadToEnd();
                                String[] SS = line.Split(';');
                                UserMonitor6 = SS[9].ToString();
                                sr.Dispose();
                            }
                            catch (Exception ex)
                            {
                                if (sr != null)
                                    sr.Dispose();
                            }

                            if (UserMonitor6 != "")
                            {

                                MonitorPanel M6 = new MonitorPanel();
                                M6.isEnableAPI = EnableAPIInMonitorMode;
                                M6.Width = panContent.Width - 10;
                                M6.usercode = UserMonitor6;
                                UserMonitor6 = "    " + UserMonitor6;
                                M6.M = this;
                                btnMonitor6.Text = UserMonitor6.Substring(UserMonitor6.Length - 4, 4);
                                panContent.Controls.Add(M6);

                            }

                        }

                        if (ShowMonitor7 == 1)
                        {
                            String UserMonitor7 = "";

                            try
                            {
                                sr = File.OpenText("AutoCoinConfig.ini");
                                string line = sr.ReadToEnd();
                                String[] SS = line.Split(';');
                                UserMonitor7 = SS[10].ToString();
                                sr.Dispose();
                            }
                            catch (Exception ex)
                            {
                                if (sr != null)
                                    sr.Dispose();
                            }

                            if (UserMonitor7 != "")
                            {

                                MonitorPanel M7 = new MonitorPanel();
                                M7.isEnableAPI = EnableAPIInMonitorMode;
                                M7.Width = panContent.Width - 10;
                                M7.usercode = UserMonitor7;
                                UserMonitor7 = "    " + UserMonitor7;
                                M7.M = this;
                                btnMonitor7.Text =  UserMonitor7.Substring(UserMonitor7.Length - 4, 4);
                                panContent.Controls.Add(M7);

                            }

                        }

                }
            }
            catch (Exception ex) {
               // MessageBox.Show(ex.ToString()); 
            }

            try
            {
                        if (MonitorData == 0)
                            {
                                DStatic.MonitorDataUpdate(Usercode, currentWorker, "No");

                            }
            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.ToString());
            }

            panContent.Visible = true;

        }

        public void CheckProcess_RunIfNoExist(string processname)
        {
            try
            {
                Process[] P = Process.GetProcesses();
                int kq = 0;
                foreach (Process p in P)
                {
                    string pname = p.ProcessName;
                    if (pname.ToUpper() == processname.ToUpper() | pname.ToUpper() == "CMD")
                    {
                        kq++;
                    }
                }

                if (kq > 0)
                {

                }

                else
                {
                    //DHuy.ShowMessage("Manual start Path due to no Process Step 1", 600);
                    //btnStart.PerformClick();
                    System.Diagnostics.Process.Start(path);

                }

               
               
               
            }
            catch (Exception ex) { }
        }

        public void CheckProcess_StopIfNotResponding(string processname)
        {
            try
            {
                Process[] P = Process.GetProcesses();
                int kq = 0;
                foreach (Process p in P)
                {
                    string pname = p.ProcessName;
                    if ((pname.ToUpper() == processname.ToUpper() && p.Responding == false) || pname.ToLower() == "WerFault".ToLower())
                    {
                        p.Kill();
                    }
                }
            }
            catch (Exception ex) { }

        }

        private void CONFIG(object sender, EventArgs e)
        {
            Config A = new Config(); // U = new U
            timer1.Stop();
            A.ShowDialog();
            if (A.res == 1)
            {
                try
                {
                    Usercode = A.AccountName;
                    UserPassword = A.Password;

                    AcceptKillCount = 0;
                    RejectKillCount = 0;
                    RestartCount = 0;
                    ForceKillCount = 0;
                    KillCount = 0;
                    //TotalAcceptBuffer = 0;


                    btnStart.PerformClick();
                    btnLockConfig.PerformClick();
                }
                catch (Exception ex)
                {
                    //  MessageBox.Show(ex.ToString());
                }
            }

            timer1.Start();
        }

        private void ADD_COIN(object sender, EventArgs e)
        {
           timer1.Stop();
            try
            {
                Add_Coin A = new Add_Coin();
                A.usercode = Usercode;
                A.ShowDialog();
                if (A.res == 1)
                {
                   // LoadCoins();
                    if (ShowMonitor == 0 && IsShowCoin == 0)
                    {
                        DataTable dtmore = DStatic.CoinList_One(Usercode, A.COINNAME);
                        foreach (DataRow dr in dtmore.Rows)
                        {
                            Coin C = new Coin();
                            C.M = this;
                            C.CoinName = DBase.StringReturn(dr["COIN"]);
                            C.WorkerName = DBase.StringReturn(dr["USERNAME"]);
                            C.Link = DBase.StringReturn(dr["LINK"]);
                            C.Pass = DBase.StringReturn(dr["PASSWORD"]);
                            C.UseMaxDiff = DBase.IntReturn(dr["USEMAXDIFF"]);
                            C.AutoRestart = DBase.IntReturn(dr["AUTORESTART"]);
                            C.UseAddress = DBase.IntReturn(dr["USEADDRESS"]);
                            C.MaxDiff = DBase.DecimalReturn(dr["MAXDIFF"]);
                            C.MaxReject = DBase.IntReturn(dr["MAXREJECT"]);
                            C.MaxSecond = DBase.IntReturn(dr["MAXSECOND"]);
                            C.Remark = DBase.StringReturn(dr["REMARK"]);


                            C.API = DBase.StringReturn(dr["API"]);

                            C.ALGO = DBase.StringReturn(dr["ALGO"]);


                            if (C.CoinName == currentCoin)
                            {
                                continue;

                            }
                            else C.btnCheck.Checked = false;


                            C.URL = DBase.StringReturn(dr["URL"]);
                            C.UserCode = Usercode;
                           
                                panContent.Controls.Add(C);
                            


                        }
                    }
                }
            }
            catch (Exception ex) { }
            timer1.Start();
        }

        private void UPDATE(object sender, EventArgs e)
        {
            try
            {
                foreach (Process P in Process.GetProcesses())
                {

                    if (P.ProcessName.ToString().ToLower() == excuteDevice || P.ProcessName == "DetecterKill")
                    {
                        P.Kill();
                    }

                }

                DataTable fileinfo = new DataTable();
                Process Pcurrent = System.Diagnostics.Process.GetCurrentProcess();
                int num = DStatic.DownloadFile("UpdateFire.exe");
                if (num > 0)
                {
                    Process[] PList = System.Diagnostics.Process.GetProcesses();
                    foreach (Process P in PList)
                    {
                        if (P.ProcessName.ToLower() == Pcurrent.ProcessName.ToLower() && P.Id != Pcurrent.Id)
                        {
                            P.Kill();
                        }
                    }
                    System.Diagnostics.Process.Start("UpdateFire.exe");
                    Pcurrent.Kill();

                }
            }
            catch (Exception ex) { }
        }

        private void UPDATEEX(object sender, EventArgs e)
        {
            try
            {
                foreach (Process P in Process.GetProcesses())
                {

                    if (P.ProcessName.ToString().ToLower() == excuteDevice || P.ProcessName == "DetecterKill")
                    {
                        P.Kill();
                    }

                }

                DataTable fileinfo = new DataTable();
                Process Pcurrent = System.Diagnostics.Process.GetCurrentProcess();
                int num = DStatic.DownloadFile("UpdateFireExtract.exe");
                if (num > 0)
                {
                    Process[] PList = System.Diagnostics.Process.GetProcesses();
                    foreach (Process P in PList)
                    {
                        if (P.ProcessName.ToLower() == Pcurrent.ProcessName.ToLower() && P.Id != Pcurrent.Id)
                        {
                            P.Kill();
                        }
                    }
                    System.Diagnostics.Process.Start("UpdateFireExtract.exe");
                    Pcurrent.Kill();

                }
            }
            catch (Exception ex) { }
        }


        public void TestOnly(string COINTEST)
        {

            try
            {


                dtDetail = DStatic.CoinInfo_DetailConfig(Usercode, COINTEST);
                if (dtDetail.Rows.Count <= 0)
                {
                    LoadCoins();
                    return;

                }
                string URL = DBase.StringReturn(dtDetail.Rows[0]["URL"]);
                UseAddress = DBase.IntReturn(dtDetail.Rows[0]["USERADDRESS"]);
                edtURL.Text = URL;
                string UserName = DBase.StringReturn(dtDetail.Rows[0]["USERNAME"]);

                if (UseAddress == 0)
                {
                    UserName = UserName + "." + edtWorkerSubFix.Text;
                }

                else
                {
                    UserName = UserName;
                }



                this.Text = Usercode + " - Miner - " + edtWorkerSubFix.Text + " ( " + MD5.Substring(MD5.Length-5,5) + " )";
                cmsUpdate.Text = "Update ( " + CurrentVersion + " ) | " + timer1.Interval.ToString();
                string Pass = DBase.StringReturn(dtDetail.Rows[0]["PASSWORD"]);
                string Config = edtConfigSCRYPT.Text;

                //-o http://gld.minepool.net:3333 -u tramphuochuy.7 -p asdasd --scrypt 
                cmd = Config + "   -o " + URL + " -u " + UserName + " -p " + Pass;
                //edtConfigSum.Text = cmd;
                string path = Application.StartupPath + "\\AutoCoinTest.bat";

                System.IO.File.WriteAllText(path, cmd);

                currentCoinProcess = System.Diagnostics.Process.Start(path);
                currentCoinProcessID = currentCoinProcess.Id;
                currentCoinProcessName = currentCoinProcess.ProcessName;

                timer1.Start();
                LoadCoins();
            }
            catch (Exception ex) { }
        }

        private void SAVEAUTOSTART(object sender, EventArgs e)
        {
            AutoRestart_Seconds = DBase.IntReturn(edtAutoReset.Value);
            btnStart.PerformClick();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            //Donate D = new Donate();
            //D.ShowDialog();
        }

        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12)
            {
                //Donate D = new Donate();
                //D.ShowDialog();
            }

            if (e.KeyCode == Keys.F11)
            {
                APIMonitor A = new APIMonitor();
                A.Show();
            }

        }

        private void LoadDefault(object sender, EventArgs e)
        {
            edtConfigSCRYPT.Text = excuteDevice + " --scrypt   ";
            edtConfigX11.Text = excuteDevice + " -k x11mod    ";
            edtConfigX13.Text = excuteDevice + " -k x13mod ";
            edtConfigNFACTOR.Text = excuteDevice + "  --thread-concurrency 8192  -I 13 -g 2 -w 256 --lookup-gap 2 --shaders 2048  --gpu-fan 100 --gpu-engine 1040 --gpu-memclock 1475";
            edtConfigTALK.Text = excuteDevice + "  --thread-concurrency 8192  -I 13 -g 2 -w 256 --lookup-gap 2 --shaders 2048  --gpu-fan 100 --gpu-engine 1040 --gpu-memclock 1475";

            edtConfigGROESTL.Text = excuteDevice + "  --thread-concurrency 8192  -I 13 -g 2 -w 256 --lookup-gap 2 --shaders 2048  --gpu-fan 100 --gpu-engine 1040 --gpu-memclock 1475";

            btnLockConfig.PerformClick();
        }

        private void LoadDefault_7970(object sender, EventArgs e)
        {
            edtConfigSCRYPT.Text = excuteDevice + " --scrypt --thread-concurrency 8192  -I 13 -g 2 -w 256 --lookup-gap 2 --shaders 2048  --gpu-fan 100 --gpu-engine 1040 --gpu-memclock 1475";
            edtConfigX11.Text = excuteDevice + " -k x11mod  --thread-concurrency 8192  -I 19 -g 2 -w 256 --lookup-gap 2 --shaders 2048  --gpu-fan 100 --gpu-engine 1040 --gpu-memclock 1475";
            edtConfigX13.Text = excuteDevice + " -k x13mod  --thread-concurrency 8192  -I 19 -g 2 -w 256 --lookup-gap 2 --shaders 2048  --gpu-fan 100 --gpu-engine 1040 --gpu-memclock 1475";
            edtConfigNFACTOR.Text = excuteDevice + "  --thread-concurrency 8192  -I 13 -g 2 -w 256 --lookup-gap 2 --shaders 2048  --gpu-fan 100 --gpu-engine 1040 --gpu-memclock 1475";
            edtConfigTALK.Text = excuteDevice + "  --thread-concurrency 8192  -I 13 -g 2 -w 256 --lookup-gap 2 --shaders 2048  --gpu-fan 100 --gpu-engine 1040 --gpu-memclock 1475";
            
            edtConfigGROESTL.Text = excuteDevice + "  --thread-concurrency 8192  -I 13 -g 2 -w 256 --lookup-gap 2 --shaders 2048  --gpu-fan 100 --gpu-engine 1040 --gpu-memclock 1475";
            
            btnLockConfig.PerformClick();
        }

        private void LoadDefault_7970_1000_1250(object sender, EventArgs e)
        {
            edtConfigSCRYPT.Text = excuteDevice + " --scrypt --thread-concurrency 8192  -I 13 -g 2 -w 256 --lookup-gap 2 --shaders 2048  --gpu-fan 100 --gpu-engine 1000 --gpu-memclock 1250";
            edtConfigX11.Text = excuteDevice + " -k x11mod  --thread-concurrency 8192  -I 19 -g 2 -w 256 --lookup-gap 2 --shaders 2048  --gpu-fan 100 --gpu-engine 1000 --gpu-memclock 1250";
            edtConfigX13.Text = excuteDevice + " -k x13mod  --thread-concurrency 8192  -I 19 -g 2 -w 256 --lookup-gap 2 --shaders 2048  --gpu-fan 100 --gpu-engine 1000 --gpu-memclock 1250";
           
            
            edtConfigGROESTL.Text = excuteDevice + "  --thread-concurrency 8192  -I 13 -g 2 -w 256 --lookup-gap 2 --shaders 2048  --gpu-fan 100 --gpu-engine 1000 --gpu-memclock 1250";
            btnLockConfig.PerformClick();
        
        }


        private void LoadDefault_7870(object sender, EventArgs e)
        {
            edtConfigSCRYPT.Text = excuteDevice + "   --scrypt --thread-concurrency 15232 --lookup-gap 2 -w 256 -I 19 -g 1  --gpu-fan 100 --gpu-engine 935 --gpu-memclock 1375";
            edtConfigX11.Text = excuteDevice + " -k darkcoin --thread-concurrency 8192 --lookup-gap 2 -w 256 -I 13 -g 2  --gpu-fan 100 --gpu-engine 935 --gpu-memclock 1375";
            edtConfigGROESTL.Text = excuteDevice + "  Your config nFactor ";
            edtConfigX13.Text = excuteDevice + " -k groestlcoin --difficulty-multiplier 0.00390625  --thread-concurrency 8192 --lookup-gap 2 -w 256 -I 13 -g 2  --gpu-fan 100 --gpu-engine 935 --gpu-memclock 1375";

            btnLockConfig.PerformClick();
        }

        private void LoadDefault_5870(object sender, EventArgs e)
        {
            edtConfigSCRYPT.Text = excuteDevice + "   --scrypt --thread-concurrency 8192 --lookup-gap 2 -w 256 -I 18 -g 1  --gpu-fan 100 --gpu-engine 800";
            edtConfigX11.Text = excuteDevice + "    -k darkcoin  --thread-concurrency 8192 --lookup-gap 2 -w 256 -I 18 -g 1  --gpu-fan 100 --gpu-engine 800";
            edtConfigGROESTL.Text = excuteDevice + "  Your config nFactor ";
            btnLockConfig.PerformClick();
        }

        private void LoadDefault_6950(object sender, EventArgs e)
        {
            edtConfigSCRYPT.Text = excuteDevice + "   --scrypt --thread-concurrency 8192 --lookup-gap 2 -w 256 -I 18 -g 1  --gpu-fan 100 --gpu-engine 840 --gpu-memclock 1250";

            edtConfigX11.Text = excuteDevice + "    -k darkcoin  --thread-concurrency 8192 --lookup-gap 2 -w 256 -I 18 -g 1  --gpu-fan 100 --gpu-engine 840 --gpu-memclock 1250";
            edtConfigGROESTL.Text = excuteDevice + "  Your config nFactor ";
            edtConfigX13.Text = excuteDevice + " -k groestlcoin --difficulty-multiplier 0.00390625   --thread-concurrency 8192 --lookup-gap 2 -w 256 -I 18 -g 1  --gpu-fan 100 --gpu-engine 840 --gpu-memclock 1250";
            btnLockConfig.PerformClick();
        
        }

        private void LoadDefault_R290X(object sender, EventArgs e)
        {
            edtConfigSCRYPT.Text = excuteDevice + "   --scrypt --thread-concurrency 33792 -I 20 -g 1 -w 256 -v 1 --lookup-gap 2  --gpu-fan 100 --gpu-engine 939 --gpu-memclock 1250 ";
            edtConfigX11.Text = excuteDevice + "   -k darkcoin --thread-concurrency 33792 -I 20 -g 1 -w 256 -v 1 --lookup-gap 2  --gpu-fan 100 --gpu-engine 939 --gpu-memclock 1250 ";
            edtConfigGROESTL.Text = excuteDevice + "  Your config nFactor ";
            btnLockConfig.PerformClick();
        }


        private void LoadDefault_R290_32765(object sender, EventArgs e)
        {
            edtConfigSCRYPT.Text = excuteDevice + "   --scrypt --thread-concurrency 24500 -I 20 -g 1 -w 256 -v 1 --lookup-gap 2  --gpu-fan 100 --gpu-engine 939 --gpu-memclock 1250 ";
            edtConfigX11.Text = excuteDevice + "   -k darkcoin --thread-concurrency 24500 -I 20 -g 1 -w 256 -v 1 --lookup-gap 2  --gpu-fan 100 --gpu-engine 939 --gpu-memclock 1250 ";
            edtConfigGROESTL.Text = excuteDevice + "  Your config nFactor ";
            btnLockConfig.PerformClick();
        }

        private void LoadDefault_R290(object sender, EventArgs e)
        {
            edtConfigSCRYPT.Text = excuteDevice + "   --scrypt --thread-concurrency 15333 -I 20 -g 1 -w 256 -v 1 --lookup-gap 2 --gpu-engine 939 --gpu-memclock 1250 ";
            edtConfigX11.Text = excuteDevice + "   -k darkcoin --thread-concurrency 15333 -I 20 -g 1 -w 256 -v 1 --lookup-gap 2 --gpu-engine 939 --gpu-memclock 1250";
            edtConfigGROESTL.Text = excuteDevice + "  Your config nFactor ";
            edtConfigX13.Text = excuteDevice + " -k groestlcoin --difficulty-multiplier 0.00390625  --thread-concurrency 15333 -I 20 -g 1 -w 256 -v 1 --lookup-gap 2 --gpu-engine 939 --gpu-memclock 1250";
            btnLockConfig.PerformClick();

        }

        private void configDànhChoMáyQuảnLýKhôngStartCgminerKhiMởChươngTrìnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            edtConfigSCRYPT.Text = "Scrypt Config";
            edtConfigX11.Text = "X11 Config ";
            edtConfigGROESTL.Text = "NFACTOR Config";
            edtConfigX13.Text = "X13 Config";

            StartDetecterWhenOpen = 0;
            MonitorData = 0;
            UpdateIni();
            btnLockConfig.PerformClick();

            UpdateButton();
        }

    
     


        private void chkStartup_Click(object sender, EventArgs e)
        {
           // SetStartup(chkStartup.Checked);
        }

        public void SetStartup(bool true_fase)
        {
            if (true_fase == true)
            {
                RegistryKey Reg = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

                Reg.SetValue("Autocoin by Juy", "\"" + Application.ExecutablePath.ToString() + "\"");
                Reg.DeleteValue("Autocoin by Juy");
            }

            else
            {

            }



        }



        private void HELP(object sender, EventArgs e)
        {
            Guide G = new Guide();
            G.Show();

        }

        private void OPEN_AUTOBAT(object sender, EventArgs e)
        {
            Process.Start("notepad.exe", path);
        }

        private void OPEN_AUTOINI(object sender, EventArgs e)
        {
            Process.Start("notepad.exe", "Autocoin.ini");
        }

        private void CHECK_CLICK(object sender, EventArgs e)
        {
            try
            {
                UseMaxDiff = btnUseMaxDiff.Checked == true ? 1 : 0;
                KillProcess = btnKillProcess.Checked == true ? 1 : 0;
                ForceRestart = btnForceRestart.Checked == true ? 1 : 0;
                btnStart.PerformClick();
            }
            catch (Exception ex) { }
        }



        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://www.cryptsy.com/users/balances");
            }
            catch (Exception ex) { }
        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://btc-e.com/");
            }
            catch (Exception ex) { }
        }

        private void toolStripStatusLabel3_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("http://www.coinwarz.com/cryptocurrency");
            }
            catch (Exception ex) { }
        }

        private void toolStripStatusLabel4_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("http://www.coindesk.com/companies/exchanges/btc-china/");
            }
            catch (Exception ex) { }
        }



        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                timer1.Stop();
                foreach (Process P in Process.GetProcesses())
                {

                    if (P.ProcessName.ToString().ToLower() == excuteDevice || P.ProcessName.ToString().ToLower() == "conhost")
                    {
                        P.Kill();
                    }

                }
            }
            catch (Exception ex) { }

        }

        private void cmsExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAPI_Click(object sender, EventArgs e)
        {
            APIMonitor A = new APIMonitor();
            A.Show(); //
        }

        private void ShowHideCoin(object sender, EventArgs e)
        {
            try
            {
                IsShowCoin = IsShowCoin == 1 ? 0 : 1;
                ShowMonitor = 0;
                UpdateIni();
                LoadCoins();
                UpdateButton();
            }
            catch (Exception ex) { }
        }

        private void btnUpdateALL_Click(object sender, EventArgs e)
        {
            String MD5Sever = DStatic.MD5Server("Autocoin.exe");
            DStatic.ProfileVersionUpdate_AllUser(MD5Sever);


        }

       
        private void cmsConfigEditor_Click(object sender, EventArgs e)
        {
            ConfigEditor C = new ConfigEditor();
            C.ShowDialog();

            try
            {
                sr = File.OpenText("AutoCoinConfig.ini");
                string line = sr.ReadToEnd();
                String[] SS = line.Split(';');
                string mo2 = "    " + SS[5].ToString();
                string mo3 = "    " + SS[6].ToString();
                string mo4 = "    " + SS[7].ToString();
                string mo5 = "    " + SS[8].ToString();
                string mo6 = "    " + SS[9].ToString();
                string mo7 = "    " + SS[10].ToString();

                //string subs = Usercode.Substring(btnShowMonitor.Text.Length - 4, 4);
                //btnShowMonitor.Text = subs;
                btnMonitor2.Text = mo2.Substring(mo2.Length - 4, 4);
                btnMonitor3.Text = mo3.Substring(mo3.Length - 4, 4);
                btnMonitor4.Text = mo4.Substring(mo4.Length - 4, 4);
                btnMonitor5.Text = mo5.Substring(mo5.Length - 4, 4);
                btnMonitor6.Text = mo6.Substring(mo6.Length - 4, 4);
                btnMonitor7.Text = mo7.Substring(mo7.Length - 4, 4);



                sr.Dispose();
            }
            catch (Exception ex)
            {
                if (sr != null)
                    sr.Dispose();
            }



            UpdateButton();

        }

        private void btnLoadConfig1_Click(object sender, EventArgs e)
        {
            try
            {
                sr = File.OpenText("AutoCoinConfig.ini");
                string line = sr.ReadToEnd();
                String[] SS = line.Split(';');
                String t = SS[0].ToString();
                if (t != "") edtConfigSCRYPT.Text = t;
                else
                {
                    DStatic.ShowMessage("No text found", 500);
                    sr.Dispose();
                    return;
                }
                sr.Dispose();
            }
            catch (Exception ex)
            {
                if (sr != null)
                    sr.Dispose();
            }

            ConfigIndex = 1;
            btnStart.PerformClick();
            UpdateButtonConfig();
        }

        private void btnLoadConfig2_Click(object sender, EventArgs e)
        {
            try
            {
                sr = File.OpenText("AutoCoinConfig.ini");
                string line = sr.ReadToEnd();
                String[] SS = line.Split(';');
                String t = SS[1].ToString();
                if (t != "") edtConfigSCRYPT.Text = t;
                else
                {
                    DStatic.ShowMessage("No text found", 500);
                    sr.Dispose();
                    return;
                }
                sr.Dispose();
            }
            catch (Exception ex)
            {
                if (sr != null)
                    sr.Dispose();
            }
            ConfigIndex = 2;
            btnStart.PerformClick();
            UpdateButtonConfig();
        }

        private void btnLoadConfig3_Click(object sender, EventArgs e)
        {
            try
            {
                sr = File.OpenText("AutoCoinConfig.ini");
                string line = sr.ReadToEnd();
                String[] SS = line.Split(';');
                String t = SS[2].ToString();
                if (t != "") edtConfigSCRYPT.Text = t;
                else
                {
                    DStatic.ShowMessage("No text found", 500);
                    sr.Dispose();
                    return;
                }
                sr.Dispose();
            }
            catch (Exception ex)
            {
                if (sr != null)
                    sr.Dispose();
            }
            ConfigIndex = 3;
            btnStart.PerformClick();
            UpdateButtonConfig();
        }

        public void UpdateButtonConfig()
        {
            btnLoadConfig1.Text = "1";
            btnLoadConfig2.Text = "2";
           // btnConfigMain.Text = "3";
            if (ConfigIndex == 1) btnLoadConfig1.Text = "<<1>>";
            if (ConfigIndex == 2) btnLoadConfig2.Text = "<<2>>";
           // if (ConfigIndex == 3) btnConfigMain.Text = "<<3>>";
            

        
        }

        private void cmsMonitorMode_Click(object sender, EventArgs e)
        {
            try
            {
                ShowMonitor = ShowMonitor == 1 ? 0 : 1;

                if (ShowMonitor == 1)
                {
                    timer1.Stop();
                    IsShowCoin = 0;
                }
                UpdateIni();
                LoadCoins();

                UpdateButton();

                //if (ShowMonitor == 1) DHuy.ShowMessage("Enabled Monitor", 450);
                //else DHuy.ShowMessage("Monitor Mode is OFF", 450);
            }
            catch (Exception ex) { }
        }

        private void FORCEUPDATE_ONOFF(object sender, EventArgs e)
        {
            try
            {
              int i =   DStatic.MonitorForceUpdate(Usercode, ForceUpdate == 1 ? 0 : 1);
              if (i > 0)
              {
                  DBase.ShowMessage("ForceUpdate is : " + (ForceUpdate == 0 ? "On" : "Off"), 300);
              }
            }
            catch (Exception ex)
            { }
        }

        private void cmsAPI_Click(object sender, EventArgs e)
        {
            APIMonitor A = new APIMonitor();
            A.Show();
        }

        private void REFRESHCOIN(object sender, EventArgs e)
        {
            LoadCoins();
        }

        private void btnMonitor3_Click(object sender, EventArgs e)
        {
            ShowMonitor3 = ShowMonitor3 == 1 ? 0 : 1;
            UpdateIni();
            LoadCoins();
            UpdateButton();
        }

        private void btnMonitor2_Click(object sender, EventArgs e)
        {
            ShowMonitor2 = ShowMonitor2 == 1 ? 0 : 1;
            UpdateIni();
            LoadCoins();
            UpdateButton();
          
        }

        private void btnMonitor4_Click(object sender, EventArgs e)
        {
            ShowMonitor4 = ShowMonitor4 == 1 ? 0 : 1;
            UpdateIni();
            LoadCoins();
            UpdateButton();
        }

        private void btnMonitor5_Click(object sender, EventArgs e)
        {
            ShowMonitor5 = ShowMonitor5 == 1 ? 0 : 1;
            UpdateIni();
            LoadCoins();
            UpdateButton();
        }

        private void btnMonitor6_Click(object sender, EventArgs e)
        {
            ShowMonitor6 = ShowMonitor6 == 1 ? 0 : 1;
            UpdateIni();
            LoadCoins();
            UpdateButton();
        }

        private void btnMonitor7_Click(object sender, EventArgs e)
        {
            ShowMonitor7 = ShowMonitor7 == 1 ? 0 : 1;
            UpdateIni();
            LoadCoins();
            UpdateButton();
        }

        public void UpdateButton()
        {
            try
            {
                btnMonitor2.Visible = btnMonitor2.Text.Replace(" ","") == "" ? false : true;
                btnMonitor3.Visible = btnMonitor3.Text.Replace(" ", "") == "" ? false : true;
                btnMonitor4.Visible = btnMonitor4.Text.Replace(" ", "") == "" ? false : true;
                btnMonitor5.Visible = btnMonitor5.Text.Replace(" ", "").Replace(" ","") == "" ? false : true;
                btnMonitor6.Visible = btnMonitor6.Text.Replace(" ", "") == "" ? false : true;
                btnMonitor7.Visible = btnMonitor7.Text.Replace(" ", "") == "" ? false : true;
              

                if (ShowMonitor7 == 1)
                {
                    btnMonitor7.BackColor = Color.PaleGreen;
                }

                else
                {
                    btnMonitor7.BackColor = Color.LightGray;
                }

                if (ShowMonitor6 == 1)
                {
                    btnMonitor6.BackColor = Color.PaleGreen;
                }

                else
                {
                    btnMonitor6.BackColor = Color.LightGray;
                }

                if (ShowMonitor5 == 1)
                {
                    btnMonitor5.BackColor = Color.PaleGreen;
                }

                else
                {
                    btnMonitor5.BackColor = Color.LightGray;
                }


                if (ShowMonitor4 == 1)
                {
                    btnMonitor4.BackColor = Color.PaleGreen;
                }

                else
                {
                    btnMonitor4.BackColor = Color.LightGray;
                }


                if (ShowMonitor3 == 1)
                {
                    btnMonitor3.BackColor = Color.PaleGreen;
                }

                else
                {
                    btnMonitor3.BackColor = Color.LightGray;
                }

                if (ShowMonitor2 == 1)
                {
                    btnMonitor2.BackColor = Color.PaleGreen;
                }

                else
                {
                    btnMonitor2.BackColor = Color.LightGray;
                }

                if (ShowMonitor == 1)
                {
                    btnShowMonitor.BackColor = Color.PaleGreen;
                }

                else
                {
                    btnShowMonitor.BackColor = Color.LightGray;
                }

                if (IsShowCoin == 1)
                {
                    btnShowHideCoin.BackColor = Color.OldLace;
                }

                else
                {
                    btnShowHideCoin.BackColor = Color.LightGray;
                }

                if (MonitorData == 1)
                {
                    btnMonitorDataOnOf.BackColor = Color.OldLace;
                    
                }

                else
                {
                    btnMonitorDataOnOf.BackColor = Color.LightGray;
                   
                }

                //if (StartWhenStarApp == 1) cmsStartWhenOpen.Image = Properties.Resources.check;
                //else cmsStartWhenOpen.Image = null;

                //if (StartWithLiteMode == 1) cmsSmallWindow.Image = Properties.Resources.check;
                //else cmsSmallWindow.Image = null;


                if (EnableAPIInMonitorMode == 1) cmsEnableAPIInMonitorMode.Image = Properties.Resources.check;
                else cmsEnableAPIInMonitorMode.Image = null;

                if (EnableAMInMonitorMode == 1) cmsEnableAMInMonitorMode.Image = Properties.Resources.check;
                else cmsEnableAMInMonitorMode.Image = null;

                if (StartDetecterWhenOpen == 1) cmsStartDetector.Image = Properties.Resources.check;
                else cmsStartDetector.Image = null;


            }
            catch (Exception ex) { }
        }

        private void btnMonitorDataOnOf_Click(object sender, EventArgs e)
        {
            try
            {
                MonitorData = MonitorData == 1 ? 0 : 1;
                UpdateIni();
                UpdateButton();

                if (MonitorData==1) DStatic.ShowMessage("MonitorData is ON", 450);
                else DStatic.ShowMessage("MonitorData is OFF",450);
            }
            catch (Exception ex) { }
        }

        private void monitorFloatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //if (Usercode == "tramphuochuy") System.Diagnostics.Process.Start("AutoCoinMonitor.exe");
                //else {
                //    DBase.ShowMessage("No availible!..", 300); 
                //}
                System.Diagnostics.Process.Start("Monitor.exe");
            }
            catch (Exception ex) { }
        }

        private void enableThreadConcurencyMaximumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
              
                DBase.SetMaxTheadConcurency();
                DBase.SetObjectSync();
           
            }
            catch (Exception ex)
            {

            }
        }

        private void disableStarupRepairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DBase.SetNoRecovery();
            DBase.SetNoStarupFailures();
        }

        private void disable100ThreadConcurencyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DBase.SetMaxTheadConcurency_Clear();
        }

        private void clearBinFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string BinBat = Application.StartupPath + "\\ClearBin.bat";
                System.IO.File.WriteAllText(BinBat, "del *.bin");
                System.Diagnostics.Process.Start(BinBat);


            }
            catch (Exception ex) { }

            try
            {
               
            }
            catch (Exception ex) { }
        }

        private void openFileLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
          string path =  System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
          System.Diagnostics.Process.Start("explorer.exe", path);
   
        
        }

        private void cmsStartWhenOpen_Click(object sender, EventArgs e)
        {
            StartWhenStarApp = StartWhenStarApp == 1 ? 0 : 1;
            UpdateIni();
            UpdateButton();
        }

        private void smallWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartWithLiteMode = StartWithLiteMode == 1 ? 0 : 1;
            UpdateIni();
            UpdateButton();
        }

        private void enableAPIInMonitorModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EnableAPIInMonitorMode = EnableAPIInMonitorMode == 1 ? 0 : 1;
            UpdateIni();
            UpdateButton();
        }

        private void cmsEnableAMInMonitorMode_Click(object sender, EventArgs e)
        {
            EnableAMInMonitorMode = EnableAMInMonitorMode == 1 ? 0 : 1;
            UpdateIni();
            UpdateButton();
        }


        public void MOVING(string newAccount)
        {
            try
            {
             
              DataTable dtinfo =  DStatic.CoinInfo(newAccount);
                if ( dtinfo.Rows.Count <= 0 ) return;
                else
                {
                    string s = DBase.StringReturn( dtinfo.Rows[0]["PASSWORD"]);

                    Usercode = newAccount;
                    UserPassword = s;
                    btnStart.PerformClick();


                }

            }
            catch (Exception ex) { }

        }

        private void VersionCgminerSelect(object sender, EventArgs e)
        {
            try
            {
                DStatic.DownloadFile("cgminer-3.0.0.tgz");
            }

            catch (Exception ex) { }
        }

        private void startDetecterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                StartDetecterWhenOpen = StartDetecterWhenOpen == 1 ? 0 : 1;
                UpdateIni();
                UpdateButton();
            }
            catch (Exception ex)
            {
            }
        }

        private void TimerIntervalClick(object sender, EventArgs e)
        {
            try
            {
                ToolStripMenuItem T = (ToolStripMenuItem)sender;

                int N = DBase.IntReturn(T.Text) * 1000;
                timer1.Interval = N;
                TimerInterval = timer1.Interval;
                UpdateIni();
            }
            catch (Exception ex) { }
        }

        private void ResetTimeLimit_Click(object sender, EventArgs e)
        {
            try
            {
                ToolStripMenuItem T = (ToolStripMenuItem)sender;

                int N = DBase.IntReturn(T.Text) ;
                TimeResetLimit = N;
                UpdateIni();
            }
            catch (Exception ex) { }
        }

        private void SAVE_TO_SLOT(object sender, EventArgs e)
        {
            try
            {
            ToolStripMenuItem T = (ToolStripMenuItem)sender;
            string index = T.Text.Split(' ')[1].ToString();
            DBase.ReplaceConfig("AutocoinConfig.ini", DBase.IntReturn(index) - 1, edtConfigSCRYPT.Text);
            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.ToString());
            }

        }

        private void CONFIG_COPYTEXT(object sender, EventArgs e)
        {
            try
            {

                Clipboard.SetText(edtConfigSCRYPT.SelectedText);

            }
            catch (Exception ex)
            {
              //  MessageBox.Show(ex.ToString());
            }
        }

        private void CONFIG_CUTTEXT(object sender, EventArgs e)
        {
            try
            {
                SendKeys.Send("{DELETE}");
               // edtConfig.Text = edtConfig.Text.Replace(edtConfig.SelectedText, " ");
                Clipboard.SetText(edtConfigSCRYPT.SelectedText);

            }
            catch (Exception ex)
            {
                //  MessageBox.Show(ex.ToString());
            }
        }

        private void CONFIG_SELECTALL_TEXT(object sender, EventArgs e)
        {
            try
            {
                edtConfigSCRYPT.SelectionStart = 0;
                edtConfigSCRYPT.SelectionLength = edtConfigSCRYPT.Text.Length;
            }
            catch (Exception ex)
            {
              //  MessageBox.Show(ex.ToString());
            }
        }

        private void CONFIG_PASTE(object sender, EventArgs e)
        {
            try
            {
                SendKeys.Send("^(v)");
                // edtConfig.Text = edtConfig.Text.Replace(edtConfig.SelectedText, " ");
               

            }
            catch (Exception ex)
            {
                //  MessageBox.Show(ex.ToString());
            }
        }

        private void btnShowMainMenu_Click(object sender, EventArgs e)
        {
            cmsMainMenu.Show(btnShowMainMenu,new Point(0,btnShowMainMenu.Height));
        }

        private void cmsLockPCConfig_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateIni();
                int kq = DStatic.ConfigAddUpdate(Usercode, PCID, edtWorkerSubFix.Text, edtConfigSCRYPT.Text, edtConfigX11.Text, edtConfigGROESTL.Text, edtConfigX13.Text, edtConfigX13.Text);
               if (kq > 0)
               {
                   DBase.ShowMessage("Locked Config",500);
               }
            }
            catch (Exception ex)
            {

            }
        }

        private void cmsConfigions_Click(object sender, EventArgs e)
        {
            if (Usercode != "tramphuochuy2")
            {
                DBase.ShowMessage("Not Allow Feature!", 300);
                return;
            }
            
            Configions C = new Configions();
            C.Show();
        }

        private void edtConfigSCRYPT_TextChanged(object sender, EventArgs e)
        {
            if (edtConfigSCRYPT.Text == "") lbHintLoadConfig.Visible = true;
            else lbHintLoadConfig.Visible = false;
        }

        private void cmsHelp_Click(object sender, EventArgs e)
        {
            Guide G = new Guide();
            G.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            try
            {


                //DHuy.ZipExtract(Application.StartupPath + "\\MINER.zip");

                DStatic.ZipFolder(Application.StartupPath + "\\MINER","MINER.zip");


            }
            catch (Exception ex) {
              //  MessageBox.Show(ex.ToString());
            }
        }

        private void darkRemoveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApiWorker A = new ApiWorker("127.0.0.1", 4028);
            A.Request("removepool|0");
        }

        public void UpdateGUI()
        {
            if (ShowMonitor == 1)
            {

            }

            else
            {



            }


        }

        private void aDeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i = DStatic.MonitorDelete_All();
        }

      
       
      

     

  


    
      
    }


}
