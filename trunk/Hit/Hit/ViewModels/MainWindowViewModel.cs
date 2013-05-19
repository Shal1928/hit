using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Hit.DataManagers;
using Hit.Models;
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
        }

        private readonly HitDataManager _hitDataManager;
        private DateTime _date;

        #region Properties

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

        #endregion


        #region Command Methods

        private void OnAddABBYYMailHitCommand()
        {
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

            FILENETCallsCount = RequestsCollection.Count(request => request.RequestThemeId == RequestTheme.FILENET && request.RequestTypeId == RequestType.Call);
            FILENETEmailsCount = RequestsCollection.Count(request => request.RequestThemeId == RequestTheme.FILENET && request.RequestTypeId == RequestType.Email);

            SAPCallsCount = RequestsCollection.Count(request => request.RequestThemeId == RequestTheme.SAP && request.RequestTypeId == RequestType.Call);
            SAPEmailsCount = RequestsCollection.Count(request => request.RequestThemeId == RequestTheme.SAP && request.RequestTypeId == RequestType.Email);

            EnvironmentCallsCount = RequestsCollection.Count(request => request.RequestThemeId == RequestTheme.Environment && request.RequestTypeId == RequestType.Call);
            EnvironmentEmailsCount = RequestsCollection.Count(request => request.RequestThemeId == RequestTheme.Environment && request.RequestTypeId == RequestType.Email);
        }

        #endregion
    }
}