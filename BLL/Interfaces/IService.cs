using Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface IService<T> : IDisposable
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
