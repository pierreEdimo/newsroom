using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace newsroom.Model
{
    public class Suggestion
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Article")]
        public int articleId { get; set; }
        public virtual Article article { get; set; }
    }
}