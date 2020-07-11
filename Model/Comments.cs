using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace newsroom.Model
{
    public class Comments
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public String uid { get; set; }
        [Required]
        public int articleId { get; set; }
        [Required]
        public String content { get; set; }
        [JsonIgnore]
        public virtual Article article { get; set; }
        [JsonIgnore]
        public virtual UserEntity author { get; set; }
    }
}
