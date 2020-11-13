using newsroom.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace newsroom.DTO
{
    public class FavoriteDTo
    {

        [Required]
        public string userId { get; set; }
        [Key, ForeignKey("Article")]
        public int articleId { get; set; }
        [JsonIgnore]
        public virtual Article Article { get; set; }
    }
}
