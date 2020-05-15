using findaDoctor.Model;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace findaDoctor.DTO
{
    public class FavoriteDoctorDTo
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string userId { get; set; }
        [Required]
        public int doctorId { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual UserEntity UserPatient { get; set; }

    }
}
