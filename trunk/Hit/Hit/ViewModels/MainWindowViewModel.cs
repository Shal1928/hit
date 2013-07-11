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

        public virtual int ABBYYCount
        {
            get; 
            set;
        }

        public virtual int ABBYYCallsCount
        {
            get; 
            set;
        }

        public virtual int ABBYYEmailsCount
        {
            get; 
            set;
        }

        public virtual int FILENETCount
        {
            get; 
            set;
        }

        public virtual int FILENETEmailsCount
        {
            get; 
            set;
        }

        public virtual int FILENETCallsCount
        {
            get; 
            set;
        }

        public virtual int SAPCount
        {
            get; 
            set;
        }

        public virtual int SAPEmailsCount
        {
            get; 
            set;
        }

        public virtual int SAPCallsCount
        {
            get; 
            set;
        }

        public virtual int EnvironmentCount
        {
            get; 
            set;
        }

        public virtual int EnvironmentEmailsCount
        {
            get; 
            set;
        }

        public virtual int EnvironmentCallsCount
        {
            get; 
            set;
        }

        public virtual int Total
        {
            get; 
            set;
        }

        public virtual int EmailTotal
        {
            get; 
            set;
        }

        public virtual int CallTotal
        {
            get; 
            set;
        }

        private DateTime _selectedDate = DateTime.Now;
        public virtual DateTime SelectedDate
        {
            get
            {
                return _selectedDate;
            }
            set
            {
                _selectedDate = value;
                _date = _useSelectedDate ? SelectedDate : DateTime.Now.Date;
            }
        }

        private bool _useSelectedDate;
        public virtual bool UseSelectedDate
        {
            get
            {
                return _useSelectedDate;
            }
            set
            {
                _useSelectedDate = value;
                _date = _useSelectedDate ? SelectedDate : DateTime.Now.Date;
            }
        }

        public virtual ObservableCollection<Requests> RequestsCollection
        {
            get; 
            set;
        }

        public virtual bool IsTotalsVisible
        {
            get
            {
                return HitSettings.IsTotalsVisible;
            }
            set
            {
                HitSettings.IsTotalsVisible = value;
            }
        }

        public virtual bool IsABBYYWeekChartVisible
        {
            get
            {
                return HitSettings.IsABBYYWeekChartVisible;
            }
            set
            {
                HitSettings.IsABBYYWeekChartVisible = value;
            }
        }

        public virtual bool IsFILENETWeekChartVisible
        {
            get
            {
                return HitSettings.IsFILENETWeekChartVisible;
            }
            set
            {
                HitSettings.IsFILENETWeekChartVisible = value;
            }
        }

        public virtual bool IsSAPWeekChartVisible
        {
            get
            {
                return HitSettings.IsSAPWeekChartVisible;
            }
            set
            {
                HitSettings.IsSAPWeekChartVisible = value;
            }
        }

        public virtual bool IsEnvironmentWeekChartVisible
        {
            get
            {
                return HitSettings.IsEnvironmentWeekChartVisible;
            }
            set
            {
                HitSettings.IsEnvironmentWeekChartVisible = value;
            }
        }

        public virtual WeekChartDisplayType DisplayType
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
            }
        }

        private bool _isAllWeekDisplay;
        public virtual bool IsAllWeekDisplay
        {
            get
            {
                return _isAllWeekDisplay;
            }
            set
            {
                _isAllWeekDisplay = value;
                if (_isAllWeekDisplay) DisplayType = WeekChartDisplayType.All;
            }
        }

        private bool _isOnlyWorkDaysDisplay;
        public virtual bool IsOnlyWorkDaysDisplay
        {
            get
            {
                return _isOnlyWorkDaysDisplay;
            }
            set
            {
                _isOnlyWorkDaysDisplay = value;
                if(_isOnlyWorkDaysDisplay) DisplayType = WeekChartDisplayType.WorkDays;
            }
        }

        private bool _isOnlyYesterdayAndTodayDisplay;
        public virtual bool IsOnlyYesterdayAndTodayDisplay
        {
            get
            {
                return _isOnlyYesterdayAndTodayDisplay;
            }
            set
            {
                _isOnlyYesterdayAndTodayDisplay = value;
                if (_isOnlyYesterdayAndTodayDisplay) DisplayType = WeekChartDisplayType.TodayAndYesterday;
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

        public virtual WeekChartConfiguration ABBYYWeekChartConfiguration
        {
            get
            {
                return HitSettings.WeekChartConfigurationList[0];
            }
            set
            {
                HitSettings.WeekChartConfigurationList[0] = value;
            }
        }

        public virtual WeekChartConfiguration FILENETWeekChartConfiguration
        {
            get
            {
                return HitSettings.WeekChartConfigurationList[1];
            }
            set
            {
                HitSettings.WeekChartConfigurationList[1] = value;
            }
        }

        public virtual WeekChartConfiguration SAPWeekChartConfiguration
        {
            get
            {
                return HitSettings.WeekChartConfigurationList[2];
            }
            set
            {
                HitSettings.WeekChartConfigurationList[2] = value;
            }
        }

        public virtual WeekChartConfiguration EnvironmentWeekChartConfiguration
        {
            get
            {
                return HitSettings.WeekChartConfigurationList[3];
            }
            set
            {
                HitSettings.WeekChartConfigurationList[3] = value;
            }
        }

        #endregion


        #region ABBYY Properties for WeekChart

        public virtual int ABBYYMondayEmailsCount
        {
            get; 
            set;
        }

        public virtual int ABBYYMondayCallsCount
        {
            get; 
            set;
        }


        public virtual int ABBYYTuesdayEmailsCount
        {
            get; 
            set;
        }

        public virtual int ABBYYTuesdayCallsCount
        {
            get; 
            set;
        }


        public virtual int ABBYYWednesdayEmailsCount
        {
            get; 
            set;
        }

        public virtual int ABBYYWednesdayCallsCount
        {
            get; 
            set;
        }


        public virtual int ABBYYThursdayEmailsCount
        {
            get; 
            set;
        }

        public virtual int ABBYYThursdayCallsCount
        {
            get; 
            set;
        }


        public virtual int ABBYYFridayEmailsCount
        {
            get; 
            set;
        }

        public virtual int ABBYYFridayCallsCount
        {
            get; 
            set;
        }


        public virtual int ABBYYSaturdayEmailsCount
        {
            get; 
            set;
        }

        public virtual int ABBYYSaturdayCallsCount
        {
            get; 
            set;
        }


        public virtual int ABBYYSundayEmailsCount
        {
            get; 
            set;
        }

        public virtual int ABBYYSundayCallsCount
        {
            get; 
            set;
        }

        #endregion

        #region FILENET Properties for WeekChart

        public virtual int FILENETMondayEmailsCount
        {
            get; 
            set;
        }

        public virtual int FILENETMondayCallsCount
        {
            get; 
            set;
        }


        public virtual int FILENETTuesdayEmailsCount
        {
            get; 
            set;
        }

        public virtual int FILENETTuesdayCallsCount
        {
            get; 
            set;
        }


        public virtual int FILENETWednesdayEmailsCount
        {
            get; 
            set;
        }

        public virtual int FILENETWednesdayCallsCount
        {
            get; 
            set;
        }


        public virtual int FILENETThursdayEmailsCount
        {
            get; 
            set;
        }

        public virtual int FILENETThursdayCallsCount
        {
            get; 
            set;
        }


        public virtual int FILENETFridayEmailsCount
        {
            get; 
            set;
        }

        public virtual int FILENETFridayCallsCount
        {
            get; 
            set;
        }


        public virtual int FILENETSaturdayEmailsCount
        {
            get; 
            set;
        }

        public virtual int FILENETSaturdayCallsCount
        {
            get; 
            set;
        }


        public virtual int FILENETSundayEmailsCount
        {
            get; 
            set;
        }

        public virtual int FILENETSundayCallsCount
        {
            get; 
            set;
        }

        #endregion

        #region SAP Properties for WeekChart

        public virtual int SAPMondayEmailsCount
        {
            get; 
            set;
        }

        public virtual int SAPMondayCallsCount
        {
            get; 
            set;
        }


        public virtual int SAPTuesdayEmailsCount
        {
            get; 
            set;
        }

        public virtual int SAPTuesdayCallsCount
        {
            get; 
            set;
        }


        public virtual int SAPWednesdayEmailsCount
        {
            get; 
            set;
        }

        public virtual int SAPWednesdayCallsCount
        {
            get; 
            set;
        }


        public virtual int SAPThursdayEmailsCount
        {
            get; 
            set;
        }

        public virtual int SAPThursdayCallsCount
        {
            get; 
            set;
        }


        public virtual int SAPFridayEmailsCount
        {
            get; 
            set;
        }

        public virtual int SAPFridayCallsCount
        {
            get; 
            set;
        }


        public virtual int SAPSaturdayEmailsCount
        {
            get; 
            set;
        }

        public virtual int SAPSaturdayCallsCount
        {
            get; 
            set;
        }


        public virtual int SAPSundayEmailsCount
        {
            get; 
            set;
        }

        public virtual int SAPSundayCallsCount
        {
            get; 
            set;
        }

        #endregion

        #region Environment Properties for WeekChart

        public virtual int EnvironmentMondayEmailsCount
        {
            get; 
            set;
        }

        public virtual int EnvironmentMondayCallsCount
        {
            get; 
            set;
        }


        public virtual int EnvironmentTuesdayEmailsCount
        {
            get; 
            set;
        }

        public virtual int EnvironmentTuesdayCallsCount
        {
            get; 
            set;
        }


        public virtual int EnvironmentWednesdayEmailsCount
        {
            get; 
            set;
        }

        public virtual int EnvironmentWednesdayCallsCount
        {
            get; 
            set;
        }


        public virtual int EnvironmentThursdayEmailsCount
        {
            get; 
            set;
        }

        public virtual int EnvironmentThursdayCallsCount
        {
            get; 
            set;
        }


        public virtual int EnvironmentFridayEmailsCount
        {
            get; 
            set;
        }

        public virtual int EnvironmentFridayCallsCount
        {
            get; 
            set;
        }


        public virtual int EnvironmentSaturdayEmailsCount
        {
            get; 
            set;
        }

        public virtual int EnvironmentSaturdayCallsCount
        {
            get; 
            set;
        }


        public virtual int EnvironmentSundayEmailsCount
        {
            get; 
            set;
        }

        public virtual int EnvironmentSundayCallsCount
        {
            get; 
            set;
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