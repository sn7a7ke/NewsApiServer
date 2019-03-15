using Microsoft.EntityFrameworkCore;
using Model.Models;
//using System.Data.Entity;

namespace DAL.Context
{
    public class NewsContext : DbContext
    {
        //public NewsContext()
        //    : base("DefaultConnection")
        public NewsContext(DbContextOptions<NewsContext> options)
            : base(options)
        {
        }

        public DbSet<NewsModel> NewsModels { get; set; }
        public DbSet<TopicModel> TopicModels { get; set; }
    }
}