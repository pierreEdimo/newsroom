using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace newsroom.Model
{
    public class PodCast
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public Author Author { get; set; }
        public int AuthorId { get; set; }
        public List<Episode> Episodes { get; set; }
    }
}