using Fitnessclub_WPF.UserControls;
using Fitnessclub_WPF.ViewModel;
using Fitnessclub_WPF.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Fitnessclub_WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            MainViewModel viewmodel = new MainViewModel();
            MainView view = new MainView();

            WelkomControl usc = new WelkomControl();
            usc.DataContext = new WelkomViewModel();

            viewmodel.Welkom = "Visible";
            viewmodel.AccountPanel = "Hidden";

            viewmodel.Control = usc;
            view.DataContext = viewmodel;
            view.Show();

            
        }
    }
}
