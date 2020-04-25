using System;
using System.Collections.Generic;
using findaDoctor.Model;

namespace findaDoctor.DTO
{
    public class ThemeDTo
    {

        public int Id { get; set; }
        public string name { get; set; }
        public string imageUrl { get; set; }
        public virtual List<Article> Articles { get; set; }
    }
}