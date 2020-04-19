using Microsoft.EntityFrameworkCore;
using findaDoctor.Model;

namespace findaDoctor.DBContext
{


    public class DatabaseContext : DbContext

    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasMany(c => c.Doctors).WithOne(a => a.Category).HasForeignKey(a => a.categoryId);

            modelBuilder.Entity<Doctor>().HasMany(c => c.Articles).WithOne(a => a.Doctor).HasForeignKey(a => a.autorId);

            modelBuilder.Seed();
        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Article> Articles { get; set; }
    }
}