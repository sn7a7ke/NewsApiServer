using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;
using DAL;
using DAL.Interfaces;
using DAL.Repositories;
using Model.Models;

namespace BLL.Services
{
    public abstract class Service<TEntity> : IService<TEntity>
        where TEntity : EntityBase
    {
        protected IRepository<TEntity> Repository;
        protected IUnitOfWork UofW;
        //protected readonly Action Save;


        //protected Service(IUnitOfWork unitOfWork)
        //{
        //    Repository = (IRepository<TEntity>)unitOfWork.News;
        //    Save = unitOfWork.Save;
        //}

        // if (save == null) doesn't save into repository
        protected Service(IUnitOfWork uofW, IRepository<TEntity> repository) // , Action save
        {
            UofW = uofW;
            Repository = repository;
            //Save = save;
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            var res = Repository.GetAll();
            return res;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            var res = await Repository.GetAllAsync();
            return res;
        }

        public virtual TEntity Get(int id)
        {
            var res = Repository.Get(id);
            return res;
        }

        public virtual async Task<TEntity> GetAsync(int id)
        {
            var res = await Repository.GetAsync(id);
            return res;
        }

        public virtual TEntity Add(TEntity item)
        {
            var res = Repository.Add(item);
            UofW.Save();
            return res;
        }

        public virtual async Task<TEntity> AddAsync(TEntity item)
        {
            var res = await Repository.AddAsync(item);
            await UofW.SaveAsync();
            return res;
        }

        public virtual TEntity Update(TEntity item)
        {
            var res = Repository.Update(item);
            UofW.Save();
            return res;
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity item)
        {
            var res = await Repository.UpdateAsync(item);
            await UofW.SaveAsync();
            return res;
        }

        public virtual void Delete(int id)
        {
            Repository.Delete(id);
            UofW.Save();
        }

        public virtual async Task DeleteAsync(int id)
        {
            await Repository.DeleteAsync(id);
            await UofW.SaveAsync();
        }

        public virtual void Delete(TEntity item)
        {
            Repository.Delete(item);
            UofW.Save();
        }
        
        public virtual async Task DeleteAsync(TEntity item)
        {
            await Repository.DeleteAsync(item);
            await UofW.SaveAsync();
        }

        public void Dispose()
        {
            Repository = null;
            UofW.Dispose();
        }
    }
}
