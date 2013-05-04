using System;
using System.Collections.Generic;
using System.Windows;
using Hit.ViewModels;
using Hit.Views;
using UseAbilities.MVVM.Managers;

namespace Hit
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void OnStartup(object sender, StartupEventArgs e)
        {
            var relationsViewToViewModel = new Dictionary<Type, Type>
                                         {
                                            {typeof (MainWindowViewModel), typeof (MainWindowView)}
                                         };

            ViewManager.RegisterViewViewModelRelations(relationsViewToViewModel);
            ViewModelManager.ActiveViewModels.CollectionChanged += ViewManager.OnViewModelsCoolectionChanged;

            var startupWindow = new MainWindowViewModel();
            startupWindow.Show();
        }
    }
}
