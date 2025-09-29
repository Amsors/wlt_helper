using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using IWshRuntimeLibrary;

namespace wlt_helper.Services
{
    internal class AppSettings
    {
        public static bool autostartEnable;

        public static bool SetAutoStart(string shortcutName = "MyApp", string description = "Default")
        {
            try
            {
                string startupPath = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
                Debug.WriteLine(startupPath);
                string shortcutPath = Path.Combine(startupPath, $"{shortcutName}.lnk");
                //string appPath = Process.GetCurrentProcess().MainModule.FileName;
                string? appPath = Environment.ProcessPath;
                if (appPath == null)
                {
                    Debug.WriteLine("Error");
                    return false;
                }

                if (autostartEnable)
                {
                    WshShell shell = new WshShell();
                    IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutPath);

                    shortcut.TargetPath = appPath;
                    shortcut.WorkingDirectory = Path.GetDirectoryName(appPath);
                    shortcut.Description = description;
                    //shortcut.IconLocation = "icon.ico, 0";

                    shortcut.Save();
                }
                else
                {
                    if (System.IO.File.Exists(shortcutPath))
                    {
                        System.IO.File.Delete(shortcutPath);
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static byte[] GetIconBytes()
        {
            return Properties.Resources.icon_1_16x16;
        }

        public static Icon BytesToIcon(byte[] iconBytes)
        {
            using (MemoryStream ms = new MemoryStream(iconBytes))
            {
                return new Icon(ms);
            }
        }

        public static void ReadConfigFile()
        {
            if (System.IO.File.Exists("wlt_helper_config.json"))
            {
                Debug.WriteLine("存在配置文件");
            }
            else
            {
                Debug.WriteLine("不存在配置文件");
            }
        }
    }

    internal static class Config
    {
        private static bool _hideOnLaunch = false;
        public static bool HideOnLaunch
        {
            get
            {
                return _hideOnLaunch;
            }
            set
            {
                _hideOnLaunch = value;
            }
        }
        private static bool _launchOnBoot = false;
        public static bool LaunchOnBoot
        {
            get
            {
                return _launchOnBoot;
            }
            set
            {

                _launchOnBoot = value;
            }
        }
    }
}
