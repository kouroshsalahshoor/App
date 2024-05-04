using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser, IdentityRole, string>(options)
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var roles = new List<IdentityRole>();
            builder.Entity<IdentityRole>().HasData(new IdentityRole { Id = Guid.NewGuid().ToString(), Name =ApplicationConstants.Role_Admin, NormalizedName= ApplicationConstants.Role_Admin.ToUpper()});
            builder.Entity<IdentityRole>().HasData(new IdentityRole { Id = Guid.NewGuid().ToString(), Name =ApplicationConstants.Role_User, NormalizedName= ApplicationConstants.Role_User.ToUpper()});

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
