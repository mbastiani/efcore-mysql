using Microsoft.EntityFrameworkCore;

namespace efcore_mysql
{
    public class AppDbContext : DbContext
    {
        public DbSet<PersonModel> Persons { get; set; }
        public DbSet<AddressModel> Addresses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=efcore;user=root;password=");
        }
    }
}