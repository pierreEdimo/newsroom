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
        [StringLength(80)]
        public String Title { get; set;  }
        [Required]
        public String Content { get; set;  }
        [Required]
        [FileSizeValidator(4)]
        [ContentTypeValidator(ContentTypeGroup.Image ) ]
        public IFormFile ImageUrl { get; set;  }
        [Required]
        [ModelBinder(BinderType =typeof(TypeBinder<int>))]
        public int TopicId { get; set;  }
        [Required]
        [ModelBinder(BinderType = typeof(TypeBinder<int>))]
        public int AuthorId { get; set;  }
        [Required]
        public string ImageCredits { get; set; }

    }
}
