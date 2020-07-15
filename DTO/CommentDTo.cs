using newsroom.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace newsroom.DTO
{
    public class CommentDTo
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
        public virtual UserEntity author { get; set; }
        public DateTime createdAt { get; set; } = DateTime.Now;
        public int forumId { get; set; }
        [JsonIgnore]
        public virtual Forum Forum { get; set; }
    }
}
