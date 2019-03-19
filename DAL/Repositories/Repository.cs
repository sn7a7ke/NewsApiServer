using DAL.Exceptions;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Model.Models;
using System;
using System.Collections.Generic;
//using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity>
                where TEntity : EntityBase
    {
        protected DbContext Context;
        protected DbSet<TEntity> DbSet;

        protected Repository(DbContext context)
        {
            Context = context;
            DbSet = Context.Set<TEntity>(); // C or c?
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            var result = DbSet.ToList();
            return result;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            var result = await DbSet.ToListAsync(); // .ToList();
            return result;
        }

        public virtual TEntity Get(int id)
        {
            var entry = DbSet.FirstOrDefault(e => e.Id == id);
            if (entry == null)
                throw new EntityNotFoundException();
            return entry;
        }

        public virtual async Task<TEntity> GetAsync(int id)
        {
            var entry = await DbSet.FirstOrDefaultAsync(e => e.Id == id);
            if (entry == null)
                throw new EntityNotFoundException();
            return entry;
        }

        public virtual TEntity Add(TEntity entity)
        {
            var result = DbSet.Add(entity);
            return result.Entity;
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            var result = await DbSet.AddAsync(entity);
            return result.Entity;
        }

        public virtual TEntity Update(TEntity entity)
        {
            var dbEntry = DbSet.FirstOrDefault(e => e.Id == entity.Id);
            if (dbEntry == null)
                throw new EntityNotFoundException();
            MapThem(dbEntry, entity);
            return dbEntry;
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            var dbEntry = await DbSet.FirstOrDefaultAsync(e => e.Id == entity.Id);
            if (dbEntry == null)
                throw new EntityNotFoundException();
            MapThem(dbEntry, entity);
            return dbEntry;
        }

        public virtual void Delete(int id)
        {
            var entry = DbSet.FirstOrDefault(e => e.Id == id);
            if (entry == null)
                throw new EntityNotFoundException();
            DbSet.Remove(entry);
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entry = await DbSet.FirstOrDefaultAsync(e => e.Id == id);
            if (entry == null)
                throw new EntityNotFoundException();
            DbSet.Remove(entry);
        }

        public abstract void MapThem(TEntity source, TEntity change);

        public virtual void Delete(TEntity entity) // Delete(entity.id); ???
        {
            DbSet.Attach(entity);
            Context.Entry(entity).State = EntityState.Deleted;
        }

        public virtual async Task DeleteAsync(TEntity entity)
        {
            await Task.Run(() => Delete(entity));
        }
    }
}
