using Microsoft.Win32;

namespace IEZettaiKillApp.Core.Domain
{
    public class IEKiller
    {
        public bool DefaultWebBrowserIsIE()
        {
            var webBrowserType = GetDefaultBrowser();
            if (webBrowserType == DefaultBrowserType.IE)
            {
                return true;
            }
            return false;
        }

        public DefaultBrowserType GetDefaultBrowser()
        {
            var subkey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\Shell\Associations\UrlAssociations\http\UserChoice");
            var name = subkey?.GetValue("ProgId") as string;
            if (name.Contains("IE"))
            {
                return DefaultBrowserType.IE;
            }
            return DefaultBrowserType.OTHER;
        }
    }
}
