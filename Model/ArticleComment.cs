using System;
using System.ComponentModel.DataAnnotations;

namespace newsroom.Model
{
    public class ArticleComment : Comments
    {
        [Required]
        public int articleId { get; set; }
    }
}