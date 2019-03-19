using DAL.Repositories;
using System;
using System.Threading.Tasks;

namespace DAL
{
    public interface IUnitOfWork : IDisposable
    {
        NewsRepository News { get; }
        TopicsRepository Topics { get; }
        void Save();
        Task SaveAsync();
    }
}