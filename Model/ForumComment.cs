using System;
using System.ComponentModel.DataAnnotations;

namespace newsroom.Model
{
    public class ForumComments : Comments
    {
        [Required]
        public int forumId { get; set; }
    }
}