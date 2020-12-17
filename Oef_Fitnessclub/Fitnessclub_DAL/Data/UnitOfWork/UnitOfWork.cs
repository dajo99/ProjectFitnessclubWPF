using Fitnessclub_DAL.Data.Repositories;
using Fitnessclub_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitnessclub_DAL.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {

        private IRepository<Klant> _klantRepo;
        private IRepository<Log> _logRepo;
        private IRepository<Log_Oefening> _log_oefeningRepo;
        private IRepository<Oefening> _oefeningRepo;
        private IRepository<Trainer> _trainerRepo;
        private IRepository<Werkgever> _werkgeverRepo;


        public UnitOfWork(FitnessclubEntities Entities)
        {
            this.Entities = Entities;

        }
        private FitnessclubEntities Entities { get; }

        public IRepository<Klant> KlantRepo
        {
            get
            {
                if (_klantRepo == null)
                {
                    _klantRepo = new Repository<Klant>(this.Entities);
                }
                return _klantRepo;
            }
        }

        public IRepository<Log> LogRepo
        {
            get
            {
                if (_logRepo == null)
                {
                    _logRepo = new Repository<Log>(this.Entities);
                }
                return _logRepo;
            }
        }

        public IRepository<Log_Oefening> Log_OefeningRepo
        {
            get
            {
                if (_log_oefeningRepo == null)
                {
                    _log_oefeningRepo = new Repository<Log_Oefening>(this.Entities);
                }
                return _log_oefeningRepo;
            }
        }

        public IRepository<Oefening> OefeningRepo
        {
            get
            {
                if (_oefeningRepo == null)
                {
                    _oefeningRepo = new Repository<Oefening>(this.Entities);
                }
                return _oefeningRepo;
            }
        }

        public IRepository<Trainer> TrainerRepo
        {
            get
            {
                if (_trainerRepo == null)
                {
                    _trainerRepo = new Repository<Trainer>(this.Entities);
                }
                return _trainerRepo;
            }
        }

        public IRepository<Werkgever> WerkgeverRepo
        {
            get
            {
                if (_werkgeverRepo == null)
                {
                    _werkgeverRepo = new Repository<Werkgever>(this.Entities);
                }
                return _werkgeverRepo;
            }
        }


        public void Dispose()
        {
            Entities.Dispose();
        }

        public int Save()
        {
            return Entities.SaveChanges();
        }
    }
}
