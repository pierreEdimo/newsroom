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

            modelBuilder.Entity<Comments>().HasOne(f => f.author).WithMany(a => a.Comments);

            modelBuilder.Entity<Comments>().HasOne(f => f.Forum).WithMany(a => a.Comments);

            modelBuilder.Entity<Forum>().HasMany(f => f.Comments).WithOne(a => a.Forum).HasForeignKey(a => a.forumId);

            modelBuilder.Entity<Forum>().HasOne(f => f.Author).WithMany(a => a.Forums);

            modelBuilder.Entity<UserEntity>().HasMany(a => a.Comments).WithOne(a => a.author).HasForeignKey(a => a.uid);

            modelBuilder.Entity<UserEntity>().HasMany(a => a.Forums).WithOne(a => a.Author).HasForeignKey(a => a.uid);



            modelBuilder.Seed();
        }


        public DbSet<Article> Articles { get; set; }
        public DbSet<Theme> Themes { get; set; }
        public DbSet<FavoriteArticle> FavoriteeArticles { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Forum> Forums { get; set; }

    }
}