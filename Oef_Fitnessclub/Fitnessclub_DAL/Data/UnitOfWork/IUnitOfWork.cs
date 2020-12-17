using Fitnessclub_DAL.Data.Repositories;
using Fitnessclub_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitnessclub_DAL.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Klant> KlantRepo { get; }
        IRepository<Log> LogRepo { get; }
        IRepository<Log_Oefening> Log_OefeningRepo { get; }
        IRepository<Oefening> OefeningRepo { get; }
        IRepository<Trainer> TrainerRepo { get; }
        IRepository<Werkgever> WerkgeverRepo { get; }
        int Save();
    }
}
