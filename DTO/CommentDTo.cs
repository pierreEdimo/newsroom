using System;
using System.Collections.Generic;
using newsroom.Model;
using newsroom.OnlyDate;
using Newtonsoft.Json;

namespace newsroom.DTO
{
    public class CommentDTO
    {
        public int Id { get; set;  }
        public UserDTO Author { get; set;  }
        public String Content { get; set;  }
        [JsonConverter(typeof(OnlyDateConverter))]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int ArticleId { get; set; }
        public String AuthorId { get; set; }
        public virtual List<ReportDTO> Reports {get; set; }
    }
}
