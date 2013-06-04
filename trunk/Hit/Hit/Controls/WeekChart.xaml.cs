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

        #region DependencyProperties Monday

        public static readonly DependencyProperty MondayEmailsCountProperty =
            DependencyProperty.Register("MondayEmailsCount",
                                        typeof(int),
                                        typeof(WeekChart),
                                        new UIPropertyMetadata(0, MondayEmailsCountChanged)
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

        private static void MondayEmailsCountChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //
        }



        public static readonly DependencyProperty MondayCallsCountProperty =
            DependencyProperty.Register("MondayCallsCount",
                                        typeof(int),
                                        typeof(WeekChart),
                                        new UIPropertyMetadata(0, MondayCallsCountChanged)
                                        );

        public int MondayCallsCount
        {
            get
            {
                return (int)GetValue(MondayCallsCountProperty);
            }
            set
            {
                SetValue(MondayCallsCountProperty, value);
            }
        }

        private static void MondayCallsCountChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //
        }



        public static readonly DependencyProperty MondayCountProperty =
            DependencyProperty.Register("MondayCount",
                                        typeof(int),
                                        typeof(WeekChart),
                                        new UIPropertyMetadata(0, MondayCountChanged)
                                        );

        public int MondayCount
        {
            get
            {
                return (int)GetValue(MondayCountProperty);
            }
            set
            {
                SetValue(MondayCountProperty, value);
            }
        }

        private static void MondayCountChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //
        }

        #endregion





        #region DependencyProperties Tuesday

        public static readonly DependencyProperty TuesdayEmailsCountProperty =
            DependencyProperty.Register("TuesdayEmailsCount",
                                        typeof(int),
                                        typeof(WeekChart),
                                        new UIPropertyMetadata(0, TuesdayEmailsCountChanged)
                                        );

        public int TuesdayEmailsCount
        {
            get
            {
                return (int)GetValue(TuesdayEmailsCountProperty);
            }
            set
            {
                SetValue(TuesdayEmailsCountProperty, value);
            }
        }

        private static void TuesdayEmailsCountChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //
        }



        public static readonly DependencyProperty TuesdayCallsCountProperty =
            DependencyProperty.Register("TuesdayCallsCount",
                                        typeof(int),
                                        typeof(WeekChart),
                                        new UIPropertyMetadata(0, TuesdayCallsCountChanged)
                                        );

        public int TuesdayCallsCount
        {
            get
            {
                return (int)GetValue(TuesdayCallsCountProperty);
            }
            set
            {
                SetValue(TuesdayCallsCountProperty, value);
            }
        }

        private static void TuesdayCallsCountChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //
        }



        public static readonly DependencyProperty TuesdayCountProperty =
            DependencyProperty.Register("TuesdayCount",
                                        typeof(int),
                                        typeof(WeekChart),
                                        new UIPropertyMetadata(0, TuesdayCountChanged)
                                        );

        public int TuesdayCount
        {
            get
            {
                return (int)GetValue(TuesdayCountProperty);
            }
            set
            {
                SetValue(TuesdayCountProperty, value);
            }
        }

        private static void TuesdayCountChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //
        }

        #endregion





        #region DependencyProperties Wednesday

        public static readonly DependencyProperty WednesdayEmailsCountProperty =
            DependencyProperty.Register("WednesdayEmailsCount",
                                        typeof(int),
                                        typeof(WeekChart),
                                        new UIPropertyMetadata(0, WednesdayEmailsCountChanged)
                                        );

        public int WednesdayEmailsCount
        {
            get
            {
                return (int)GetValue(WednesdayEmailsCountProperty);
            }
            set
            {
                SetValue(WednesdayEmailsCountProperty, value);
            }
        }

        private static void WednesdayEmailsCountChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //
        }



        public static readonly DependencyProperty WednesdayCallsCountProperty =
            DependencyProperty.Register("WednesdayCallsCount",
                                        typeof(int),
                                        typeof(WeekChart),
                                        new UIPropertyMetadata(0, WednesdayCallsCountChanged)
                                        );

        public int WednesdayCallsCount
        {
            get
            {
                return (int)GetValue(WednesdayCallsCountProperty);
            }
            set
            {
                SetValue(WednesdayCallsCountProperty, value);
            }
        }

        private static void WednesdayCallsCountChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //
        }



        public static readonly DependencyProperty WednesdayCountProperty =
            DependencyProperty.Register("WednesdayCount",
                                        typeof(int),
                                        typeof(WeekChart),
                                        new UIPropertyMetadata(0, WednesdayCountChanged)
                                        );

        public int WednesdayCount
        {
            get
            {
                return (int)GetValue(WednesdayCountProperty);
            }
            set
            {
                SetValue(WednesdayCountProperty, value);
            }
        }

        private static void WednesdayCountChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //
        }

        #endregion





        #region DependencyProperties Thursday

        public static readonly DependencyProperty ThursdayEmailsCountProperty =
            DependencyProperty.Register("ThursdayEmailsCount",
                                        typeof(int),
                                        typeof(WeekChart),
                                        new UIPropertyMetadata(0, ThursdayEmailsCountChanged)
                                        );

        public int ThursdayEmailsCount
        {
            get
            {
                return (int)GetValue(ThursdayEmailsCountProperty);
            }
            set
            {
                SetValue(ThursdayEmailsCountProperty, value);
            }
        }

        private static void ThursdayEmailsCountChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //
        }



        public static readonly DependencyProperty ThursdayCallsCountProperty =
            DependencyProperty.Register("ThursdayCallsCount",
                                        typeof(int),
                                        typeof(WeekChart),
                                        new UIPropertyMetadata(0, ThursdayCallsCountChanged)
                                        );

        public int ThursdayCallsCount
        {
            get
            {
                return (int)GetValue(ThursdayCallsCountProperty);
            }
            set
            {
                SetValue(ThursdayCallsCountProperty, value);
            }
        }

        private static void ThursdayCallsCountChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //
        }



        public static readonly DependencyProperty ThursdayCountProperty =
            DependencyProperty.Register("ThursdayCount",
                                        typeof(int),
                                        typeof(WeekChart),
                                        new UIPropertyMetadata(0, ThursdayCountChanged)
                                        );

        public int ThursdayCount
        {
            get
            {
                return (int)GetValue(ThursdayCountProperty);
            }
            set
            {
                SetValue(ThursdayCountProperty, value);
            }
        }

        private static void ThursdayCountChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //
        }

        #endregion





        #region DependencyProperties Friday

        public static readonly DependencyProperty FridayEmailsCountProperty =
            DependencyProperty.Register("FridayEmailsCount",
                                        typeof(int),
                                        typeof(WeekChart),
                                        new UIPropertyMetadata(0, FridayEmailsCountChanged)
                                        );

        public int FridayEmailsCount
        {
            get
            {
                return (int)GetValue(FridayEmailsCountProperty);
            }
            set
            {
                SetValue(FridayEmailsCountProperty, value);
            }
        }

        private static void FridayEmailsCountChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //
        }



        public static readonly DependencyProperty FridayCallsCountProperty =
            DependencyProperty.Register("FridayCallsCount",
                                        typeof(int),
                                        typeof(WeekChart),
                                        new UIPropertyMetadata(0, FridayCallsCountChanged)
                                        );

        public int FridayCallsCount
        {
            get
            {
                return (int)GetValue(FridayCallsCountProperty);
            }
            set
            {
                SetValue(FridayCallsCountProperty, value);
            }
        }

        private static void FridayCallsCountChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //
        }



        public static readonly DependencyProperty FridayCountProperty =
            DependencyProperty.Register("FridayCount",
                                        typeof(int),
                                        typeof(WeekChart),
                                        new UIPropertyMetadata(0, FridayCountChanged)
                                        );

        public int FridayCount
        {
            get
            {
                return (int)GetValue(FridayCountProperty);
            }
            set
            {
                SetValue(FridayCountProperty, value);
            }
        }

        private static void FridayCountChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //
        }

        #endregion





        #region DependencyProperties Saturday

        public static readonly DependencyProperty SaturdayEmailsCountProperty =
            DependencyProperty.Register("SaturdayEmailsCount",
                                        typeof(int),
                                        typeof(WeekChart),
                                        new UIPropertyMetadata(0, SaturdayEmailsCountChanged)
                                        );

        public int SaturdayEmailsCount
        {
            get
            {
                return (int)GetValue(SaturdayEmailsCountProperty);
            }
            set
            {
                SetValue(SaturdayEmailsCountProperty, value);
            }
        }

        private static void SaturdayEmailsCountChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //
        }



        public static readonly DependencyProperty SaturdayCallsCountProperty =
            DependencyProperty.Register("SaturdayCallsCount",
                                        typeof(int),
                                        typeof(WeekChart),
                                        new UIPropertyMetadata(0, SaturdayCallsCountChanged)
                                        );

        public int SaturdayCallsCount
        {
            get
            {
                return (int)GetValue(SaturdayCallsCountProperty);
            }
            set
            {
                SetValue(SaturdayCallsCountProperty, value);
            }
        }

        private static void SaturdayCallsCountChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //
        }



        public static readonly DependencyProperty SaturdayCountProperty =
            DependencyProperty.Register("SaturdayCount",
                                        typeof(int),
                                        typeof(WeekChart),
                                        new UIPropertyMetadata(0, SaturdayCountChanged)
                                        );

        public int SaturdayCount
        {
            get
            {
                return (int)GetValue(SaturdayCountProperty);
            }
            set
            {
                SetValue(SaturdayCountProperty, value);
            }
        }

        private static void SaturdayCountChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //
        }

        #endregion





        #region DependencyProperties Sunday

        public static readonly DependencyProperty SundayEmailsCountProperty =
            DependencyProperty.Register("SundayEmailsCount",
                                        typeof(int),
                                        typeof(WeekChart),
                                        new UIPropertyMetadata(0, SundayEmailsCountChanged)
                                        );

        public int SundayEmailsCount
        {
            get
            {
                return (int)GetValue(SundayEmailsCountProperty);
            }
            set
            {
                SetValue(SundayEmailsCountProperty, value);
            }
        }

        private static void SundayEmailsCountChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //
        }



        public static readonly DependencyProperty SundayCallsCountProperty =
            DependencyProperty.Register("SundayCallsCount",
                                        typeof(int),
                                        typeof(WeekChart),
                                        new UIPropertyMetadata(0, SundayCallsCountChanged)
                                        );

        public int SundayCallsCount
        {
            get
            {
                return (int)GetValue(SundayCallsCountProperty);
            }
            set
            {
                SetValue(SundayCallsCountProperty, value);
            }
        }

        private static void SundayCallsCountChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //
        }



        public static readonly DependencyProperty SundayCountProperty =
            DependencyProperty.Register("SundayCount",
                                        typeof(int),
                                        typeof(WeekChart),
                                        new UIPropertyMetadata(0, SundayCountChanged)
                                        );

        public int SundayCount
        {
            get
            {
                return (int)GetValue(SundayCountProperty);
            }
            set
            {
                SetValue(SundayCountProperty, value);
            }
        }

        private static void SundayCountChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //
        }

        #endregion
    }
}
