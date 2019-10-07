using Microsoft.Win32;

namespace IEZettaiKillApp.Domain
{
    public class IEKiller
    {
        public bool DefaultWebBrowserIsIE()
        {
            var webBrowser = GetDefaultBrowser();
            if (webBrowser == WebBrowser.IE)
            {
                return true;
            }
            return false;
        }

        public WebBrowser GetDefaultBrowser()
        {
            var subkey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\Shell\Associations\UrlAssociations\http\UserChoice");
            var name = subkey?.GetValue("ProgId") as string;
            if (name.Contains("IE"))
            {
                return WebBrowser.IE;
            }
            return WebBrowser.OTHER;
        }
    }
}
