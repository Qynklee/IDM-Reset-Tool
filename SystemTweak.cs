﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace IDM_Reset_Tool
{
    /// <summary>
    /// This class Call Windows Task to kill Proc, and run as admin
    /// </summary>
    public class SystemTweak
    {
        /// <summary>
        /// Check tool is run as admin ?
        /// </summary>
        /// <returns></returns>
        public bool IsRunAsAdmin()
        {
            var identity = WindowsIdentity.GetCurrent();
            var principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        /// <summary>
        /// Kill IDMan.exe and IEMonitor.exe
        /// </summary>
        public bool KillIDMProc()
        {
            try
            {
                foreach (var procIDM in Process.GetProcessesByName("IDMan"))
                {
                    procIDM.Kill();
                }

                foreach (var procIEMonitor in Process.GetProcessesByName("IEMonitor.exe"))
                {
                    procIEMonitor.Kill();
                }
            }
            catch(Exception)
            {
                throw;
            }
            return true;
        }

    }
}
