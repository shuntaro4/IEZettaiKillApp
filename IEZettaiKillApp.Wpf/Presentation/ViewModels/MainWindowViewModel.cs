
using IEZettaiKillApp.Core.ApplicationService.Interfaces;
using IEZettaiKillApp.Core.Domain;
using Prism.Mvvm;
using Reactive.Bindings;
using System.Threading.Tasks;
using System.Windows;
using Unity;

namespace IEZettaiKillApp.Presentation.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        [Dependency]
        public IAutoLaunchService AutoLaunchService { get; set; }

        [Dependency]
        public IIEZettaiKillService IEZettaiKillService { get; set; }

        [Dependency]
        public IDefaultBrowserService DefaultBrowserService { get; set; }

        [Dependency]
        public IScreenInfoService ScreenInfoService { get; set; }

        public ReactiveProperty<string> Title { get; } = new ReactiveProperty<string>("IEZettaiKillApp");

        public ReactiveProperty<string> StatusMessage { get; } = new ReactiveProperty<string>("IE Process Monitoring...");

        public ReactiveProperty<string> Message { get; } = new ReactiveProperty<string>("Kill Counter: 0");

        public ReactiveCommand WindowContentRenderedCommand { get; }

        private int ieKillCount;

        public MainWindowViewModel()
        {
            WindowContentRenderedCommand = new ReactiveCommand();
            WindowContentRenderedCommand.Subscribe(WindowContentRenderedAction);
        }

        public ScreenInfo GetPrimaryScreenInfo()
        {
            return ScreenInfoService.GetPrimaryScreenInfo();
        }

        private async void WindowContentRenderedAction()
        {
            AutoLaunchService.SetAutoLaunchSetting();

            if (DefaultBrowserService.IsIE())
            {
                MessageBox.Show("Oh...Your default browser is IE.\r\n" +
                    "You need to change a default browser.\r\n" +
                    "Because I keep killing IE Process.");
            }

            while (true)
            {
                await Task.Delay(1000);

                ieKillCount += IEZettaiKillService.KillIEProcesses();
                Message.Value = $"Kill Counter: {ieKillCount}";
            }
        }
    }
}
