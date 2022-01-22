using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newsroom.DTO
{
    public class FilterArticleDTO : FilterDTO
    {
        public int TopicId { get; set; }
        public String Title { get; set; }
        public String Author { get; set; }
        public String UserId { get; set; }
    }
}
