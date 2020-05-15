using findaDoctor.Model;
using System.Text.Json.Serialization;

namespace findaDoctor.DTO
{
    public class FavoriteDoctorDTo
    {
        
        public int Id { get; set; }
        public string userId { get; set; }
        public int doctorId { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual UserEntity UserPatient { get; set; }

    }
}
