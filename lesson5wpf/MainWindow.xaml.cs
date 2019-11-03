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

namespace lesson5wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static Random random = new Random();
        public MainWindow()
        {
            InitializeComponent();
            //button1.MouseMove += btnMy_MouseMove;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.button1.Content = "DO IT";
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Button me = sender as Button;
            MessageBoxResult result = MessageBox.Show("Please read me!",
                "My best title", MessageBoxButton.YesNoCancel,
                MessageBoxImage.Hand, MessageBoxResult.Cancel);
            if (result == MessageBoxResult.Yes)
                me.Content = "IT IS DONE";
            else
                me.Content = "DO IT AGAIN";
        }

        private void myGotFocus(object sender, RoutedEventArgs e)
        {

        }

        void btnMy_MouseMove(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            Size size = (btn.Parent as Grid).RenderSize;
            Thickness margin = btn.Margin;
            margin.Left = random.NextDouble() * (size.Width - btn.ActualWidth);
            margin.Top = random.NextDouble() * (size.Height - btn.ActualHeight);
            btn.Margin = margin;
            
        }

    }
}
