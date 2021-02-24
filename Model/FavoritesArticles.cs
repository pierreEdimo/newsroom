using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace newsroom.Model
{
    public class FavoritesArticles
    {
        [Required]
        public int ArticleId { get; set;  }
        public Article Article { get; set;  }
        [Required]
        public String OwnerId { get; set;  }
        public UserEntity User { get; set;  }
    }
}
