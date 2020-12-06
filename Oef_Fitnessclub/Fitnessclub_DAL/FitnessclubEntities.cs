using Fitnessclub_DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitnessclub_DAL
{
    class FitnessclubEntities: DbContext
    {
        public FitnessclubEntities(): base("name=FitnessclubDBConnectionString")
        {

        }

        public DbSet<Persoon> Personen { get; set; }
        public DbSet<Klant> Klanten { get; set; }
        public DbSet<Werkgever> Werkgevers { get; set; }
        public DbSet<Trainer> Trainers { get; set; }

        public DbSet<Log> Logs { get; set; }
        public DbSet<Log_Oefening> Log_Workouts { get; set; }
        public DbSet<Oefening> Oefeningen { get; set; }

    }
}
