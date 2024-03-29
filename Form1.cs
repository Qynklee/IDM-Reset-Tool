﻿using System;
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
        private LogWriter LOG;

        public Form1(string VERSION)
        {
            InitializeComponent();
            STW = new SystemTweak();
            RST = new Reseter();
            LOG = new LogWriter("QYNKLEE");
            this.Text = "Reset IDM Tool " + VERSION;
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
                    string FolderDeleted = RST.DeleteOldSettingsBAKFile();

                    LOG.LogWrite("Deleted " + FolderDeleted);
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Something were wrong!!! Please contact admin");
                    LOG.LogWrite(ex.ToString());
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

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult abouttool = MessageBox.Show("Tested: IDM v6.41 build 6");
        }
    }
}
