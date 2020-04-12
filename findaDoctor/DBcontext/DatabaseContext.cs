

using findaDoctor.model;
using Microsoft.EntityFrameworkCore;

namespace findaDoctor.DBcontext
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options):base(options) { }

        public DbSet<Doctor> Doctors { get; set;  }
    }
}
