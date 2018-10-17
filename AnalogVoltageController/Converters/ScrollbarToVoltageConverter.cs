using System;
using System.Globalization;
using System.Windows.Data;

namespace AnalogVoltageController.Converters
{
    public class ScrollbarToVoltageConverter : IValueConverter
    {
        //Converts voltage range [-10.0,10.0] <---> scollbar range [0,200]
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (double)value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return 0;
            double voltage = (System.Convert.ToDouble(value) - 100) / 10;
            return Math.Round(voltage, 1);
        }
    }
}
