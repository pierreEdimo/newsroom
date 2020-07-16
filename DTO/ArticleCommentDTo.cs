using System;
using System.ComponentModel.DataAnnotations;

namespace newsroom.DTO
{
    public class ArticleCommentDTo : CommentDTo
    {
        [Required]
        public int articleId { get; set; }
    }
}