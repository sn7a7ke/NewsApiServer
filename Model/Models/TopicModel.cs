using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Model.Models
{
    //[DataContract]
    public class TopicModel : EntityBase
    {
        public TopicModel()
        {
            News = new List<NewsModel>();
        }

        //public TopicModel()
        //{
        //    News = new List<NewsModel>();
        //}

        //[DataMember]
        public string Name { get; set; }

        //[DataMember]
        public virtual ICollection<NewsModel> News { get; set; } = new List<NewsModel>();
    }
}