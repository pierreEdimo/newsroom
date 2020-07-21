using newsroom.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace newsroom.DTO
{
    public class AuthorDTo
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public String name { get; set; }
        [Required]
        public String biography { get; set; }
        [Required]
        public String imageUrl { get; set; }
        public virtual List<Article> Articles { get; set; }
    }
}
