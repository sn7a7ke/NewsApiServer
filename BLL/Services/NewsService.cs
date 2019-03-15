using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Repositories;
using Model.Models;

namespace BLL.Services
{
    public class NewsService : Service<NewsModel>, INewsService
    {
        public NewsService(INewsRepository repository, Action save) : base(repository, save)
        {
        }

        public IEnumerable<NewsModel> FindByContext(string substring)
        {
            var ret = Repository.GetAll().Where(
                        n => n.Body.Contains(substring) ||
                             n.Title.Contains((substring)));
            return ret;
        }
    }
}
