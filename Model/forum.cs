using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace newsroom.Model
{
    public class Forum
    {
        [Key]
        public int Id { get; set; }
        public string uid { get; set; }
        [Required]
        public String title { get; set; }
        [JsonIgnore]
        public virtual UserEntity Author { get; set; }
        public DateTime createdAt { get; set; } = DateTime.Now;

    }
}