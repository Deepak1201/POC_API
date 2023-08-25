using Microsoft.EntityFrameworkCore;

namespace POCAPI.Model
{    
        public class ProductDBContext : DbContext
        {
            public ProductDBContext(DbContextOptions<ProductDBContext> options) : base(options) { }
            public DbSet<Product> Product { get; set; }

        }
   }
