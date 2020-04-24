using System;
using System.Collections.Generic;

namespace findaDoctor.Model
{
    public class User
    {
        public int Id { get; set; }
        public string email { get; set; }
        public virtual List<Article> Favourites { get; set; }
    }
}