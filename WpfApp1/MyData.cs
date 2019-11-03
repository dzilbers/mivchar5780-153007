using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1
{

    class Person : DependencyObject
    {
        public static readonly DependencyProperty AgeProperty =
       DependencyProperty.Register("Age", typeof(int), typeof(Person),
                                   new UIPropertyMetadata(0));
        public int Age
        {
            get { return (int)GetValue(AgeProperty); }
            set { SetValue(AgeProperty, value); }
        }

        static int func1(int x) { return 1; }
        static char func1(ref int x) { return 'c'; }
        static float func1<T>(T x) where T : class { return 1.2f; }

        static void func() {
            int m = 12;
            var rsult = func1(m);
        }
    }

    public static class Ext
    {
        static IEnumerable MyFunc<T>(this IEnumerable<T> source, Func<T, bool> par)
        {
            foreach (var item in source)
            {
                if (par(item))
                    yield return item;
            }
        }
    }

    public class MyData : INotifyPropertyChanged
    {
        string user;
        public string User {
            get { return user; }
            set {
                string old = user;
                user = value;
                if (PropertyChanged != null)
                    if (!old.Equals(value))
                        PropertyChanged(this,
                                        new PropertyChangedEventArgs("User"));
            }
        }
        public string Password { get; set; }
        public const int MaxUsers = 10;

        public event PropertyChangedEventHandler PropertyChanged;

        public static string MaxUsersString { get { return MaxUsers.ToString(); } }
    }
}
