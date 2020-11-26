using Fitnessclub_DAL.Models;
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

    }
}
