using Fitnessclub_DAL;
using Fitnessclub_DAL.Data.UnitOfWork;
using Fitnessclub_DAL.Models;
using Fitnessclub_Models.UserControlHelper;
using Fitnessclub_WPF.UserControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Fitnessclub_WPF.ViewModel
{
    public class KlantenlijstViewmodel:BasisViewModel, IDisposable
    {
        IUnitOfWork unitOfWork = new UnitOfWork((new FitnessclubEntities()));
        private ObservableCollection<Klant> _klanten;
        private Klant _geselecteerdeKlant;


        public ObservableCollection<Klant> Klanten
        {
            get { return _klanten; }
            set
            {
                _klanten = value;
                NotifyPropertyChanged();
            }
        }

        public Klant GeselecteerdeKlant
        {
            get { return _geselecteerdeKlant; }
            set
            {
                _geselecteerdeKlant = value;
                NotifyPropertyChanged();

            }
        }


        public KlantenlijstViewmodel()
        {
            Klanten = new ObservableCollection<Klant>(unitOfWork.KlantRepo.Ophalen());
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
                case "Terug":
                    Terug();
                    break;
                case "Verwijderen":
                    Verwijderen();
                    break;
                case "Opslaan":
                    Opslaan();
                    break;


            }
        }

        private void Opslaan()
        {
            if (GeselecteerdeKlant != null)
            {
                if (GeselecteerdeKlant.IsGeldig())
                {


                    unitOfWork.KlantRepo.Aanpassen(GeselecteerdeKlant);

                    //Save-methode gaat alle veranderingen in DbContext doorvoeren naar de database
                    int ok = unitOfWork.Save();

                    if (ok > 0)
                    {
                        Klanten = new ObservableCollection<Klant>(unitOfWork.KlantRepo.Ophalen());
                        GeselecteerdeKlant = null;
                    }
                    else
                    {
                        MessageBox.Show("Klant is niet aangepast!", "Foutmelding");
                    }
                }


            }
            else
            {
                MessageBox.Show("Eerst klant selecteren!", "Foutmelding");
            }
        }

        private void Verwijderen()
        {
            if (GeselecteerdeKlant != null)
            {
                unitOfWork.KlantRepo.Verwijderen(GeselecteerdeKlant);
                int ok = unitOfWork.Save();
                if (ok > 0)
                {
                    Klanten = new ObservableCollection<Klant>(unitOfWork.KlantRepo.Ophalen());
                    GeselecteerdeKlant = null;
                }
                else
                {
                    MessageBox.Show("Klant is niet verwijderd!", "Foutmelding");
                }
            }
            else
            {
                MessageBox.Show("Eerst klant selecteren!", "Foutmelding");
            }
        }

        private void Terug()
        {
            FunctiesAdminControl usc = new FunctiesAdminControl();
            usc.DataContext = new FunctiesAdminViewModel();
            ControlSwitch.InvokeSwitch(usc, "Functies");
        }

        //unitOfWork mag “vernietigd” worden wanneer ViewModel niet meer gebruikt wordt
        public void Dispose()
        {
            unitOfWork?.Dispose();
        }

    }
}
