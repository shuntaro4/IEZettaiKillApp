using IEZettaiKillApp.Core.ApplicationService.Interfaces;
using IEZettaiKillApp.Core.Infrastructure.Interfaces;
using Unity;

namespace IEZettaiKillApp.Core.ApplicationService
{
    public class IEZettaiKillService : IIEZettaiKillService
    {
        [Dependency]
        public ISystemSound SystemSound;

        [Dependency]
        public IProcessFinder ProcessFinder;

        public int KillIEProcesses()
        {
            var killCount = 0;
            var processes = ProcessFinder.FindByName("iexplore");
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
