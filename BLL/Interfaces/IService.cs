using Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IService<T> : IDisposable
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

        //IEnumerable<T> GetAll();
        //T Get(int id);
        //T Add(T item);
        //T Update(T item);
        //void Delete(int id);
        //void Delete(T item);
    }
}
