using Fitnessclub_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitnessclub_WPF.ViewModel
{
    public class LogInViewModel: BasisViewModel
    {

        private string _email;
        private string _wachtwoord;
        private string _melding;

        public string Melding
        {
            get { return _melding; }
            set
            {
                _melding = value;
                NotifyPropertyChanged();
            }
        }


        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                NotifyPropertyChanged();
            }
        }
        public string Wachtwoord
        {
            get { return _wachtwoord; }
            set
            {
                _wachtwoord = value;
                NotifyPropertyChanged();
            }
        }

        Persoon persoon;
        public void Authenticeer()
        {
            /*gebruiker = DatabaseOperations.GetUserByEmail(Email);

            if (gebruiker == null)
            {
                Melding = "Een gebruiker met dit emailadres bestaat niet!";
            }

            if (gebruiker.password == Wachtwoord)
            {
                Melding = "Succesvol aangemeld!";
            }
            else
            {
                Melding = "Fout wachtwoord!";
            }*/


        }



        public override string this[string columnName]
        {
            get
            {
                if (columnName == "Email" && string.IsNullOrWhiteSpace(Email))
                {
                    return "Vul een geldig emailadres in!";
                }
                else if (columnName == "Wachtwoord" && string.IsNullOrWhiteSpace(Email))
                {
                    return "Vul een wachtwoord in om aan te melden!";
                }

                return "";
            }
        }




        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "Aanmelden": Authenticeer(); break;
            }
        }
    }
}
