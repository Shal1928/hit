using System.Windows;
using System.Windows.Controls;

namespace Hit.Controls
{
    public class ButtonExt : Button
    {
        #region DependencyProperty AdditionalContent

        public static readonly DependencyProperty AdditionalContentProperty =
            DependencyProperty.Register("AdditionalContent",
                                        typeof(string),
                                        typeof(ButtonExt),
                                        new UIPropertyMetadata(null, AdditionalContentChanged)
                                        );

        public string AdditionalContent
        {
            get
            {
                return (string)GetValue(AdditionalContentProperty);
            }
            set
            {
                SetValue(AdditionalContentProperty, value);
            }
        }

        private static void AdditionalContentChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //
        }

        #endregion
    }
}
