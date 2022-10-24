using IEZettaiKillApp.Core.ApplicationService;
using IEZettaiKillApp.Core.ApplicationService.Interfaces;
using IEZettaiKillApp.Core.Domain;
using IEZettaiKillApp.Core.Infrastructure;
using IEZettaiKillApp.Core.Infrastructure.Interfaces;
using IEZettaiKillApp.Presentation.Views;
using Prism.Ioc;
using System.Diagnostics;
using System.Threading;
using System.Windows;

namespace IEZettaiKillApp
{
    public partial class App
    {
        private static readonly string mutexName = "IEZettailKillApp";

        private static Mutex mutex = new Mutex(false, mutexName);

        private static bool hasHandle = false;

        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // IEZettaiKillApp.Core
            // ApplicationService
            containerRegistry.Register<IDefaultBrowserService, DefaultBrowserService>();
            containerRegistry.Register<IAutoLaunchService, AutoLaunchService>();
            containerRegistry.Register<IIEZettaiKillService, IEZettaiKillService>();
            containerRegistry.Register<IScreenInfoService, ScreenInfoService>();
            // Domain
            containerRegistry.Register<IScreenInfoHelper, ScreenInfoHelper>();
            // Infrastructure
            containerRegistry.Register<IIEZettaiProcess, IEZettaiProcess>();
            containerRegistry.Register<IProcessFinder, ProcessFinder>();
            containerRegistry.Register<ISystemSound, SystemSound>();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            hasHandle = mutex.WaitOne(0, false);
            if (!hasHandle)
            {
                Shutdown(1995816);
                return;
            }

            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);

            if (hasHandle)
            {
                mutex.ReleaseMutex();
            }

            mutex.Close();

            if (e.ApplicationExitCode != 1995816)
            {
                var cloneProcess = Process.Start(@"IEZettaiKillApp.exe");
                cloneProcess.WaitForExit();
            }
        }
    }
}
