using Fitnessclub_WPF.UserControls;
using Fitnessclub_WPF.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitnessclub_WPF.ViewModel
{
    public class WelkomViewModel:BasisViewModel
    {
        MainView main = (MainView)App.Current.MainWindow;
        public WelkomViewModel()
        {


        }


        public override string this[string columnName] => throw new NotImplementedException();
        public override bool CanExecute(object parameter)
        {
            return true;
        }

       

        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "Klant":
                    LogInKlant();
                    break;

            }
        }
        private void LogInKlant()
        {
            main.GridMain.Children.Clear();
            LogInControl usc = new LogInControl();
            usc.DataContext = new LogInViewModel();
            main.GridMain.Children.Add(usc);
        }
    }
    
    
}
