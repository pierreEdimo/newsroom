using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newsroom.DTO
{
    public class FilterArticleDTO
    {
        public int TopicId { get; set; }

        public String Title { get; set; }
        public String Author { get; set;  }
    }
}
