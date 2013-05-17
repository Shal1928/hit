using System;
using System.Globalization;
using UseAbilities.WPF.Converters.Base;

namespace Hit.Converters
{
    public class InversionBoolConverter : ConvertorBase<InversionBoolConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !((bool) value);
        }
    }
}
