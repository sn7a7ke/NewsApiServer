using System.Collections.Generic;
using System.Threading.Tasks;
using Model.Models;

namespace DAL.Interfaces
{
    public interface IRepository<T> 
                where T : EntityBase
    {
        IEnumerable<T> GetAll();

        Task<IEnumerable<T>> GetAllAsync();

        T Get(int id);

        Task<T> GetAsync(int id);

        T Add(T item);

        Task<T> AddAsync(T item);

        T Update(T item);

        Task<T> UpdateAsync(T item);

        void Delete(int id);

        Task DeleteAsync(int id);

        void Delete(T item);

        Task DeleteAsync(T item);

    }
}
