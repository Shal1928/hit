using System;
using System.Collections.Generic;
using System.Windows;
using Hit.Helpers;
using Hit.Models;
using Hit.Stores;
using Hit.Stores.Base;
using Hit.ViewModels;
using Hit.Views;
using UseAbilities.MVVM.Base;
using UseAbilities.MVVM.Managers;
using UseAbilities.IoC.Core;

namespace Hit
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        private void OnStartup(object sender, StartupEventArgs e)
        {
            Loader(StaticHelper.IoCcontainer);

            var startupWindow = (MainWindowViewModel)StaticHelper.IoCcontainer.Resolve(ObserveWrapper.Wrap(typeof(MainWindowViewModel)));

            var relationsViewToViewModel = new Dictionary<Type, Type>
                                         {
                                            {startupWindow.GetType(), typeof (MainWindowView)},
                                            {typeof (ReportViewModel), typeof (ReportView)}
                                         };

            ViewManager.RegisterViewViewModelRelations(relationsViewToViewModel);
            ViewModelManager.ActiveViewModels.CollectionChanged += ViewManager.OnViewModelsCoolectionChanged;
            
            startupWindow.Show();
        }

        private static void Loader(IoC ioc)
        {
            ioc.RegisterSingleton<IXmlStore<HitSettings>, HitSettingsStore>();
            //ioc.RegisterSingleton<DBStore<Requests>, RequestsDBStore>();
        }
    }    
}
