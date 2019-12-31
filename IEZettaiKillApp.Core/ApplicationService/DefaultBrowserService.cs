using IEZettaiKillApp.Core.ApplicationService.Interfaces;
using IEZettaiKillApp.Core.Domain;

namespace IEZettaiKillApp.Core.ApplicationService
{
    public class DefaultBrowserService : IDefaultBrowserService
    {
        public bool IsIE()
        {
            var defaultBrowser = new DefaultBrowser();
            return defaultBrowser?.IsIE ?? false;
        }
    }
}
