using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace newsroom.Model
{
    public class FavoritesArticles
    {
        [Required]
        public int ArticleId { get; set;  }
        [JsonIgnore]
        public Article Article { get; set;  }
        [Required]
        public String OwnerId { get; set;  }
        [JsonIgnore]
        public UserEntity User { get; set;  }
    }
}
