using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace newsroom.DTO
{
    public class CreateAuthorDTO
    {
        [Required]
        public String Name { get; set;  }
    }
}
