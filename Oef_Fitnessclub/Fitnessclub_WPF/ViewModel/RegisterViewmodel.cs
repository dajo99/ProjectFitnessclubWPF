using Fitnessclub_DAL;
using Fitnessclub_DAL.Models;
using Fitnessclub_Models;
using Fitnessclub_WPF.UserControls;
using Fitnessclub_WPF.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Fitnessclub_WPF.ViewModel
{
    public class RegisterViewmodel : BasisViewModel
    {
        MainView main = (MainView)App.Current.MainWindow;

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


        private void Registreren()
        {
            //nieuw klantaccount aanmaken en invoergegevens erin zetten
            Klant k = new Klant();



            if (k.IsGeldig())
            {


                //wachtwoord encrypteren 
                k.Wachtwoord = SecurePassword.EncryptString(k.Wachtwoord);

                // Lijst maken met alle accounts maken   
                //Nieuw account als paramater is nodig zodat ik geen 2de methode moet aanmaken om een lijst van accounts op te vullen (om account te wijzigen heb je een paramter nodig)
                List<Persoon> accounts = DataManager.OphalenKlantViaKlant(new Klant());

                if (!accounts.Contains(k))//Kijken als er al een acocunt met deze mail in database zit
                {
                    int ok = DataManager.ToevoegenKlant(k);
                    if (ok > 0)
                    {
                        User.klant = k; //nodig om account van de gebruiker te onthouden



                        //Nieuwe usercontrol oproepen
                        main.GridMain.Children.Clear();
                        UserControl usc = new FunctiesKlantControl();
                        usc.DataContext = new FunctiesKlantViewModel();
                        main.GridMain.Children.Add(usc);
                    }
                    else
                    {
                        MessageBox.Show("Account is niet toegevoegd!", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Deze email is al in gebruik!", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
            else
            {
                MessageBox.Show(k.Error, "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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
                case "GeenAccount":; break;

            }
        }


    }
}
