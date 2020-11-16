using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitnessclub_DAL.Models
{
    public class Werkgever
    {
        public int WerkgeverID { get; set; }
        public bool IsAdmin { get; set; }

        //navigatieproperties
        public ICollection<Workout> Workouts { get; set; }
    }
}
