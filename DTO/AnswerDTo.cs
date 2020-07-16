using newsroom.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace newsroom.DTO
{
    public class AnswerDTo
    {
        [Key]
        public int Id { get; set; }
        public int commentId { get; set; }
        public String uid { get; set; }
        [JsonIgnore]
        public virtual Comments Comments { get; set; }
        public virtual UserEntity Author { get; set; }
        public String content { get; set; }
    }
}
