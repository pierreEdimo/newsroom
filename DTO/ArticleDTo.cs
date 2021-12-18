using System;
using newsroom.Model;
using Newtonsoft.Json;
using newsroom.OnlyDate;
using System.Collections.Generic;

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
        public AuthorDTO Author { get; set;  }
        public Topic Topic { get; set;  }
         public int CommentCount { get; set;  }
        public List<CommentDTO> Comments { get; set; }
        public List<FavoritesArticles> HasFavorites { get; set;  }
        public string ImageCredits { get; set; }
        public bool IsFavorite { get; set; } = false; 
  
    }
}