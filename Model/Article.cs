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
        [DisplayName("Title")]
        public string title { get; set; }
        [Required]
        [DisplayName("Image Url")]
        public string imageUrl { get; set; }
        [Required]
        [MaxLength(8000)]
        [DisplayName("Body")]
        public string content { get; set; }
        [Required]
        [DataType(DataType.Duration)]
        [DisplayName("Created At")]
        public DateTime createdAt { get; set; } = DateTime.Now;
        [Required]
        public int themeId { get; set; }
        [JsonIgnore]
        public virtual Theme Theme { get; set; }
        [Required]
        [MaxLength(50)]
        [DisplayName("Author")]
        public string author { get; set; }
        [Required]
        [MaxLength(255)]
        [DisplayName("Biography")]
        public string biography { get; set; }
        [Required]
        [DisplayName("Avatar")]
        public string authorImg { get; set; }
        [JsonIgnore]
        public virtual List<Comments> Comments { get; set;  }

    }
}