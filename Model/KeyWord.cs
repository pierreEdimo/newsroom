using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace newsroom.Model
{
    public class KeyWord
    {
       [Key]
        public int Id { get; set;  }
        [Required]
        public String UserId { get; set;  }
        [Required]
        public String Word { get; set;  }
    }
}
