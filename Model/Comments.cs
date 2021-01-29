
using newsroom.OnlyDate;
using System;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;


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
        [JsonConverter(typeof(OnlyDateConverter))]
        public DateTime createdAt { get; set; } = DateTime.Now;
        public virtual Article Article { get; set;}
    }
}
