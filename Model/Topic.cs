using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json; 

namespace newsroom.Model
{
    public class Topic
    {
        [Key]
        public int Id { get; set;  }
        [Required]
        public String Name { get; set;  }
        [Required]
        public String ImageUrl { get; set;  }
        [JsonIgnore]
        public List<Article> Articles { get; set;  }
    }
}
