using IEZettaiKillApp.Views;
using Prism.Ioc;
using System.Diagnostics;
using System.Windows;

namespace IEZettaiKillApp
{
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);

            if (e.ApplicationExitCode != 1995816)
            {
                var cloneProcess = Process.Start(@"IEZettaiKillApp.exe");
                cloneProcess.WaitForExit();
            }
        }
    }
}
