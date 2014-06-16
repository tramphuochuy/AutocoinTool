using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace AutoCoin
{
    public partial class Config : Form
    {
        StreamReader sr = null;
        public string AccountName = "";
        public string Password = "1";
        string WorkerPrefix = "";
        public int res = 0;
        public string config = "";
        public Config()
        {
            InitializeComponent();
        }

        private void AddUserCode_Load(object sender, EventArgs e)
        {
            try
            {
                sr = File.OpenText("AutoCoin.ini");
                string line = sr.ReadToEnd();
                String[] SS = line.Split(';');
              
                edtUserCode.Text = SS[0].ToString();
                edtPrefix.Text = WorkerPrefix = SS[1].ToString();
                edtConfig.Text = SS[2].ToString();
                edtPass.Text  = SS[3].ToString();
                edtResetValue.Text = WorkerPrefix = SS[4].ToString();
                sr.Dispose();
            }
            catch (Exception ex)
            {
               //if (  MessageBox.Show("","",MessageBoxButtons.YesNo,MessageBoxIcon.Asterisk,MessageBoxDefaultButton.Button1 ) == System.Windows.Forms.DialogResult.Yes)
               // {
               //     loadDefaultToolStripMenuItem_Click(null, null);
               // }
               // if (sr != null)
               //     sr.Dispose();
            }

            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                if (edtUserCode.Text == "1") edtUserCode.Text = "tramphuochuy";
                if (edtUserCode.Text == "2") edtUserCode.Text = "tramphuochuy2";
                if (edtUserCode.Text == "3") edtUserCode.Text = "tramphuochuy3";
                if (edtUserCode.Text == "4") edtUserCode.Text = "tramphuochuy4";
                if (edtUserCode.Text == "5") edtUserCode.Text = "tramphuochuy5";
                if (edtUserCode.Text == "6") edtUserCode.Text = "tramphuochuy6";
                if (edtUserCode.Text == "7") edtUserCode.Text = "tramphuochuy7";
                if (edtUserCode.Text == "t") edtUserCode.Text = "test";

                int kq =  DStatic.Login(edtUserCode.Text, edtPass.Text);
                if (kq <= 0)
                {
                    MessageBox.Show("Account incorrect !");
                    return;
                }

                AccountName = edtUserCode.Text;
                Password = edtPass.Text;
               
                
            }
            catch (Exception ex)
            { }

            res = 1;
            this.Close();
        }

        private void loadDefaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            edtConfig.Text = "cgminer4   --scrypt  --lookup-gap 2 -w 256 ";
            edtUserCode.Text = "tramphuochuy";
            edtPrefix.Text = "1";
        }

        private void REGISTER(object sender, EventArgs e)
        {
            Register R = new Register();
            R.ShowDialog();
            edtUserCode.Text = R.Username;
            edtPass.Text = R.password;
        }

        private void edtUserCode_TextChanged(object sender, EventArgs e)
        {

        }

        private void edtUserCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) button1.PerformClick();
        }
    }
}
