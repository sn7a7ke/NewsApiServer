using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Model.Models;

namespace BLL.Interfaces
{
    public interface INewsService : IService<NewsModel>
    {
        IEnumerable<NewsModel> FindByContext(string substring);

        Task<IEnumerable<NewsModel>> FindByContextAsync(string substring);
    }
}
