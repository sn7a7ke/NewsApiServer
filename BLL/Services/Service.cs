using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;
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
        protected readonly IRepository<TEntity> Repository;
        protected readonly Action Save;


        protected Service(IUnitOfWork unitOfWork)
        {
            Repository = (IRepository<TEntity>)unitOfWork.News;
            Save = unitOfWork.Save;
        }

        // if (save == null) doesn't save into repository
        protected Service(IRepository<TEntity> repository, Action save)
        {
            Repository = repository;
            Save = save;
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            var ret = Repository.GetAll();
            return ret;
        }

        public virtual TEntity Get(int id)
        {
            var ret = Repository.Get(id);
            return ret;
        }

        public virtual TEntity Add(TEntity item)
        {
            var ret = Repository.Add(item);
            Save?.Invoke();
            return ret;
        }

        public virtual TEntity Update(TEntity item)
        {
            var ret = Repository.Update(item);
            Save?.Invoke();
            return ret;
        }

        public virtual void Delete(int id)
        {
            Repository.Delete(id);
            Save?.Invoke();
        }

        public virtual void Delete(TEntity item)
        {
            Repository.Delete(item);
            Save?.Invoke();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
