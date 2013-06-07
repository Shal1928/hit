using System;
using System.Globalization;
using System.Windows;
using UseAbilities.WPF.Converters.Base;

namespace Hit.Converters
{
    public class BoolToGridUnitTypeConverter : ConverterBase<BoolToGridUnitTypeConverter>
    {
        public BoolToGridUnitTypeConverter()
        {
            //
        }

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is bool)) throw new ArgumentException("Value is not bool");

            var boolValue = (bool)value;
            var converter = new GridLengthConverter();

            return boolValue ? GridUnitType.Star : converter.ConvertFrom(0);
        }
    }
}
