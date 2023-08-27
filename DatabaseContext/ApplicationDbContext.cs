using Microsoft.EntityFrameworkCore;
using WebApplicationwithApiAndAngular.Models;

namespace WebApplicationwithApiAndAngular.DatabaseContext
{
    public class ApplicationDbContext:DbContext
    {

       
        public ApplicationDbContext(DbContextOptions options):base (options){ 
       
        
        }

        public ApplicationDbContext()
        {

        }

        public virtual DbSet<Place> Places { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Place>().HasData(new Place() { PlaceId =Guid.Parse("79BF0D51-6ECC-48BE-9886-0D399CA1224C") ,PlaceName="delhi"});

        }
    }
}
