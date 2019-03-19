using DAL.Interfaces;
using Model.Models;
using System;
using System.Collections.Generic;
//using System.Data.Entity;
using DAL.Context;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DAL.Exceptions;

namespace DAL.Repositories
{
    public class NewsRepository : Repository<NewsModel>, INewsRepository
    {
        protected NewsContext Db;

        public NewsRepository(NewsContext context) : base(context)
        {
            Db = context ?? throw new NullReferenceException();
        }

        public override void MapThem(NewsModel source, NewsModel change)
        {
            source.Title = change.Title;
            source.Body = change.Body;
            //change.Title = source.Title;
            //change.Body = source.Body;
        }

        public IEnumerable<NewsModel> Find(Func<NewsModel, bool> predicate)
        {
            var res = Db.NewsModels.Where(predicate).ToList();
            return res;
        }

        public async Task<IEnumerable<NewsModel>> FindAsync(Func<NewsModel, bool> predicate)
        {
            //=============== ??????????????? ============
            var res = await Task.Run(() => Find(predicate));
            //var res = await Task.Run(() => Db.NewsModels.Where(predicate).ToList());
            return res;
        }

        public override async Task<NewsModel> GetAsync(int id)
        {
            var entry = await DbSet.Include(n => n.Topic).FirstOrDefaultAsync(e => e.Id == id);
            if (entry == null)
                throw new EntityNotFoundException();
            return entry;
        }
    }
}