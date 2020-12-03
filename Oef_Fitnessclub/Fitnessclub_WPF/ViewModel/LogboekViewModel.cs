using Fitnessclub_DAL;
using Fitnessclub_DAL.Models;
using Fitnessclub_Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitnessclub_WPF.ViewModel
{
    public class LogboekViewModel: BasisViewModel
    {
        private ObservableCollection<Log_Oefening> _logoefeningen;

        public ObservableCollection<Log_Oefening> LogOefeningen
        {
            get { return _logoefeningen; }
            set
            {
                _logoefeningen = value;
                NotifyPropertyChanged();
            }
        }

        public LogboekViewModel()
        {
            List<Log_Oefening> lijst = DataManager.OphalenLogOefeningen(User.persoon.PersoonID);
            LogOefeningen = new ObservableCollection<Log_Oefening>(lijst);

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
                    ;
                    break;
                case "Logboek":
                    ;
                    break;

            }
        }
    }
}
