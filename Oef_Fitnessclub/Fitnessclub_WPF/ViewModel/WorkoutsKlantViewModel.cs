using Fitnessclub_DAL;
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
using System.Windows.Controls;

namespace Fitnessclub_WPF.ViewModel
{
    public class WorkoutsKlantViewModel: BasisViewModel
    {
        private ObservableCollection<Oefening> _oefeningen;
        private string _selectieTrainer;
        private string _gekozenOefening;
        bool trainerNodig;
        string trainer;

        private Oefening _geselecteerdeOefening;

        private DateTime _datum;
        private string _resultaat;
        Log_Oefening logoefening = new Log_Oefening();

        public string GekozenOefening
        {
            get { return _gekozenOefening; }
            set
            {
                _gekozenOefening = value;
                NotifyPropertyChanged();
            }
        }

        public string SelectieTrainer
        {
            get { return _selectieTrainer; }
            set
            {
                _selectieTrainer = value;
                Selectie();
                NotifyPropertyChanged();
            }
        }


        public string Resultaat
        {
            get { return _resultaat; }
            set { _resultaat = value; }
        }

        
        public DateTime Datum 
        {
            get { return _datum; }
            set
            {
                if (value >= DateTime.Today)
                {
                    _datum = value;
                }
               
                NotifyPropertyChanged();
            }
        }

        public ObservableCollection<Oefening> Oefeningen
        {
            get { return _oefeningen; }
            set
            {
                _oefeningen = value;
                NotifyPropertyChanged();
            }
        }

        public Oefening GeselecteerdeOefening
        {
            get { return _geselecteerdeOefening; }
            set
            {
                _geselecteerdeOefening = value;
                Toevoegen();
                NotifyPropertyChanged();
            }
        }

        

        public WorkoutsKlantViewModel()
        {
            
            Datum = DateTime.Today;
            List<Oefening> lijstoefeningen = DataManager.OphalenOefeningen();
            Oefeningen = new ObservableCollection<Oefening>(lijstoefeningen);
            
        }
        private void Toevoegen()
        {
            if (GeselecteerdeOefening!=null)
            {
                GekozenOefening = GeselecteerdeOefening.Naam;
                logoefening.OefeningID = GeselecteerdeOefening.OefeningID;
                logoefening.Oefening = GeselecteerdeOefening;

            }
            else
            {
                MessageBox.Show("Mislukt");
            }

            

        }

        private void Selectie()
        {
            if (SelectieTrainer == "0")
            {
                Resultaat = "U heeft geen trainer. \nDe administrator zal u geen trainer toewijzen.";
                trainerNodig = false;
                trainer = "/";
            }
            else
            {
                Resultaat = "U heeft gekozen voor een trainer. \nDe administrator zal u een trainer toewijzen.";
                trainerNodig = true;
                trainer = "Nog te bepalen!";
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

            }
        }

        private void Terug()
        {
            UserControl usc = new FunctiesKlantControl();
            usc.DataContext = new FunctiesKlantViewModel();
            ControlSwitch.InvokeSwitch(usc, "Functies");
        }

        private void Bevestigen()
        {
            if (Datum != null && GekozenOefening != "" && Resultaat!=null)
            {
                Log log = new Log();
                log.Datum = Datum;
                log.KlantID = User.persoon.PersoonID;
                log.TrainerNodig = trainerNodig;
                log.Trainer = trainer;
                log.Review = "";
                int ok = DataManager.ToevoegenLog(log);
                if (ok>0)
                {
                    MessageBox.Show("log is toegevoegd");

                    List<Log> lijst = DataManager.OphalenLog(User.persoon.PersoonID);
                    int logid = 0;
                    foreach (var item in lijst)
                    {
                        MessageBox.Show(item.LogID.ToString());
                        logid = item.LogID;
                        logoefening.Log = item;

                    }

                    logoefening.LogID = logid;
                    

                    int resultaat = DataManager.ToevoegenLogoefening(logoefening);
                    if (resultaat>0)
                    {
                        MessageBox.Show("logoefening is tooeegevoegd");

                    }
                    else
                    {
                        MessageBox.Show("Fail2");
                    }
                }
                else
                {
                    MessageBox.Show("Fail1");
                }

                
            }
        }
    }
}
