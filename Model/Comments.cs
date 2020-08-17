
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
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
        public virtual UserEntity author { get; set; }
        [JsonIgnore]
        public virtual List<Answer> Answers { get; set; }
        public DateTime createdAt { get; set; } = DateTime.Now;
        public virtual Article Article { get; set;}
    }
}
