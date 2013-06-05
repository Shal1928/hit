using System;
using System.Globalization;
using UseAbilities.WPF.Converters.Base;

namespace Hit.Converters
{
    public class CountToPercentHeightMultiConverter : MultiConverterBase<CountToPercentHeightMultiConverter>
    {
        public CountToPercentHeightMultiConverter()
        {
            //
        }

        public override object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length < 2 && !(values[0] is int) && !(values[1] is int)) throw new Exception("CountToPercentHeightMultiConverter");

            var rowHeight = (double) values[0];
            var hitCount = (int)values[1];
            var result = rowHeight / 100 * hitCount;

            return result;
        }
    }
}
