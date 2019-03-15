using BLL.Interfaces;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using DAL.Repositories;

namespace BLL.Services
{
    public class TopicService : Service<TopicModel>, ITopicService
    {
        public TopicService(Repository<TopicModel> repository, Action save) : base(repository, save)
        {
        }
    }
}
