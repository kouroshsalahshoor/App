using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System.Reflection.Metadata;

namespace API.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var ps = new List<Product>();
            for (int i = 1; i <= 10; i++)
            {
                var p = new Product
                {
                    Id = i,
                    Name = i.ToString(),
                    IsActive = (i % 3) == 0
                };
                ps.Add(p);
            }

            builder.Entity<Product>().HasData(ps);
        }
    }
}
