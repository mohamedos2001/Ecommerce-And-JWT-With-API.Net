using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Models
{
    public class ITIAPIContext : IdentityDbContext<AppLoacationUser>
    {
        public ITIAPIContext()
        {

        }
        public ITIAPIContext(DbContextOptions options)
        {
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=DbEcommerce;Trusted_Connection=True;Encrypt=False");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
