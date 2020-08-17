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
        public String content { get; set; }
        public int forumId { get; set; }
        public int articleId { get; set; }
        public virtual UserEntity author { get; set; }
        public virtual List<Answer> Answers { get; set; }
        public DateTime createdAt { get; set; } = DateTime.Now;

    }
}
