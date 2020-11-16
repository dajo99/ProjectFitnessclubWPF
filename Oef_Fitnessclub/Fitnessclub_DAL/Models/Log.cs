using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitnessclub_DAL.Models
{
    public class Log
    {
        public int LogID { get; set; }
        public int KlantID { get; set; }
        public string Review { get; set; }
        public string Trainer { get; set; }
        public bool TrainerNodig { get; set; }
        public DateTime Datum { get; set; }

        //navigatieproperties
        public Klant Klant { get; set; }
    }
}
