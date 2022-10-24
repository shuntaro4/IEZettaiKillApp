using IEZettaiKillApp.Core.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace IEZettaiKillApp.Core.Infrastructure
{
    public class ProcessFinder : IProcessFinder
    {
        public IEnumerable<IIEZettaiProcess> FindByName(string name)
        {
            var processes = Process.GetProcesses();
            return processes.Where(x => x.ProcessName.Contains(name)).Select(x => new IEZettaiProcess(x));
        }
    }
}
