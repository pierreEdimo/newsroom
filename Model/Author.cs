using System;
using System.Collections.Generic;

namespace findaDoctor.Model
{
    public class Author
    {
        public int Id { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public string biography { get; set; }
        public string imageUrl { get; set; }
        public DateTime createdAt { get; set; } = DateTime.Now;
        public virtual List<Article> Articles { get; set; }
    }
}