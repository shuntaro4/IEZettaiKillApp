using IEZettaiKillApp.Domain;
using System.Windows;
using System.Windows.Input;
using Unity;

namespace IEZettaiKillApp.Views
{
    public partial class MainWindow : Window
    {
        [Dependency]
        public IEKiller IEKiller { get; set; }

        [Dependency]
        public RunRegister RunRegister { get; set; }

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

        private void Window_ContentRendered(object sender, System.EventArgs e)
        {
            RunRegister.RegistKey(true);

            var isIE = IEKiller.DefaultWebBrowserIsIE();
            if (!isIE)
            {
                return;
            }

            MessageBox.Show("Oh...Your default browser is IE.\r\n" +
                "You need to change a default browser.\r\n" +
                "Because I keep killing IE Process.");
        }
    }
}
