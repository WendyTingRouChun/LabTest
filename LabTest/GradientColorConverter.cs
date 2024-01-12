using System;
using Microsoft.Maui.Controls;

namespace LabTest
{
    public class GradientColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is double sliderValue)
            {
                // Assuming slider range is 0 to 100
                double factor = sliderValue / 100.0;

                // Interpolate between blue and red based on the slider value
                Color startColor = Colors.Blue;
                Color endColor = Colors.Red;

                // Calculate the interpolated color
                Color interpolatedColor = InterpolateColors(startColor, endColor, factor);

                // Convert the interpolated color to hex
                string hexColor = ColorToHex(interpolatedColor);

                return hexColor;
            }

            return Colors.Yellow.ToHex();
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private string ColorToHex(Color color)
        {
            int r = (int)(color.Red * 255);
            int g = (int)(color.Green * 255);
            int b = (int)(color.Blue * 255);

            return $"#{r:X2}{g:X2}{b:X2}";
        }

        private Color InterpolateColors(Color startColor, Color endColor, double factor)
        {
            // Interpolate between startColor and endColor based on factor
            double r = startColor.Red + factor * (endColor.Red - startColor.Red);
            double g = startColor.Green + factor * (endColor.Green - startColor.Green);
            double b = startColor.Blue + factor * (endColor.Blue - startColor.Blue);

            return new Color((float)r, (float)g, (float)b);
        }
    }
}

