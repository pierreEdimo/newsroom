using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using newsroom.Model;

namespace newsroom.DTO
{
    public class RegisterDTo
    {



        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string passWord { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public string profession { get; set; }

    }
}
