using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace newsroom.Model
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public String Name { get; set; }
        [JsonIgnore]
        public List<Article> Articles { get; set; }
        public List<PodCast> PodCasts { get; set; }
    }
}
