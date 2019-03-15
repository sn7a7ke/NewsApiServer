using DAL.Exceptions;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Model.Models;
using System;
using System.Collections.Generic;
//using System.Data.Entity;
using System.Linq;
using System.Text;

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

        public IEnumerable<TEntity> GetAll()
        {
            var result = DbSet; // .ToList();
            return result;
        }

        public TEntity Get(int id)
        {
            var entry = DbSet.FirstOrDefault(e => e.Id == id);
            if (entry == null)
                throw new RecordNotFoundException();
            return entry;
        }

        public TEntity Add(TEntity entity)
        {
            //DbSet.Add(entity);
            //var result = DbSet.FirstOrDefault(e => e.Id == entity.Id);
            //return result;
            
            
            // === NULL??? ===

            var result = DbSet.Add(entity);
            return result.Entity;
        }

        public TEntity Update(TEntity entity)
        {
            var dbEntry = DbSet.FirstOrDefault(e => e.Id == entity.Id);
            if (dbEntry == null)
                throw new RecordNotFoundException();

            MapThem(dbEntry, entity);

            return dbEntry;

            // db.Entry(oneNews).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var entry = DbSet.FirstOrDefault(e => e.Id == id);
            if (entry == null)
                throw new RecordNotFoundException();
            DbSet.Remove(entry);
        }

        public abstract void MapThem(TEntity source, TEntity change);

        public void Delete(TEntity entity) // Delete(entity.id); ???
        {
            DbSet.Attach(entity);
            Context.Entry(entity).State = EntityState.Deleted;
        }
    }
}
