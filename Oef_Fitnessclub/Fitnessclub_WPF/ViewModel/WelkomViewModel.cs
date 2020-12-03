using Fitnessclub_Models;
using Fitnessclub_Models.UserControlHelper;
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
                case "Administrator":
                    LogInAdministrator();
                    break;

            }
        }

        private void LogInAdministrator()
        {
            UserControlStatic.Title = "Administrator";
            UserControls.LogInControl usc = new UserControls.LogInControl();
            usc.DataContext = new LogInViewModel();
            ControlSwitch.InvokeSwitch(usc, "Administrator");
            
        }

        private void LogInKlant()
        {
            UserControlStatic.Title = "Klant";
            UserControls.LogInControl usc = new UserControls.LogInControl();
            usc.DataContext = new LogInViewModel();
            ControlSwitch.InvokeSwitch(usc, "Klant");

        }
    }
    
    
}
