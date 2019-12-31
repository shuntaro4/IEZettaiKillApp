using System.Windows;
using System.Windows.Input;

namespace IEZettaiKillApp.Presentation.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            Topmost = true;
            WindowStyle = WindowStyle.None;
            AllowsTransparency = true;
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
    }
}
