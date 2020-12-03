using Fitnessclub_Models.UserControlHelper;
using Fitnessclub_WPF.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Fitnessclub_WPF.ViewModel
{
    public class FunctiesKlantViewModel: BasisViewModel
    {
        

        public FunctiesKlantViewModel()
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
                case "Workout":
                    Workout();
                    break;
                case "Logboek":
                    Logboek();
                    break;

            }
        }

        private void Logboek()
        {
            LogboekControl usc = new LogboekControl();
            usc.DataContext = new LogboekViewModel();
            ControlSwitch.InvokeSwitch(usc, "Logboek");
        }

        private void Workout()
        {
            WorkoutsKlantControl usc = new WorkoutsKlantControl();
            usc.DataContext = new WorkoutsKlantViewModel();
            ControlSwitch.InvokeSwitch(usc, "Workout");
        }
    }
}
