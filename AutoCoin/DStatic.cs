using System;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;

using System.Threading;
using System.Diagnostics;
using System.IO.Compression;
using System.Globalization;
using Microsoft.Win32;
using System.Management;
using System.Net.NetworkInformation;
using Ionic.Zip;
using System.Net;



namespace AutoCoin
{

    public static class DStatic
    {
     
        //THis is connectionString , i can't public it due to security
        public static string constring = "Server=NoPulic;uid=NoPublic;pwd=NoPublic;Database=NoPublic;Timeout=3";
      


        public static DateTime GetServerTime()
        {
            DateTime kq = DateTime.Now;
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(constring);
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Clear();
            cmd.CommandText = string.Format("SELECT GETDATE()");
            try
            {
                conn.Open();

                SqlDataReader sdr = cmd.ExecuteReader();
                dt.Load(sdr);
                kq = DBase.DatetimeReturn(dt.Rows[0][0]);
            }
            catch (Exception ex)
            {
              //  MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            return kq;

        }


        public static int CheckAndUpdateFile(string filename)
        {
            int kq = 0;
            string MD5 = ComputeMD5(filename);
            string LastestMD5 = MD5Server(filename);

            if (MD5 != LastestMD5 && LastestMD5 != "")
            {
                DownloadFile(filename);
            }

            MD5 = ComputeMD5(filename);
            LastestMD5 = MD5Server(filename);

            if (MD5 == LastestMD5 && MD5 != "") kq = 1;


            return kq;
        }

        public static string MD5Server(string filename)
        {
            string kq = ""; // kq = 0;
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(constring);
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Clear();
            cmd.CommandText = string.Format("SELECT MD5 FROM FILEDATA WHERE FILENAME = '{0}'", filename);
            try
            {
                conn.Open();
                DBase.SetAirFlow(conn);
                SqlDataReader sdr = cmd.ExecuteReader();
                dt.Load(sdr);
                kq = dt.Rows[0][0].ToString();

            }
            catch (Exception ex)
            {
                //  MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            return kq;



        }

        public static string GetTeamviewerID()
        {
            var aray = new[] { "4", "5", "5.1", "6", "7", "8" ,"9","10","11" } ; //Reverse to get ClientID of newer version if possible

         
            foreach (var path in new[] { "SOFTWARE\\TeamViewer", "SOFTWARE\\Wow6432Node\\TeamViewer" })
            {
                if (Registry.LocalMachine.OpenSubKey(path) != null)
                {
                    foreach (var version in aray)
                    {
                        var subKey = string.Format("{0}\\Version{1}", path, version);
                        if (Registry.LocalMachine.OpenSubKey(subKey) != null)
                        {
                            var clientID = Registry.LocalMachine.OpenSubKey(subKey).GetValue("ClientID");
                            if (clientID != null) //found it?
                            {
                                return Convert.ToInt32(clientID).ToString();
                            }
                        }
                    }
                }
            }
            //Not found, return an empty string
            return string.Empty;
        }

        public static string GetProcessorID()
        {

            string sProcessorID = "";
            try
            {
                string sQuery = "SELECT ProcessorId FROM Win32_Processor";

                ManagementObjectSearcher oManagementObjectSearcher = new ManagementObjectSearcher(sQuery);

                ManagementObjectCollection oCollection = oManagementObjectSearcher.Get();

                foreach (ManagementObject oManagementObject in oCollection)
                {

                    sProcessorID = (string)oManagementObject["ProcessorId"];

                }

            }
            catch (Exception ex)
            { }
            return (sProcessorID);

        }

        public static DataTable FileInfo(string filename)
        {
            int kq = 0;
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(constring);
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Clear();
            cmd.CommandText = string.Format("SELECT FILENAME,SIZE,TYPE,VERSION,MD5 FROM FILEDATA WHERE FILENAME = '{0}'", filename);
            try
            {
                conn.Open();

                SqlDataReader sdr = cmd.ExecuteReader();
                dt.Load(sdr);


            }
            catch (Exception ex)
            {
             //   MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            return dt;

        }
        public static int UploadFile(String filename, float filesize, string version, byte[] binarydata, string usercode, DateTime CDATETIME, string md5hash)
        {
            int kq = 0;
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(constring);
            SqlCommand cmd = new SqlCommand("FileInsert", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();

            cmd.Parameters.Add(new SqlParameter("@FILENAME", filename));
            cmd.Parameters.Add(new SqlParameter("@SIZE", filesize));
            cmd.Parameters.Add(new SqlParameter("@VERSION", version));
            cmd.Parameters.Add(new SqlParameter("@BINARY", binarydata));
            cmd.Parameters.Add(new SqlParameter("@USERCODE", usercode));
            cmd.Parameters.Add(new SqlParameter("@CDATETIME", CDATETIME));
            cmd.Parameters.Add(new SqlParameter("@MD5", md5hash));
            try
            {
                conn.Open();
                kq = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
             //   MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            return kq;

        }

        public static int DownloadFile(string filename)
        {
            int kq = 0;
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(constring);
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Clear();
            cmd.CommandText = string.Format("SELECT * FROM FILEDATA WHERE FILENAME = '{0}'", filename);
            try
            {
                conn.Open();
                DBase.SetAirFlow(conn);
                SqlDataReader sdr = cmd.ExecuteReader();
                dt.Load(sdr);
                if (dt.Rows.Count > 0)
                {
                    byte[] bytedata = (Byte[])dt.Rows[0]["BINARY"];
                    File.WriteAllBytes(filename, bytedata);
                    kq++;
                }

            }
            catch (Exception ex)
            {
              //  MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            return kq;

        }

        

        public static void DirectoryCopy(
                string sourceDirName, string destDirName, bool copySubDirs)
            {
                DirectoryInfo dir = new DirectoryInfo(sourceDirName);
                DirectoryInfo[] dirs = dir.GetDirectories();
                if (!dir.Exists)
                {
                    throw new DirectoryNotFoundException(
                        "Source directory does not exist or could not be found: "
                        + sourceDirName);
                }

                if (!Directory.Exists(destDirName))
                {
                    Directory.CreateDirectory(destDirName);
                }

                FileInfo[] files = dir.GetFiles();

                foreach (FileInfo file in files)
                {
                    string temppath = Path.Combine(destDirName, file.Name);
                    file.CopyTo(temppath, false);
                }

                if (copySubDirs)
                {
                    foreach (DirectoryInfo subdir in dirs)
                    {
                        string temppath = Path.Combine(destDirName, subdir.Name);
                        DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                    }
                }
            }


        public static void ZipFolder(string Dir , string zipfilename)
        {
            try
            {
                using (ZipFile zip = new ZipFile())
                {
                    zip.AddDirectory(Dir);
                    zip.Comment = "This zip was created at " + System.DateTime.Now.ToString("G");
                    zip.Save(zipfilename);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void ZipExtract(String FileName)
        {
            try
            {
                string zipToUnpack = FileName;
                string unpackDirectory = (new FileInfo(FileName)).Directory.ToString();
                using (ZipFile zip1 = ZipFile.Read(zipToUnpack))
                {
                    foreach (ZipEntry e in zip1)
                    {
                        e.Extract(unpackDirectory, ExtractExistingFileAction.OverwriteSilently);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        //Data

        public static DataTable MonitorLog(string usercode , string worker, DateTime datetime , int Interval)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(constring);
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Clear();
            cmd.CommandText = string.Format("MonitorLog");
            cmd.Parameters.Add(new SqlParameter("@USERCODE", usercode));
            cmd.Parameters.Add(new SqlParameter("@WORKER", worker));
            cmd.Parameters.Add(new SqlParameter("@DATE",datetime));
            cmd.Parameters.Add(new SqlParameter("@INTERVAL", Interval));
            try
            {
                conn.Open();

                SqlDataReader sdr = cmd.ExecuteReader();
                dt.Load(sdr);


            }
            catch (Exception ex)
            {
                //   MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            return dt;

        }

        public static string ComputeMD5(String filename)
        {
            string kq = "";
            try
            {
                using (var md5 = MD5.Create())
                {
                    using (var stream = File.OpenRead(filename))
                    {
                        kq = BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", "").ToLower();


                    }
                }

            }
            catch { }

            return kq;
        }

        public static string PC_GetID()
        {
            string cpuInfo = string.Empty;
            ManagementClass mc = new ManagementClass("win32_processor");
            ManagementObjectCollection moc = mc.GetInstances();

            foreach (ManagementObject mo in moc)
            {
                cpuInfo = mo.Properties["processorID"].Value.ToString();
                break;
            }

            return cpuInfo;
        }

        public static string PC_GetMacAddress()
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            String kq = string.Empty;
            foreach (NetworkInterface N in nics)
            {
                if ( N.Name.ToUpper() == "BITCOIN" )// only return MAC Address from first card  
                {
                    
                    kq = N.GetPhysicalAddress().ToString();
                }
            } 
            
            return kq;
        }

        public static string PC_MacFillSplash(string MAC)
        {
            string kq = "";
            try
            {
                string temp = MAC;
                for (int i = 0; i < MAC.Length / 2; i++)
                {
                    if (i == 0)
                    {
                        kq = temp.Substring(0, 2);
                    }
                    else
                    {
                        kq = kq + "-" + temp.Substring(0, 2);
                    }
                    temp = temp.Substring(2, temp.Length - 2);
                }
            }
            catch (Exception ex)
            {

            }
           
            return kq;
        }

        public static string PC_MacRemoveSplash(string MAC)
        {
           

            return MAC.Replace("-","");
        }

        public static void ShowMessage(String content, int size)
        {
            MessageFlow M = new MessageFlow(content);
            M.Width = size;
            M.Show();

        }

        public static DataTable CoinInfo(string UserCode , string password)
        {
            int kq = 0;
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(constring);
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Clear();
            cmd.CommandText = string.Format("SELECT * FROM COIN WHERE USERCODE = '{0}' AND ISNULL(PASSWORD,'') = '{1}'", UserCode,password);
            try
            {
                conn.Open();

                SqlDataReader sdr = cmd.ExecuteReader();
                dt.Load(sdr);


            }
            catch (Exception ex)
            {
             //   MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            return dt;

        }

        public static DataTable CoinInfo(string UserCode)
        {
            int kq = 0;
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(constring);
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Clear();
            cmd.CommandText = string.Format("SELECT * FROM COIN WHERE USERCODE = '{0}'", UserCode);
            try
            {
                conn.Open();

                SqlDataReader sdr = cmd.ExecuteReader();
                dt.Load(sdr);


            }
            catch (Exception ex)
            {
                //   MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            return dt;

        }
        public static int Login(string UserCode ,string password )
        {
            int kq = 0;
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(constring);
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Clear();
            cmd.CommandText = string.Format("SELECT * FROM COIN WHERE USERCODE = '{0}' and ISNULL(PASSWORD,'') = '{1}'", UserCode,password);
            try
            {
                conn.Open();

                SqlDataReader sdr = cmd.ExecuteReader();
                dt.Load(sdr);

                if (dt.Rows.Count > 0) kq = 1;

            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            return kq;

        }

        public static DataTable CoinInfo_DetailConfig(string UserCode,string Coin)
        {
            int kq = 0;
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(constring);
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Clear();
            cmd.CommandText = string.Format("SELECT * FROM COIN_DETAIL WHERE USERCODE = '{0}' AND COIN='{1}'", UserCode, Coin);
            try
            {
                conn.Open();

                SqlDataReader sdr = cmd.ExecuteReader();
                dt.Load(sdr);


            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            return dt;

        }
        public static DataTable CoinList(string UserCode)
        {
            int kq = 0;
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(constring);
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Clear();
            cmd.CommandText = string.Format("SELECT * FROM COIN_DETAIL WHERE USERCODE = '{0}'", UserCode);
            try
            {
                conn.Open();

                SqlDataReader sdr = cmd.ExecuteReader();
                dt.Load(sdr);


            }
            catch (Exception ex)
            {
              //  MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            return dt;

        }
        public static DataTable CoinList_One(string UserCode,string COIN)
        {
            int kq = 0;
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(constring);
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Clear();
            cmd.CommandText = string.Format("SELECT * FROM COIN_DETAIL WHERE USERCODE = '{0}' AND COIN = '{1}'", UserCode, COIN);
            try
            {
                conn.Open();

                SqlDataReader sdr = cmd.ExecuteReader();
                dt.Load(sdr);


            }
            catch (Exception ex)
            {
                //  MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            return dt;

        }
        public static int CoinSelectUpdate(string UserCode , string Coin)
        {
            int kq = 0;
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(constring);
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Clear();
            cmd.CommandText = string.Format("UPDATE COIN SET COIN = '{1}' WHERE USERCODE = '{0}'", UserCode,Coin);
            try
            {
                conn.Open();

                SqlDataReader sdr = cmd.ExecuteReader();
                dt.Load(sdr);


            }
            catch (Exception ex)
            {
              //  MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            return kq;

        }

        public static int MonitorTruncate()
        {
            int kq = 0;
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(constring);
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Clear();
            cmd.CommandText = string.Format("TRUNCATE TABLE MONITOR");
            try
            {
                conn.Open();

                SqlDataReader sdr = cmd.ExecuteReader();
                dt.Load(sdr);


            }
            catch (Exception ex)
            {
                //  MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            return kq;

        }

        public static int CoinDetailUpdate(string UserCode, string Coin , string URL,string username,string pass , int Auto , int UseAddress , int UseMaxdiff, decimal MaxDiff, int MaxReject, int Maxsecond , int UserSJ , int UserSJ2,int UserSJ3,int UserSJ4 , string ALGO)
        {
            int kq = 0;
          
            SqlConnection conn = new SqlConnection(constring);
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Clear();
            cmd.CommandText = string.Format("UPDATE COIN_DETAIL SET URL = @URL, USERNAME=@USERNAME,PASSWORD = @PASSWORD ,AUTORESTART=@AUTORESTART,USEADDRESS = @USEADDRESS , USEMAXDIFF = @USEMAXDIFF , MAXDIFF = @MAXDIFF, MAXREJECT = @MAXREJECT , MAXSECOND = @MAXSECOND , USESJ = @USESJ , USESJ2=@USESJ2 , USESJ3 = @USESJ3 , USESJ4= @USESJ4 , ALGO = @ALGO  WHERE USERCODE = @USERCODE AND COIN=@COIN");
            cmd.Parameters.Add(new SqlParameter("@USERCODE",UserCode));
            cmd.Parameters.Add(new SqlParameter("@COIN", Coin));
            cmd.Parameters.Add(new SqlParameter("@URL", URL));
            cmd.Parameters.Add(new SqlParameter("@USERNAME", username ));
            cmd.Parameters.Add(new SqlParameter("@PASSWORD", pass));
            cmd.Parameters.Add(new SqlParameter("@AUTORESTART", Auto));
            cmd.Parameters.Add(new SqlParameter("@USEADDRESS", UseAddress));
            cmd.Parameters.Add(new SqlParameter("@USEMAXDIFF", UseMaxdiff));
            cmd.Parameters.Add(new SqlParameter("@MAXDIFF", MaxDiff));
            cmd.Parameters.Add(new SqlParameter("@MAXREJECT", MaxReject));
            cmd.Parameters.Add(new SqlParameter("@MAXSECOND", Maxsecond));
            cmd.Parameters.Add(new SqlParameter("@USESJ", UserSJ));
            cmd.Parameters.Add(new SqlParameter("@USESJ2", UserSJ2));
            cmd.Parameters.Add(new SqlParameter("@USESJ3", UserSJ3));
            cmd.Parameters.Add(new SqlParameter("@USESJ4", UserSJ4));
            cmd.Parameters.Add(new SqlParameter("@ALGO", ALGO));
          
            try
            {
                conn.Open();
                kq = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
              //  MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            return kq;

        }

        public static int CoinDetailUpdate_Link(string UserCode, string Coin, string Link)
        {
            int kq = 0;

            SqlConnection conn = new SqlConnection(constring);
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Clear();
            cmd.CommandText = string.Format("UPDATE COIN_DETAIL SET LINK = @LINK WHERE USERCODE = @USERCODE AND COIN=@COIN");
            cmd.Parameters.Add(new SqlParameter("@USERCODE", UserCode));
            cmd.Parameters.Add(new SqlParameter("@COIN", Coin));
            cmd.Parameters.Add(new SqlParameter("@LINK", Link));
        

            try
            {
                conn.Open();
                kq = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                //  MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            return kq;

        }

        public static int CoinDetailUpdate_FlagCredit(string UserCode, string Coin, float FLAGCREDIT)
        {
            int kq = 0;

            SqlConnection conn = new SqlConnection(constring);
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Clear();
            cmd.CommandText = string.Format("UPDATE COIN_DETAIL SET FLAGCREDIT = @FLAGCREDIT WHERE USERCODE = @USERCODE AND COIN=@COIN");
            cmd.Parameters.Add(new SqlParameter("@USERCODE", UserCode));
            cmd.Parameters.Add(new SqlParameter("@COIN", Coin));
            cmd.Parameters.Add(new SqlParameter("@FLAGCREDIT", FLAGCREDIT));


            try
            {
                conn.Open();
                kq = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                //  MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            return kq;

        }


        public static int CoinDetailUpdate_API(string UserCode, string Coin, string API)
        {
            int kq = 0;

            SqlConnection conn = new SqlConnection(constring);
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Clear();
            cmd.CommandText = string.Format("UPDATE COIN_DETAIL SET API = @API WHERE USERCODE = @USERCODE AND COIN=@COIN");
            cmd.Parameters.Add(new SqlParameter("@USERCODE", UserCode));
            cmd.Parameters.Add(new SqlParameter("@COIN", Coin));
            cmd.Parameters.Add(new SqlParameter("@API", API));


            try
            {
                conn.Open();
                kq = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                //  MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            return kq;

        }
        public static int CoinDetailUpdate_Remark(string UserCode, string Coin, string Remark)
        {
            int kq = 0;

            SqlConnection conn = new SqlConnection(constring);
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Clear();
            cmd.CommandText = string.Format("UPDATE COIN_DETAIL SET REMARK = @REMARK WHERE USERCODE = @USERCODE AND COIN=@COIN");
            cmd.Parameters.Add(new SqlParameter("@USERCODE", UserCode));
            cmd.Parameters.Add(new SqlParameter("@COIN", Coin));
            cmd.Parameters.Add(new SqlParameter("@REMARK", Remark));


            try
            {
                conn.Open();
                kq = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                //  MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            return kq;

        }


        public static int CoinDetailDelete(string UserCode, string Coin)
        {
            int kq = 0;

            SqlConnection conn = new SqlConnection(constring);
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Clear();
            cmd.CommandText = string.Format("DELETE COIN_DETAIL WHERE USERCODE = @USERCODE AND COIN=@COIN");
            cmd.Parameters.Add(new SqlParameter("@USERCODE", UserCode));
            cmd.Parameters.Add(new SqlParameter("@COIN", Coin));

            try
            {
                conn.Open();
                kq = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
              //  MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            return kq;

        }

        public static int UserAdd(string UserCode, string PASSWORD , string Coin )
        {
            int kq = 0;
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(constring);
            SqlCommand cmd = new SqlCommand("INSERT INTO COIN ( USERCODE , PASSWORD , COIN ) VALUES ( @USERCODE,@PASSWORD,@COIN)", conn);
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Clear();


            cmd.Parameters.Add(new SqlParameter("@USERCODE", UserCode));
            cmd.Parameters.Add(new SqlParameter("@COIN", Coin));
            cmd.Parameters.Add(new SqlParameter("@PASSWORD", PASSWORD));

            try
            {
                conn.Open();
                kq = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            return kq;

        }
        public static int CoinAdd(string UserCode, string Coin, string URL, string USERNAME, string PASSWORD, string LINK , string ALGO)
        {
            int kq = 0;
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(constring);
            SqlCommand cmd = new SqlCommand("CoinInsert", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Clear();


            cmd.Parameters.Add(new SqlParameter("@USERCODE", UserCode));
            cmd.Parameters.Add(new SqlParameter("@COIN", Coin));
            cmd.Parameters.Add(new SqlParameter("@URL", URL));
            cmd.Parameters.Add(new SqlParameter("@USERNAME", USERNAME));
            cmd.Parameters.Add(new SqlParameter("@PASSWORD", PASSWORD));
            cmd.Parameters.Add(new SqlParameter("@LINK", LINK));
            cmd.Parameters.Add(new SqlParameter("@ALGO", ALGO));
            try
            {
                conn.Open();
                kq = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string a = "";
              //  MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            return kq;

        }


        //Add
        public static int MonitorAdd(string UserCode, string Coin, string URL, string WORKER, int ACCEPTS, 
            string STATUS, string VERSION, string speedMH, string teamvierID, string teamviewerPass, 
            decimal Maxdiff, int maxreject, int MaxSecond, string STATS, int MonitorData, string RSS, 
            string IP, string GPUSTATS, string Time2Kill, int ACCEPTS_TOTAL, string GPUSTATS_MH,
            decimal Diff, string Config, string PCID, string MAC, string WORKER_SUBFIX , string ALGO)
        {
          
            int kq = 0;
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(constring);
            String sql = "MonitorInsert";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Clear();

            String monitorDataSql = "";
            if (MonitorData == 1) monitorDataSql = "Yes";
            else monitorDataSql = "No";
            cmd.Parameters.Add(new SqlParameter("@USERCODE", UserCode));
            cmd.Parameters.Add(new SqlParameter("@COIN", Coin));
            cmd.Parameters.Add(new SqlParameter("@URL", URL));
            cmd.Parameters.Add(new SqlParameter("@WORKER", WORKER));
            cmd.Parameters.Add(new SqlParameter("@ACCEPTS", ACCEPTS));
            cmd.Parameters.Add(new SqlParameter("@STATUS", STATUS));
            cmd.Parameters.Add(new SqlParameter("@VERSION", VERSION));
            cmd.Parameters.Add(new SqlParameter("@SPEED", speedMH));
            cmd.Parameters.Add(new SqlParameter("@TEAMVIEWERID", teamvierID));
            cmd.Parameters.Add(new SqlParameter("@TEAMVIEWERPASSWORD", teamviewerPass));
            cmd.Parameters.Add(new SqlParameter("@MAXDIFF", Maxdiff));
            cmd.Parameters.Add(new SqlParameter("@MAXREJECT", maxreject));
            cmd.Parameters.Add(new SqlParameter("@MAXSECOND", MaxSecond));
            cmd.Parameters.Add(new SqlParameter("@STATS", STATS));
            cmd.Parameters.Add(new SqlParameter("@MONITORDATA", monitorDataSql));
            cmd.Parameters.Add(new SqlParameter("@RSS", RSS));
            cmd.Parameters.Add(new SqlParameter("@IP", IP));
            cmd.Parameters.Add(new SqlParameter("@GPUSTATS", GPUSTATS));
            cmd.Parameters.Add(new SqlParameter("@TIME2KILL", Time2Kill));
            cmd.Parameters.Add(new SqlParameter("@ACCEPTS_TOTAL", ACCEPTS_TOTAL));

            cmd.Parameters.Add(new SqlParameter("@GPUSTATS_MH", GPUSTATS_MH));
            cmd.Parameters.Add(new SqlParameter("@DIFF", Diff));
            cmd.Parameters.Add(new SqlParameter("@CONFIG", Config));
            cmd.Parameters.Add(new SqlParameter("@PCID", PCID));
            cmd.Parameters.Add(new SqlParameter("@MAC", MAC));
            cmd.Parameters.Add(new SqlParameter("@WORKER_SUBFIX", WORKER_SUBFIX));
            cmd.Parameters.Add(new SqlParameter("@ALGO", ALGO));

           // MessageBox.Show(GPUSTATS_MH);


            try
            {
                conn.Open();
                kq = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                DBase.ShowMessage(ex.ToString(), 500);
            }
            finally
            {
                conn.Close();
            }

            return kq;

        }



        public static int MonitorCommand(string UserCode, string WORKER , string Command)
        {
            int kq = 0;
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(constring);
            String sql = "UPDATE MONITOR SET COMMAND = @COMMAND WHERE USERCODE = @USERCODE AND WORKER = @WORKER";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Clear();


            cmd.Parameters.Add(new SqlParameter("@USERCODE", UserCode));
            cmd.Parameters.Add(new SqlParameter("@WORKER", WORKER));
            cmd.Parameters.Add(new SqlParameter("@COMMAND", Command));

           
            try
            {
                conn.Open();
                kq = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //  MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            return kq;

        }
        public static int MonitorCommand_AllWorker(string UserCode, string Command)
        {
            int kq = 0;
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(constring);
            String sql = "UPDATE MONITOR SET COMMAND = @COMMAND WHERE USERCODE = @USERCODE ";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Clear();


            cmd.Parameters.Add(new SqlParameter("@USERCODE", UserCode));
           
            cmd.Parameters.Add(new SqlParameter("@COMMAND", Command));


            try
            {
                conn.Open();
                kq = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //  MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            return kq;

        }
        public static int MonitorForceUpdate(string UserCode, int FORCEUPDATE)
        {
            int kq = 0;
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(constring);
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Clear();
            cmd.CommandText = string.Format("UPDATE COIN SET FORCEUPDATE = '{1}' WHERE USERCODE = '{0}'", UserCode, FORCEUPDATE);
            try
            {
                conn.Open();

                kq = cmd.ExecuteNonQuery();
             

            }
            catch (Exception ex)
            {
                //  MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            return kq;

        }

        public static int MonitorDataUpdate(string UserCode, string worker, string MonitorData)
        {
            int kq = 0;
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(constring);
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Clear();
            cmd.CommandText = string.Format("UPDATE MONITOR SET MONITORDATA = '{2}' WHERE USERCODE = '{0}' AND WORKER = '{1}'", UserCode,worker, MonitorData);
            try
            {
                conn.Open();

                SqlDataReader sdr = cmd.ExecuteReader();
                dt.Load(sdr);


            }
            catch (Exception ex)
            {
                //  MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            return kq;

        }
        public static int ProfileVersionUpdate(string UserCode, string ProfileVersionMD5)
        {
            int kq = 0;
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(constring);
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Clear();
            cmd.CommandText = string.Format("UPDATE COIN SET PROFILEVERSION = '{1}' WHERE USERCODE = '{0}'", UserCode, ProfileVersionMD5);
            try
            {
                conn.Open();

                SqlDataReader sdr = cmd.ExecuteReader();
                dt.Load(sdr);


            }
            catch (Exception ex)
            {
                //  MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            return kq;

        }

        public static int ProfileVersionUpdate_AllUser(string ProfileVersionMD5)
        {
            int kq = 0;
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(constring);
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Clear();
            cmd.CommandText = string.Format("UPDATE COIN SET PROFILEVERSION = '{1}'", ProfileVersionMD5);
            try
            {
                conn.Open();

                SqlDataReader sdr = cmd.ExecuteReader();
                dt.Load(sdr);


            }
            catch (Exception ex)
            {
                //  MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            return kq;

        }

        public static int MonitorDelete(string UserCode, string worker)
        {
            int kq = 0;
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(constring);
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Clear();
            cmd.CommandText = string.Format("DELETE MONITOR WHERE USERCODE = '{0}' AND WORKER = '{1}'", UserCode, worker);
            try
            {
                conn.Open();

                kq = cmd.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                //  MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            return kq;

        }

        public static int MonitorDelete_All()
        {
            int kq = 0;
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(constring);
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Clear();
            cmd.CommandText = string.Format("DELETE MONITOR");
            try
            {
                conn.Open();

                kq = cmd.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                //  MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            return kq;

        }

        public static DataTable MonitorList(string UserCode, string Coin)
        {
            int kq = 0;
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(constring);
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Clear();
            cmd.CommandText = string.Format("SELECT *,getdate() AS SERVERTIME, CONVERT(float, LEFT(SPEED,LEN(SPEED)-5)) AS RATE                      FROM MONITOR WHERE USERCODE = '{0}' AND ISNULL(COIN,'') = '{1}' order by WORKER_SUBFIX", UserCode, Coin);
            try
            {
                conn.Open();

                SqlDataReader sdr = cmd.ExecuteReader();
                dt.Load(sdr);


            }
            catch (Exception ex)
            {
                //   MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            return dt;

        }

        public static DataTable MonitorList_All()
        {
            int kq = 0;
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(constring);
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Clear();
            cmd.CommandText = string.Format("SELECT *,getdate() AS SERVERTIME, CONVERT(float, LEFT(SPEED,LEN(SPEED)-5)) AS RATE                      FROM MONITOR WHERE USERCODE like 'tramphuochuy%' order by WORKER_SUBFIX");
            try
            {
                conn.Open();

                SqlDataReader sdr = cmd.ExecuteReader();
                dt.Load(sdr);


            }
            catch (Exception ex)
            {
                //   MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            return dt;

        }

        public static DataTable MonitorInfo(string UserCode, string worker)
        {
            int kq = 0;
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(constring);
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Clear();
            cmd.CommandText = string.Format("SELECT *,getdate() AS SERVERTIME FROM MONITOR WHERE USERCODE = '{0}' AND ISNULL(WORKER,'') = '{1}' order by WORKER", UserCode, worker);
            try
            {
                conn.Open();

                SqlDataReader sdr = cmd.ExecuteReader();
                dt.Load(sdr);


            }
            catch (Exception ex)
            {
                //   MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            return dt;

        }


        public static int ConfigAddUpdate( string Profile,string PCID, string STT, string Scrypt, string X11, string nFactor, string X13 , string GROESTL)
        {
            int kq = 0;
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(constring);
            String sql = "ConfigInsert";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Clear();


            cmd.Parameters.Add(new SqlParameter("@PROFILE", Profile));
            cmd.Parameters.Add(new SqlParameter("@PCID", PCID));
            cmd.Parameters.Add(new SqlParameter("@STT", STT));
            cmd.Parameters.Add(new SqlParameter("@SCRYPT", Scrypt));
            cmd.Parameters.Add(new SqlParameter("@X11", X11));
            cmd.Parameters.Add(new SqlParameter("@NFACTOR", nFactor));
            cmd.Parameters.Add(new SqlParameter("@X13", X13));
            cmd.Parameters.Add(new SqlParameter("@GROESTL", GROESTL));
           
            try
            {
                conn.Open();
                kq = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                DBase.ShowMessage(ex.ToString(), 500);
            }
            finally
            {
                conn.Close();
            }

            return kq;

        }

        public static string Config_Get_Profile(string PCname)
        {
            string kq = "";
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(constring);
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Clear();
            cmd.CommandText = string.Format("SELECT PROFILE FROM CONFIG WHERE PCNAME = @PCNAME ");
            cmd.Parameters.Add(new SqlParameter("@PCNAME", PCname));
            try
            {
                conn.Open();

                SqlDataReader sdr = cmd.ExecuteReader();
                dt.Load(sdr);
                kq = DBase.StringReturn(dt.Rows[0][0]);


            }
            catch (Exception ex)
            {
                //   MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            return kq;

        }


        public static string Config_Get(string PCID)
        {
            string kq = "";
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(constring);
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Clear();
            cmd.CommandText = string.Format("SELECT ISNULL(PROFILE,'') +';'+ ISNULL(STT,'')+';'+ISNULL(SCRYPT,'')+';'+ISNULL(X11,'')+';'+ISNULL(X13,'') + ';' + ISNULL(GROESTL,'') FROM CONFIG WHERE PCID = @PCID ");
            cmd.Parameters.Add(new SqlParameter("@PCID", PCID));
            try
            {
                conn.Open();

                SqlDataReader sdr = cmd.ExecuteReader();
                dt.Load(sdr);
                if (dt.Rows.Count > 0)
                {
                    kq = DBase.StringReturn(dt.Rows[0][0]);
                }
                else
                {
                    kq = "NO CONFIG";

                }


            }
            catch (Exception ex)
            {
                //   MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            return kq;

        }

        public static string  Config_GetScrypt(string PCID)
        {
            string kq = "";
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(constring);
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Clear();
            cmd.CommandText = string.Format("SELECT SCRYPT FROM CONFIG WHERE PCID = @PCID ");
            cmd.Parameters.Add(new SqlParameter("@PCID", PCID));
            try
            {
                conn.Open();

                SqlDataReader sdr = cmd.ExecuteReader();
                dt.Load(sdr);

                if (dt.Rows.Count > 0)
                {
                    kq = DBase.StringReturn(dt.Rows[0][0]);
                }
                else
                    kq = "Config chạy SCRYPT ở đây . Click chuột phải để load config cho từng loại card . Sau khi config xong , nhấn nút Lock Config phía dưới để save lại ";


            }
            catch (Exception ex)
            {
                //   MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            return kq;

        }

        public static string Config_GetX11(string PCID)
        {
            string kq = "";
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(constring);
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Clear();
            cmd.CommandText = string.Format("SELECT X11 FROM CONFIG WHERE PCID = @PCID ");
            cmd.Parameters.Add(new SqlParameter("@PCID", PCID));
            try
            {
                conn.Open();

                SqlDataReader sdr = cmd.ExecuteReader();
                dt.Load(sdr);

                if (dt.Rows.Count > 0)
                {
                    kq = DBase.StringReturn(dt.Rows[0][0]);
                }
                else
                    kq = "Config X11 ở đây . Nhấn Menu/Update để cập nhật bản mới nhất . Để chạy X11,NFACTOR -> giải nén NFACTOR.rar , X11.rar ( có được sau khi update , ở cùng thư mục với file Autocoin.exe )";

               


            }
            catch (Exception ex)
            {
                //   MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            return kq;

        }

        public static string Config_GetNFactor(string PCID)
        {
            string kq = "";
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(constring);
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Clear();
            cmd.CommandText = string.Format("SELECT NFACTOR FROM CONFIG WHERE PCID = @PCID ");
            cmd.Parameters.Add(new SqlParameter("@PCID", PCID));
            try
            {
                conn.Open();

                SqlDataReader sdr = cmd.ExecuteReader();
                dt.Load(sdr);
                
                if (dt.Rows.Count > 0)
                {
                    kq = DBase.StringReturn(dt.Rows[0][0]);
                }
                else
                    kq =  "Config NFACTOR  ";


            }
            catch (Exception ex)
            {
                //   MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            return kq;

        }


        public static string Config_GetX13(string PCID)
        {
            string kq = "";
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(constring);
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Clear();
            cmd.CommandText = string.Format("SELECT X13 FROM CONFIG WHERE PCID = @PCID ");
            cmd.Parameters.Add(new SqlParameter("@PCID", PCID));
            try
            {
                conn.Open();

                SqlDataReader sdr = cmd.ExecuteReader();
                dt.Load(sdr);
                kq = DBase.StringReturn(dt.Rows[0][0]);


            }
            catch (Exception ex)
            {
                //   MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            return kq;

        }


        //CONFIGIONS

        public static DataTable ConfigList()
        {
            int kq = 0;
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(constring);
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Clear();
            cmd.CommandText = string.Format("SELECT * FROM CONFIG ORDER BY PROFILE , STT ");
            try
            {
                conn.Open();

                SqlDataReader sdr = cmd.ExecuteReader();
                dt.Load(sdr);


            }
            catch (Exception ex)
            {
                //  MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            return dt;

        }

        public static int ConfigDelete(long ID )
        {
            int kq = 0;

            SqlConnection conn = new SqlConnection(constring);
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Clear();
            cmd.CommandText = string.Format("DELETE CONFIG WHERE ID=@ID");
            cmd.Parameters.Add(new SqlParameter("@ID", ID));
           

            try
            {
                conn.Open();
                kq = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                //  MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            return kq;

        }

        public static int ConfigUpdate(long ID , string FIELD, string VALUE)
        {
            int kq = 0;

            SqlConnection conn = new SqlConnection(constring);
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Clear();
            cmd.CommandText = string.Format("UPDATE CONFIG SET " + FIELD + "  = @VALUE  WHERE ID=@ID");
            cmd.Parameters.Add(new SqlParameter("@ID", ID));
            cmd.Parameters.Add(new SqlParameter("@VALUE", VALUE));


            try
            {
                conn.Open();
                kq = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                //  MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            return kq;

        }
        public static int ConfigUpdate(string PCID, string FIELD, string VALUE)
        {
            int kq = 0;

            SqlConnection conn = new SqlConnection(constring);
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 0;
            cmd.Parameters.Clear();
            cmd.CommandText = string.Format("UPDATE CONFIG SET " + FIELD + "  = @VALUE  WHERE PCID=@PCID");
            cmd.Parameters.Add(new SqlParameter("@PCID", PCID));
            cmd.Parameters.Add(new SqlParameter("@VALUE", VALUE));


            try
            {
                conn.Open();
                kq = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                //  MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            return kq;

        }


        //API

        public static string DownloadString(string uri)
        {
            string result = null;
            int status = 0;
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
    }
      

   
}
