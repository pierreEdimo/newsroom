using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace newsroom.Model
{
    public class Report
    {
        public String Content {get; set;}
        [Key]
        public int Id {get; set; }
        public int CommentId {get; set; }
        [JsonIgnore]
        public virtual Comment Comment {get; set; }
        
    }
}