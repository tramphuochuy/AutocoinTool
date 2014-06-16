using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;

namespace AutoCoin
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            Process[] P = Process.GetProcesses();
            int kq = 0;
            foreach (Process p in P)
            {
                string pname = p.ProcessName;
                if (pname.ToUpper() == "AUTOCOIN")
                {
                    kq++;
                }
            }

            if (kq > 1)
            {
           //   MessageBox.Show("Already running...");

                Application.Exit();
            }
            else
            {
              //  MessageBox.Show(kq.ToString());
                   Application.Run(new Main());
                 
                
            }
        }
    }
}
