using BLL.Interfaces;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using DAL.Repositories;
using DAL;
using DAL.Interfaces;

namespace BLL.Services
{
    public class TopicService : Service<TopicModel>, ITopicService
    {
        public TopicService(IUnitOfWork unitOfWork, ITopicRepository repository) : 
            base(unitOfWork, repository)
        {
        }
    }
}
