using Prism.Mvvm;
using Reactive.Bindings;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace IEZettaiKillApp.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public ReactiveProperty<string> Title { get; } = new ReactiveProperty<string>("IEZettaiKillApp");

        public ReactiveProperty<string> StatusMessage { get; } = new ReactiveProperty<string>("IE Process Monitoring...");

        public ReactiveProperty<string> Message { get; } = new ReactiveProperty<string>("Kill Counter: 0");

        public ReactiveProperty<string> StartStopIcon { get; } = new ReactiveProperty<string>("■");

        public ReactiveCommand IEZettaiKillCommand { get; }

        public ReactiveCommand IEZettaiKillStartStopCommand { get; }

        private int ieKillCount;

        private bool killIE = true;

        public MainWindowViewModel()
        {
            IEZettaiKillCommand = new ReactiveCommand();
            IEZettaiKillCommand.Subscribe(IEZettaiKillAction);

            IEZettaiKillStartStopCommand = new ReactiveCommand();
            IEZettaiKillStartStopCommand.Subscribe(IEZettaiKillStartStopAction);
        }
        private async void IEZettaiKillAction()
        {
            while (true)
            {
                await Task.Delay(1000);
                if (!killIE)
                {
                    continue;
                }
                var processes = Process.GetProcesses();
                var ieProcesses = processes.Where(x => x.ProcessName.Contains("iexplore"));
                foreach (var ie in ieProcesses)
                {
                    ie.Kill(true);
                    Message.Value = $"Kill Counter:{++ieKillCount}";
                }
            }
        }

        private void IEZettaiKillStartStopAction()
        {
            killIE = !killIE;
            if (killIE)
            {
                StartStopIcon.Value = "■";
                StatusMessage.Value = "IE Monitoring...";
            }
            else
            {
                StartStopIcon.Value = "▶";
                StatusMessage.Value = "Stop";
            }
        }
    }
}
