using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newsroom.Model
{
    public class Comment
    {
        public int Id { get; set;  }
        [JsonIgnore]
        public String AuthorId { get; set;  }
        public UserEntity Author { get; set;  }
        public String Content { get; set;  }
        [JsonIgnore]
        public int ArticleId { get; set;  }
        [JsonIgnore]
        public Article Article { get; set;  }
        public DateTime CreatedAt { get; set; } = DateTime.Now; 
    }
}
