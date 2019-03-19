using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace NewsApiServer.Provider
{
    public static class RepositoryProvider
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<INewsRepository, NewsRepository>();
            services.AddScoped<ITopicRepository, TopicsRepository>();
        }
    }
}
