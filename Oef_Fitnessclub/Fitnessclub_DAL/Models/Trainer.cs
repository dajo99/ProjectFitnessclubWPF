using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitnessclub_DAL.Models
{
    public class Trainer:Persoon
    {
        public int TrainerID { get; set; }
        [Required]
        public string Functie { get; set; }
        [Required]
        public string Specialisatie { get; set; }

  



    }
}
