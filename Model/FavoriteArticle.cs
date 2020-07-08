using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newsroom.Model
{
    public class FavoriteArticle { 
    
        [Key]
        public int Id { get; set;  }
        [Required]
        public string userId { get; set;  }
        [Required]
        public int articleId { get; set;  }
        [JsonIgnore]
        public virtual Article Article { get; set; }
        [JsonIgnore]
        public virtual UserEntity UserReader { get; set;  }
    }
}
