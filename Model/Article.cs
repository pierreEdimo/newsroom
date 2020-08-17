using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


using Newtonsoft.Json;

namespace newsroom.Model
{
    public class Article
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string title { get; set; }
        [Required]

        public string imageUrl { get; set; }
        [Required]
        public string content { get; set; }
        public DateTime createdAt { get; set; } = DateTime.Now;
        [Required]
        public int themeId { get; set; }
        [JsonIgnore]
        public virtual Theme Theme { get; set; }
        public int authorId { get; set; }
        public virtual Author Author { get; set; }
        public virtual List<Comments> Comments { get; set; }
        public int numberOfComments { get; set; }


    }
}