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

        public static readonly DependencyProperty MondayHitCount =
            DependencyProperty.Register("SelectedColumnIndex",
                                        typeof(int),
                                        typeof(ColumnHeaderFilterBehavior),
                                        new UIPropertyMetadata(0, SelectedColumnIndexChanged)
                                        );

        public int SelectedColumnIndex
        {
            get
            {
                return (int)GetValue(SelectedColumnIndexProperty);
            }
            set
            {
                SetValue(SelectedColumnIndexProperty, value);
            }
        }

        private static void SelectedColumnIndexChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //
        }

        #endregion
    }
}
