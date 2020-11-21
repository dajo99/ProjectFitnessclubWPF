using Fitnessclub_WPF.UserControls;
using Fitnessclub_WPF.Views;
using GalaSoft.MvvmLight;
using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Fitnessclub_WPF.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : BasisViewModel
    {
        
        public MainViewModel()
        {
           

        }

        
        public override string this[string columnName] => throw new NotImplementedException();
        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public void Close()
        {
            MessageBoxResult Result = MessageBox.Show("Ben je zeker dat je wilt afsluiten?", "Afsluiten", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (Result == MessageBoxResult.Yes)
            {
                App.Current.Shutdown();
            }

        }
       
        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "Afsluiten":
                    Close();
                    break;  

            }
        }
    }
}