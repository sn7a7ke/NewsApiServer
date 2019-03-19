using System;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Model.Models
{
    //[Serializable]
    //[DataContract]
    public class NewsModel : EntityBase
    {

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("createTime")]
        public string CreateTime { get; set; }

        [JsonProperty("topicId")]
        public int TopicId { get; set; }
        [JsonProperty("topic")]
        [ForeignKey("TopicId")]
        public virtual TopicModel Topic { get; set; }
    }
    public class GetNewsModelView
    {
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("createTime")]
        public string CreateTime { get; set; }
    }

    public class PutNewsModelView
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }
    }
    public class PostNewsModelView
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("createTime")]
        public string CreateTime { get; set; }

    }
}