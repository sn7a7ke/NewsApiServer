using DAL.Repositories;
using System;

namespace DAL
{
    public interface IUnitOfWork : IDisposable
    {
        NewsRepository News { get; }
        TopicsRepository Topics { get; }
        void Save();
    }
}