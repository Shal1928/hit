using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Hit.Controls.Configurations;
using Hit.DataManagers;
using Hit.Models;
using Hit.Stores.Base;
using UseAbilities.Extensions.DateTimeExt;
using UseAbilities.IoC.Attributes;
using UseAbilities.MVVM.Base;
using UseAbilities.MVVM.Command;

namespace Hit.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            _date = _useSelectedDate ? SelectedDate : DateTime.Now.Date;
            _hitDataManager = new HitDataManager();
            UpdateRequestsCollection();
            //FillABBYYWeekChartData();
        }

        private readonly HitDataManager _hitDataManager;
        private DateTime _date;
        
        #region Properties

        private int _abbyyCount;
        public int ABBYYCount
        {
            get
            {
                return _abbyyCount;
            }
            set
            {
                _abbyyCount = value;
                OnPropertyChanged(() => ABBYYCount);
            }
        }

        private int _abbyyCallsCount;
        public int ABBYYCallsCount
        {
            get
            {
                return _abbyyCallsCount;
            }
            set
            {
                _abbyyCallsCount = value;
                OnPropertyChanged(() => ABBYYCallsCount);
            }
        }

        private int _abbyyEmailsCount;
        public int ABBYYEmailsCount
        {
            get
            {
                return _abbyyEmailsCount;
            }
            set
            {
                _abbyyEmailsCount = value;
                OnPropertyChanged(() => ABBYYEmailsCount);
            }
        }

        private int _filenetCount;
        public int FILENETCount
        {
            get
            {
                return _filenetCount;
            }
            set
            {
                _filenetCount = value;
                OnPropertyChanged(() => FILENETCount);
            }
        }

        private int _filenetEmailsCount;
        public int FILENETEmailsCount
        {
            get
            {
                return _filenetEmailsCount;
            }
            set
            {
                _filenetEmailsCount = value;
                OnPropertyChanged(() => FILENETEmailsCount);
            }
        }

        private int _filenetCallsCount;
        public int FILENETCallsCount
        {
            get
            {
                return _filenetCallsCount;
            }
            set
            {
                _filenetCallsCount = value;
                OnPropertyChanged(() => FILENETCallsCount);
            }
        }

        private int _sapCount;
        public int SAPCount
        {
            get
            {
                return _sapCount;
            }
            set
            {
                _sapCount = value;
                OnPropertyChanged(() => SAPCount);
            }
        }

        private int _sapEmailsCount;
        public int SAPEmailsCount
        {
            get
            {
                return _sapEmailsCount;
            }
            set
            {
                _sapEmailsCount = value;
                OnPropertyChanged(() => SAPEmailsCount);
            }
        }

        private int _sapCallsCount;
        public int SAPCallsCount
        {
            get
            {
                return _sapCallsCount;
            }
            set
            {
                _sapCallsCount = value;
                OnPropertyChanged(() => SAPCallsCount);
            }
        }

        private int _environmentCount;
        public int EnvironmentCount
        {
            get
            {
                return _environmentCount;
            }
            set
            {
                _environmentCount = value;
                OnPropertyChanged(() => EnvironmentCount);
            }
        }

        private int _environmentEmailsCount;
        public int EnvironmentEmailsCount
        {
            get
            {
                return _environmentEmailsCount;
            }
            set
            {
                _environmentEmailsCount = value;
                OnPropertyChanged(() => EnvironmentEmailsCount);
            }
        }

        private int _environmentCallsCount;
        public int EnvironmentCallsCount
        {
            get
            {
                return _environmentCallsCount;
            }
            set
            {
                _environmentCallsCount = value;
                OnPropertyChanged(() => EnvironmentCallsCount);
            }
        }

        private int _total;
        public int Total
        {
            get
            {
                return _total;
            }
            set
            {
                _total = value;
                OnPropertyChanged(() => Total);
            }
        }

        private int _emailTotal;
        public int EmailTotal
        {
            get
            {
                return _emailTotal;
            }
            set
            {
                _emailTotal = value;
                OnPropertyChanged(() => EmailTotal);
            }
        }

        private int _callTotal;
        public int CallTotal
        {
            get
            {
                return _callTotal;
            }
            set
            {
                _callTotal = value;
                OnPropertyChanged(() => CallTotal);
            }
        }

        private DateTime _selectedDate = DateTime.Now;
        public DateTime SelectedDate
        {
            get
            {
                return _selectedDate;
            }
            set
            {
                _selectedDate = value;
                _date = _useSelectedDate ? SelectedDate : DateTime.Now.Date;
                OnPropertyChanged(() => SelectedDate);
            }
        }

        private bool _useSelectedDate;
        public bool UseSelectedDate
        {
            get
            {
                return _useSelectedDate;
            }
            set
            {
                _useSelectedDate = value;
                _date = _useSelectedDate ? SelectedDate : DateTime.Now.Date;
                OnPropertyChanged(() => UseSelectedDate);
            }
        }

        private ObservableCollection<Requests> _requestsCollection;
        public ObservableCollection<Requests> RequestsCollection
        {
            get
            {
                return _requestsCollection;
            }
            set
            {
                _requestsCollection = value;
                OnPropertyChanged(() => RequestsCollection);
            }
        }

        public bool IsTotalsVisible
        {
            get
            {
                return HitSettings.IsTotalsVisible;
            }
            set
            {
                HitSettings.IsTotalsVisible = value;
                OnPropertyChanged(() => IsTotalsVisible);
            }
        }

        public bool IsABBYYWeekChartVisible
        {
            get
            {
                return HitSettings.IsABBYYWeekChartVisible;
            }
            set
            {
                HitSettings.IsABBYYWeekChartVisible = value;
                OnPropertyChanged(() => IsABBYYWeekChartVisible);
            }
        }

        public bool IsFILENETWeekChartVisible
        {
            get
            {
                return HitSettings.IsFILENETWeekChartVisible;
            }
            set
            {
                HitSettings.IsFILENETWeekChartVisible = value;
                OnPropertyChanged(() => IsFILENETWeekChartVisible);
            }
        }

        public bool IsSAPWeekChartVisible
        {
            get
            {
                return HitSettings.IsSAPWeekChartVisible;
            }
            set
            {
                HitSettings.IsSAPWeekChartVisible = value;
                OnPropertyChanged(() => IsSAPWeekChartVisible);
            }
        }

        public bool IsEnvironmentWeekChartVisible
        {
            get
            {
                return HitSettings.IsEnvironmentWeekChartVisible;
            }
            set
            {
                HitSettings.IsEnvironmentWeekChartVisible = value;
                OnPropertyChanged(() => IsEnvironmentWeekChartVisible);
            }
        }

        public WeekChartDisplayType DisplayType
        {
            get
            {
                _isAllWeekDisplay = HitSettings.DisplayType == WeekChartDisplayType.All;
                _isOnlyWorkDaysDisplay = HitSettings.DisplayType == WeekChartDisplayType.WorkDays;
                _isOnlyYesterdayAndTodayDisplay = HitSettings.DisplayType == WeekChartDisplayType.TodayAndYesterday;
                return HitSettings.DisplayType;
            }
            set
            {
                HitSettings.DisplayType = value;
                OnPropertyChanged(() => DisplayType);
            }
        }

        private bool _isAllWeekDisplay;
        public bool IsAllWeekDisplay
        {
            get
            {
                return _isAllWeekDisplay;
            }
            set
            {
                _isAllWeekDisplay = value;
                if (_isAllWeekDisplay) DisplayType = WeekChartDisplayType.All;
                OnPropertyChanged(()=> IsAllWeekDisplay);
            }
        }

        private bool _isOnlyWorkDaysDisplay;
        public bool IsOnlyWorkDaysDisplay
        {
            get
            {
                return _isOnlyWorkDaysDisplay;
            }
            set
            {
                _isOnlyWorkDaysDisplay = value;
                if(_isOnlyWorkDaysDisplay) DisplayType = WeekChartDisplayType.WorkDays;
                OnPropertyChanged(()=> IsOnlyWorkDaysDisplay);
            }
        }

        private bool _isOnlyYesterdayAndTodayDisplay;
        public bool IsOnlyYesterdayAndTodayDisplay
        {
            get
            {
                return _isOnlyYesterdayAndTodayDisplay;
            }
            set
            {
                _isOnlyYesterdayAndTodayDisplay = value;
                if (_isOnlyYesterdayAndTodayDisplay) DisplayType = WeekChartDisplayType.TodayAndYesterday;
                OnPropertyChanged(() => IsOnlyYesterdayAndTodayDisplay);
            }
        }

        private HitSettings _hitSettings;
        private HitSettings HitSettings
        {
            get
            {
                return _hitSettings ?? (_hitSettings = HitSettingsStore.Load());
            }
        }

        public WeekChartConfiguration ABBYYWeekChartConfiguration
        {
            get
            {
                return HitSettings.WeekChartConfigurationList[0];
            }
            set
            {
                HitSettings.WeekChartConfigurationList[0] = value;
                OnPropertyChanged(()=>ABBYYWeekChartConfiguration);
            }
        }

        public WeekChartConfiguration FILENETWeekChartConfiguration
        {
            get
            {
                return HitSettings.WeekChartConfigurationList[1];
            }
            set
            {
                HitSettings.WeekChartConfigurationList[1] = value;
                OnPropertyChanged(() => FILENETWeekChartConfiguration);
            }
        }

        public WeekChartConfiguration SAPWeekChartConfiguration
        {
            get
            {
                return HitSettings.WeekChartConfigurationList[2];
            }
            set
            {
                HitSettings.WeekChartConfigurationList[2] = value;
                OnPropertyChanged(() => SAPWeekChartConfiguration);
            }
        }

        public WeekChartConfiguration EnvironmentWeekChartConfiguration
        {
            get
            {
                return HitSettings.WeekChartConfigurationList[3];
            }
            set
            {
                HitSettings.WeekChartConfigurationList[3] = value;
                OnPropertyChanged(() => EnvironmentWeekChartConfiguration);
            }
        }

        #endregion


        #region ABBYY Properties for WeekChart
        
        private int _abbyyMondayEmailsCount;
        public int ABBYYMondayEmailsCount
        {
            get
            {
                return _abbyyMondayEmailsCount;
            }
            set
            {
                _abbyyMondayEmailsCount = value;
                OnPropertyChanged(() => ABBYYMondayEmailsCount);
            }
        }

        private int _abbyyMondayCallsCount;
        public int ABBYYMondayCallsCount
        {
            get
            {
                return _abbyyMondayCallsCount;
            }
            set
            {
                _abbyyMondayCallsCount = value;
                OnPropertyChanged(() => ABBYYMondayCallsCount);
            }
        }


        private int _abbyyTuesdayEmailsCount;
        public int ABBYYTuesdayEmailsCount
        {
            get
            {
                return _abbyyTuesdayEmailsCount;
            }
            set
            {
                _abbyyTuesdayEmailsCount = value;
                OnPropertyChanged(() => ABBYYTuesdayEmailsCount);
            }
        }

        private int _abbyyTuesdayCallsCount;
        public int ABBYYTuesdayCallsCount
        {
            get
            {
                return _abbyyTuesdayCallsCount;
            }
            set
            {
                _abbyyTuesdayCallsCount = value;
                OnPropertyChanged(() => ABBYYTuesdayCallsCount);
            }
        }


        private int _abbyyWednesdayEmailsCount;
        public int ABBYYWednesdayEmailsCount
        {
            get
            {
                return _abbyyWednesdayEmailsCount;
            }
            set
            {
                _abbyyWednesdayEmailsCount = value;
                OnPropertyChanged(() => ABBYYWednesdayEmailsCount);
            }
        }

        private int _abbyyWednesdayCallsCount;
        public int ABBYYWednesdayCallsCount
        {
            get
            {
                return _abbyyWednesdayCallsCount;
            }
            set
            {
                _abbyyWednesdayCallsCount = value;
                OnPropertyChanged(() => ABBYYWednesdayCallsCount);
            }
        }


        private int _abbyyThursdayEmailsCount;
        public int ABBYYThursdayEmailsCount
        {
            get
            {
                return _abbyyThursdayEmailsCount;
            }
            set
            {
                _abbyyThursdayEmailsCount = value;
                OnPropertyChanged(() => ABBYYThursdayEmailsCount);
            }
        }

        private int _abbyyThursdayCallsCount;
        public int ABBYYThursdayCallsCount
        {
            get
            {
                return _abbyyThursdayCallsCount;
            }
            set
            {
                _abbyyThursdayCallsCount = value;
                OnPropertyChanged(() => ABBYYThursdayCallsCount);
            }
        }


        private int _abbyyFridayEmailsCount;
        public int ABBYYFridayEmailsCount
        {
            get
            {
                return _abbyyFridayEmailsCount;
            }
            set
            {
                _abbyyFridayEmailsCount = value;
                OnPropertyChanged(() => ABBYYFridayEmailsCount);
            }
        }

        private int _abbyyFridayCallsCount;
        public int ABBYYFridayCallsCount
        {
            get
            {
                return _abbyyFridayCallsCount;
            }
            set
            {
                _abbyyFridayCallsCount = value;
                OnPropertyChanged(() => ABBYYFridayCallsCount);
            }
        }


        private int _abbyySaturdayEmailsCount;
        public int ABBYYSaturdayEmailsCount
        {
            get
            {
                return _abbyySaturdayEmailsCount;
            }
            set
            {
                _abbyySaturdayEmailsCount = value;
                OnPropertyChanged(() => ABBYYSaturdayEmailsCount);
            }
        }

        private int _abbyySaturdayCallsCount;
        public int ABBYYSaturdayCallsCount
        {
            get
            {
                return _abbyySaturdayCallsCount;
            }
            set
            {
                _abbyySaturdayCallsCount = value;
                OnPropertyChanged(() => ABBYYSaturdayCallsCount);
            }
        }


        private int _abbyySundayEmailsCount;
        public int ABBYYSundayEmailsCount
        {
            get
            {
                return _abbyySundayEmailsCount;
            }
            set
            {
                _abbyySundayEmailsCount = value;
                OnPropertyChanged(() => ABBYYSundayEmailsCount);
            }
        }

        private int _abbyySundayCallsCount;
        public int ABBYYSundayCallsCount
        {
            get
            {
                return _abbyySundayCallsCount;
            }
            set
            {
                _abbyySundayCallsCount = value;
                OnPropertyChanged(() => ABBYYSundayCallsCount);
            }
        }


        #endregion

        #region FILENET Properties for WeekChart

        private int _filenetMondayEmailsCount;
        public int FILENETMondayEmailsCount
        {
            get
            {
                return _filenetMondayEmailsCount;
            }
            set
            {
                _filenetMondayEmailsCount = value;
                OnPropertyChanged(() => FILENETMondayEmailsCount);
            }
        }

        private int _filenetMondayCallsCount;
        public int FILENETMondayCallsCount
        {
            get
            {
                return _filenetMondayCallsCount;
            }
            set
            {
                _filenetMondayCallsCount = value;
                OnPropertyChanged(() => FILENETMondayCallsCount);
            }
        }


        private int _filenetTuesdayEmailsCount;
        public int FILENETTuesdayEmailsCount
        {
            get
            {
                return _filenetTuesdayEmailsCount;
            }
            set
            {
                _filenetTuesdayEmailsCount = value;
                OnPropertyChanged(() => FILENETTuesdayEmailsCount);
            }
        }

        private int _filenetTuesdayCallsCount;
        public int FILENETTuesdayCallsCount
        {
            get
            {
                return _filenetTuesdayCallsCount;
            }
            set
            {
                _filenetTuesdayCallsCount = value;
                OnPropertyChanged(() => FILENETTuesdayCallsCount);
            }
        }


        private int _filenetWednesdayEmailsCount;
        public int FILENETWednesdayEmailsCount
        {
            get
            {
                return _filenetWednesdayEmailsCount;
            }
            set
            {
                _filenetWednesdayEmailsCount = value;
                OnPropertyChanged(() => FILENETWednesdayEmailsCount);
            }
        }

        private int _filenetWednesdayCallsCount;
        public int FILENETWednesdayCallsCount
        {
            get
            {
                return _filenetWednesdayCallsCount;
            }
            set
            {
                _filenetWednesdayCallsCount = value;
                OnPropertyChanged(() => FILENETWednesdayCallsCount);
            }
        }


        private int _filenetThursdayEmailsCount;
        public int FILENETThursdayEmailsCount
        {
            get
            {
                return _filenetThursdayEmailsCount;
            }
            set
            {
                _filenetThursdayEmailsCount = value;
                OnPropertyChanged(() => FILENETThursdayEmailsCount);
            }
        }

        private int _filenetThursdayCallsCount;
        public int FILENETThursdayCallsCount
        {
            get
            {
                return _filenetThursdayCallsCount;
            }
            set
            {
                _filenetThursdayCallsCount = value;
                OnPropertyChanged(() => FILENETThursdayCallsCount);
            }
        }


        private int _filenetFridayEmailsCount;
        public int FILENETFridayEmailsCount
        {
            get
            {
                return _filenetFridayEmailsCount;
            }
            set
            {
                _filenetFridayEmailsCount = value;
                OnPropertyChanged(() => FILENETFridayEmailsCount);
            }
        }

        private int _filenetFridayCallsCount;
        public int FILENETFridayCallsCount
        {
            get
            {
                return _filenetFridayCallsCount;
            }
            set
            {
                _filenetFridayCallsCount = value;
                OnPropertyChanged(() => FILENETFridayCallsCount);
            }
        }


        private int _filenetSaturdayEmailsCount;
        public int FILENETSaturdayEmailsCount
        {
            get
            {
                return _filenetSaturdayEmailsCount;
            }
            set
            {
                _filenetSaturdayEmailsCount = value;
                OnPropertyChanged(() => FILENETSaturdayEmailsCount);
            }
        }

        private int _filenetSaturdayCallsCount;
        public int FILENETSaturdayCallsCount
        {
            get
            {
                return _filenetSaturdayCallsCount;
            }
            set
            {
                _filenetSaturdayCallsCount = value;
                OnPropertyChanged(() => FILENETSaturdayCallsCount);
            }
        }


        private int _filenetSundayEmailsCount;
        public int FILENETSundayEmailsCount
        {
            get
            {
                return _filenetSundayEmailsCount;
            }
            set
            {
                _filenetSundayEmailsCount = value;
                OnPropertyChanged(() => FILENETSundayEmailsCount);
            }
        }

        private int _filenetSundayCallsCount;
        public int FILENETSundayCallsCount
        {
            get
            {
                return _filenetSundayCallsCount;
            }
            set
            {
                _filenetSundayCallsCount = value;
                OnPropertyChanged(() => FILENETSundayCallsCount);
            }
        }


        #endregion

        #region SAP Properties for WeekChart

        private int _sapMondayEmailsCount;
        public int SAPMondayEmailsCount
        {
            get
            {
                return _sapMondayEmailsCount;
            }
            set
            {
                _sapMondayEmailsCount = value;
                OnPropertyChanged(() => SAPMondayEmailsCount);
            }
        }

        private int _sapMondayCallsCount;
        public int SAPMondayCallsCount
        {
            get
            {
                return _sapMondayCallsCount;
            }
            set
            {
                _sapMondayCallsCount = value;
                OnPropertyChanged(() => SAPMondayCallsCount);
            }
        }


        private int _sapTuesdayEmailsCount;
        public int SAPTuesdayEmailsCount
        {
            get
            {
                return _sapTuesdayEmailsCount;
            }
            set
            {
                _sapTuesdayEmailsCount = value;
                OnPropertyChanged(() => SAPTuesdayEmailsCount);
            }
        }

        private int _sapTuesdayCallsCount;
        public int SAPTuesdayCallsCount
        {
            get
            {
                return _sapTuesdayCallsCount;
            }
            set
            {
                _sapTuesdayCallsCount = value;
                OnPropertyChanged(() => SAPTuesdayCallsCount);
            }
        }


        private int _sapWednesdayEmailsCount;
        public int SAPWednesdayEmailsCount
        {
            get
            {
                return _sapWednesdayEmailsCount;
            }
            set
            {
                _sapWednesdayEmailsCount = value;
                OnPropertyChanged(() => SAPWednesdayEmailsCount);
            }
        }

        private int _sapWednesdayCallsCount;
        public int SAPWednesdayCallsCount
        {
            get
            {
                return _sapWednesdayCallsCount;
            }
            set
            {
                _sapWednesdayCallsCount = value;
                OnPropertyChanged(() => SAPWednesdayCallsCount);
            }
        }


        private int _sapThursdayEmailsCount;
        public int SAPThursdayEmailsCount
        {
            get
            {
                return _sapThursdayEmailsCount;
            }
            set
            {
                _sapThursdayEmailsCount = value;
                OnPropertyChanged(() => SAPThursdayEmailsCount);
            }
        }

        private int _sapThursdayCallsCount;
        public int SAPThursdayCallsCount
        {
            get
            {
                return _sapThursdayCallsCount;
            }
            set
            {
                _sapThursdayCallsCount = value;
                OnPropertyChanged(() => SAPThursdayCallsCount);
            }
        }


        private int _sapFridayEmailsCount;
        public int SAPFridayEmailsCount
        {
            get
            {
                return _sapFridayEmailsCount;
            }
            set
            {
                _sapFridayEmailsCount = value;
                OnPropertyChanged(() => SAPFridayEmailsCount);
            }
        }

        private int _sapFridayCallsCount;
        public int SAPFridayCallsCount
        {
            get
            {
                return _sapFridayCallsCount;
            }
            set
            {
                _sapFridayCallsCount = value;
                OnPropertyChanged(() => SAPFridayCallsCount);
            }
        }


        private int _sapSaturdayEmailsCount;
        public int SAPSaturdayEmailsCount
        {
            get
            {
                return _sapSaturdayEmailsCount;
            }
            set
            {
                _sapSaturdayEmailsCount = value;
                OnPropertyChanged(() => SAPSaturdayEmailsCount);
            }
        }

        private int _sapSaturdayCallsCount;
        public int SAPSaturdayCallsCount
        {
            get
            {
                return _sapSaturdayCallsCount;
            }
            set
            {
                _sapSaturdayCallsCount = value;
                OnPropertyChanged(() => SAPSaturdayCallsCount);
            }
        }


        private int _sapSundayEmailsCount;
        public int SAPSundayEmailsCount
        {
            get
            {
                return _sapSundayEmailsCount;
            }
            set
            {
                _sapSundayEmailsCount = value;
                OnPropertyChanged(() => SAPSundayEmailsCount);
            }
        }

        private int _sapSundayCallsCount;
        public int SAPSundayCallsCount
        {
            get
            {
                return _sapSundayCallsCount;
            }
            set
            {
                _sapSundayCallsCount = value;
                OnPropertyChanged(() => SAPSundayCallsCount);
            }
        }


        #endregion

        #region Environment Properties for WeekChart

        private int _environmentMondayEmailsCount;
        public int EnvironmentMondayEmailsCount
        {
            get
            {
                return _environmentMondayEmailsCount;
            }
            set
            {
                _environmentMondayEmailsCount = value;
                OnPropertyChanged(() => EnvironmentMondayEmailsCount);
            }
        }

        private int _environmentMondayCallsCount;
        public int EnvironmentMondayCallsCount
        {
            get
            {
                return _environmentMondayCallsCount;
            }
            set
            {
                _environmentMondayCallsCount = value;
                OnPropertyChanged(() => EnvironmentMondayCallsCount);
            }
        }


        private int _environmentTuesdayEmailsCount;
        public int EnvironmentTuesdayEmailsCount
        {
            get
            {
                return _environmentTuesdayEmailsCount;
            }
            set
            {
                _environmentTuesdayEmailsCount = value;
                OnPropertyChanged(() => EnvironmentTuesdayEmailsCount);
            }
        }

        private int _environmentTuesdayCallsCount;
        public int EnvironmentTuesdayCallsCount
        {
            get
            {
                return _environmentTuesdayCallsCount;
            }
            set
            {
                _environmentTuesdayCallsCount = value;
                OnPropertyChanged(() => EnvironmentTuesdayCallsCount);
            }
        }


        private int _environmentWednesdayEmailsCount;
        public int EnvironmentWednesdayEmailsCount
        {
            get
            {
                return _environmentWednesdayEmailsCount;
            }
            set
            {
                _environmentWednesdayEmailsCount = value;
                OnPropertyChanged(() => EnvironmentWednesdayEmailsCount);
            }
        }

        private int _environmentWednesdayCallsCount;
        public int EnvironmentWednesdayCallsCount
        {
            get
            {
                return _environmentWednesdayCallsCount;
            }
            set
            {
                _environmentWednesdayCallsCount = value;
                OnPropertyChanged(() => EnvironmentWednesdayCallsCount);
            }
        }


        private int _environmentThursdayEmailsCount;
        public int EnvironmentThursdayEmailsCount
        {
            get
            {
                return _environmentThursdayEmailsCount;
            }
            set
            {
                _environmentThursdayEmailsCount = value;
                OnPropertyChanged(() => EnvironmentThursdayEmailsCount);
            }
        }

        private int _environmentThursdayCallsCount;
        public int EnvironmentThursdayCallsCount
        {
            get
            {
                return _environmentThursdayCallsCount;
            }
            set
            {
                _environmentThursdayCallsCount = value;
                OnPropertyChanged(() => EnvironmentThursdayCallsCount);
            }
        }


        private int _environmentFridayEmailsCount;
        public int EnvironmentFridayEmailsCount
        {
            get
            {
                return _environmentFridayEmailsCount;
            }
            set
            {
                _environmentFridayEmailsCount = value;
                OnPropertyChanged(() => EnvironmentFridayEmailsCount);
            }
        }

        private int _environmentFridayCallsCount;
        public int EnvironmentFridayCallsCount
        {
            get
            {
                return _environmentFridayCallsCount;
            }
            set
            {
                _environmentFridayCallsCount = value;
                OnPropertyChanged(() => EnvironmentFridayCallsCount);
            }
        }


        private int _environmentSaturdayEmailsCount;
        public int EnvironmentSaturdayEmailsCount
        {
            get
            {
                return _environmentSaturdayEmailsCount;
            }
            set
            {
                _environmentSaturdayEmailsCount = value;
                OnPropertyChanged(() => EnvironmentSaturdayEmailsCount);
            }
        }

        private int _environmentSaturdayCallsCount;
        public int EnvironmentSaturdayCallsCount
        {
            get
            {
                return _environmentSaturdayCallsCount;
            }
            set
            {
                _environmentSaturdayCallsCount = value;
                OnPropertyChanged(() => EnvironmentSaturdayCallsCount);
            }
        }


        private int _environmentSundayEmailsCount;
        public int EnvironmentSundayEmailsCount
        {
            get
            {
                return _environmentSundayEmailsCount;
            }
            set
            {
                _environmentSundayEmailsCount = value;
                OnPropertyChanged(() => EnvironmentSundayEmailsCount);
            }
        }

        private int _environmentSundayCallsCount;
        public int EnvironmentSundayCallsCount
        {
            get
            {
                return _environmentSundayCallsCount;
            }
            set
            {
                _environmentSundayCallsCount = value;
                OnPropertyChanged(() => EnvironmentSundayCallsCount);
            }
        }


        #endregion

        #region InjectedProperties

        [InjectedProperty]
        public IXmlStore<HitSettings> HitSettingsStore
        {
            get;
            set;
        }

        //[InjectedProperty]
        //public DBStore<Requests> RequestsDBStore
        //{
        //    get;
        //    set;
        //}

        #endregion


        #region Commands Description

        private ICommand _addABBYYMailHitCommand;
        public ICommand AddABBYYMailHitCommand
        {
            get
            {
                return _addABBYYMailHitCommand ?? (_addABBYYMailHitCommand = new RelayCommand(param => OnAddABBYYMailHitCommand(), null));
            }
        }

        private ICommand _addABBYYCallHitCommand;
        public ICommand AddABBYYCallHitCommand
        {
            get
            {
                return _addABBYYCallHitCommand ?? (_addABBYYCallHitCommand = new RelayCommand(param => OnAddABBYYCallHitCommand(), null));
            }
        }

        private ICommand _addFILENETMailHitCommand;
        public ICommand AddFILENETMailHitCommand
        {
            get
            {
                return _addFILENETMailHitCommand ?? (_addFILENETMailHitCommand = new RelayCommand(param => OnAddFILENETMailHitCommand(), null));
            }
        }

        private ICommand _addFILENETCallHitCommand;
        public ICommand AddFILENETCallHitCommand
        {
            get
            {
                return _addFILENETCallHitCommand ?? (_addFILENETCallHitCommand = new RelayCommand(param => OnAddFILENETCallHitCommand(), null));
            }
        }

        private ICommand _addSAPMailHitCommand;
        public ICommand AddSAPMailHitCommand
        {
            get
            {
                return _addSAPMailHitCommand ?? (_addSAPMailHitCommand = new RelayCommand(param => OnAddSAPMailHitCommand(), null));
            }
        }

        private ICommand _addSAPCallHitCommand;
        public ICommand AddSAPCallHitCommand
        {
            get
            {
                return _addSAPCallHitCommand ?? (_addSAPCallHitCommand = new RelayCommand(param => OnAddSAPCallHitCommand(), null));
            }
        }

        private ICommand _addEnvironmentMailHitCommand;
        public ICommand AddEnvironmentMailHitCommand
        {
            get
            {
                return _addEnvironmentMailHitCommand ?? (_addEnvironmentMailHitCommand = new RelayCommand(param => OnAddEnvironmentMailHitCommand(), null));
            }
        }

        private ICommand _addEnvironmentCallHitCommand;
        public ICommand AddEnvironmentCallHitCommand
        {
            get
            {
                return _addEnvironmentCallHitCommand ?? (_addEnvironmentCallHitCommand = new RelayCommand(param => OnAddEnvironmentCallHitCommand(), null));
            }
        }

        private ICommand _updateRequestsCollectionCommand;
        public ICommand UpdateRequestsCollectionCommand
        {
            get
            {
                return _updateRequestsCollectionCommand ?? (_updateRequestsCollectionCommand = new RelayCommand(param => UpdateRequestsCollection(), null));
            }
        }

        private ICommand _saveSettingsCommand;
        public ICommand SaveSettingsCommand
        {
            get
            {
                return _saveSettingsCommand ?? (_saveSettingsCommand = new RelayCommand(param => SaveSettings(), null));
            }
        }

        private ICommand _showReportViewCommand;
        public ICommand ShowReportViewCommand
        {
            get
            {
                return _showReportViewCommand ?? (_showReportViewCommand = new RelayCommand(param => ShowReportView(), null));
            }
        }
        
        #endregion


        #region Command Methods

        private void OnAddABBYYMailHitCommand()
        {
            //var a = RequestsDBStore.LoadObject(1);
            _hitDataManager.AddRequests(Requests.CreateRequests(1, RequestType.Email, RequestTheme.ABBYY, _date));
            UpdateRequestsCollection();
        }

        private void OnAddABBYYCallHitCommand()
        {
            _hitDataManager.AddRequests(Requests.CreateRequests(1, RequestType.Call, RequestTheme.ABBYY, _date));
            UpdateRequestsCollection();
        }



        private void OnAddFILENETMailHitCommand()
        {
            _hitDataManager.AddRequests(Requests.CreateRequests(1, RequestType.Email, RequestTheme.FILENET, _date));
            UpdateRequestsCollection();
        }

        private void OnAddFILENETCallHitCommand()
        {
            _hitDataManager.AddRequests(Requests.CreateRequests(1, RequestType.Call, RequestTheme.FILENET, _date));
            UpdateRequestsCollection();
        }



        private void OnAddSAPMailHitCommand()
        {
            _hitDataManager.AddRequests(Requests.CreateRequests(1, RequestType.Email, RequestTheme.SAP, _date));
            UpdateRequestsCollection();
        }

        private void OnAddSAPCallHitCommand()
        {
            _hitDataManager.AddRequests(Requests.CreateRequests(1, RequestType.Call, RequestTheme.SAP, _date));
            UpdateRequestsCollection();
        }



        private void OnAddEnvironmentMailHitCommand()
        {
            _hitDataManager.AddRequests(Requests.CreateRequests(1, RequestType.Email, RequestTheme.Environment, _date));
            UpdateRequestsCollection();
        }

        private void OnAddEnvironmentCallHitCommand()
        {
            _hitDataManager.AddRequests(Requests.CreateRequests(1, RequestType.Call, RequestTheme.Environment, _date));
            UpdateRequestsCollection();
        }

        public void UpdateRequestsCollection()
        {
            RequestsCollection = new ObservableCollection<Requests>(_hitDataManager.FindRequestsList(SelectedDate));

            ABBYYCallsCount = RequestsCollection.Count(request => request.RequestThemeId == RequestTheme.ABBYY && request.RequestTypeId == RequestType.Call);
            ABBYYEmailsCount = RequestsCollection.Count(request => request.RequestThemeId == RequestTheme.ABBYY && request.RequestTypeId == RequestType.Email);
            ABBYYCount = ABBYYCallsCount + ABBYYEmailsCount;

            FILENETCallsCount = RequestsCollection.Count(request => request.RequestThemeId == RequestTheme.FILENET && request.RequestTypeId == RequestType.Call);
            FILENETEmailsCount = RequestsCollection.Count(request => request.RequestThemeId == RequestTheme.FILENET && request.RequestTypeId == RequestType.Email);
            FILENETCount = FILENETCallsCount + FILENETEmailsCount;

            SAPCallsCount = RequestsCollection.Count(request => request.RequestThemeId == RequestTheme.SAP && request.RequestTypeId == RequestType.Call);
            SAPEmailsCount = RequestsCollection.Count(request => request.RequestThemeId == RequestTheme.SAP && request.RequestTypeId == RequestType.Email);
            SAPCount = SAPCallsCount + SAPEmailsCount;

            EnvironmentCallsCount = RequestsCollection.Count(request => request.RequestThemeId == RequestTheme.Environment && request.RequestTypeId == RequestType.Call);
            EnvironmentEmailsCount = RequestsCollection.Count(request => request.RequestThemeId == RequestTheme.Environment && request.RequestTypeId == RequestType.Email);
            EnvironmentCount = EnvironmentCallsCount + EnvironmentEmailsCount;

            Total = ABBYYCount + FILENETCount + SAPCount + EnvironmentCount;
            EmailTotal = ABBYYEmailsCount + FILENETEmailsCount + SAPEmailsCount + EnvironmentEmailsCount;
            CallTotal = ABBYYCallsCount + FILENETCallsCount + SAPCallsCount + EnvironmentCallsCount;

            FillABBYYWeekChartData();
            FillFILENETWeekChartData();
            FillSAPWeekChartData();
            FillEnvironmentWeekChartData();
        }

        private void SaveSettings()
        {
            HitSettingsStore.Save(HitSettings);
        }

        private void ShowReportView()
        {
            var reportViewModel = new ReportViewModel();
            reportViewModel.Show();
        }

        private void FillABBYYWeekChartData()
        {
            var week = SelectedDate.GetWeek();

            //request.RequestDate == week[0].Date && 
            //request.RequestDate == week[0].Date && 
            var requestCollection = _hitDataManager.FindRequestsList(week[0], week[6]);

            ABBYYMondayEmailsCount = requestCollection.Count(request => request.RequestDate == week[0].Date && request.RequestThemeId == RequestTheme.ABBYY && request.RequestTypeId == RequestType.Email);
            ABBYYMondayCallsCount = requestCollection.Count(request => request.RequestDate == week[0].Date && request.RequestThemeId == RequestTheme.ABBYY && request.RequestTypeId == RequestType.Call);

            ABBYYTuesdayEmailsCount = requestCollection.Count(request => request.RequestDate == week[1].Date && request.RequestThemeId == RequestTheme.ABBYY && request.RequestTypeId == RequestType.Email);
            ABBYYTuesdayCallsCount = requestCollection.Count(request => request.RequestDate == week[1].Date && request.RequestThemeId == RequestTheme.ABBYY && request.RequestTypeId == RequestType.Call);

            ABBYYWednesdayEmailsCount = requestCollection.Count(request => request.RequestDate == week[2].Date && request.RequestThemeId == RequestTheme.ABBYY && request.RequestTypeId == RequestType.Email);
            ABBYYWednesdayCallsCount = requestCollection.Count(request => request.RequestDate == week[2].Date && request.RequestThemeId == RequestTheme.ABBYY && request.RequestTypeId == RequestType.Call);

            ABBYYThursdayEmailsCount = requestCollection.Count(request => request.RequestDate == week[3].Date && request.RequestThemeId == RequestTheme.ABBYY && request.RequestTypeId == RequestType.Email);
            ABBYYThursdayCallsCount = requestCollection.Count(request => request.RequestDate == week[3].Date && request.RequestThemeId == RequestTheme.ABBYY && request.RequestTypeId == RequestType.Call);

            ABBYYFridayEmailsCount = requestCollection.Count(request => request.RequestDate == week[4].Date && request.RequestThemeId == RequestTheme.ABBYY && request.RequestTypeId == RequestType.Email);
            ABBYYFridayCallsCount = requestCollection.Count(request => request.RequestDate == week[4].Date && request.RequestThemeId == RequestTheme.ABBYY && request.RequestTypeId == RequestType.Call);

            ABBYYSaturdayEmailsCount = requestCollection.Count(request => request.RequestDate == week[5].Date && request.RequestThemeId == RequestTheme.ABBYY && request.RequestTypeId == RequestType.Email);
            ABBYYSaturdayCallsCount = requestCollection.Count(request => request.RequestDate == week[5].Date && request.RequestThemeId == RequestTheme.ABBYY && request.RequestTypeId == RequestType.Call);

            ABBYYSundayEmailsCount = requestCollection.Count(request => request.RequestDate == week[6].Date && request.RequestThemeId == RequestTheme.ABBYY && request.RequestTypeId == RequestType.Email);
            ABBYYSundayCallsCount = requestCollection.Count(request => request.RequestDate == week[6].Date && request.RequestThemeId == RequestTheme.ABBYY && request.RequestTypeId == RequestType.Call);
        }

        private void FillFILENETWeekChartData()
        {
            var week = SelectedDate.GetWeek();

            //request.RequestDate == week[0].Date && 
            //request.RequestDate == week[0].Date && 
            var requestCollection = _hitDataManager.FindRequestsList(week[0], week[6]);

            FILENETMondayEmailsCount = requestCollection.Count(request => request.RequestDate == week[0].Date && request.RequestThemeId == RequestTheme.FILENET && request.RequestTypeId == RequestType.Email);
            FILENETMondayCallsCount = requestCollection.Count(request => request.RequestDate == week[0].Date && request.RequestThemeId == RequestTheme.FILENET && request.RequestTypeId == RequestType.Call);

            FILENETTuesdayEmailsCount = requestCollection.Count(request => request.RequestDate == week[1].Date && request.RequestThemeId == RequestTheme.FILENET && request.RequestTypeId == RequestType.Email);
            FILENETTuesdayCallsCount = requestCollection.Count(request => request.RequestDate == week[1].Date && request.RequestThemeId == RequestTheme.FILENET && request.RequestTypeId == RequestType.Call);

            FILENETWednesdayEmailsCount = requestCollection.Count(request => request.RequestDate == week[2].Date && request.RequestThemeId == RequestTheme.FILENET && request.RequestTypeId == RequestType.Email);
            FILENETWednesdayCallsCount = requestCollection.Count(request => request.RequestDate == week[2].Date && request.RequestThemeId == RequestTheme.FILENET && request.RequestTypeId == RequestType.Call);

            FILENETThursdayEmailsCount = requestCollection.Count(request => request.RequestDate == week[3].Date && request.RequestThemeId == RequestTheme.FILENET && request.RequestTypeId == RequestType.Email);
            FILENETThursdayCallsCount = requestCollection.Count(request => request.RequestDate == week[3].Date && request.RequestThemeId == RequestTheme.FILENET && request.RequestTypeId == RequestType.Call);

            FILENETFridayEmailsCount = requestCollection.Count(request => request.RequestDate == week[4].Date && request.RequestThemeId == RequestTheme.FILENET && request.RequestTypeId == RequestType.Email);
            FILENETFridayCallsCount = requestCollection.Count(request => request.RequestDate == week[4].Date && request.RequestThemeId == RequestTheme.FILENET && request.RequestTypeId == RequestType.Call);

            FILENETSaturdayEmailsCount = requestCollection.Count(request => request.RequestDate == week[5].Date && request.RequestThemeId == RequestTheme.FILENET && request.RequestTypeId == RequestType.Email);
            FILENETSaturdayCallsCount = requestCollection.Count(request => request.RequestDate == week[5].Date && request.RequestThemeId == RequestTheme.FILENET && request.RequestTypeId == RequestType.Call);

            FILENETSundayEmailsCount = requestCollection.Count(request => request.RequestDate == week[6].Date && request.RequestThemeId == RequestTheme.FILENET && request.RequestTypeId == RequestType.Email);
            FILENETSundayCallsCount = requestCollection.Count(request => request.RequestDate == week[6].Date && request.RequestThemeId == RequestTheme.FILENET && request.RequestTypeId == RequestType.Call);
        }

        private void FillSAPWeekChartData()
        {
            var week = SelectedDate.GetWeek();

            //request.RequestDate == week[0].Date && 
            //request.RequestDate == week[0].Date && 
            var requestCollection = _hitDataManager.FindRequestsList(week[0], week[6]);

            SAPMondayEmailsCount = requestCollection.Count(request => request.RequestDate == week[0].Date && request.RequestThemeId == RequestTheme.SAP && request.RequestTypeId == RequestType.Email);
            SAPMondayCallsCount = requestCollection.Count(request => request.RequestDate == week[0].Date && request.RequestThemeId == RequestTheme.SAP && request.RequestTypeId == RequestType.Call);

            SAPTuesdayEmailsCount = requestCollection.Count(request => request.RequestDate == week[1].Date && request.RequestThemeId == RequestTheme.SAP && request.RequestTypeId == RequestType.Email);
            SAPTuesdayCallsCount = requestCollection.Count(request => request.RequestDate == week[1].Date && request.RequestThemeId == RequestTheme.SAP && request.RequestTypeId == RequestType.Call);

            SAPWednesdayEmailsCount = requestCollection.Count(request => request.RequestDate == week[2].Date && request.RequestThemeId == RequestTheme.SAP && request.RequestTypeId == RequestType.Email);
            SAPWednesdayCallsCount = requestCollection.Count(request => request.RequestDate == week[2].Date && request.RequestThemeId == RequestTheme.SAP && request.RequestTypeId == RequestType.Call);

            SAPThursdayEmailsCount = requestCollection.Count(request => request.RequestDate == week[3].Date && request.RequestThemeId == RequestTheme.SAP && request.RequestTypeId == RequestType.Email);
            SAPThursdayCallsCount = requestCollection.Count(request => request.RequestDate == week[3].Date && request.RequestThemeId == RequestTheme.SAP && request.RequestTypeId == RequestType.Call);

            SAPFridayEmailsCount = requestCollection.Count(request => request.RequestDate == week[4].Date && request.RequestThemeId == RequestTheme.SAP && request.RequestTypeId == RequestType.Email);
            SAPFridayCallsCount = requestCollection.Count(request => request.RequestDate == week[4].Date && request.RequestThemeId == RequestTheme.SAP && request.RequestTypeId == RequestType.Call);

            SAPSaturdayEmailsCount = requestCollection.Count(request => request.RequestDate == week[5].Date && request.RequestThemeId == RequestTheme.SAP && request.RequestTypeId == RequestType.Email);
            SAPSaturdayCallsCount = requestCollection.Count(request => request.RequestDate == week[5].Date && request.RequestThemeId == RequestTheme.SAP && request.RequestTypeId == RequestType.Call);

            SAPSundayEmailsCount = requestCollection.Count(request => request.RequestDate == week[6].Date && request.RequestThemeId == RequestTheme.SAP && request.RequestTypeId == RequestType.Email);
            SAPSundayCallsCount = requestCollection.Count(request => request.RequestDate == week[6].Date && request.RequestThemeId == RequestTheme.SAP && request.RequestTypeId == RequestType.Call);
        }

        private void FillEnvironmentWeekChartData()
        {
            var week = SelectedDate.GetWeek();

            //request.RequestDate == week[0].Date && 
            //request.RequestDate == week[0].Date && 
            var requestCollection = _hitDataManager.FindRequestsList(week[0], week[6]);

            EnvironmentMondayEmailsCount = requestCollection.Count(request => request.RequestDate == week[0].Date && request.RequestThemeId == RequestTheme.Environment && request.RequestTypeId == RequestType.Email);
            EnvironmentMondayCallsCount = requestCollection.Count(request => request.RequestDate == week[0].Date && request.RequestThemeId == RequestTheme.Environment && request.RequestTypeId == RequestType.Call);

            EnvironmentTuesdayEmailsCount = requestCollection.Count(request => request.RequestDate == week[1].Date && request.RequestThemeId == RequestTheme.Environment && request.RequestTypeId == RequestType.Email);
            EnvironmentTuesdayCallsCount = requestCollection.Count(request => request.RequestDate == week[1].Date && request.RequestThemeId == RequestTheme.Environment && request.RequestTypeId == RequestType.Call);

            EnvironmentWednesdayEmailsCount = requestCollection.Count(request => request.RequestDate == week[2].Date && request.RequestThemeId == RequestTheme.Environment && request.RequestTypeId == RequestType.Email);
            EnvironmentWednesdayCallsCount = requestCollection.Count(request => request.RequestDate == week[2].Date && request.RequestThemeId == RequestTheme.Environment && request.RequestTypeId == RequestType.Call);

            EnvironmentThursdayEmailsCount = requestCollection.Count(request => request.RequestDate == week[3].Date && request.RequestThemeId == RequestTheme.Environment && request.RequestTypeId == RequestType.Email);
            EnvironmentThursdayCallsCount = requestCollection.Count(request => request.RequestDate == week[3].Date && request.RequestThemeId == RequestTheme.Environment && request.RequestTypeId == RequestType.Call);

            EnvironmentFridayEmailsCount = requestCollection.Count(request => request.RequestDate == week[4].Date && request.RequestThemeId == RequestTheme.Environment && request.RequestTypeId == RequestType.Email);
            EnvironmentFridayCallsCount = requestCollection.Count(request => request.RequestDate == week[4].Date && request.RequestThemeId == RequestTheme.Environment && request.RequestTypeId == RequestType.Call);

            EnvironmentSaturdayEmailsCount = requestCollection.Count(request => request.RequestDate == week[5].Date && request.RequestThemeId == RequestTheme.Environment && request.RequestTypeId == RequestType.Email);
            EnvironmentSaturdayCallsCount = requestCollection.Count(request => request.RequestDate == week[5].Date && request.RequestThemeId == RequestTheme.Environment && request.RequestTypeId == RequestType.Call);

            EnvironmentSundayEmailsCount = requestCollection.Count(request => request.RequestDate == week[6].Date && request.RequestThemeId == RequestTheme.Environment && request.RequestTypeId == RequestType.Email);
            EnvironmentSundayCallsCount = requestCollection.Count(request => request.RequestDate == week[6].Date && request.RequestThemeId == RequestTheme.Environment && request.RequestTypeId == RequestType.Call);
        }

        #endregion
    }
}