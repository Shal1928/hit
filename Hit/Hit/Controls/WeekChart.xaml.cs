using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hit.Controls
{
    /// <summary>
    /// Interaction logic for WeekChart.xaml
    /// </summary>
    public partial class WeekChart : UserControl
    {
        public WeekChart()
        {
            InitializeComponent();
        }

        #region DependencyProperty SelectedColumnIndex

        public static readonly DependencyProperty MondayEmailsCountProperty =
            DependencyProperty.Register("MondayEmailsCount",
                                        typeof(int),
                                        typeof(WeekChart),
                                        new UIPropertyMetadata(0, SelectedColumnIndexChanged)
                                        );

        public int MondayEmailsCount
        {
            get
            {
                return (int)GetValue(MondayEmailsCountProperty);
            }
            set
            {
                SetValue(MondayEmailsCountProperty, value);
            }
        }

        private static void SelectedColumnIndexChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //
        }

        #endregion
    }
}
