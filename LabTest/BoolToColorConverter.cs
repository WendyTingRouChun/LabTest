using System;
using Microsoft.Maui.Controls;

namespace LabTest
{
    public class BoolToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is bool boolValue)
            {
                return boolValue ? Color.FromHex("#008000") : Color.FromHex("#FF0000");
            }
            return Color.FromHex("FF0000");
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}


