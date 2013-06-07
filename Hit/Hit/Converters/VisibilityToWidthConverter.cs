using System;
using System.Globalization;
using System.Windows;
using UseAbilities.WPF.Converters.Base;

namespace Hit.Converters
{
    public class VisibilityToWidthConverter : ConverterBase<VisibilityToWidthConverter>
    {
        public VisibilityToWidthConverter()
        {
            //
        }

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is Visibility)) throw new ArgumentException("Value is not Visibility");

            var visibility = (Visibility) value;
            var result = visibility == Visibility.Visible ? GridUnitType.Star : GridUnitType.Auto;
            return result;
        }
    }
}
