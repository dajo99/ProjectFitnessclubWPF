using Fitnessclub_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Fitnessclub_DAL.Data.Repositories
{
    public interface IRepository<T>
           where T : class, new()
    {
        IEnumerable<T> Ophalen();
        void Toevoegen(T entity);
        void Aanpassen(T entity);
        void Verwijderen(T entity);


        //uitbreiding
        IEnumerable<T> Ophalen(Expression<Func<T, bool>> voorwaarden);
        IEnumerable<T> Ophalen(string includes);
        IEnumerable<T> Ophalen(Expression<Func<T, bool>> voorwaarden,
            string includes);


        //handige functies
        T ZoekOpPK<TPrimaryKey>(TPrimaryKey id);
        void ToevoegenOfAanpassen(T entity);
        void ToevoegenRange(IEnumerable<T> entities);
        void Verwijderen<TPrimaryKey>(TPrimaryKey id);
        void VerwijderenRange(IEnumerable<T> entities);


        
            
    }
}
