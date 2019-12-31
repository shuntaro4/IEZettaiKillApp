
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

        public ReactiveCommand IEZettaiKillCommand { get; }

        private int ieKillCount;

        public MainWindowViewModel()
        {
            IEZettaiKillCommand = new ReactiveCommand();
            IEZettaiKillCommand.Subscribe(IEZettaiKillAction);
        }
        private async void IEZettaiKillAction()
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
