using System;
using System.Collections.Generic;
using System.Windows;
using Hit.Helpers;
using Hit.Models;
using Hit.Stores;
using Hit.Stores.Base;
using Hit.ViewModels;
using Hit.Views;
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
            var relationsViewToViewModel = new Dictionary<Type, Type>
                                         {
                                            {typeof (MainWindowViewModel), typeof (MainWindowView)}
                                         };

            ViewManager.RegisterViewViewModelRelations(relationsViewToViewModel);
            ViewModelManager.ActiveViewModels.CollectionChanged += ViewManager.OnViewModelsCoolectionChanged;

            //var startupWindow = new MainWindowViewModel();
            Loader(StaticHelper.IoCcontainer);

            var startupWindow = StaticHelper.IoCcontainer.Resolve<MainWindowViewModel>();
            startupWindow.Show();
        }

        private static void Loader(IoC ioc)
        {
            ioc.RegisterSingleton<IXmlStore<HitSettings>, HitSettingsStore>();
            ioc.RegisterSingleton<DBStore<Requests>, RequestsDBStore>();
        }
    }    
}
