using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Hit.Controls.Configurations;
using UseAbilities.WPF.Converters.Base;

namespace Hit.Converters
{
    public class WeekChartDisplayTypeToBoolConverter : ConverterBase<WeekChartDisplayTypeToBoolConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var stringParametr = parameter as string;
            if (!(value is WeekChartDisplayType) && stringParametr == null) throw new Exception(" Value is not WeekChartDisplayType or parametr is null!");

            var displayType = (WeekChartDisplayType) value;

            return displayType == (WeekChartDisplayType)Enum.Parse(typeof(WeekChartDisplayType), stringParametr);  
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var stringParametr = parameter as string;
            if (!(value is bool) && stringParametr == null) throw new Exception(" Value is not WeekChartDisplayType or parametr is null!");

            var enumValue = (WeekChartDisplayType) Enum.Parse(typeof (WeekChartDisplayType), stringParametr);

            return enumValue;
        }
    }
}
