﻿using Fitnessclub_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace Fitnessclub_DAL
{
    public class DataManager
    {
        //----------------------
        //Usercontrole Account
        //----------------------
        public static List<Persoon> OphalenKlantViaKlant(Klant klant)
        {
            using (FitnessclubEntities Entities = new FitnessclubEntities())
            {
                return Entities.Personen
                    .Where(x => x.Email != klant.Email)
                    .ToList();
            }

        }

        public static Persoon OphalenKlantViaKlantMail(string email)
        {
            try
            {
                using (FitnessclubEntities Entities = new FitnessclubEntities())
                {
                    return Entities.Personen
                        .Where(x => x.Email == email)
                        .SingleOrDefault();
                }
            }
            catch (Exception ex)
            {
                FileOperations.Foutloggen(ex);
                return null;
            }
          

        }


        public static int ToevoegenKlant(Klant klant)
        {
            try
            {
                using (FitnessclubEntities Entities = new FitnessclubEntities())
                {
                    Entities.Personen.Add(klant);
                    return Entities.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                FileOperations.Foutloggen(ex);
                return 0;
            }
        }

        public static List<Oefening> OphalenOefeningen()
        {
            using (FitnessclubEntities Entities = new FitnessclubEntities())
            {
                return Entities.Oefeningen
                    .OrderBy(x => x.Naam)
                    .ToList();
            }

        }

        public static int ToevoegenLogoefening(Log_Oefening log_Oefening)
        {
            try
            {
                using (FitnessclubEntities Entities = new FitnessclubEntities())
                {
                    Entities.Log_Workouts.Add(log_Oefening);
                    return Entities.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                FileOperations.Foutloggen(ex);
                return 0;
            }
        }

        public static int ToevoegenLog(Log log)
        {
            try
            {
                using (FitnessclubEntities Entities = new FitnessclubEntities())
                {
                    Entities.Logs.Add(log);
                    return Entities.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                FileOperations.Foutloggen(ex);
                return 0;
            }
        }

        public static List<Log> OphalenLog(int Klantid)
        {
            using (FitnessclubEntities Entities = new FitnessclubEntities())
            {
                return Entities.Logs
                    .Where(x=> x.KlantID == Klantid)
                    .OrderBy(x => x.LogID)
                    .ToList();
                    
            }

        }

        public static List<Log_Oefening> OphalenLogOefeningen(int Klantid)
        {
            using (FitnessclubEntities Entities = new FitnessclubEntities())
            {
                return Entities.Log_Workouts
                    .Where(x => x.Log.KlantID == Klantid)
                    .OrderBy(x => x.LogID)
                    .ToList();

            }

        }

    }
}
