using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using newsroom.Model; 
 

namespace newsroom.DTO
{
    public class FavoriteDTO
    {
        public String OwnerId { get; set; }
        public int ArticleId { get; set;  }
        public Article Article { get; set;  }
    }
}
