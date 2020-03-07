using System;

namespace IEZettaiKillApp.Core.Domain
{
    public interface IScreenInfoHelper
    {
        ScreenInfo GetPrimaryScreenInfo();

        float GetScreenDisplayScale(IntPtr hmon);

        ScreenInfoCollection GetScreenInfoCollection();
    }
}