using Microsoft.EntityFrameworkCore;

namespace Lab_5_ASP_NET.Models
{
    public class CookbookContext : DbContext
    {
        public CookbookContext(DbContextOptions<CookbookContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Recipe> recipes { get; set; }
        public DbSet<Product> products { get; set; }

    }
}
