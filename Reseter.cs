using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IDM_Reset_Tool
{
    public class Reseter
    {
        private static string ID1 = "{7B8E9164-324D-4A2E-A46D-0165FB2000EC}";
        private static string ID2 = "{6DDF00DB-1234-46EC-8356-27E7B2051192}";
        private static string ID3 = "{D5B91409-A8CA-4973-9A0B-59F713D25671}";
        private static string ID4 = "{07999AC3-058B-40BF-984F-69EB1E554CA7}";
        private static string ID5 = "{5ED60779-4DE2-4E07-B862-974CA4FF2E9C}";

        private SystemTweak STW;

        public Reseter()
        {
            this.STW = new SystemTweak();
        }

        public bool DeleteKeyValue()
        {

            try
            {
                //ID1:
                Registry.ClassesRoot.DeleteSubKeyTree(@"CLSID\" + ID1, false);
                Registry.CurrentUser.DeleteSubKeyTree(@"Software\Classes\Wow6432Node\CLSID\" + ID1, false);
                Registry.CurrentUser.DeleteSubKeyTree(@"Software\Classes\CLSID\" + ID1, false);
                Registry.LocalMachine.DeleteSubKeyTree(@"Software\Classes\Wow6432Node\CLSID\" + ID1, false);
                Registry.LocalMachine.DeleteSubKeyTree(@"Software\Classes\CLSID\" + ID1, false);

                //ID2:
                Registry.ClassesRoot.DeleteSubKeyTree(@"CLSID\" + ID2, false);
                Registry.CurrentUser.DeleteSubKeyTree(@"Software\Classes\Wow6432Node\CLSID\" + ID2, false);
                Registry.CurrentUser.DeleteSubKeyTree(@"Software\Classes\CLSID\" + ID2, false);
                Registry.LocalMachine.DeleteSubKeyTree(@"Software\Classes\Wow6432Node\CLSID\" + ID2, false);
                Registry.LocalMachine.DeleteSubKeyTree(@"Software\Classes\CLSID\" + ID2, false);

                //ID3:
                Registry.ClassesRoot.DeleteSubKeyTree(@"CLSID\" + ID3, false);
                Registry.CurrentUser.DeleteSubKeyTree(@"Software\Classes\Wow6432Node\CLSID\" + ID3, false);
                Registry.CurrentUser.DeleteSubKeyTree(@"Software\Classes\CLSID\" + ID3, false);
                Registry.LocalMachine.DeleteSubKeyTree(@"Software\Classes\Wow6432Node\CLSID\" + ID3, false);
                Registry.LocalMachine.DeleteSubKeyTree(@"Software\Classes\CLSID\" + ID3, false);

                //ID4:
                Registry.ClassesRoot.DeleteSubKeyTree(@"CLSID\" + ID4, false);
                Registry.CurrentUser.DeleteSubKeyTree(@"Software\Classes\Wow6432Node\CLSID\" + ID4, false);
                Registry.CurrentUser.DeleteSubKeyTree(@"Software\Classes\CLSID\" + ID4, false);
                Registry.LocalMachine.DeleteSubKeyTree(@"Software\Classes\Wow6432Node\CLSID\" + ID4, false);
                Registry.LocalMachine.DeleteSubKeyTree(@"Software\Classes\CLSID\" + ID4, false);

                //ID5:
                Registry.ClassesRoot.DeleteSubKeyTree(@"CLSID\" + ID5, false);
                Registry.CurrentUser.DeleteSubKeyTree(@"Software\Classes\Wow6432Node\CLSID\" + ID5, false);
                Registry.CurrentUser.DeleteSubKeyTree(@"Software\Classes\CLSID\" + ID5, false);
                Registry.LocalMachine.DeleteSubKeyTree(@"Software\Classes\Wow6432Node\CLSID\" + ID5, false);
                Registry.LocalMachine.DeleteSubKeyTree(@"Software\Classes\CLSID\" + ID5, false);


                //FIX:
                Registry.CurrentUser.DeleteSubKeyTree(@"SOFTWARE\Backup_IDM", false);
            }
            catch (Exception)
            {
                throw;
            }
            return true;
        }


        public bool DeleteKeySIDValue()
        {
            try
            {
                string SID = STW.GetCurrentSID();

                //ID1:
                Registry.Users.DeleteSubKeyTree(SID + @"\Software\Classes\CLSID\" + ID1, false);
                Registry.Users.DeleteSubKeyTree(SID + @"_Classes\CLSID\" + ID1, false);

                //ID2:
                Registry.Users.DeleteSubKeyTree(SID + @"\Software\Classes\CLSID\" + ID2, false);
                Registry.Users.DeleteSubKeyTree(SID + @"_Classes\CLSID\" + ID2, false);

                //ID3:
                Registry.Users.DeleteSubKeyTree(SID + @"\Software\Classes\CLSID\" + ID3, false);
                Registry.Users.DeleteSubKeyTree(SID + @"_Classes\CLSID\" + ID3, false);

                //ID4:
                Registry.Users.DeleteSubKeyTree(SID + @"\Software\Classes\CLSID\" + ID4, false);
                Registry.Users.DeleteSubKeyTree(SID + @"_Classes\CLSID\" + ID4, false);

                //ID5:
                Registry.Users.DeleteSubKeyTree(SID + @"\Software\Classes\CLSID\" + ID5, false);
                Registry.Users.DeleteSubKeyTree(SID + @"_Classes\CLSID\" + ID5, false);
            }
            catch (Exception)
            {
                throw;
            }

            return true;
        }

        public bool ResetRegKey()
        {
            try
            {
                string SID = STW.GetCurrentSID();
                //Delete Invalid Reg:
                RegistryKey Key2DeleteValue = Registry.CurrentUser.OpenSubKey(@"Software\DownloadManager", true);
                Key2DeleteValue.DeleteValue("CheckUpdtVM", false);
                Key2DeleteValue.DeleteValue("scansk", false);
                Key2DeleteValue.DeleteValue("tvfrdt", false);
                Key2DeleteValue.DeleteValue("LstCheck", false);
                Key2DeleteValue.DeleteValue("FName", false);
                Key2DeleteValue.DeleteValue("LName", false);
                Key2DeleteValue.DeleteValue("Email", false);
                Key2DeleteValue.DeleteValue("Serial", false);

                //Delete Invalid Reg Key in SID:
                RegistryKey KeyRegAllUser = Registry.Users.OpenSubKey(SID + @"\Software\DownloadManager", true);
                if (KeyRegAllUser != null)
                {
                    KeyRegAllUser.DeleteValue("FName", false);
                    KeyRegAllUser.DeleteValue("LName", false);
                    KeyRegAllUser.DeleteValue("Email", false);
                    KeyRegAllUser.DeleteValue("Serial", false);
                    KeyRegAllUser.DeleteValue("CheckUpdtVM", false);
                    KeyRegAllUser.DeleteValue("scansk", false);
                    KeyRegAllUser.DeleteValue("tvfrdt", false);
                }

            }
            catch (Exception)
            {
                throw;
            }

            return true;
        }

        public bool RegistrationWithTrialInfor()
        {
            try
            {
                //+++++++++++++++++++++++++++ Old Menthod:
                //1
                Registry.LocalMachine.CreateSubKey(@"Software\Internet Download Manager", true);
                Registry.LocalMachine.OpenSubKey(@"Software\Internet Download Manager", true).SetValue("FName", "", RegistryValueKind.String);
                Registry.LocalMachine.OpenSubKey(@"Software\Internet Download Manager", true).SetValue("LName", "", RegistryValueKind.String);
                Registry.LocalMachine.OpenSubKey(@"Software\Internet Download Manager", true).SetValue("Email", "", RegistryValueKind.String);
                Registry.LocalMachine.OpenSubKey(@"Software\Internet Download Manager", true).SetValue("Serial", "", RegistryValueKind.String);

                Registry.LocalMachine.OpenSubKey(@"Software\Internet Download Manager", true).SetValue("CheckUpdtVM", "", RegistryValueKind.String);
                Registry.LocalMachine.OpenSubKey(@"Software\Internet Download Manager", true).SetValue("scansk", "", RegistryValueKind.String);
                Registry.LocalMachine.OpenSubKey(@"Software\Internet Download Manager", true).SetValue("tvfrdt", "", RegistryValueKind.String);

                Registry.LocalMachine.CreateSubKey(@"Software\Wow6432Node\Internet Download Manager", true);
                Registry.LocalMachine.OpenSubKey(@"Software\Wow6432Node\Internet Download Manager", true).SetValue("FName", "", RegistryValueKind.String);
                Registry.LocalMachine.OpenSubKey(@"Software\Wow6432Node\Internet Download Manager", true).SetValue("LName", "", RegistryValueKind.String);
                Registry.LocalMachine.OpenSubKey(@"Software\Wow6432Node\Internet Download Manager", true).SetValue("Email", "", RegistryValueKind.String);
                Registry.LocalMachine.OpenSubKey(@"Software\Wow6432Node\Internet Download Manager", true).SetValue("Serial", "", RegistryValueKind.String);

                Registry.LocalMachine.OpenSubKey(@"Software\Wow6432Node\Internet Download Manager", true).SetValue("CheckUpdtVM", "", RegistryValueKind.String);
                Registry.LocalMachine.OpenSubKey(@"Software\Wow6432Node\Internet Download Manager", true).SetValue("scansk", "", RegistryValueKind.String);
                Registry.LocalMachine.OpenSubKey(@"Software\Wow6432Node\Internet Download Manager", true).SetValue("tvfrdt", "", RegistryValueKind.String);

                Registry.LocalMachine.OpenSubKey(@"Software\Wow6432Node\Internet Download Manager", true).SetValue("InstallStatus", 1, RegistryValueKind.DWord);
            }
            catch (Exception)
            {
                throw;
            }


            try {
            //++++++++++++++++++++++++++++++New Menthod:
            Registry.CurrentUser.CreateSubKey(@"Software\DownloadManager", true);
                Registry.CurrentUser.OpenSubKey(@"Software\DownloadManager", true).SetValue("FName", "", RegistryValueKind.String);
                Registry.CurrentUser.OpenSubKey(@"Software\DownloadManager", true).SetValue("LName", "", RegistryValueKind.String);
                Registry.CurrentUser.OpenSubKey(@"Software\DownloadManager", true).SetValue("Email", "", RegistryValueKind.String);
                Registry.CurrentUser.OpenSubKey(@"Software\DownloadManager", true).SetValue("Serial", "", RegistryValueKind.String);

                Registry.CurrentUser.OpenSubKey(@"Software\DownloadManager", true).SetValue("CheckUpdtVM", "", RegistryValueKind.String);
                Registry.CurrentUser.OpenSubKey(@"Software\DownloadManager", true).SetValue("scansk", "", RegistryValueKind.String);
                Registry.CurrentUser.OpenSubKey(@"Software\DownloadManager", true).SetValue("tvfrdt", "", RegistryValueKind.String);

                Registry.CurrentUser.OpenSubKey(@"Software\DownloadManager", true).SetValue("LastCheckQU", 0, RegistryValueKind.DWord);
                Registry.CurrentUser.OpenSubKey(@"Software\DownloadManager", true).SetValue("LstCheck", "", RegistryValueKind.String);
                // counter open IDM.exe:
                Registry.CurrentUser.OpenSubKey(@"Software\DownloadManager", true).SetValue("radxcnt", 0, RegistryValueKind.DWord);


                //string SID = STW.GetCurrentSID();
                ////Registry.Users.CreateSubKey(SID + @"Software\DownloadManager");
                //Registry.Users.OpenSubKey(SID + @"Software\DownloadManager", true).SetValue("FName", "", RegistryValueKind.String);
                //Registry.Users.OpenSubKey(SID + @"Software\DownloadManager",true).SetValue("LName", "", RegistryValueKind.String);
                //Registry.Users.OpenSubKey(SID + @"Software\DownloadManager",true).SetValue("Email", "", RegistryValueKind.String);
                //Registry.Users.OpenSubKey(SID + @"Software\DownloadManager",true).SetValue("Serial", "", RegistryValueKind.String);

                //Registry.Users.OpenSubKey(SID + @"Software\DownloadManager",true).SetValue("CheckUpdtVM", "", RegistryValueKind.String);
                //Registry.Users.OpenSubKey(SID + @"Software\DownloadManager",true).SetValue("scansk", "", RegistryValueKind.String);
                //Registry.Users.OpenSubKey(SID + @"Software\DownloadManager",true).SetValue("tvfrdt", "", RegistryValueKind.String);
            }
            catch (Exception)
            {
                throw;
            }


            return true;
        }


        public string DeleteOldSettingsBAKFile()
        {
            //string cachePath = "C:\Users\<USERNAME>\AppData\Roaming\DMCache\settings.bak";

            string AppDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string FolderToDelete = Path.Combine(AppDataFolder, "DMCache");

            try
            {
                Directory.Delete(FolderToDelete, true);
            }
            catch (Exception)
            {
                throw;
            }

            return FolderToDelete;
        }
    }
}
