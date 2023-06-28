using System;
using System.Globalization;
using System.Windows.Data;

namespace Crypto.Helpers
{
    public class TruncateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string text = value as string;
            if (text != null && text.Length > 11)
            {
                return text.Substring(0, 11) + "...";
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
