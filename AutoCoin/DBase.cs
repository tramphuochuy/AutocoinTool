using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Printing;

using System.Windows.Forms;
using System.IO;
using System.Threading;

using System.Security.Cryptography;
using System.Globalization;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Diagnostics;
using Microsoft.Win32;
using System.Net;
using System.Media;
using System.IO.Compression;


namespace AutoCoin
{
    public class DBase
    {
        public static List<String> StringCopyBuffer = new List<string>();
     
      
        public static List<Color> LColorDark = new List<Color>();
        public static int isLoadStatuscompleted = 0;
        public static int isDebug = 0;
        public static int isAllowNew = 0;
        public static int isEnableColor =1;
        public static int isEnableGridline = 0;
        public static int showLocationDetail = 1;
        public static int Date = DateTime.Now.Day;
        public static int Month = DateTime.Now.Month;
        public static int Year = DateTime.Now.Year;
        public static int showToolTip = 1;
        public static int isAntialiasing = 1;
        public static int isDisplay4Location = 0;
        public static int isDisableXYLocation = 0;
        public static int WidthDefault = 400;
        public static int WidthWindow = 0;
        public static string exeFileName = "Parugrid.exe";
        public static string exeFileNameDir = Application.StartupPath + "\\" + exeFileName;

        public static int ExportExcelType = 0;

        public static Font IndiFont = new Font("Arial", 9, FontStyle.Bold);
        public static Font InCellLocationFont = new Font("Arial",5, FontStyle.Bold);
        public static int LockDrawMaxSelectCell = 0;
        public static int LocationInCell = 0;
        public static int CharInCell = 0;

        public static string StatusInfo = "";

        //public static LinearGradientBrush B = new LinearGradientBrush(
        //                    new Point(0, 10),
        //                    new Point(50, 10),
        //                    Color.WhiteSmoke,   // Opaque red
        //                    Color.LightGreen);

        public static Pen PenGridline = new Pen(Brushes.Gray);

        public static SolidBrush B = new SolidBrush(Color.Fuchsia);




        public static SolidBrush BSelect = new SolidBrush(Color.Khaki);
        public static SolidBrush BPin = new SolidBrush(Color.Fuchsia);
                    
     

        public static int PenMode = 0; // 0 - normal ; 1 - Drawing ; 2 - Pin

        public static long PixelWidthDefault = 3;
        public static long PixelWidthBase = 3;

        public static int isOnline = 1;
        public static string connectionString = "";
     
        public static bool isMsgDisconnect = false;
        public static bool isMessage = true;

        public static int debugmode = 0;
        

        //variable----------------------------------------------------------------------
        public SqlDataAdapter mD_DADT;
        public SqlCommand cmd;
        public DataTable mD_DTABLE;
        public DataRow mD_DROW;
        public string mD_SQL;
        
        public static Dictionary<string,string> CharCodeColorList = new Dictionary<string,string>() ;
        public static DataTable StatusList = new DataTable("StatusList");

        public static bool firstRead = true;
        public static string Server = "";
        public static string Database;
        public static string UserID;
        public static string Pass;
        public static string connectTimeout;
        
        //login
        public static string UserCode = "";
        public static string UserPassword = "";
        public static string UserProfile = "";

        public static string UserDepartment = "";

        public static string UserCompanyID = "";
        public static string UserCompanyName = "";
        public static string UserName = "";


        public static string str_ModName = "";
        public static string str_AgencyParentCode = "";

        public static bool KickOut;
        public static DateTime LoginDateTime;
        public const int cExist = 1;
        public const int cInvalidPwd = -1;
        public static string form_class = "";
        public static string form_name = "";
        //Permission
        public static bool ADMIN;
        public static bool SPU;
        public static bool UINV;
        public static bool URPT;

        //connect database-------------------------------------------------------------
        public const string cIniFile = "MMS.ini";
        public const char cIniFileSeparator = '=';
        public const string cAppName = "AppName";
        public const string cServer = "Server";
        public const string cDatabase = "Database";
        public const string cUserID = "UserID";
        public const string cPassword = "Password";
        public const string cConnectionTimeOut = "ConnectionTimeOut";
        public const string cPathClass = "MMS.PresentationTier.";

        //MMS.ini
        public static string cPathIniFile = Application.ExecutablePath.Substring(0, Application.ExecutablePath.LastIndexOf("\\") + 1);
        public static string str_AppPath = cPathIniFile;

        // Crystal unit
        public const int cCrystalUnit = 568;
        public const string cLeft = "Left";
        public const string cTop = "Top";
        public const string cReportIniFile = "REPORT.INI";

        //Report Folder
        public const string cReport = "Report\\";

        //Template Folder
        public const string cTemplate = "ExcelTemplate\\";

        //Layout Folder
        public const string cLayouts = "GridLayout\\";



        public const string cResult = "RESULT";

        public enum Result
        {
            cNoData = -1, cDuplicate, cSuccess, cReference, cOther //, cInvalidDate, cLessThanToday,
            //cDataRequire, cDuplicateBRT, cDuplicateSeal, cInOtherLocation, cNotYours
        };


        public static void PlayWav(string filename)
        {
            try
            {
                using (SoundPlayer player = new SoundPlayer(filename))
                {
                    player.PlaySync();
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.ToString());
            }

        }

        public static void PlayMp3(string filename)
        {
            try
            {
                WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();

                wplayer.URL = filename;
                wplayer.controls.play();
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.ToString());
            }

        }


        //enum--------------------------------------------------------------------------
        public enum OperationFlag
        {
            ofNone, ofInsert, ofUpdate, ofCopy, ofView
        };

        private static string[] DigitBase = new string[10] { " KHÔNG", " MỘT", " HAI", " BA", " BỐN", " NĂM", " SÁU", " BẢY", " TÁM", " CHÍN" };
        private static string[] UnitBase = new string[4] { "", " NGHÌN", " TRIỆU", " TỶ" };

        private static string[] DigitOther = new string[20] { "", " ONE", " TWO", " THREE", " FOUR", " FIVE", " SIX", " SEVEN", " EIGHT", " NINE", " TEN", " ELEVEN", " TWELVE", " THIRTEEN", " FOURTEEN", " FIFTEEN", " SIXTEEN", " SEVENTEEN", " EIGHTEEN", " NINETEEN" };
        private static string[] UnitOther = new string[4] { "", " THOUSAND", " MILLION", " BILLION" };
        private static string[] TenOther = new string[10] { "", "", " TWENTY", " THIRTY", " FORTY", " FIFTY", " SIXTY", " SEVENTY", " EIGHTY", " NINETY" };

        //function------------------------------------------------------------------------------
        public static int NumberOfCharInStr(string str, char ch)
        {
            int count = 0;

            for (int i = 0; i < str.Length; i++)
                if (str[i] == ch)
                    count++;

            return count;
        }

        public static string RemoveCharInStr(string str, char ch)
        {
            string remove = ch.ToString();
            return str.Replace(remove, String.Empty);
        }

        public static string RemoveStrInStr(string sourcestr, string strtoremove)
        {
            string str = sourcestr.Replace(strtoremove, String.Empty);

            while (str.IndexOf("  ") > 0)
            {
                str = str.Replace("  ", " ");
            }

            return str;
        }

        public static string RemoveSpace(string str)
        {
            return str.Replace(" ", String.Empty);
        }

        public static string BoolToStr(bool b)
        {
            if (b)
                return "1";
            else
                return "0";
        }

        public static int BoolToInt(bool b)
        {
            if (b)
                return 1;
            else
                return 0;
        }

        public static string GetFieldInLeftStr(string str, char sepa)
        {
            string[] subtr = str.Split(new Char[] { sepa });

            if (str.IndexOf(sepa) != -1)
                return (String)subtr[0].Trim();   //lay ben trai sepa
            else
                return null;
        }

        public static string GetFieldInRightStr(string str, char sepa)
        {
            string[] subtr = str.Split(new Char[] { sepa });

            if (str.IndexOf(sepa) != -1)
                return (String)subtr[1].Trim();   //lay ben phai sepa
            else
                return null;
        }

        public static string NewLine(int n)
        {
            string str = "";

            for (int i = 0; i <= n - 1; i++)
                str += "\r\n";

            return str;
        }

        public static string LeftStr(string str, int length)
        {
            if (str.Length > 0)
                return str.Substring(0, length);
            else
                return "";
        }

        public static string RightStr(string str, int length)
        {
            if (str.Length > 0)
            {
                return str.Substring(str.Length - length, length);
            }
            else
                return "";
        }

        public static string QuotedString(string str)
        {
            return "'" + str + "'";
        }

        public static string SayVNDTwoDigit(string TwoDigit)
        {
            int Num1 = int.Parse(TwoDigit.Substring(0, 1));
            int Num2 = int.Parse(TwoDigit.Substring(1, 1));

            string Result = "";

            if (Num1 == 0)
            {
                if (Num2 != 0)  //1 -> 9
                    Result = String.Format(" LINH{0}", DigitBase[Num2]);
            }
            else if (Num1 == 1) //10 ->19
            {
                Result = " MƯỜI";
                if (Num2 != 0)  //10
                {
                    if (Num2 == 5)
                        Result = String.Format("{0} LĂM", Result);
                    else
                        Result = Result + DigitBase[Num2];
                }
            }
            else //(num1 in [2..9])
            {
                if (Num2 == 0)
                    Result = String.Format("{0} MƯƠI", DigitBase[Num1]);
                else
                    if (Num2 == 1)
                        Result = String.Format("{0} MƯƠI MỐT", DigitBase[Num1]);
                    else
                        if (Num2 == 5)
                            Result = String.Format("{0} MƯƠI LĂM", DigitBase[Num1]);
                        else
                            Result = String.Format("{0} MƯƠI{1}", DigitBase[Num1], DigitBase[Num2]);
            }
            return Result;
        }

        public static string SayVNDThrParugridgit(string ThrParugridgit)
        {
            string Result = "";
            int num = int.Parse(ThrParugridgit.Substring(0, 1));
            if (num != 0)
                Result = String.Format("{0} TRĂM", DigitBase[num]);

            Result = Result + SayVNDTwoDigit(ThrParugridgit.Substring(1, 2));
            return Result;
        }

        public static string SayVND(string Num)
        {
            int i, NumComma;
            string[] NumPart;
            string result = "";

            //Loai bo phan le
            //Num = Num.Substring(0, Num.Length - 3); //.25
            Num = Num.Substring(0, Num.IndexOf('.')); //.25

            //So luong dau phay
            NumComma = NumberOfCharInStr(Num, ',');
            NumPart = Num.Split(',');

            for (i = NumPart.Length - 1; i > 0; i--)
            {
                //Doc moi lan 3 chu so

                if (i == NumPart.Length - 1)
                    result = SayVNDThrParugridgit(NumPart[i]) + result;
                else
                    if (int.Parse(NumPart[i]) > 0)
                        result = SayVNDThrParugridgit(NumPart[i]) + UnitBase[NumPart.Length - i - 1] + result;
            }

            //Cac chu so trong 3 chu so ben trai nhat
            i = NumComma;

            switch (NumPart[0].Length)
            {
                case 3:
                    if (i == 0)
                        result = SayVNDThrParugridgit(NumPart[0]) + result;
                    else
                        result = SayVNDThrParugridgit(NumPart[0]) + UnitBase[i] + result;
                    break;

                case 2:
                    if (i == 0)
                        result = SayVNDTwoDigit(NumPart[0]) + result;
                    else
                        result = SayVNDTwoDigit(NumPart[0]) + UnitBase[i] + result;
                    break;

                case 1:
                    if (i == 0)
                        result = DigitBase[int.Parse(NumPart[0])] + result;
                    else
                        result = DigitBase[int.Parse(NumPart[0])] + UnitBase[i] + result;
                    break;

                default:
                    break;
            }
            return result.Trim();
        }

        public static string SayEngTwoDigit(string TwoDigit)
        {
            int Num1 = int.Parse(TwoDigit.Substring(0, 1));
            int Num2 = int.Parse(TwoDigit.Substring(1, 1));

            string Result = "";

            if (Num1 == 0)
            {
                if (Num2 != 0)  //1 -> 9
                    Result = Result + DigitOther[Num2];
            }
            else
                if (Num1 == 1)  //10...19
                    Result = Result + DigitOther[int.Parse(TwoDigit)];
                else //Num1 = 2..9
                    if (Num2 != 0)
                        Result = Result + TenOther[Num1] + DigitOther[Num2];
                    else
                        Result = Result + TenOther[Num1];
            return Result;
        }

        public static string SayEngThrParugridgit(string ThrParugridgit)
        {
            string str;

            string Result = "";
            int num = int.Parse(ThrParugridgit.Substring(0, 1));

            if (num != 0)
                Result = String.Format("{0} HUNDRED", DigitOther[num]);

            str = SayEngTwoDigit(ThrParugridgit.Substring(1, 2));

            if (str != "")
                Result = String.Format("{0} AND", Result);

            Result = Result + str;
            return Result;
        }

        public static string SayEng(string Num)
        {
            int i, NumComma;
            string[] NumPart;

            string Result = "";

            //Loai bo phan le
            //Num = Num.Substring(0, Num.Length - 3); //.25
            Num = Num.Substring(0, Num.IndexOf('.')); //.25

            //So luong dau phay
            NumComma = NumberOfCharInStr(Num, ',');
            NumPart = Num.Split(',');

            for (i = NumPart.Length - 1; i > 0; i--)
            {
                //Doc moi lan 3 chu so

                if (i == NumPart.Length - 1)
                    Result = SayEngThrParugridgit(NumPart[i]) + Result;
                else
                    if (int.Parse(NumPart[i]) > 0)
                        Result = SayEngThrParugridgit(NumPart[i]) + UnitOther[NumPart.Length - i - 1] + Result;
            }

            //Cac chu so trong 3 chu so ben trai nhat
            i = NumComma;

            switch (NumPart[0].Length)
            {
                case 3:
                    if (i == 0)
                        Result = SayEngThrParugridgit(NumPart[0]) + Result;
                    else
                        Result = SayEngThrParugridgit(NumPart[0]) + UnitOther[i] + Result;
                    break;

                case 2:
                    if (i == 0)
                        Result = SayEngTwoDigit(NumPart[0]) + Result;
                    else
                        Result = SayEngTwoDigit(NumPart[0]) + UnitOther[i] + Result;
                    break;

                case 1:
                    if (i == 0)
                        Result = DigitOther[int.Parse(NumPart[0])] + Result;
                    else
                        Result = DigitOther[int.Parse(NumPart[0])] + UnitOther[i] + Result;
                    break;

                default:
                    break;
            }
            return Result.Trim();
        }

        //function DB----------------------------------------------------------------------------
        public static object LookupValue(DataTable dt, string keyField, object keyValue, string outField)
        {
            int dataRowCount = dt.Rows.Count;
            bool match;

            for (int i = 0; i < dataRowCount; i++)
            {
                match = true;
                DataRow row = dt.Rows[i];

                if (!row[keyField].Equals(keyValue))
                    match = false;

                if (match)
                    return row[outField];
            }

            return null;
        }

        public static int GetRowIndexInDataSource(DataTable dt, string keyfield, object keyvalue)
        {
            int dataRowCout = dt.Rows.Count;
            bool match;

            for (int i = 0; i < dataRowCout; i++)
            {
                match = true;
                DataRow row = dt.Rows[i];

                if (!row[keyfield].Equals(keyvalue))
                    match = false;

                if (match)
                    return i;
            }

            return -1;
        }

        public static void GotoRecord(CurrencyManager cm, DataTable dt, string keyfield, object keyvalue)
        {
            int dataRowCout = dt.Rows.Count;
            bool match;
            int gotorow = 0;

            for (int i = 0; i < dataRowCout; i++)
            {
                match = true;
                DataRow row = dt.Rows[i];

                if (!row[keyfield].Equals(keyvalue))
                    match = false;

                if (match)
                {
                    gotorow = i;
                    break;
                }
            }

            cm.Position = gotorow;
        }

        public virtual int Search(DataTable dt, string fieldlist, string condition)
        {
            return 0;
        }

        public static int ExecSQL(string str, SqlConnection cnn)
        {
            SqlCommand cmd;
            try
            {
                cmd = new SqlCommand(str, cnn);

                try
                {
                    return cmd.ExecuteNonQuery();
                }
                catch (SqlException)
                {
                    return 0;
                }

            }
            catch
            {
                return 0;
            }
        }

        public static object ExecScalarSQL(string str, SqlConnection cnn)
        {
            SqlCommand cmd;
            object ob;
            try
            {
                cmd = new SqlCommand(str, cnn);
                try
                {
                    ob = cmd.ExecuteScalar();
                    return ob;
                }
                catch (SqlException)
                {
                    return DBNull.Value;
                }
            }
            catch
            {
                return DBNull.Value;
            }
        }

        public static DataTable FillTable(string str, SqlConnection cnn)
        {
            DataTable datatable;
            SqlDataAdapter da;

            try
            {
                da = new SqlDataAdapter(str, cnn);
                datatable = new DataTable();

                try
                {
                    da.Fill(datatable);
                }
                catch (SqlException)
                {
                    return null;
                }
                return datatable;
            }
            catch
            {
                return null;
            }
        }

        public static DataRow FillTableAtFirstRow(string str, SqlConnection cnn)
        {
            DataTable datatable;
            SqlDataAdapter da;

            try
            {

                da = new SqlDataAdapter(str, cnn);
                datatable = new DataTable();
                try
                {
                    da.Fill(datatable);
                }
                catch (SqlException)
                {
                    return null;
                }

                return datatable.Rows[0];
            }
            catch
            {
                return null;
            }
        }

        public static void SetSystemFormat()
        {
            int[] ARR = { 3, 2, 2 };
            System.Globalization.CultureInfo cultureInfo = new System.Globalization.CultureInfo("en-US");
            System.Globalization.DateTimeFormatInfo dateTimeInfo = new System.Globalization.DateTimeFormatInfo();
            System.Globalization.NumberFormatInfo NumberInfo = new System.Globalization.NumberFormatInfo();

            dateTimeInfo.DateSeparator = "/";
            dateTimeInfo.LongDatePattern = "dd/MMM/yyyy";
            dateTimeInfo.ShortDatePattern = "dd/MM/yyyy";
            dateTimeInfo.LongTimePattern = "hh:mm:ss tt";
            dateTimeInfo.ShortTimePattern = "hh:mm tt";

            //NumberInfo.CurrencySymbol = "Rs"; 
            NumberInfo.CurrencyDecimalDigits = 3;
            NumberInfo.CurrencyDecimalSeparator = ".";
            NumberInfo.CurrencyGroupSizes = ARR;
            NumberInfo.CurrencyGroupSeparator = ",";
            NumberInfo.PositiveInfinitySymbol = " ";

            //dateTimeInfo.SetAllDateTimePatterns = "dd/MM/yyyy,hh:mm:ss tt"; 
            cultureInfo.DateTimeFormat = dateTimeInfo;
            cultureInfo.NumberFormat = NumberInfo;
            Application.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
        }


        

        //Encryption

        public static string Encrypt(string clearText, string password, byte[] salt)
        {
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(password, salt);

            MemoryStream ms = new MemoryStream();
            Rijndael alg = Rijndael.Create();

            alg.Key = pdb.GetBytes(32);
            alg.IV = pdb.GetBytes(16);

            CryptoStream cs = new CryptoStream(ms, alg.CreateEncryptor(), CryptoStreamMode.Write);

            cs.Write(clearBytes, 0, clearBytes.Length);
            cs.Close();

            byte[] EncryptedData = ms.ToArray();

            return Convert.ToBase64String(EncryptedData);
        }

        public static string Decrypt(string cipherText, string password,
            byte[] salt)
        {
            try
            {
                byte[] cipherBytes = Convert.FromBase64String(cipherText);

                PasswordDeriveBytes pdb = new PasswordDeriveBytes(password, salt);

                MemoryStream ms = new MemoryStream();
                Rijndael alg = Rijndael.Create();

                alg.Key = pdb.GetBytes(32);
                alg.IV = pdb.GetBytes(16);

                CryptoStream cs = new CryptoStream(ms, alg.CreateDecryptor(), CryptoStreamMode.Write);

                cs.Write(cipherBytes, 0, cipherBytes.Length);
                cs.Close();

                byte[] DecryptedData = ms.ToArray();

                return Encoding.Unicode.GetString(DecryptedData);
            }
            catch (Exception)
            {
                return "";
            }
        }


        //Excel Index

        public static string ExcelIndex2Column(int columnNumber)
        {
            int dividend = columnNumber;
            string columnName = String.Empty;
            int modulo;

            while (dividend > 0)
            {
                modulo = (dividend - 1) % 26;
                columnName = Convert.ToChar(65 + modulo).ToString() + columnName;
                dividend = (int)((dividend - modulo) / 26);
            }

            return columnName;
        }
        
        //Strign return

        public static string getLineNumber(int zeronum, int input) // Create LineNumber From int 
        {
            string zero = "";
            for (int i = 1; i <= zeronum; i++)
            {
                zero = "0" + zero;
            }

            string kq = zero.Substring(0, (zeronum - input.ToString().Length)) + input.ToString();
            return kq;
        }

        public static string getLineNumber_Space(int zeronum, int input) // Create LineNumber From int 
        {
            string zero = "";
            for (int i = 1; i <= zeronum; i++)
            {
                zero = " " + zero;
            }

            string kq = zero.Substring(0, (zeronum - input.ToString().Length)) + input.ToString();
            return kq;
        }
        public static bool isInt(string number)  //Check Int
        {
            bool kq = true;
            try
            {
                Int64.Parse(number);
            }
            catch (Exception)
            {
                kq = false;
            }

            return kq;
        }

        public static bool isDouble(object number) //Check double
        {
            bool kq = true;
            try
            {
                Double.Parse(number.ToString());
            }
            catch (Exception)
            {
                kq = false;
            }

            return kq;
        }

        public static DateTime DatetimeReturn(object d) //return DateTime from object
        {
            DateTime kq = new DateTime(1900, 1, 1);
            try
            {
            kq = d == null ? new DateTime(1900, 1, 1) : (d.ToString() == "" ? new DateTime(1900, 1, 1) : (DateTime)d);
            }
            catch(Exception ex)
            {
                try
                {
                    kq = DateTime.Parse(d.ToString());
                }
                catch (Exception exs)
                {
                }
            }
            return kq;
        }

        public static string DatetimeReturnString(object d) //return DateTime from object
        {
            String S = "";
            DateTime kq = new DateTime(1900, 1, 1);
            try
            {
                kq = d == null ? new DateTime(1900, 1, 1) : (d.ToString() == "" ? new DateTime(1900, 1, 1) : (DateTime)d);
                if (kq.Year == 1900)
                {
                    S = "";
                }
                else
                {
                    S = kq.ToString();
                }
            }
            catch (Exception ex)
            {
                try
                {
                    S = "";
                }
                catch (Exception exs)
                {
                }
            }

            return S;
        }

        public static DateTime DatetimeReturn_DD_MM_YYYY(String S) //return DateTime from object
        {
            DateTime kq = new DateTime(1900, 1, 1);
            try
            {
                kq = DateTime.ParseExact(S, "dd/MM/yyyy",
                                        System.Globalization.CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
            }
            return kq;
        }

        public static DateTime DatetimeReturnByFormat(String S,String formatddmmyy) //return DateTime from object
        {
            DateTime kq = new DateTime(1900, 1, 1);
            try
            {
                kq = DateTime.ParseExact(S, formatddmmyy,
                                        System.Globalization.CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
            }
            return kq;
        }

        public static string StringReturn(object d) //return String from object
        {
            return d == null ? "" : d.ToString();
        }

        public static double DoubleReturn(object d) //return number from object
        {
            return (isDouble(d) ? double.Parse(d.ToString()) : 0);
        }

        public static decimal DecimalReturn(object d) //return number from object
        {
            decimal kq = 0;
            try
            {
                NumberFormatInfo nfi = (NumberFormatInfo)
                CultureInfo.InvariantCulture.NumberFormat.Clone();
                nfi.NumberGroupSeparator = "";
                nfi.NumberDecimalSeparator = ".";
                kq= (isDouble(d) ? Decimal.Parse(d.ToString(), nfi) : 0);
            }
            catch (Exception ex)
            {
                
            }

            return kq;
        }
        public static string DecimalReturn1Places(object d)
        {
            NumberFormatInfo nfi = (NumberFormatInfo)
            CultureInfo.InvariantCulture.NumberFormat.Clone();
            nfi.NumberGroupSeparator = "";

            return (isDouble(d) ? Decimal.Parse(d.ToString()).ToString("n1",nfi) : "0");
        }
        public static string DecimalReturn2Places(object d) //return number from object
        {
            NumberFormatInfo nfi = (NumberFormatInfo)
            CultureInfo.InvariantCulture.NumberFormat.Clone();
            nfi.NumberGroupSeparator = "";
            return (isDouble(d) ? Decimal.Parse(d.ToString()).ToString("n2",nfi) : "0");
        }
        public static string DecimalReturn3Places(object d ) //return number from object
        {
            NumberFormatInfo nfi = (NumberFormatInfo)
            CultureInfo.InvariantCulture.NumberFormat.Clone();
            nfi.NumberGroupSeparator = "";
            return (isDouble(d) ? Decimal.Parse(d.ToString()).ToString("n3",nfi) : "0");
        }

        public static string DecimalReturn4Places(object d) //return number from object
        {
            NumberFormatInfo nfi = (NumberFormatInfo)
            CultureInfo.InvariantCulture.NumberFormat.Clone();
            nfi.NumberGroupSeparator = "";
            return (isDouble(d) ? Decimal.Parse(d.ToString()).ToString("n4",nfi) : "0");
        }
        public static float FloatReturn(object d) //return number from object
        {
            return (isDouble(d) ? float.Parse(d.ToString()) : 0);
        }


        public static long LongReturn(object d) //return number from object
        {
            return (isDouble(d) ? long.Parse(d.ToString()) : 0);
        }

        public static int IntReturn(object d)  //return number from object
        {
            return (isDouble(d) ? (int)double.Parse(d.ToString()) : 0);
        }

        public static string Fect(DataTable dt, string filedname)
        {
            string kq = "";

            kq = StringReturn(dt.Rows[0][filedname]);

            return kq;
        }

        public static DateTime FectDateTime(DataTable dt, string filedname)
        {
         
            return  DatetimeReturn(dt.Rows[0][filedname]);
        }

        public static string Tach(string s )
        {
            return "\r\n" + s;
        }

        public static string biDate(DateTime d)
        {
            string kq = "";
            kq = d.Year.ToString().Substring(d.Year.ToString().Length - 2, 2) + d.Month.ToString() + d.Day.ToString() + d.Hour.ToString() + d.Minute.ToString();

            return kq;
        }

         public static string biDate2(DateTime d)
        {
            string kq = "";
            kq = d.Year.ToString() +  ( d.Month < 10 ? "0"+d.Month.ToString() : d.Month.ToString())  + (  d.Day < 10 ? "0"+ d.Day.ToString():d.Day.ToString()) ;

            return kq;
        }

         public static string biDate3(DateTime d)
         {
             string kq = "";
             kq = d.Year.ToString().Substring( (d.Year.ToString().Length - 2 ),2 ) + (d.Month < 10 ? "0" + d.Month.ToString() : d.Month.ToString()) + (d.Day < 10 ? "0" + d.Day.ToString() : d.Day.ToString()) + getLineNumber(2,d.Hour) + getLineNumber(2, d.Minute);

             return kq;
         }

        //Transform
        public static string IntColumn( int X )
        {
            string kq = " ";

            for (int i = 0; i < X.ToString().Length; i++)
            {
               
                kq = kq + X.ToString().Substring(i,1) + "\r\n";
            }

            return kq;

        }

        //Supoprt Connection
        public static void SetAirFlow(SqlConnection con)
        {
            using (SqlCommand comm = new SqlCommand("SET ARITHABORT ON", con))
            { comm.ExecuteNonQuery(); }
        }

       

      

    
        public static int Location2Pixel(int X)
        {

            return DBase.IntReturn((X - 0.5) * PixelWidthBase);
        }


        public static bool isContainNumber(string S)
        {
            bool kq = false;

            for (int i = 0; i < S.Length; i++)
            {
                if (char.IsNumber(S[i]))
                {
                    kq = true;
                    return kq;
                }
            }
            return kq;
        }

        public static Color RandomColor()
        {
            
            Random R = new Random();
            Color Co = Color.FromArgb(R.Next(0, 255), R.Next(0, 255), R.Next(0, 255));

            return Co;

        }

        public static Color RandomColor_Dark()
        {

            if ( LColorDark.Count == 0 )
            {

                foreach (var colorValue in Enum.GetValues(typeof(KnownColor)))
                    {
                        Color color = Color.FromKnownColor((KnownColor)colorValue);
                        if ( color.Name.Contains("Dark"))  LColorDark.Add(color);
                    }
            }

            int R = new Random().Next(0, LColorDark.Count - 1);



            return LColorDark[R];

        }

        public static Color RandomColor_Dark_InList()
        {
            List<Color> L = new List<Color>();
           
           // L.Add(Color.DarkOrange);
            //L.Add(Color.DarkSalmon);
            L.Add(Color.DarkBlue);

            if (LColorDark.Count == 0)
            {

                foreach (var colorValue in Enum.GetValues(typeof(KnownColor)))
                {
                    Color color = Color.FromKnownColor((KnownColor)colorValue);
                    if (     color.Name.Contains("Dark")  
                        ) LColorDark.Add(color);
                }
            }

            int R = new Random().Next(0, L.Count);



            return L[R];

        }



        public static Color RandomColor_Light()
        {

            if (LColorDark.Count == 0)
            {

                foreach (var colorValue in Enum.GetValues(typeof(KnownColor)))
                {
                    Color color = Color.FromKnownColor((KnownColor)colorValue);
                    if (color.Name.Contains("Light")) LColorDark.Add(color);
                }
            }

            int R = new Random().Next(0, LColorDark.Count - 1);



            return LColorDark[R];

        }

        public static void ShowMessage(String content, int size)
        {
            MessageFlow M = new MessageFlow(content);
            M.Width = size;
            M.Show();

        }

        public static string JSONSub(String APIRES, String Starsplit, String EndSplit)
        {
            string kq = "";
            try
            {
                int T1 = APIRES.IndexOf(Starsplit);
                APIRES = APIRES.Substring(T1, APIRES.Length - T1);
                kq = APIRES.Substring(APIRES.IndexOf(Starsplit) + Starsplit.Length, APIRES.IndexOf(EndSplit) - APIRES.IndexOf(Starsplit) - Starsplit.Length);

            }
            catch (Exception ex) { }
            return kq;
                 
        }

        public static string JSONSub(String APIRES, String Starsplit, bool EndString)
        {
            string kq = "";
            try
            {
                int T1 = APIRES.IndexOf(Starsplit);
                APIRES = APIRES.Substring(T1, APIRES.Length - T1);
                kq = APIRES.Substring(APIRES.IndexOf(Starsplit) + Starsplit.Length, (APIRES.Length) - APIRES.IndexOf(Starsplit) - Starsplit.Length);

            }
            catch (Exception ex) { }
            return kq;

        }

        public static string JSONSub(String APIRES, String Starsplit)
        {
            string kq = "";
            try
            {

                APIRES = APIRES.Substring(APIRES.IndexOf(Starsplit), APIRES.Length - APIRES.IndexOf(Starsplit));

                int EndIndex = APIRES.IndexOf(',');
                kq = APIRES.Substring(0 + Starsplit.Length, EndIndex - Starsplit.Length);


            }
            catch (Exception ex) { }
            return kq;

        }

        public static string JSON_FunctionFromAnyAPI(String API, String Function)
        {
            string kq = API;
            try
            {
               string FunctionAPI = DBase.JSONSub(API, "action=", "&");
               kq = API.Replace(FunctionAPI, Function);

            }

            catch (Exception ex) { }
            return kq;

        }

        public static Dictionary<string,string> JSONSubArray(String APIRES,String keysTring , string valueString)
        {
            Dictionary<string, string> kq = new  Dictionary<string,string>() ;
            try
            {
                int T = APIRES.IndexOf(keysTring);
               


            }
            catch (Exception ex) { }
            return kq;

        }

        public static decimal ToDecimal(string Value, string DecimalSeparator, string GroupSeparator)
        {
            decimal kq = 0;
            try
            {
                System.Globalization.NumberFormatInfo info = new System.Globalization.NumberFormatInfo();
                info.NumberDecimalSeparator = DecimalSeparator;
                info.NumberGroupSeparator = GroupSeparator;
                kq = Convert.ToDecimal(Value, info);
            }
            catch
                (Exception ex) { }

            return kq;
        }

        public static void SetTime(DateTime d)
        {
            try
            {
                string time = d.ToString("hh:mm:ss");
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.CreateNoWindow = true;
                startInfo.Arguments = "/C TIME " + time;
                startInfo.FileName = "CMD";
                System.Diagnostics.Process.Start(startInfo);
            }
            catch (Exception ex) { };
        }
        
        public static void SetMaxTheadConcurency()
        {
            Process P = new Process();
            try
            {
                
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.CreateNoWindow = true;
                startInfo.Arguments = "/c setx GPU_MAX_ALLOC_PERCENT 100" ;
                startInfo.FileName = "CMD";
                P.StartInfo = startInfo;
                P.Start();
            }
            catch (Exception ex) { };
            P.Dispose();
        }

        public static void SetObjectSync()
        {
            Process P = new Process();
            try
            {

                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.CreateNoWindow = true;
                startInfo.Arguments = "/c setx GPU USE SYNC OBJECTS";
                startInfo.FileName = "CMD";
                P.StartInfo = startInfo;
                P.Start();
            }
            catch (Exception ex) { };
            P.Dispose();
        }


        public static void SetMaxTheadConcurency_Clear()
        {
            try
            {

                //string keyName = @"Computer\HKEY_CURRENT_USER\Environment";

                string keyName = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run";
                


                RegistryKey key = Registry.CurrentUser.OpenSubKey(keyName,true);
                
                if (key == null)
                {
                    // Key doesn't exist. Do whatever you want to handle
                    // this case
                }
                else
                {
                       
                    key.DeleteValue("GPU_MAX_ALLOC_PERCENT");
                }
                
            }
            catch (Exception ex) { }

           
        }

        public static void SetNoRecovery()
        {
            Process P = new Process();
            try
            {

                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.CreateNoWindow = true;
                startInfo.Arguments = "/c bcdedit /set {default} recoveryenabled No";
                startInfo.FileName = "CMD";
                P.StartInfo = startInfo;
                P.Start();
            }
            catch (Exception ex) { };
           // P.Dispose();
            
        }


        public static void SetNoStarupFailures()
        {
            Process P = new Process();
            try
            {

                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.CreateNoWindow = true;
                startInfo.Arguments = "/c bcdedit /set {default} bootstatuspolicy ignoreallfailures";
                startInfo.FileName = "CMD";
                P.StartInfo = startInfo;
                P.Start();
            }
            catch (Exception ex) { };
         //   P.Dispose();
            
        }


        public static void Regedit_StartupApp(string appName)
        {
            try
            {
                Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run", appName, Application.ExecutablePath);
            }
            catch (Exception ex) { }

        }


        public static void Regedit_DeleteStartupApp(string appName)
        {
            try
            {
                string keyName = @"Software\Microsoft\Windows\CurrentVersion\Run";
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(keyName, true))
                {
                    if (key == null)
                    {
                        // Key doesn't exist. Do whatever you want to handle
                        // this case
                    }
                    else
                    {
                        key.DeleteValue(appName);
                    }
                }
            }
            catch (Exception ex) { }

        }
        public static void Regedit_Delete(string keyName , string appName)
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(keyName, true))
                {
                    if (key == null)
                    {
                        // Key doesn't exist. Do whatever you want to handle
                        // this case
                    }
                    else
                    {
                        key.DeleteValue(appName);
                    }
                }
            }
            catch (Exception ex) { }

        }



        public static string GetIP()
        {

            IPHostEntry host;
            string localIP = "?";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    localIP = ip.ToString();
                }
            }
            return localIP;
        }

        public static string ReadTextFromFile(string filename)
        {
            String kq = "";
            StreamReader sr = null;
            try
            {
                sr = File.OpenText("AutoCoinConfig.ini");
                kq = sr.ReadToEnd();
                sr.Dispose();
            }
            catch (Exception ex)
            {
                if (sr != null)
                    sr.Dispose();
            }
            return kq;
        }
        public static string ReplaceConfig(string ConfigFile , int Index , string NewConfig )
        {
            string kq = "";
            StreamReader sr = null;
            try
            {
                sr = File.OpenText(ConfigFile);
                string line = sr.ReadToEnd();
                String[] SS = line.Split(';');

                SS[Index] = NewConfig;

                sr.Dispose();

                try
                {
                   
                    for (int i = 0; i < SS.Length; i++)
                    {
                        kq = kq + kq ==""? ""+SS[i] : kq + ";" + SS[i];
                    }
                }
                catch (Exception ex)
                { }


            }
            catch (Exception ex)
            {
                if (sr != null)
                    sr.Dispose();
            }


            try
            {
                System.IO.File.WriteAllText(ConfigFile, kq);

            }
            catch (Exception ex)
            { }

            return kq;
        }

    }
    public static class Grap
    {
        [DllImport("user32.dll")]
        static extern IntPtr GetDC(IntPtr hwnd);

        [DllImport("user32.dll")]
        static extern Int32 ReleaseDC(IntPtr hwnd, IntPtr hdc);

        [DllImport("gdi32.dll")]
        static extern uint GetPixel(IntPtr hdc, int nXPos, int nYPos);

        static public System.Drawing.Color GetPixelColor(int x, int y)
        {
            IntPtr hdc = GetDC(IntPtr.Zero);
            uint pixel = GetPixel(hdc, x, y);
            ReleaseDC(IntPtr.Zero, hdc);
            Color color = Color.FromArgb((int)(pixel & 0x000000FF),
                         (int)(pixel & 0x0000FF00) >> 8,
                         (int)(pixel & 0x00FF0000) >> 16);
            return color;
        }

       
    }
}