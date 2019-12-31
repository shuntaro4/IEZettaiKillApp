using Microsoft.Win32;

namespace IEZettaiKillApp.Core.Domain
{
    public class DefaultBrowser
    {
        private WebBrowserType type;

        public bool IsIE
        {
            get
            {
                if (type == WebBrowserType.IE)
                {
                    return true;
                }
                return false;
            }
        }

        public DefaultBrowser()
        {
            var subkey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\Shell\Associations\UrlAssociations\http\UserChoice");
            var name = subkey?.GetValue("ProgId") as string ?? "";
            type = name.Contains("IE") ? WebBrowserType.IE : WebBrowserType.OTHER;
        }
    }
}
