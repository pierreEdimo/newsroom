using System;
using System.ComponentModel.DataAnnotations;

namespace newsroom.DTO
{
    public class ForumCommentDTo : CommentDTo
    {
        [Required]
        public int forumId { get; set; }
    }
}