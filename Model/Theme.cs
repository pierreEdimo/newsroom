using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace newsroom.Model
{
    public class Theme
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        [DisplayName("Name")]
        public string name { get; set; }
        [Required]
        public string imageUrl { get; set; }
        public virtual List<Article> Articles { get; set; }
    }
}