using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json; 

namespace newsroom.Model
{
    public class Topic
    {
        public int Id { get; set;  }
        public String Name { get; set;  }
        public String ImageUrl { get; set;  }
        [JsonIgnore]
        public List<Article> Articles { get; set;  }
    }
}
