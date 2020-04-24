using System;
using System.Collections.Generic;

namespace findaDoctor.Model
{
    public class Theme
    {
        public int Id { get; set; }
        public string name { get; set; }
        public virtual List<Article> Articles { get; set; }
    }
}