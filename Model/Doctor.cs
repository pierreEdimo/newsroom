using System;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace findaDoctor.Model
{
    public class Doctor
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string specialisation { get; set; }
        public string description { get; set; }
        public string poBox { get; set; }
        public string location { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string email { get; set; }
        public string number { get; set; }
        public string searchWord { get; set; }
        public DateTime opening { get; set; }
        public DateTime closing { get; set; }
        public int categoryId { get; set; }
        [JsonIgnore]
        public virtual Category Category { get; set; }
        public virtual List<Article> Articles { get; set; }

    }
}