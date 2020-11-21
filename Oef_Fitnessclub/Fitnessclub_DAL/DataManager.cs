using Fitnessclub_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
