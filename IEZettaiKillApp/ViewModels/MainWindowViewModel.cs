using Prism.Mvvm;
using Reactive.Bindings;

namespace IEZettaiKillApp.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public ReactiveProperty<string> Title { get; } = new ReactiveProperty<string>("IEZettaiKillApp");
    }
}
