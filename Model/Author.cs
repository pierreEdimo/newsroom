using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace newsroom.Model
{
    public class Author
    {
        [Key]
        public int Id { get; set;  }
        [Required]
        public String name { get; set;  }
        [Required]
        public String biography { get; set; }
        [Required]
        public String imageUrl { get; set;  }
        [JsonIgnore]
        public virtual List<Article> Articles { get; set;  }
    }
}
