using Microsoft.Win32;

namespace IEZettaiKillApp.Domain
{
    public class IEGuard
    {
        public string GetDefaultBrowser()
        {
            var subkey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\Shell\Associations\UrlAssociations\http\UserChoice");
            var name = subkey?.GetValue("ProgId") as string;
            return name;
        }
    }
}
