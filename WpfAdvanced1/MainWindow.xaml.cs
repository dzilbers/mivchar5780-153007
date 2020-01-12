using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WpfAdvanced1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        static public ObservableCollection<MyData> List { get; set; } = new ObservableCollection<MyData>();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List1.SelectionMode = SelectionMode.Multiple;

            List.Add(new MyData() { User = "dani", Password = "123" });
            List.Add(new MyData() { User = "yossi", Password = "234" });
            List.Add(new MyData() { User = "hanni", Password = "345" });
            //for (int i = 1; i < 6; ++i)
            //    Combo1.Items.Add(new ComboBoxItem() { Content = "Item " + i });
            Combo1.DataContext = List;
            Label1.DataContext = new MyData() { User = "Israel", Password = "4321" };
        }

        private void List1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string text = "";
            foreach (ListBoxItem item in (sender as ListBox).SelectedItems)
                text += item.Content + "\n";
            Label1.Content = text.Substring(0, text.Length - 1);
        }

        private void Combo1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Label1.Content = ((sender as ComboBox).SelectedItem as MyData).Password;
            //Label1.Content = ((sender as ComboBox).SelectedItem as ComboBoxItem).Content;
        }

        int counter = 0;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Label1.Content = "Boom " + ++counter;
            List.Add(new MyData() { User = "User" + counter, Password = "111" });
        }
    }
}
