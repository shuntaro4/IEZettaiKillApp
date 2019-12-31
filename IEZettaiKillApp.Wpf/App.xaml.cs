using IEZettaiKillApp.Core.ApplicationService;
using IEZettaiKillApp.Core.ApplicationService.Interfaces;
using IEZettaiKillApp.Core.Infrastructure;
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
            containerRegistry.Register<RunRegister>();
            containerRegistry.Register<IDefaultBrowserService, DefaultBrowserService>();
            containerRegistry.Register<IAutoLaunchService, AutoLaunchService>();
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
