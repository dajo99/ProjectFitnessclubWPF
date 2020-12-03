using Fitnessclub_Models;
using Fitnessclub_Models.UserControlHelper;
using Fitnessclub_WPF.UserControls;
using Fitnessclub_WPF.Views;
using GalaSoft.MvvmLight;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Fitnessclub_WPF.ViewModel
{
    public class MainViewModel : BasisViewModel
    {
        private string _windowTitle;
        private UserControl _control;
        public string _welkom { get; set; }

        public string _accountpanel { get; set; }

        public string _accountnaam { get; set; }

        public string _profileimage { get; set; }

        public string Welkom
        {
            get { return _welkom; }
            set { _welkom = value;}
        }

        public string AccountPanel
        {
            get { return _accountpanel; }
            set { _accountpanel = value; }
        }

        public string Accountnaam
        {
            get { return _accountnaam; }
            set { _accountnaam = value; }
        }

        public string ProfileImage
        {
            get { return _profileimage; }
            set { _profileimage = value; }
        }
        public UserControl Control
        {
            get
            {
                return _control;
            }
            set
            {
                _control = value;
                NotifyPropertyChanged();
            }
        }

        public string WindowTitle
        {
            get { return _windowTitle; }
            set
            {
                _windowTitle = value;
                NotifyPropertyChanged();
            }
        }


        public MainViewModel()
        {
            ControlSwitch.UscEvent += SwitchControl;
            ControlSwitch.VisibilityEvent += ChangePropertyVisibility;
            ControlSwitch.ImageEvent += SetImage;
            ControlSwitch.ContentEvent += SetContent;

        }

        private void SetContent(string content, string Property)
        {
            switch (Property.ToString())
            {
                case "Accountnaam":
                    Accountnaam = content;
                    break;
                

            }
        }

        public void SwitchControl(UserControl usc, string title)
        {
            Control = usc;
            WindowTitle = title;

        }

        public void ChangePropertyVisibility(string visibility, string Property)
        {
            switch (Property.ToString())
            {
                case "AccountPanel":
                    AccountPanel = visibility;
                    break;
                case "Welkom":
                    Welkom = visibility;
                    break;
               
            }
        }

        public void SetImage(string Image, string Property)
        {
            switch (Property)
            {
                case "ProfileImage":
                    ProfileImage = Image;
                    break;
                

            }
        }

        public void Close()
        {
            MessageBoxResult Result = MessageBox.Show("Ben je zeker dat je wilt afsluiten?", "Afsluiten", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (Result == MessageBoxResult.Yes)
            {
                App.Current.Shutdown();
            }

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
                case "Afsluiten":
                    Close();
                    break;
                case "Logout":
                    LogOut();
                    break;

            }
        }

        private void LogOut()
        {
            //User en profielfoto leegmaken
            User.persoon = null;
            ProfileImage = null;

            //knoppen enablen
            AccountPanel = "Hidden";
            Welkom = "Visible";

            //Nieuw scherm oproepen
            WelkomControl usc = new WelkomControl();
            usc.DataContext = new WelkomViewModel();
            ControlSwitch.InvokeSwitch(usc, "Welkom");
        }
    }
}