using newsroom.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newsroom.DTO
{
    public class FavoriteDTo
    {
        public String userId { get; set;  }
        public UserEntity User { get; set;  }
        public Article Article { get; set;  }
        public int articleId { get; set;  }
    }
}
