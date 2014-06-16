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
    public partial class ConfigEditor : Form
    {
        StreamReader sr = null;

        public ConfigEditor()
        {
            InitializeComponent();
        }

        private void ConfigEditor_Load(object sender, EventArgs e)
        {
            try
            {
                sr = File.OpenText("AutoCoinConfig.ini");
                string line = sr.ReadToEnd();
                String[] SS = line.Split(';');
                edtConfig1.Text = SS[0].ToString();
                edtConfig2.Text = SS[1].ToString();
                edtConfig3.Text = SS[2].ToString();
           
                edtTeamviewerID.Text = SS[3].ToString();
                edtTeamviewerPass.Text = SS[4].ToString();
                edtMonitor2.Text = SS[5].ToString();
                edtMonitor3.Text = SS[6].ToString();
                edtMonitor4.Text = SS[7].ToString();
                edtMonitor5.Text = SS[8].ToString();
                edtMonitor6.Text = SS[9].ToString();
                edtMonitor7.Text = SS[10].ToString();


                sr.Dispose();
            }
            catch (Exception ex)
            {
                if (sr != null)
                    sr.Dispose();
            }


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (edtMonitor2.Text == "1") edtMonitor2.Text = "tramphuochuy";
                if (edtMonitor2.Text == "2") edtMonitor2.Text = "tramphuochuy2";
                if (edtMonitor2.Text == "3") edtMonitor2.Text = "tramphuochuy3";
                if (edtMonitor2.Text == "4") edtMonitor2.Text = "tramphuochuy4";
                if (edtMonitor2.Text == "5") edtMonitor2.Text = "tramphuochuy5";
                if (edtMonitor2.Text == "6") edtMonitor2.Text = "tramphuochuy6";
                if (edtMonitor2.Text == "7") edtMonitor2.Text = "tramphuochuy7";


                if (edtMonitor3.Text == "1") edtMonitor3.Text = "tramphuochuy";
                if (edtMonitor3.Text == "2") edtMonitor3.Text = "tramphuochuy2";
                if (edtMonitor3.Text == "3") edtMonitor3.Text = "tramphuochuy3";
                if (edtMonitor3.Text == "4") edtMonitor3.Text = "tramphuochuy4";
                if (edtMonitor3.Text == "5") edtMonitor3.Text = "tramphuochuy5";
                if (edtMonitor3.Text == "6") edtMonitor3.Text = "tramphuochuy6";
                if (edtMonitor3.Text == "7") edtMonitor3.Text = "tramphuochuy7";

                if (edtMonitor4.Text == "1") edtMonitor4.Text = "tramphuochuy";
                if (edtMonitor4.Text == "2") edtMonitor4.Text = "tramphuochuy2";
                if (edtMonitor4.Text == "3") edtMonitor4.Text = "tramphuochuy3";
                if (edtMonitor4.Text == "4") edtMonitor4.Text = "tramphuochuy4";
                if (edtMonitor4.Text == "5") edtMonitor4.Text = "tramphuochuy5";
                if (edtMonitor4.Text == "6") edtMonitor4.Text = "tramphuochuy6";
                if (edtMonitor4.Text == "7") edtMonitor4.Text = "tramphuochuy7";

                if (edtMonitor5.Text == "1") edtMonitor5.Text = "tramphuochuy";
                if (edtMonitor5.Text == "2") edtMonitor5.Text = "tramphuochuy2";
                if (edtMonitor5.Text == "3") edtMonitor5.Text = "tramphuochuy3";
                if (edtMonitor5.Text == "4") edtMonitor5.Text = "tramphuochuy4";
                if (edtMonitor5.Text == "5") edtMonitor5.Text = "tramphuochuy5";
                if (edtMonitor5.Text == "6") edtMonitor5.Text = "tramphuochuy6";
                if (edtMonitor5.Text == "7") edtMonitor5.Text = "tramphuochuy7";

                if (edtMonitor6.Text == "1") edtMonitor6.Text = "tramphuochuy";
                if (edtMonitor6.Text == "2") edtMonitor6.Text = "tramphuochuy2";
                if (edtMonitor6.Text == "3") edtMonitor6.Text = "tramphuochuy3";
                if (edtMonitor6.Text == "4") edtMonitor6.Text = "tramphuochuy4";
                if (edtMonitor6.Text == "5") edtMonitor6.Text = "tramphuochuy5";
                if (edtMonitor6.Text == "6") edtMonitor6.Text = "tramphuochuy6";
                if (edtMonitor6.Text == "7") edtMonitor6.Text = "tramphuochuy7";

                if (edtMonitor7.Text == "1") edtMonitor7.Text = "tramphuochuy";
                if (edtMonitor7.Text == "2") edtMonitor7.Text = "tramphuochuy2";
                if (edtMonitor7.Text == "3") edtMonitor7.Text = "tramphuochuy3";
                if (edtMonitor7.Text == "4") edtMonitor7.Text = "tramphuochuy4";
                if (edtMonitor7.Text == "5") edtMonitor7.Text = "tramphuochuy5";
                if (edtMonitor7.Text == "6") edtMonitor7.Text = "tramphuochuy6";
                if (edtMonitor7.Text == "7") edtMonitor7.Text = "tramphuochuy7";

                if (edtMonitor2.Text == "t") edtMonitor2.Text = "test";
                if (edtMonitor3.Text == "t") edtMonitor3.Text = "test";
                if (edtMonitor4.Text == "t") edtMonitor4.Text = "test";
                if (edtMonitor5.Text == "t") edtMonitor5.Text = "test";
                if (edtMonitor6.Text == "t") edtMonitor6.Text = "test";
                if (edtMonitor7.Text == "t") edtMonitor7.Text = "test";
               


                System.IO.File.WriteAllText("AutoCoinConfig.ini", edtConfig1.Text + ";" + edtConfig2.Text + ";" + edtConfig3.Text + ";" + edtTeamviewerID.Text + ";" + edtTeamviewerPass.Text + ";" + edtMonitor2.Text + ";" + edtMonitor3.Text + ";" + edtMonitor4.Text + ";" + edtMonitor5.Text + ";" + edtMonitor6.Text + ";" + edtMonitor7.Text);

            }
            catch (Exception ex)
            { }

            this.Close();
        }
    }
}
