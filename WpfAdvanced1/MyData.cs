using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WpfAdvanced1
{
    public enum GenderType { MALE, FEMALE }

    public class MyData
    {
        static public int MaxPasswordLength { get; set; } = 10;
        public string User { get; set; }
        public string Password { get; set; }
        public DateTime Birthday { get; set; }
        public int Id { get; set; }
        public GenderType Gender { get; set; }

        public bool Status { get; set; }
        public override string ToString()
        {
            return User;
        }
    }

    public class IntToString : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int)
            {
                return "Value:" + (int)value;
            }
            else
                throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string source = "" + value;
            if (source.Equals("")) source = "0";
            return int.Parse(source);
        }
    }

}
