using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitnessclub_DAL.Models
{
    [Table("Log_Oefeningen")]
    public class Log_Oefening
    {
        public int Log_OefeningID { get; set; }
        public int OefeningID { get; set; }
        public int LogID { get; set; }


        //navigatieproperties
        public Oefening Oefening { get; set; }
        public Log Log { get; set; }
    }
}
