using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitnessclub_DAL.Models
{
    public class Werkgever:Persoon
    {
        [Required]
        public int WerkgeverID { get; set; }
        public bool IsAdmin { get; set; }

    }
}
