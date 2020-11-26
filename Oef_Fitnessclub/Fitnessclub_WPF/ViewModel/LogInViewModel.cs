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
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Fitnessclub_WPF.ViewModel
{
    public class LogInViewModel : BasisViewModel
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
        


        public void Inloggen()
        {

            Klant k = new Klant();
            k.Email = Email;
            k.Wachtwoord = Wachtwoord;

            Persoon b = DataManager.OphalenKlantViaKlantMail(k.Email);
            if (b != null)
            {
                string dp = SecurePassword.DecryptString(b.Wachtwoord); //deëncrypteren van database-wachtwoord van account;
                if (k.Wachtwoord == dp)
                {
                    User.persoon = b ; //nodig om account van de klant te onthouden
                    main.Accountnaam.Content = b.Voornaam;
                    if (b.Profielfoto != null)
                    {
                        string profielImage = Encoding.ASCII.GetString(k.Profielfoto);
                        main.ProfileImage.Source = new BitmapImage(new Uri(profielImage));
                    }

                    main.Welkom.Visibility = Visibility.Hidden;
                    main.AccountPanel.Visibility = Visibility.Visible;



                    //Nieuwe usercontrol oproepen
                    main.GridMain.Children.Clear();
                    UserControl usc = new FunctiesKlantControl();
                    usc.DataContext = new FunctiesKlantViewModel();
                    main.GridMain.Children.Add(usc);

                }

                else
                {
                    MessageBox.Show("De opgegeven mail en het wachtwoord komen niet overeen!", "foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Deze mail bestaat niet!", "foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
            }




        }

        private void Registreren()
        {
            main.GridMain.Children.Clear();
            RegisterControl usc = new RegisterControl();
            usc.DataContext = new RegisterViewmodel();
            main.GridMain.Children.Add(usc);
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
                case "LogInKlant": Inloggen(); break;
                case "GeenAccount": Registreren(); break;

            }
        }


    }
}
