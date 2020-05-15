using findaDoctor.Model; 

namespace findaDoctor.DTO
{
    public class FavoriteArticleDTo
    {
        public int Id { get; set; }
        public string userId { get; set; }
        public int articleId { get; set; }
        public virtual Article Article { get; set; }
        public virtual UserEntity UserEntity { get; set; }
    }
}
