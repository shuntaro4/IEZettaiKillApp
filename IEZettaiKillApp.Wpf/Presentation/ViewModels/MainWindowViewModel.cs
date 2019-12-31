
using IEZettaiKillApp.Core.ApplicationService.Interfaces;
using Prism.Mvvm;
using Reactive.Bindings;
using System.Threading.Tasks;
using Unity;

namespace IEZettaiKillApp.Presentation.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        [Dependency]
        public IIEZettaiKillService IEZettaiKillService { get; set; }

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
        private async void WindowContentRenderedAction()
        {
            while (true)
            {
                await Task.Delay(1000);

                ieKillCount += IEZettaiKillService.KillIEProcesses();
                Message.Value = $"Kill Counter: {ieKillCount}";
            }
        }
    }
}
