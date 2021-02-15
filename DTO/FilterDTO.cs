using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newsroom.DTO
{
    public class FilterDTO
    {
        public int TopicId { get; set;  }
        public int Page { get; set;  }
        public int RecordsPerPage { get; set;  }
        public PaginationDTO Pagination
        {
            get
            {
                return new PaginationDTO()
                {
                    Page = Page,
                    RecordsPerPage = RecordsPerPage
                }; 
            }
        }

        public String Title { get; set;  }
        public String OrderingField { get; set; }
        public bool AscendingOrder { get; set; } = true; 
        public int ArticleId { get; set;  }
        public String UserId { get; set;  }
    }
}
