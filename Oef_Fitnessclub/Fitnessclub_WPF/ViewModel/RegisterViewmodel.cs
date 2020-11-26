using Fitnessclub_DAL;
using Fitnessclub_DAL.Models;
using Fitnessclub_Models;
using Fitnessclub_WPF.UserControls;
using Fitnessclub_WPF.Views;
using Microsoft.Win32;
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
    public class RegisterViewmodel : BasisViewModel
    {
        MainView main = (MainView)App.Current.MainWindow;

        private string _voornaam;
        private string _achternaam;
        private string _adres;
        private string _gemeente;
        private string _postcode;
        private string _land;
        private string _wachtwoord;
        private string _email;
        private ImageSource _profielfoto;
        

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

        public string Voornaam
        {
            get { return _voornaam; }
            set
            {
                _voornaam = value;
                NotifyPropertyChanged();
            }
        }
        public string Achternaam
        {
            get { return _achternaam; }
            set
            {
                _achternaam = value;
                NotifyPropertyChanged();
            }
        }

        public string Adres
        {
            get { return _adres; }
            set
            {
                _adres = value;
                NotifyPropertyChanged();
            }
        }
        public string Gemeente
        {
            get { return _gemeente; }
            set
            {
                _gemeente = value;
                NotifyPropertyChanged();
            }
        }

        public string Postcode
        {
            get { return _postcode; }
            set
            {
                _postcode = value;
                NotifyPropertyChanged();
            }
        }
        public string Land
        {
            get { return _land; }
            set
            {
                _land = value;
                NotifyPropertyChanged();
            }
        }

        public ImageSource Profielfoto
        {
            get { return _profielfoto; }
            set
            {
                _profielfoto = value;
                NotifyPropertyChanged();
            }
        }

        public RegisterViewmodel()
        {

        }



        private void Registreren()
        {
            //nieuw klantaccount aanmaken en invoergegevens erin zetten
            Klant k = new Klant();
            k.Voornaam = Voornaam;
            k.Achternaam = Achternaam;
            k.Wachtwoord = Wachtwoord;
            k.Adres = Adres;
            k.Gemeente = Gemeente;
            k.Postcode = Postcode;
            k.Land = Land;
            

            if (Profielfoto != null)
            {
                //Het datatype in de database is varbinary dus de string moet eerst omgezet worden.
                k.Profielfoto = Encoding.ASCII.GetBytes(op.FileName);
            }


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
                        User.klant = k; //nodig om account van de klant te onthouden
                        string volledigeNaam = k.Voornaam.Trim() + " " + k.Achternaam.Trim();
                        main.Accountnaam.Content = volledigeNaam;//Menubalk naam veranderen
                        main.ProfileImage.Source = myImage;
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

        //Deze klasse opent een nieuw dialoogvenster om afbeeldingen te uploaden
        OpenFileDialog op = new OpenFileDialog();
        BitmapImage myImage;
        private void Uploaden()
        {
            //titel geven aan dialoogvenster
            op.Title = "Select a picture";
            //Zorgen dat er alleen ondersteunde bestandstypes geupload kunnen worden
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";

            if (op.ShowDialog() == true)
            {
                myImage = new BitmapImage(new Uri(op.FileName, UriKind.Absolute));
                Profielfoto = myImage;
            }
        }

        private void Terug()
        {
            main.GridMain.Children.Clear();
            WelkomControl usc = new WelkomControl();
            usc.DataContext = new WelkomViewModel();
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
                case "Uploaden":Uploaden(); break;
                case "Registreren": Registreren(); break;
                case "Terug": Terug(); break;

            }
        }

        
    }
}
