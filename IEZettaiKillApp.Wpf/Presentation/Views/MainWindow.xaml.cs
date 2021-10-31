using IEZettaiKillApp.Presentation.ViewModels;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace IEZettaiKillApp.Presentation.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Topmost = true;
            WindowStyle = WindowStyle.None;
            AllowsTransparency = true;

            var viewModel = DataContext as MainWindowViewModel;
            var primaryScreenInfo = viewModel.GetPrimaryScreenInfo();
            Left = 50 / primaryScreenInfo.DisplayScale;
            Top = (primaryScreenInfo.Top / primaryScreenInfo.DisplayScale) + (50 / primaryScreenInfo.DisplayScale);
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Shutdown();
        }

        private void DragMove(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState != MouseButtonState.Pressed)
            {
                return;
            }
            DragMove();
        }

        private void StartStopButton_Click(object sender, RoutedEventArgs e)
        {
            // after clicking the button, clear the focus.
            Keyboard.ClearFocus();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            var key = e.Key;
            var modifiersKey = Keyboard.Modifiers;

            if (modifiersKey == ModifierKeys.Control && key == Key.W)
            {
                Shutdown();
            }
        }

        private void Shutdown()
        {
            Application.Current.Shutdown(1995816);
        }

        private void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            var url = e.Uri.ToString().Replace("&", "^&");
            Process.Start(new ProcessStartInfo("cmd", $"/c start {url}"));
        }
    }
}
