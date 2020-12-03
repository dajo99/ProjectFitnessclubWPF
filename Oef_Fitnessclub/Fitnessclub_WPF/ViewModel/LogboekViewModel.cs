using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitnessclub_WPF.ViewModel
{
    public class LogboekViewModel: BasisViewModel
    {
        public LogboekViewModel()
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
                    ;
                    break;
                case "Logboek":
                    ;
                    break;

            }
        }
    }
}
