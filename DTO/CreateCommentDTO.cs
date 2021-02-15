using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using newsroom.Helpers; 

namespace newsroom.DTO
{
    public class CreateCommentDTO
    {
        [ModelBinder(BinderType = typeof(TypeBinder<String>))]
        public String AuthorId { get; set;  }
        public String Content { get; set;  }
        [ModelBinder(BinderType = typeof(TypeBinder<int>))]
        public int ArticleId { get; set;  }
    }
}
