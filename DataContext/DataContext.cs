using Microsoft.EntityFrameworkCore;

namespace ProductApi.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=LAPTOP-UJABLPO4\\SQLEXPRESS; Database= productsDb; Trusted_Connection=True; TrustServerCertificate=True;");
        }
        public DbSet<Product> Products { get; set; }

                
    }
}
