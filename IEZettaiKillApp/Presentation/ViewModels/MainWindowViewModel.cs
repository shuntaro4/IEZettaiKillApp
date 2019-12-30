﻿using Prism.Mvvm;
using Reactive.Bindings;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace IEZettaiKillApp.Presentation.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
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

                var processes = Process.GetProcesses();
                var ieProcesses = processes.Where(x => x.ProcessName.Contains("iexplore"));
                foreach (var ie in ieProcesses)
                {
                    ie.Kill(true);
                    Message.Value = $"Kill Counter:{++ieKillCount}";
                }
            }
        }
    }
}