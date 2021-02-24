using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using newsroom.Helpers;
using System.ComponentModel.DataAnnotations;

namespace newsroom.DTO
{
    public class CreateCommentDTO
    {
        [Required]
        [ModelBinder(BinderType = typeof(TypeBinder<String>))]
        public String AuthorId { get; set;  }
        [Required]
        public String Content { get; set;  }
        [Required]
        [ModelBinder(BinderType = typeof(TypeBinder<int>))]
        public int ArticleId { get; set;  }
    }
}
