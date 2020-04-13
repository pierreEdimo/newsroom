using Microsoft.EntityFrameworkCore;
using findaDoctor.Model;

namespace findaDoctor.DBContext
{


    public class DatabaseContext : DbContext

    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasMany(c => c.Doctors).WithOne(a => a.Category).HasForeignKey(async => async.categoryId);

            modelBuilder.Seed();
        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}