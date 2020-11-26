﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitnessclub_DAL.Models
{
    public class Klant:Persoon
    {
        public int KlantID { get; set; }

        //navigatieproperties
        public ICollection<Log> Logs { get; set; }
    }
}
