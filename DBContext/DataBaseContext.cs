using Microsoft.EntityFrameworkCore;
using newsroom.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace newsroom.DBContext
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

            modelBuilder.Entity<Article>().HasMany(c => c.Comments).WithOne(a => a.article).HasForeignKey(a => a.articleId);

            modelBuilder.Entity<FavoriteArticle>().HasKey(f => new { f.articleId, f.userId });

            modelBuilder.Entity<FavoriteArticle>().HasOne(c => c.Article);

            modelBuilder.Entity<Article>().HasOne(f => f.Theme).WithMany(a => a.Articles);

            modelBuilder.Entity<Comments>().HasOne(f => f.article).WithMany(a => a.Comments);

            modelBuilder.Entity<Comments>().HasKey(f => new { f.articleId, f.uid });

            modelBuilder.Entity<Comments>().HasOne(f => f.author);

            modelBuilder.Seed();
        }


        public DbSet<Article> Articles { get; set; }
        public DbSet<Theme> Themes { get; set; }
        public DbSet<FavoriteArticle> FavoriteeArticles { get; set; }
        public DbSet<Comments> Comments { get; set; }

    }
}