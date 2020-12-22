using Fitnessclub_DAL.BasisModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitnessclub_DAL.Models
{
    [Table("Personen")]
    public abstract class Persoon:Basisklasse 
    { 
        public int PersoonID { get; set; }
        public byte[] Profielfoto { get; set; }
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        [Required]
        public string Wachtwoord { get; set; }

        [Required]
        public string Email { get; set; }
        public string Adres { get; set; }
        public string Postcode { get; set; }
        public string Gemeente { get; set; }
        public string Land { get; set; }

        [NotMapped]
        public string VolledigeNaam
        {
            get { return this.Voornaam + " " + this.Achternaam; }
        }
    }
}
