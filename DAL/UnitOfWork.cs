using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Context;
using DAL.Interfaces;
using DAL.Repositories;
using Model.Models;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private NewsContext _db; // = new NewsContext();
        private NewsRepository _newsRepository;
        private TopicsRepository _topicsRepository;

        public UnitOfWork(NewsContext context) => _db = context;

        public NewsRepository News => _newsRepository ?? (_newsRepository = new NewsRepository(_db));

        public TopicsRepository Topics => _topicsRepository ?? (_topicsRepository = new TopicsRepository(_db));

        public void Save() => _db.SaveChanges();

        public async Task SaveAsync() => await _db.SaveChangesAsync();

        private bool disposed = false;
        
        public virtual void Dispose(bool disposing)
        {
            if (this.disposed) return;
            if (disposing)
                _db.Dispose();
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}