using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitnessclub_DAL.Models
{
    public class Klant:Persoon
    {
        public int KlantID { get; set; }
        public string Licentiecode { get; set; }
        public string Rekeningnummer { get; set; }

        //navigatieproperties
        public List<Log> Logs { get; set; }
    }
}
