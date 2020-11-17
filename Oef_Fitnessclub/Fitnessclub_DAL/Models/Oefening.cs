using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitnessclub_DAL.Models
{
    [Table("Oefeningen")]
    public class Oefening
    {
        public int OefeningID { get; set; }
        public string Videolink { get; set; }
        public byte[] Afbeelding { get; set; }
        [Required]
        public string Naam { get; set; }
        [Required]
        public string Omschrijving { get; set; }

        //navigatieproperties
        public ICollection<Log_Oefening> Log_Oefeningen { get; set; }
    }
}
