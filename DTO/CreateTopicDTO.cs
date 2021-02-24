using Microsoft.AspNetCore.Http;
using newsroom.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static newsroom.Validations.ContentTypeValidator;

namespace newsroom.DTO
{
    public class CreateTopicDTO
    {
        [Required]
        [StringLength(80)]
        public String Name { get; set;  }
        [Required]
        [FileSizeValidator(4)]
        [ContentTypeValidator(ContentTypeGroup.Image)]
        public IFormFile ImageUrl { get; set;  }
    }
}
