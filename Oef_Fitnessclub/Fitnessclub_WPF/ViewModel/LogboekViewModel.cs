﻿using Fitnessclub_DAL;
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
    public class LogboekViewModel : BasisViewModel
    {
        private Log _logRecord;
        private ObservableCollection<Log_Oefening> _logoefeningen;
        private Log_Oefening _geselecteerdeLogOefening;

        public Log LogRecord
        {
            get { return _logRecord; }
            set
            {
                _logRecord = value;
                NotifyPropertyChanged();

            }
        }

        public Log_Oefening GeselecteerdeLogOefening
        {
            get { return _geselecteerdeLogOefening; }
            set
            {
                _geselecteerdeLogOefening = value;
                LogRecordInstellen();
                NotifyPropertyChanged();

            }
        }

        public ObservableCollection<Log_Oefening> LogOefeningen
        {
            get { return _logoefeningen; }
            set
            {
                _logoefeningen = value;
                NotifyPropertyChanged();
            }
        }

        public LogboekViewModel()
        {
            List<Log_Oefening> lijst = DataManager.OphalenLogOefeningen(User.persoon.PersoonID);
            LogOefeningen = new ObservableCollection<Log_Oefening>(lijst);

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
                case "Bevestigen":
                    Bevestigen();
                    break;

            }
        }

        private void Bevestigen()
        {

            if (LogRecord != null)
            {

                int ok = DataManager.AanpassenLog(LogRecord);
                if (ok > 0)
                {
                    List<Log_Oefening> lijst = DataManager.OphalenLogOefeningen(User.persoon.PersoonID);
                    LogOefeningen = new ObservableCollection<Log_Oefening>(lijst);
                    Wissen();
                }
                else
                {
                    MessageBox.Show("Log is niet aangepast!", "Foutmelding");
                }



            }
            else
            {
                MessageBox.Show("Eerst log selecteren!", "Foutmelding");
            }
        }

        private void Verwijderen()
        {
            if (GeselecteerdeLogOefening != null)
            {

                int ok = DataManager.VerwijderenLogOefening(GeselecteerdeLogOefening.Log, GeselecteerdeLogOefening);
                if (ok > 0)
                {
                    List<Log_Oefening> lijst = DataManager.OphalenLogOefeningen(User.persoon.PersoonID);
                    LogOefeningen = new ObservableCollection<Log_Oefening>(lijst);
                    Wissen();
                }
                else
                {
                    MessageBox.Show("Log is niet verwijderd!", "Foutmelding");
                }
            }
            else
            {
                MessageBox.Show("Eerst log selecteren!", "Foutmelding");
            }
        }

        private void Terug()
        {
            FunctiesKlantControl usc = new FunctiesKlantControl();
            usc.DataContext = new FunctiesKlantViewModel();
            ControlSwitch.InvokeSwitch(usc, "Functies");
        }

        public void Wissen()
        {
            GeselecteerdeLogOefening = null;
            LogRecordInstellen();
        }

        private void LogRecordInstellen()
        {
            if (GeselecteerdeLogOefening != null)
            {
                LogRecord = GeselecteerdeLogOefening.Log;
            }

        }
    }
}
