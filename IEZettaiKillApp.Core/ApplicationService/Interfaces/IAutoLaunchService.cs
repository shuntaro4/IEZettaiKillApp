namespace IEZettaiKillApp.Core.ApplicationService.Interfaces
{
    public interface IAutoLaunchService
    {
        void CancelAutoLaunchSetting();

        void SetAutoLaunchSetting();
    }
}