using System;
using System.Globalization;
using System.Windows.Data;

namespace Hextasy.Trains
{
    public class DoubleMultiplierConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var dividend = (double) value;
            var divisor = double.Parse(parameter.ToString(), CultureInfo.InvariantCulture);
            return dividend*divisor;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
