using System;
using findaDoctor.Model;
using System.Text.Json.Serialization;

namespace findaDoctor.DTO
{
    public class ArticleDTo
    {
        public int id { get; set; }
        public string title { get; set; }
        public string imageUrl { get; set; }
        public string content { get; set; }
        public DateTime createdAt { get; set; } = DateTime.Now;
        [JsonIgnore]
        public int authorId { get; set; }
        public virtual Author Author { get; set; }
        public int themeId { get; set; }
        [JsonIgnore]
        public virtual Theme Theme { get; set; }

    }
}