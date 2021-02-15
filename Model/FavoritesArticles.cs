using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newsroom.Model
{
    public class FavoritesArticles
    {
        public int ArticleId { get; set;  }
        public Article Article { get; set;  }
        public String OwnerId { get; set;  }
        public UserEntity User { get; set;  }
    }
}
