using System;
using System.Text.Json.Serialization;
using findaDoctor.Model;


namespace findaDoctor.DTO
{
    public class DoctorsDTo
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string specialisation { get; set; }
        public string description { get; set; }
        public string location { get; set; }
        public string city { get; set; }
        public string poBox{get; set; }
        public string country { get; set; }
        public string email { get; set; }
        public string number { get; set; }
        public DateTime opening { get; set; }
        public DateTime closing { get; set; }
        public int categoryId { get; set; }
    }
}