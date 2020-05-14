using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace findaDoctor.Model
{
    public class FavoriteArticle
    {
        public int Id { get; set;  }
        public string userId { get; set;  }
        public int articleId { get; set;  }
        [JsonIgnore]
        public virtual Article Article { get; set; }
        [JsonIgnore]
        public virtual UserEntity UserEntity { get; set;  }
    }
}
