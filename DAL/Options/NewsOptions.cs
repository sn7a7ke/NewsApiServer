using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Models;

namespace DAL.Options
{
    public class NewsOptions : IEntityTypeConfiguration<NewsModel>
    {
        public void Configure(EntityTypeBuilder<NewsModel> builder)
        {
            builder.HasOne(p => p.Topic).WithMany(q => q.News).HasForeignKey(x => x.TopicId);
        }
    }
}
