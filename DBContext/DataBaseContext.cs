using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using newsroom.Model;

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

            modelBuilder.Entity<Article>().HasOne(x => x.Author).WithMany(x => x.Articles).HasForeignKey(x => x.AuthorId);

            modelBuilder.Entity<Article>().HasOne(x => x.Topic).WithMany(x => x.Articles).HasForeignKey(x => x.TopicId);

            modelBuilder.Entity<Article>().HasMany(x => x.Comments).WithOne(x => x.Article).HasForeignKey(x => x.ArticleId);

            modelBuilder.Entity<Comment>().HasOne(x => x.Author).WithMany(x => x.Comments).HasForeignKey(x => x.AuthorId);

            modelBuilder.Entity<UserEntity>().HasMany(x => x.Comments).WithOne(x => x.Author).HasForeignKey(x => x.AuthorId); 

            modelBuilder.Entity<FavoritesArticles>().HasKey(x => new { x.ArticleId, x.OwnerId });

            modelBuilder.Entity<Article>().HasMany(x => x.HasFavorites).WithOne(x => x.Article).HasForeignKey(x => x.ArticleId); 

            modelBuilder.Entity<Report>().HasOne(x => x.Comment).WithMany(x => x.Reports).HasForeignKey(x => x.CommentId); 

            modelBuilder.Entity<Comment>().HasMany(x => x.Reports).WithOne(x => x.Comment).HasForeignKey(x => x.CommentId);

            modelBuilder.Entity<PodCast>().HasMany(x => x.Episodes).WithOne(x => x.PodCast).HasForeignKey(x => x.PodCastId); 

            modelBuilder.Entity<PodCast>().HasOne(x => x.Author).WithMany(x => x.PodCasts).HasForeignKey(x => x.AuthorId); 

            modelBuilder.Seed();
        }


        public DbSet<Article> Articles { get; set; }
        public DbSet<Topic> Topics { get; set;  }
        public DbSet<Author> Authors { get; set;  }
        public DbSet<Comment> Comments { get; set;  }
        public DbSet<SavedWord> SavedWords { get; set;  }
        public DbSet<Report> Reports {get; set;}
        public DbSet<FavoritesArticles> Favorites { get; set;  }
        public DbSet<PodCast> PodCasts { get; set;  }
        public DbSet<Episode> Episodes { get; set; }
    }
}