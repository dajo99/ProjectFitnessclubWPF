using Fitnessclub_DAL;
using Fitnessclub_DAL.Data.UnitOfWork;
using Fitnessclub_DAL.Models;
using Fitnessclub_Models;
using Fitnessclub_Models.UserControlHelper;
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
    public class RegisterViewmodel : BasisViewModel,IDisposable
    {
        IUnitOfWork unitOfWork = new UnitOfWork(new FitnessclubEntities());

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
            k.Email = Email;
            

            if (Profielfoto != null)
            {
                //Het datatype in de database is varbinary dus de string moet eerst omgezet worden.
                k.Profielfoto = Encoding.ASCII.GetBytes(op.FileName);
            }


            if (k.IsGeldig())
            {


                //wachtwoord encrypteren 
                k.Wachtwoord = SecurePassword.EncryptString(k.Wachtwoord);


                List<Klant> accounts = unitOfWork.KlantRepo.Ophalen(x => x.Email == k.Email).ToList();
                
                if (!accounts.Contains(k))//Kijken als er al een acocunt met deze mail in database zit
                {
                    unitOfWork.KlantRepo.Toevoegen(k);
                    int ok = unitOfWork.Save();
                    if (ok > 0)
                    {
                        User.persoon = k; //nodig om account van de klant te onthouden
                        //main.Accountnaam.Content = k.Voornaam;
                       
                        ControlSwitch.SetContent(k.Voornaam, "Accountnaam");

                        ControlSwitch.SetImage(op.FileName,"ProfileImage");

                        //main.Welkom.Visibility = Visibility.Hidden;
                        ControlSwitch.ChangePropertyVisibility("Hidden", "Welkom");
                        //main.AccountPanel.Visibility = Visibility.Visible;
                        ControlSwitch.ChangePropertyVisibility("Visible", "AccountPanel");



                        //Nieuwe usercontrol oproepen

                        UserControl usc = new FunctiesKlantControl();
                        usc.DataContext = new FunctiesKlantViewModel();
                        ControlSwitch.InvokeSwitch(usc, "Functies");

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
            UserControls.LogInControl usc = new UserControls.LogInControl();
            usc.DataContext = new LogInViewModel();
            ControlSwitch.InvokeSwitch(usc, "Klant");

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

        public void Dispose()
        {
            unitOfWork?.Dispose();
        }


    }
}
