using DAL.Context;
using Model.Models;
using System.Collections.Generic;
//using System.Data.Entity;
using DAL.Interfaces;
using System;

//using NewsServer.Models;
//using NewsContext = NewsServer.Models.NewsContext;

namespace DAL.Repositories
{
    public class TopicsRepository : Repository<TopicModel>, ITopicRepository
    {
        protected NewsContext Db;

        public TopicsRepository(NewsContext context) : base(context)
        {
            Db = context ?? throw new NullReferenceException();
        }

        public override void MapThem(TopicModel source, TopicModel change)
        {
            source.Name = change.Name;
        }
    }
}