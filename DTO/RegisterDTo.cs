using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newsroom.DTO
{
    public class RegisterDTo
    {

        [MaxLength(50)]
        [DisplayName("Firstname")]
        public string firstName { get; set; }
        [MaxLength(50)]
        [DisplayName("Lastname")]
        public string lastName { get; set; }
        [Required]
        [MaxLength(50)]
        [DisplayName("Username")]
        public string UserName { get; set; }
        [MaxLength(255)]
        [DisplayName("Address")]
        public string location { get; set; }
        [MaxLength(255)]
        [DisplayName("City")]
        public string city { get; set; }
        [MaxLength(255)]
        [DisplayName("Country")]
        public string country { get; set; }
        [MaxLength(255)]
        [DisplayName("Postal Box")]
        public string poBox { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string passWord { get; set; }
        [MaxLength(255)]
        [DisplayName("Telephone Number")]
        public string PhoneNumber { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

    }
}
