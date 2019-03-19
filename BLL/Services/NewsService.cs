using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;
using DAL;
using DAL.Interfaces;
using DAL.Repositories;
using Model.Models;

namespace BLL.Services
{
    public class NewsService : Service<NewsModel>, INewsService
    {
        public NewsService(IUnitOfWork unitOfWork, INewsRepository repository) : 
            base(unitOfWork, repository)
        //public NewsService(INewsRepository repository, Action save) : base(repository, save)
        {
        }

        public IEnumerable<NewsModel> FindByContext(string substring)
        {
            var res = ((INewsRepository) Repository).Find(nm=>
                nm.Body.Contains(substring) || nm.Title.Contains(substring)
                );
            //var res = Repository.GetAll().Where(
            //            n => n.Body.Contains(substring) ||
            //                 n.Title.Contains((substring)));
            return res;
        }

        public async Task<IEnumerable<NewsModel>> FindByContextAsync(string substring)
        {
            var res = await ((INewsRepository) Repository).FindAsync(nm=>
                nm.Body.Contains(substring) || nm.Title.Contains(substring)
            );
            //var res = Repository.GetAll().Where(
            //            n => n.Body.Contains(substring) ||
            //                 n.Title.Contains((substring)));
            return res;
        }
    }
}
