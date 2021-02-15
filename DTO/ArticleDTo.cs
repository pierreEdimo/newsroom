 using System;
using newsroom.Model;
using Newtonsoft.Json;
using newsroom.OnlyDate;

namespace newsroom.DTO
{
    public class ArticleDTO
    {
       
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Content { get; set; }
        [JsonConverter(typeof(OnlyDateConverter))]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public Author Author { get; set;  }
        public Topic Topic { get; set;  }

  
    }
}