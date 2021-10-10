using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace newsroom.Model
{
    public class Comment
    {
        [Key]
        public int Id { get; set;  }
        [Required]
        [JsonIgnore]
        public String AuthorId { get; set;  }
        public UserEntity Author { get; set;  }
        [Required]
        public String Content { get; set;  }
        [Required]
        [JsonIgnore]
        public int ArticleId { get; set;  }
        [JsonIgnore]
        public Article Article { get; set;  }
        public DateTime CreatedAt { get; set; } = DateTime.Now; 
        [JsonIgnore]
        public virtual List<Report> Reports {get; set; }
    }
}
