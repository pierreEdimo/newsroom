using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using findaDoctor.Model;


namespace findaDoctor.DTO
{
    public class DoctorsDTo
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        [DisplayName("Name")]
        public string name { get; set; }
        [Required]
        [MaxLength(255)]
        [DisplayName("Specialisation")]
        public string specialisation { get; set; }
        [Required]
        [MaxLength(8000)]
        [DisplayName("Biography")]
        public string description { get; set; }
        [Required]
        [MaxLength(255)]
        [DisplayName("Current Address")]
        public string location { get; set; }
        [Required]
        [MaxLength(255)]
        [DisplayName("Current City")]
        public string city { get; set; }
        [Required]
        [MaxLength(50)]
        [DisplayName("Postal Box")]
        public string poBox { get; set; }
        [Required]
        [MaxLength(255)]
        [DisplayName("Keyword")]
        public string searchWord { get; set; }
        [Required]
        [MaxLength(255)]
        [DisplayName("Current Country")]
        public string country { get; set; }
        [Required]
        [MaxLength(255)]
        [DisplayName("E-mail Address")]
        public string email { get; set; }
        [Required]
        [MaxLength(255)]
        [DisplayName("Telephone Number")]
        public string number { get; set; }
        [Required]
        public String opening { get; set; }
        [Required]
        public String closing { get; set; }
        [Required]
        [DisplayName("Image Url")]
        public string imageUrl { get; set; }
        public virtual List<FavoriteDoctor> FavoriteDoctorRef { get; set; }
    }
}