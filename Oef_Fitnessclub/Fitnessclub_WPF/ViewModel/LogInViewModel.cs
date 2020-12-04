using Fitnessclub_DAL;
using Fitnessclub_DAL.Models;
using Fitnessclub_Models;
using Fitnessclub_Models.UserControlHelper;
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

        private string _email;
        private string _wachtwoord;
        private string _melding;
        private string _geenAccountVisibility;
        private string _gegevens;
        private string _windowTitle;

        public string Gegevens
        {
            get { return _gegevens; }
            set { _gegevens = value; }
        }
        public string WindowTitle
        {
            get { return _windowTitle; }
            set { _windowTitle = value; }
        }

        public string GeenAccountVisibility
        {
            get { return _geenAccountVisibility; }
            set { _geenAccountVisibility = value; }
        }


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
        
        public LogInViewModel()
        {
            if (UserControlStatic.Title == "Administrator")
            {
                WindowTitle = "Administrator";
                GeenAccountVisibility = "Hidden";
                Gegevens = "Visible";
            }
            else
            {
                WindowTitle = "Klant";
                Gegevens = "Hidden";
            }

        }

        

        public void Inloggen()
        {
            Persoon b;
            if (UserControlStatic.Title == "Administrator")
            {
                Werkgever w = new Werkgever();
                w.Email = Email;
                w.Wachtwoord = Wachtwoord;

                 b = DataManager.OphalenKlantViaKlantMail(w.Email);
            }
            else
            {
                Klant k = new Klant();
                k.Email = Email;
                k.Wachtwoord = Wachtwoord;

                b = DataManager.OphalenKlantViaKlantMail(k.Email);
            }
            if ((b.Voornaam == "Admin" && UserControlStatic.Title == "Klant") || (b.Voornaam != "Admin" && UserControlStatic.Title == "Administrator"))
            {
                MessageBox.Show("Verkeerde inlogpagina!", "Foutmelding", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (b != null)
                {
                    string dp = SecurePassword.DecryptString(b.Wachtwoord); //deëncrypteren van database-wachtwoord van account;
                    if (Wachtwoord == dp)
                    {
                        User.persoon = b; //nodig om account van de klant te onthouden
                        ControlSwitch.SetContent(b.Voornaam, "Accountnaam");
                        if (b.Profielfoto != null)
                        {
                            string profielImage = Encoding.ASCII.GetString(b.Profielfoto);

                            //main.ProfileImage.Source = new BitmapImage(new Uri(profielImage));
                            ControlSwitch.SetImage(profielImage, "ProfileImage");

                        }

                        ControlSwitch.ChangePropertyVisibility("Hidden", "Welkom");
                        //main.AccountPanel.Visibility = Visibility.Visible;
                        ControlSwitch.ChangePropertyVisibility("Visible", "AccountPanel");



                        //Nieuwe usercontrol oproepen
                        if (b.Voornaam == "Admin")
                        {
                            UserControl usc = new FunctiesAdminControl();
                            usc.DataContext = new FunctiesAdminViewModel();
                            ControlSwitch.InvokeSwitch(usc, "Functies");
                        }
                        else
                        {
                            UserControl usc = new FunctiesKlantControl();
                            usc.DataContext = new FunctiesKlantViewModel();
                            ControlSwitch.InvokeSwitch(usc, "Functies");
                        }




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
            




        }

        private void Registreren()
        {
            RegisterControl usc = new RegisterControl();
            usc.DataContext = new RegisterViewmodel();
            ControlSwitch.InvokeSwitch(usc, "Registreren");

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
                case "Terug": Terug(); break;


            }
        }

        private void Terug()
        {
            WelkomControl usc = new WelkomControl();
            usc.DataContext = new WelkomViewModel();
            ControlSwitch.InvokeSwitch(usc, "Welkom");
        }
    }
}
