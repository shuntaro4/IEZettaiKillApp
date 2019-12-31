using IEZettaiKillApp.Core.ApplicationService.Interfaces;
using IEZettaiKillApp.Core.Infrastructure;

namespace IEZettaiKillApp.Core.ApplicationService
{
    public class AutoLaunchService : IAutoLaunchService
    {
        private RunRegister runRegister;

        public AutoLaunchService()
        {
            runRegister = new RunRegister();
        }

        public void SetAutoLaunchSetting()
        {
            runRegister.RegistKey(true);
        }

        public void CancelAutoLaunchSetting()
        {
            runRegister.RegistKey(false);
        }
    }
}
