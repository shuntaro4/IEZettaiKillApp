using IEZettaiKillApp.Core.Infrastructure.Interfaces;
using System.Diagnostics;

namespace IEZettaiKillApp.Core.Infrastructure
{
    public class IEZettaiProcess : IIEZettaiProcess
    {
        private Process Process { get; }

        public IEZettaiProcess(Process process)
        {
            Process = process;
        }

        public void Kill()
        {
            Process.Kill();
        }
    }
}
