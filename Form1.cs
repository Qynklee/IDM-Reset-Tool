using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IDM_Reset_Tool
{
    public partial class Form1 : Form
    {
        private SystemTweak STW;
        private Reseter RST;
        public Form1()
        {
            InitializeComponent();
            STW = new SystemTweak();
            RST = new Reseter();
        }

        private void btnDebug_Click(object sender, EventArgs e)
        {
            btnDebug.Text=  STW.GetCurrentSID();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if(STW.IsRunAsAdmin())
            {
                try
                {
                    STW.KillIDMProc();
                    RST.DeleteKeyValue();
                    RST.DeleteKeySIDValue();
                    RST.ResetRegKey();
                    RST.RegistrationWithTrialInfor();
                }
                catch
                {
                    MessageBox.Show("Something were wrong!!! Please contact admin");
                    return;
                }
                MessageBox.Show("Reset was successfully");
                return;
            }
            else
            {
                MessageBox.Show("Please re run as admin", "Admin Permission Required");
            }
        }
    }
}
