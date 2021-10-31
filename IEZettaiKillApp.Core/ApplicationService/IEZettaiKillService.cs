using IEZettaiKillApp.Core.ApplicationService.Interfaces;
using IEZettaiKillApp.Core.Infrastructure;

namespace IEZettaiKillApp.Core.ApplicationService
{
    public class IEZettaiKillService : IIEZettaiKillService
    {
        public int KillIEProcesses()
        {
            var killCount = 0;
            var processFinder = new ProcessFinder();
            var processes = processFinder.FindByName("iexplore");
            foreach (var ieProcess in processes)
            {
                ieProcess.Kill();
                killCount++;
                SystemSound.Beep();
            }
            return killCount;
        }
    }
}
