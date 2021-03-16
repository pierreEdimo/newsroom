using System;
using newsroom.Model;
using Newtonsoft.Json;

namespace newsroom.DTO
{
    public class CommentDTO
    {
        public int Id { get; set;  }
        public UserDTO Author { get; set;  }
        public String Content { get; set;  }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        [JsonIgnore]
        public int ArticleId { get; set; }
    }
}
