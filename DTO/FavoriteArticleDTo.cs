using newsroom.Model;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace newsroom.DTO
{
    public class FavoriteArticleDTo
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string userId { get; set; }
        [Required]
        public int articleId { get; set; }
        public virtual Article Article { get; set; }
        [JsonIgnore]
        public virtual UserEntity UserReader { get; set; }
    }
}
