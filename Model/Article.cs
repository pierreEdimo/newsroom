using System;
using System.Text.Json.Serialization;

namespace findaDoctor.Model
{
    public class Article
    {
        public int id { get; set; }
        public string title { get; set; }
        public string imageUrl { get; set; }
        public string content { get; set; }
        public int autorId { get; set; }
        [JsonIgnore]
        public virtual Doctor Doctor { get; set; }
        public DateTime createdAt { get; set; } = DateTime.Now;
    }
}