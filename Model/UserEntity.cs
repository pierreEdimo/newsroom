using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace newsroom.Model
{
    public class UserEntity : IdentityUser
    {

        [MaxLength(50)]
        [DisplayName("Firstname")]
        public string firstName { get; set; }
        [MaxLength(50)]
        [DisplayName("Lastname")]
        public string lastName { get; set; }
        [MaxLength(255)]
        [DisplayName("Current Living address")]
        public string location { get; set; }
        [MaxLength(255)]
        [DisplayName("Current City")]
        public string city { get; set; }
        [MaxLength(255)]
        [DisplayName("Current living Country")]
        public string country { get; set; }
        [MaxLength(50)]
        [DisplayName("Postal Box")]
        public string poBox { get; set; }
        [JsonIgnore]
        public virtual Comments Comments { get; set; }


    }
}
