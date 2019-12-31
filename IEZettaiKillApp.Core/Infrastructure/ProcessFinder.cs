using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace IEZettaiKillApp.Core.Infrastructure
{
    internal class ProcessFinder
    {
        public IEnumerable<Process> FindByName(string name)
        {
            var processes = Process.GetProcesses();
            return processes.Where(x => x.ProcessName.Contains(name));
        }
    }
}
