using System.ComponentModel.DataAnnotations;
using System; 

namespace newsroom.DTO
{
   public class ReportDTO
   {
        public String Content {get; set;}
        [Key]
        public int Id {get; set; }
        public int CommentId {get; set; }
        public virtual CommentDTO Comment {get; set; }
   }   
}