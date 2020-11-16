using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitnessclub_DAL.Models
{
    public class Log_Oefening
    {
        public int Log_WorkoutID { get; set; }
        public int OefeningID { get; set; }
        public int KlantID { get; set; }


        //navigatieproperties
        public Oefening Oefening { get; set; }
        public Klant Klant { get; set; }
    }
}
