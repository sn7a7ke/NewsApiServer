using System;
using Newtonsoft.Json;

namespace Model.Models
{
    //[Serializable]
    //[DataContract]
    public class NewsModel : EntityBase
    {

        //[DataMember]
        [JsonProperty("title")]
        public string Title { get; set; }

        //[DataMember]
        [JsonProperty("body")]
        public string Body { get; set; }

        //[DataMember]
        [JsonProperty("createTime")]
        public string CreateTime { get; set; }

        //[DataMember]
        public virtual  TopicModel Topic { get; set; }
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