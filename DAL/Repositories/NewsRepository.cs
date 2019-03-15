using DAL.Interfaces;
using Model.Models;
using System;
using System.Collections.Generic;
//using System.Data.Entity;
using DAL.Context;
using System.Linq;

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
            return Db.NewsModels.Where(predicate).ToList();
        }

    }
}