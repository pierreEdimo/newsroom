using Microsoft.EntityFrameworkCore;
using findaDoctor.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace findaDoctor.DBContext
{


    public class DatabaseContext : IdentityDbContext

    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DatabaseContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Theme>().HasMany(c => c.Articles).WithOne(a => a.Theme).HasForeignKey(a => a.themeId);

            modelBuilder.Entity<FavoriteArticle>().HasKey(f => new { f.articleId, f.userId });

            modelBuilder.Entity<FavoriteArticle>().HasOne(c => c.Article).WithMany(a => a.FavoriteArticleRef).HasForeignKey(a => a.articleId);

            modelBuilder.Entity<Article>().HasOne(f => f.Theme).WithMany(a => a.Articles);

            modelBuilder.Seed();
        }


        public DbSet<Article> Articles { get; set; }
        public DbSet<Theme> Themes { get; set; }
        public DbSet<FavoriteArticle> FavoriteeArticles { get; set; }

    }
}