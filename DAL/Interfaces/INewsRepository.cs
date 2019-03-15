using System;
using System.Collections.Generic;
using System.Text;
using Model.Models;

namespace DAL.Interfaces
{
    public interface INewsRepository : IRepository<NewsModel>
    {
        IEnumerable<NewsModel> Find(Func<NewsModel, Boolean> predicate);
    }
}
