using Fitnessclub_DAL;
using Fitnessclub_DAL.Data.UnitOfWork;
using Fitnessclub_DAL.Models;
using Fitnessclub_Models;
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
    public class TrainerToewijzenViewModel : BasisViewModel,IDisposable
    {
        IUnitOfWork unitOfWork = new UnitOfWork(new FitnessclubEntities());
        private ObservableCollection<Log> _logs;
        private Log _geselecteerdeKlant;

        public string _klant;
        public string _trainer;
        public string _datum;

        private ObservableCollection<Trainer> _trainers;
        private Trainer _geselecteerdeTrainer;

        public string Klant
        {
            get { return _klant; }
            set
            {
                _klant = value;

                NotifyPropertyChanged();
            }
        }

        public string Trainer
        {
            get { return _trainer; }
            set
            {
                _trainer = value;

                NotifyPropertyChanged();
            }
        }

        public string Tijdstip
        {
            get { return _datum; }
            set
            {
                _datum = value;

                NotifyPropertyChanged();
            }
        }



        public ObservableCollection<Log> Logs
        {
            get { return _logs; }
            set
            {
                _logs = value;
                NotifyPropertyChanged();
            }
        }


        public Log GeselecteerdeKlant
        {
            get { return _geselecteerdeKlant; }
            set
            {
                _geselecteerdeKlant = value;
                SelectieKlant();
                SelectieDatum();
                NotifyPropertyChanged();
            }
        }

        public ObservableCollection<Trainer> Trainers
        {
            get { return _trainers; }
            set
            {
                _trainers = value;
                NotifyPropertyChanged();
            }
        }

        public Trainer GeselecteerdeTrainer
        {
            get { return _geselecteerdeTrainer; }
            set
            {
                _geselecteerdeTrainer = value;
                SelectieTrainer();
                NotifyPropertyChanged();
            }
        }


        public TrainerToewijzenViewModel()
        {
            Trainers = new ObservableCollection<Trainer>(unitOfWork.TrainerRepo.Ophalen());
            DataRefresh();
            
        }

        public void DataRefresh()
        {
            List<Log> nieuw = new List<Log>();
            List<Log> lijstKlanten = unitOfWork.LogRepo.Ophalen(x => x.Trainer == "Nog te bepalen!").ToList();
            foreach (var item in lijstKlanten)
            {
                int id = item.KlantID;
                Klant klant = unitOfWork.KlantRepo.Ophalen(x => x.PersoonID == id).SingleOrDefault();
                item.klant = klant;

                nieuw.Add(item);

            }


            Logs = new ObservableCollection<Log>(nieuw);
        }


        private void SelectieKlant()
        {
            if (GeselecteerdeKlant != null)
            {
                Klant = "Klant: " + GeselecteerdeKlant.klant.VolledigeNaam;
            }
            
        }

        private void SelectieTrainer()
        {
            if (GeselecteerdeTrainer != null)
            {
                Trainer = "Trainer: " + GeselecteerdeTrainer.VolledigeNaam +"\n\nSpecialisatie: " + GeselecteerdeTrainer.Specialisatie;

            }

        }

        private void SelectieDatum()
        {
            if (GeselecteerdeKlant != null)
            {
                Tijdstip = "Datum: " + GeselecteerdeKlant.Datum.ToString("dd/MM/yyyy");
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
                case "Bevestigen":
                    Bevestigen();
                    break;
                case "Terug":
                    Terug();
                    break;
                case "Verwijderen":
                    Verwijderen();
                    break;

            }
        }

        private void Bevestigen()
        {
            if (GeselecteerdeKlant!= null && GeselecteerdeTrainer!=null)
            {
                GeselecteerdeKlant.klant = null;
                GeselecteerdeKlant.Trainer = GeselecteerdeTrainer.VolledigeNaam;
                unitOfWork.LogRepo.Aanpassen(GeselecteerdeKlant);
                int ok = unitOfWork.Save();
                if (ok>0)
                {
                    MessageBox.Show("Trainer is toegewezen.");
                    DataRefresh();
                }
                else
                {
                    MessageBox.Show("Trainer is niet toegewezen.");
                }
            }
        }

        private void Verwijderen()
        {
            Log_Oefening log_Oefening = unitOfWork.Log_OefeningRepo.Ophalen(x=>x.Log == GeselecteerdeKlant).SingleOrDefault();
            if (log_Oefening!= null)
            {
                GeselecteerdeKlant.klant = null;

                unitOfWork.Log_OefeningRepo.Verwijderen(log_Oefening);
                unitOfWork.LogRepo.Verwijderen(GeselecteerdeKlant);
                int ok = unitOfWork.Save();
                if (ok>0)
                {
                    MessageBox.Show("Log is verwijderd!");
                    DataRefresh();
                }
                else
                {
                    MessageBox.Show("Log is niet verwijderd!");
                }
            }
            else
            {
                MessageBox.Show("Geen LogOefening gevonden!");
            }
        }

        private void Terug()
        {
            FunctiesAdminControl usc = new FunctiesAdminControl();
            usc.DataContext = new FunctiesAdminViewModel();
            ControlSwitch.InvokeSwitch(usc, "Functies");
        }

        public void Dispose()
        {
            unitOfWork?.Dispose();
        }


    }
}
