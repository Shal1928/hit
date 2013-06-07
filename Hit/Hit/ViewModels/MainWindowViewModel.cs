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

        public bool IsWeekendVisible
        {
            get
            {
                return WeekChartWeekendIsVisible(null);
            }
            set
            {
                WeekChartWeekendIsVisible(value);
                OnPropertyChanged(()=> IsWeekendVisible);
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
            var week = _date.GetWeek();

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

        private bool WeekChartWeekendIsVisible(bool? visible)
        {
            if(visible.HasValue)
            {
                var weekChartConfiguration = new WeekChartConfiguration(true, visible.Value);

                ABBYYWeekChartConfiguration = weekChartConfiguration;
                FILENETWeekChartConfiguration = weekChartConfiguration;
                SAPWeekChartConfiguration = weekChartConfiguration;
                EnvironmentWeekChartConfiguration = weekChartConfiguration;

                return visible.Value;
            }

            return HitSettings.WeekChartConfigurationList.All(weekChartConfig => weekChartConfig.SaturdayIsVisible && weekChartConfig.SundayIsVisible);
        }

        #endregion
    }
}