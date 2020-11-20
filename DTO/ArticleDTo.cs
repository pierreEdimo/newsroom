 using System;
using newsroom.Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using newsroom.OnlyDate;

namespace newsroom.DTO
{
    public class ArticleDTo
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string title { get; set; }
        [Required]
        public string imageUrl { get; set; }
        [Required]
        public string content { get; set; }
        [JsonConverter(typeof(OnlyDateConverter))]
        public DateTime createdAt { get; set; } = DateTime.Now;
        [JsonIgnore]
        [Required]
        public int themeId { get; set; }
        public virtual Theme Theme { get; set; }
        [Required]
        public int authorId { get; set; }
        public virtual Author Author { get; set; }
        public virtual List<Comments> Comments { get; set; }
        public int numberOfComments { get; set; }
    }
}