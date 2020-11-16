using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitnessclub_DAL.Models
{
    [Table("Logs")]
    public class Log
    {
        public int LogID { get; set; }
        public int KlantID { get; set; }
        public string Review { get; set; }
        public string Trainer { get; set; }
        public bool TrainerNodig { get; set; }

        [DataType(DataType.Date)]
        public DateTime Datum { get; set; }

        //navigatieproperties
        public Klant Klant { get; set; }
    }
}
