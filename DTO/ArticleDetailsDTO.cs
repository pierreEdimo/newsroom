using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using newsroom.Model;
using Newtonsoft.Json;

namespace newsroom.DTO
{
    public class ArticleDetailsDTO : ArticleDTO
    {
        public List<Comment> Comments { get; set; }
        public int CommentCount { get; set;  }
       
           
    }
}
