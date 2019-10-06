using Microsoft.Win32;

namespace IEZettaiKillApp.Domain
{
    public class IEGuard
    {
        public bool DefaultBrowserIsIE()
        {
            var name = GetDefaultBrowser();
            if (name.Contains("IE"))
            {
                return true;
            }
            return false;
        }

        public string GetDefaultBrowser()
        {
            var subkey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\Shell\Associations\UrlAssociations\http\UserChoice");
            var name = subkey?.GetValue("ProgId") as string;
            return name;
        }
    }
}
