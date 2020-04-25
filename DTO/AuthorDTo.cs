using System;
using System.Collections.Generic;
using findaDoctor.Model;

namespace findaDoctor.DTO
{
    public class AuthorDTo
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string biography { get; set; }
        public string imageUrl { get; set; }
        public DateTime createdAt { get; set; } = DateTime.Now;
        public virtual List<Article> Articles { get; set; }
    }
}