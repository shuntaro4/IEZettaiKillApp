using IEZettaiKillApp.Views;
using Prism.Ioc;
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
    }
}
