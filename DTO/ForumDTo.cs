using System.ComponentModel.DataAnnotations;
using System;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using newsroom.Model;

namespace newsroom.DTO
{
    public class ForumDTo
    {
        [Key]
        public int Id { get; set; }
        public string uid { get; set; }
        [Required]
        public String title { get; set; }
        public virtual UserEntity Author { get; set; }
        public DateTime createdAt { get; set; } = DateTime.Now;

    }
}