using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using newsroom.OnlyDate;
using Newtonsoft.Json;

namespace newsroom.Model
{
    public class Article
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(80)]
        public string Title { get; set; }
        [Required]
        public string ImageCredits { get; set;  }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public string Content { get; set; }
        [JsonConverter(typeof(OnlyDateConverter))]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        [JsonIgnore]
        public int TopicId { get; set;  }
        [JsonIgnore]
        public int AuthorId { get; set;  }
        [JsonIgnore]
        public Topic Topic { get; set;  }
        [JsonIgnore]
        public Author Author { get; set;  }
        [JsonIgnore]
        public List<Comment> Comments { get; set;  }
        public int CommentCount { get; set;  }
        [JsonIgnore]
        public List<FavoritesArticles> HasFavorites { get; set;  }
        public bool IsFavorite { get; set; } = false; 

    }
}