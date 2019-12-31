using Microsoft.Win32;
using System;
using System.Diagnostics;

namespace IEZettaiKillApp.Domain
{
    public class RunRegister
    {
        private static string subKey = @"Software\Microsoft\Windows\CurrentVersion\Run";

        private static string valueKey = "IEZettaiKillApp";

        public RunRegister()
        {
        }

        public void RegistKey(bool autoLaunch)
        {
            try
            {
                var registry = Registry.CurrentUser.OpenSubKey(subKey, true);
                if (autoLaunch)
                {
                    registry.SetValue(valueKey, Process.GetCurrentProcess().MainModule.FileName);
                }
                else
                {
                    registry.DeleteValue(valueKey);
                }
            }
            catch
            {
                // do nothing
            }
        }

        public void Dispose()
        {
            RegistKey(false);
            GC.SuppressFinalize(this);
        }
    }
}
