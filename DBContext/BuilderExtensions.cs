using Microsoft.EntityFrameworkCore;
using findaDoctor.Model;

namespace findaDoctor.DBContext
{
    public static class BuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, name = "psychiater" },
                new Category { Id = 2, name = "Ophtamologue" },
                new Category { Id = 3, name = "Orl" }
            );

            modelBuilder.Entity<Doctor>().HasData(
                new Doctor { Id = 1, name = "Aurelius", categoryId = 1, specialisation = "psychiater", description = "specialised in psychosomatischen Problem", location = "am Kleegarten 17", city = "Frankfurt", country = "Deutschland", email = "pedimonkoe@yahoo.com", number = "+15758516374" },
                new Doctor { Id = 2, name = "Aurelius", categoryId = 1, specialisation = "ophtamologue", description = "specialised in psychosomatischen Problem", location = "am Kleegarten 17", city = "Frankfurt", country = "Deutschland", email = "pedimonkoe@yahoo.com", number = "+15758516374" },
                new Doctor { Id = 3, name = "Aurelius", categoryId = 2, specialisation = "dermatologue", description = "specialised in psychosomatischen Problem", location = "am Kleegarten 17", city = "Frankfurt", country = "Deutschland", email = "pedimonkoe@yahoo.com", number = "+15758516374" },
                new Doctor { Id = 4, name = "Aurelius", categoryId = 2, specialisation = "psychiater", description = "specialised in psychosomatischen Problem", location = "am Kleegarten 17", city = "Fulda", country = "Deutschland", email = "pedimonkoe@yahoo.com", number = "+15758516374" },
                new Doctor { Id = 5, name = "Aurelius", categoryId = 3, specialisation = "dermatologue", description = "specialised in psychosomatischen Problem", location = "am Kleegarten 17", city = "Frankfurt", country = "Deutschland", email = "pedimonkoe@yahoo.com", number = "+15758516374" }
            );
        }
    }
}