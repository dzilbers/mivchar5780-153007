using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        string color;
        public string Color {
            get { return color; }
            set {
                string old = color;
                color = value;
                if (PropertyChanged != null)
                    if (!old.Equals(value))
                        PropertyChanged(this,
                                        new PropertyChangedEventArgs("Color"));
            }
        }

        public int X { get; set; }

        MyData user;

        public MainWindow()
        {
            Color = "White";
            X = 1234;
            InitializeComponent();
            user = (MyData)Resources["mySource"];
            myTextBlock.DataContext = this;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtBox.DataContext = this;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            listBox.Items.Clear();
            comboBox.Items.Clear();
            for (var i = 0; i < 10; ++i)
            {
                ListBoxItem item = new ListBoxItem();
                item.Content = "List Item " + i;
                listBox.Items.Add(item);

                comboBox.Items.Add(new ComboBoxItem() { Content = "Combo Item " + i });
            }
            Color = "Red";
            user.User = "Yehuda";
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((ListBoxItem)listBox.SelectedItem != null)
                label1.Content = ((ListBoxItem)listBox.SelectedItem).Content;
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((ComboBoxItem)comboBox.SelectedItem != null)
                label2.Content = ((ComboBoxItem)comboBox.SelectedItem).Content;
        }
    }
}
