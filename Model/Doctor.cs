using System;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace findaDoctor.Model
{
    public class Doctor
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string name { get; set; }
        [Required]
        [MaxLength(255)]
        public string specialisation { get; set; }
        [Required]
        [MaxLength(8000)]
        public string description { get; set; }
        [Required]
        [MaxLength(255)]
        public string poBox { get; set; }
        [Required]
        [MaxLength(255)]
        public string location { get; set; }
        [Required]
        [MaxLength(255)]
        public string city { get; set; }
        [Required]
        [MaxLength(255)]
        public string country { get; set; }
        [Required]
        [MaxLength(255)]
        public string email { get; set; }
        [Required]
        [MaxLength(255)]
        public string number { get; set; }
        [Required]
        [MaxLength(255)]
        public string searchWord { get; set; }
        [Required]
        public string imageUrl { get; set; }
        public String opening { get; set; }
        public String closing { get; set; }
    }
}