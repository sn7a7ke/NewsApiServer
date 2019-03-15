using System.Collections.Generic;
using Model.Models;

namespace DAL.Interfaces
{
    public interface IRepository<T> 
                where T : EntityBase
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        T Add(T item);
        T Update(T item);
        void Delete(int id);
        void Delete(T item);
    }
}
