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
        public DateTime createdAt { get; set; } = DateTime.Now;
        public int themeId { get; set; }
        [JsonIgnore]
        public virtual Theme Theme { get; set; }
        [JsonIgnore]
        public int authorId { get; set; }
        [JsonIgnore]
        public virtual Author Author { get; set; }


    }
}