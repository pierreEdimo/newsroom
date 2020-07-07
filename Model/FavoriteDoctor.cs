using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace findaDoctor.Model
{
    public class FavoriteDoctor
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string userId { get; set; }
        [Required]
        public int doctorId { get; set; }
        public virtual Doctor Doctor { get; set; }
        [JsonIgnore]
        public virtual UserEntity UserPatient { get; set; }
    }
}
