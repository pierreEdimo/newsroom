using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newsroom.Model
{
    public class Favorite { 
    
       
        [Required]
        public string userId { get; set;  }
        [Key, ForeignKey("Article") ]
        public int articleId { get; set;  }
        [JsonIgnore]
        public virtual Article Article { get; set; }
        
    }
}
