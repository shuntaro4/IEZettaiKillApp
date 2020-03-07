using System;
using static IEZettaiKillApp.Core.Infrastructure.ScreenInfoHelper;

namespace IEZettaiKillApp.Core.Domain
{
    public class ScreenInfo
    {
        public IntPtr Hmon { get; private set; }

        public int Left { get; private set; }

        public int Top { get; private set; }

        public int Right { get; private set; }

        public int Bottom { get; private set; }

        public float DisplayScale { get; private set; }

        public bool IsPrimary { get; private set; }

        public ScreenInfo(IntPtr hmon, MONITORINFOEX monitorInfoEx, float displayScale)
        {
            Hmon = hmon;
            Left = monitorInfoEx.Monitor.Left;
            Top = monitorInfoEx.Monitor.Top;
            Right = monitorInfoEx.Monitor.Right;
            Bottom = monitorInfoEx.Monitor.Bottom;
            DisplayScale = displayScale;
            IsPrimary = monitorInfoEx.Flags > 0;
        }
    }
}
