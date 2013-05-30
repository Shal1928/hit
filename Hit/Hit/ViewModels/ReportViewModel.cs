using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hit.DataManagers;
using UseAbilities.MVVM.Base;

namespace Hit.ViewModels
{
    public class ReportViewModel : ViewModelBase
    {
        public ReportViewModel()
        {
            _hitDataManager = new HitDataManager();
        }

        private readonly HitDataManager _hitDataManager;
    }
}
