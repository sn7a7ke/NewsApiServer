using DAL.Options;
using Microsoft.EntityFrameworkCore;
using Model.Models;
//using System.Data.Entity;

namespace DAL.Context
{
    public class NewsContext : DbContext
    {
        public NewsContext(DbContextOptions<NewsContext> options)
            : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public DbSet<NewsModel> NewsModels { get; set; }
        public DbSet<TopicModel> TopicModels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new NewsOptions());

            var tSport = new TopicModel() { Id = 1, Name = "Sport" };
            var tBusiness = new TopicModel() { Id = 2, Name = "Business" };
            var tTech = new TopicModel() { Id = 3, Name = "Tech" };

            var news1 = new NewsModel()
            {
                Id = 1,
                Title = "Dynamo vs Shakhtar",
                Body = "Who is winner in this duel?",
                CreateTime = "12.03.2019",
                //Topic = tSport
                TopicId = 1
            };
            var news2 = new NewsModel()
            {
                Id = 2,
                Title = "Europa League knockout records and statistics",
                Body = "Discover the top-scoring teams and players, record wins, biggest comebacks and plenty more",
                CreateTime = "13.03.2019",
                //Topic = tSport
                TopicId = 1
            };
            var news3 = new NewsModel()
            {
                Id = 3,
                Title = "Brace for turbulence",
                Body = "Boeing shares were poised to open lower Monday after a weekend of negative headlines about its 737 Max",
                CreateTime = "13.03.2019",
                //Topic = tBusiness
                TopicId = 2
            };

            var news4 = new NewsModel()
            {
                Id = 4,
                Title = "German super-bank?",
                Body = "Shares in Deutsche Bank (DB) and Commerzbank (CRZBF) shot higher Monday after the companies confirmed they are discussing a merger",
                CreateTime = "14.03.2019",
                //Topic = tBusiness
                TopicId = 2
            };
            var news5 = new NewsModel()
            {
                Id = 5,
                Title = "Tesla Model Y",
                Body =
                        "Elon Musk unveiled Tesla's mid-size electric SUV, the Model Y, Thursday night in Hawthorne, Calif",
                CreateTime = "14.03.2019",
                //Topic = tTech
                TopicId = 3
            };
            //tSport.News = new[] { news1, news2 };
            //tBusiness.News = new[] { news3, news4 };
            //tTech.News = new[] { news5 };

            modelBuilder.Entity<TopicModel>().HasData(tSport, tBusiness, tTech);

            modelBuilder.Entity<NewsModel>().HasData(news1, news2, news3, news4, news5);

            base.OnModelCreating(modelBuilder);
        }
    }
}