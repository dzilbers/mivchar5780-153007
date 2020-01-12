using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace morningWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static Random random = new Random(DateTime.Now.Millisecond);
        public MainWindow()
        {
            InitializeComponent();
            MyButton.Content = "I am here!";
        }

        private bool btnStatus = false;
        private void MyButton_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            btn.Content = btnStatus ? "AVRUMI" : "ISRAEL";
            btnStatus = !btnStatus;

            switch ((int)btn.Tag)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                default:
                    break;
            }

            if (btnStatus)
            {
                MessageBoxResult result = MessageBox.Show(
                    "סבא בא",
                    "MyMessage",
                    MessageBoxButton.YesNoCancel,
                    MessageBoxImage.Hand,
                    MessageBoxResult.No,
                    MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        btn.Content = "YES";
                        break;
                    case MessageBoxResult.No:
                        btn.Content = "NO";
                        break;
                    case MessageBoxResult.Cancel:
                        break;
                    default:
                        break;
                }
            }
        }

        private void MyButtonMove(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            Size size = (btn.Parent as Grid).RenderSize;
            Thickness margin = btn.Margin;
            margin.Left = random.NextDouble() * (size.Width - btn.ActualWidth);
            margin.Top = random.NextDouble() * (size.Height - btn.ActualHeight);
            btn.Margin = margin;
        }

        private void MyButton_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Button btn = sender as Button;
            btn.Content = $"{e.ChangedButton}: {e.ClickCount} clicks";
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            label1.Content = "Window loaded";
        }
    }
}
