using Fitnessclub_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitnessclub_Models
{
    public static class User
    {
        public static Persoon persoon { get; set; }
        public static Klant klant { get; set; }
        public static Werkgever baas { get; set; }
    }
}
