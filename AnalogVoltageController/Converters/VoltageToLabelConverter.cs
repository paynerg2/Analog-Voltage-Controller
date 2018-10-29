using System;
using System.Globalization;
using System.Windows.Data;

namespace AnalogVoltageController.Converters
{
    public class VoltageToLabelConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return $"{value} V";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (double)value;
        }
    }
}
