using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Models;

namespace DAL.Options
{
    public class TopicOptions : IEntityTypeConfiguration<TopicModel>
    {
        public void Configure(EntityTypeBuilder<TopicModel> builder)
        {
            builder.HasMany(p => p.News).WithOne(p => p.Topic);//.HasForeignKey<NewsModel>(p => p.);
        }
    }
}
