using IEZettaiKillApp.Core.Domain;
using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace IEZettaiKillApp.Core.Infrastructure
{


    public class ScreenInfoHelper : IScreenInfoHelper
    {
        delegate bool EnumMonitorsDelegate(IntPtr hMonitor, IntPtr hdcMonitor, ref RECT lprcMonitor, IntPtr dwData);

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        private const int CCHDEVICENAME = 32;

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct MONITORINFOEX
        {
            public int Size;
            public RECT Monitor;
            public RECT WorkArea;
            public uint Flags;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = CCHDEVICENAME)]
            public string DeviceName;
        }

        [DllImport("user32.dll")]
        static extern bool EnumDisplayMonitors(IntPtr hdc, IntPtr lprcClip, EnumMonitorsDelegate lpfnEnum, IntPtr dwData);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern bool GetMonitorInfo(IntPtr hMonitor, ref MONITORINFOEX lpmi);

        [DllImport("SHCore.dll", CharSet = CharSet.Unicode, PreserveSig = false)]
        public static extern void GetDpiForMonitor(IntPtr hmonitor, MonitorDpiType dpiType, out uint dpiX, out uint dpiY);

        public enum MonitorDpiType
        {
            Effective,
            Angular,
            Raw,
            Default = Effective
        }

        private float normalScaleDpi = 96;

        public ScreenInfoCollection GetScreenInfoCollection()
        {
            var monitorInfoCollection = new ScreenInfoCollection();

            EnumDisplayMonitors(
                IntPtr.Zero,
                IntPtr.Zero,
                delegate (IntPtr hMonitor, IntPtr hdcmonitor, ref RECT lprcMonitor, IntPtr dwData)
                {
                    var monitorInfoEx = new MONITORINFOEX();
                    monitorInfoEx.Size = Marshal.SizeOf(monitorInfoEx);
                    var result = GetMonitorInfo(hMonitor, ref monitorInfoEx);
                    if (result)
                    {
                        var displayScale = GetScreenDisplayScale(hMonitor);
                        var screenInfo = new ScreenInfo(hMonitor, monitorInfoEx, displayScale);
                        monitorInfoCollection.Add(screenInfo);
                    }
                    return true;
                },
                IntPtr.Zero);

            return monitorInfoCollection;
        }

        public ScreenInfo GetPrimaryScreenInfo()
        {
            var screenInfoCollection = GetScreenInfoCollection();
            return screenInfoCollection.Where(x => x.IsPrimary).FirstOrDefault();
        }

        public float GetScreenDisplayScale(IntPtr hmon)
        {
            GetDpiForMonitor(hmon, MonitorDpiType.Default, out var dpiX, out var dpiY);
            var displayScale = dpiX / normalScaleDpi;
            return displayScale;
        }
    }
}
