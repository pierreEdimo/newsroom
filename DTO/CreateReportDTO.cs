using System;
using System.ComponentModel.DataAnnotations;

namespace newsroom.DTO
{
    public class CreateReportDTO 
    {
        
        public String Content {get; set;}
        [Key]
        public int Id {get; set; }
        public int CommentId {get; set; }

    }
}