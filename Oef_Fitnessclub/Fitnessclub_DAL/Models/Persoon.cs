﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitnessclub_DAL.Models
{
    public abstract class Persoon
    {
        public int PersoonID { get; set; }
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public string Wachtwoord { get; set; }
        public DateTime Geboortedatum { get; set; }
        public string Email { get; set; }
        public string Straat { get; set; }
        public string Huisnummer { get; set; }
        public string Postcode { get; set; }
        public string Gemeente { get; set; }

    }
}