using Microsoft.Win32;

namespace IEZettaiKillApp.Core.Domain
{
    public class IEKiller
    {
        public bool DefaultWebBrowserIsIE()
        {
            var webBrowserType = GetDefaultBrowser();
            if (webBrowserType == WebBrowserType.IE)
            {
                return true;
            }
            return false;
        }

        public WebBrowserType GetDefaultBrowser()
        {
            var subkey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\Shell\Associations\UrlAssociations\http\UserChoice");
            var name = subkey?.GetValue("ProgId") as string;
            if (name.Contains("IE"))
            {
                return WebBrowserType.IE;
            }
            return WebBrowserType.OTHER;
        }
    }
}
