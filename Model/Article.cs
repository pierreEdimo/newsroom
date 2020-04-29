using System;
using System.Text.Json.Serialization;

namespace findaDoctor.Model
{
    public class Article
    {
        public int Id { get; set; }
        public string title { get; set; }
        public string imageUrl { get; set; }
        public string content { get; set; }
        public DateTime createdAt { get; set; } = DateTime.Now;
        [JsonIgnore]
        public int themeId { get; set; }
        [JsonIgnore]
        public virtual Theme Theme { get; set; }
        [JsonIgnore]
        public int authorId { get; set; }
        [JsonIgnore]
        public virtual Author Author { get; set; }


    }
}