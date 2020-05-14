using System;
using System.Collections.Generic;
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
        public int themeId { get; set; }
        [JsonIgnore]
        public virtual Theme Theme { get; set; }
        public string author { get; set; }
        public string biography { get; set; }
        public string authorImg { get; set; }
        [JsonIgnore]
        public virtual List<FavoriteArticle> FavoriteArticleRef { get; set; }

    }
}