using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using newsroom.Helpers;
using Microsoft.AspNetCore.Mvc;
using newsroom.Validations;
using static newsroom.Validations.ContentTypeValidator;

namespace newsroom.DTO
{
    public class CreateArticleDTO
    {
        [Required]
        public String Title { get; set;  }
        [Required]
        public String Content { get; set;  }
        [FileSizeValidator(4)]
        [ContentTypeValidator(ContentTypeGroup.Image ) ]
        public IFormFile ImageUrl { get; set;  }
        [ModelBinder(BinderType =typeof(TypeBinder<int>))]
        public int TopicId { get; set;  }
        [ModelBinder(BinderType = typeof(TypeBinder<int>))]
        public int AuthorId { get; set;  }
     
    }
}
