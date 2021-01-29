using newsroom.Model;
using newsroom.OnlyDate;
using System;

using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json; 



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
        [JsonConverter(typeof(OnlyDateConverter))]
        public DateTime createdAt { get; set; } = DateTime.Now;
        public int numberOfAnswers { get; set;  }

    }
}
