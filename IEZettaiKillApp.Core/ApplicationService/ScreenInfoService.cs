using IEZettaiKillApp.Core.ApplicationService.Interfaces;
using IEZettaiKillApp.Core.Domain;
using Unity;

namespace IEZettaiKillApp.Core.ApplicationService
{
    public class ScreenInfoService : IScreenInfoService
    {
        [Dependency]
        public IScreenInfoHelper ScreenInfoHelper { get; set; }

        public ScreenInfo GetPrimaryScreenInfo()
        {
            return ScreenInfoHelper.GetPrimaryScreenInfo();
        }
    }
}
