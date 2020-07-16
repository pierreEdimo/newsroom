using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace newsroom.Model
{
    public class Answer
    {
        [Key]
        public int Id { get; set;  }
        public int commentId { get; set;  }
        public String uid { get; set; }
        [JsonIgnore]
        public virtual Comments Comments { get; set;  }
        [JsonIgnore]
        public virtual UserEntity Author { get; set; }
        public String content { get; set; }
    }
}
