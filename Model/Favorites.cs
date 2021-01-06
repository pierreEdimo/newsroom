using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newsroom.Model
{
    public class Favorites
    {
        public String userId { get; set; }

        public virtual UserEntity User { get; set; }

        public int articleId { get; set; }

        public virtual Article Article {get; set; }
    }
}
