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

        #region DependencyProperty DarkSkin

        public static readonly DependencyProperty DarkSkinProperty =
            DependencyProperty.Register("DarkSkin",
                                        typeof(bool),
                                        typeof(ButtonExt),
                                        new UIPropertyMetadata(false, DarkSkinChanged)
                                        );

        public bool DarkSkin
        {
            get
            {
                return (bool)GetValue(DarkSkinProperty);
            }
            set
            {
                SetValue(DarkSkinProperty, value);
            }
        }

        private static void DarkSkinChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //
        }

        #endregion
    }
}
