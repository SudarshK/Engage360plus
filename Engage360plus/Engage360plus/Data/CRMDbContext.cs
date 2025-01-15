using Engage360plus.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Engage360plus.Data
{
    public class CRMDbContext:DbContext
    {
        public CRMDbContext(DbContextOptions dbContextOptions): base(dbContextOptions)
        {
            
        }
        public DbSet<Addresses> Addresses { get; set; }
        //public DbSet<CustomerProduct> CustomerProducts { get; set; }
        public DbSet<CustomerDetails> CustomerDetails { get; set; }
        public DbSet<ProductStatus> ProductStatus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Seed the data for Products
            var statuses = new List<ProductStatus>()
            {
                new ProductStatus()
                {
                    Id = Guid.Parse("e89c34df-12c2-4dd1-a4a3-8740380f0f84"),
                    Name = "In Discussion"
                },
                new ProductStatus()
                {
                    Id = Guid.Parse("8d2ee75c-1d3f-4e54-9d3d-d9d4577dfedf"),
                    Name = "Paid",
                },
                new ProductStatus()
                {
                    Id = Guid.Parse("c2b30590-bc31-42de-a9b5-a3054eba5b45"),
                    Name = "Rejected",
                }
            };

            //Seed statuses to database
            modelBuilder.Entity<ProductStatus>().HasData(statuses);

            //Seed the data for addresses
            var addresses = new List<Addresses>()
            {
                new Addresses
                {
                    Id = Guid.Parse("c2b30590-bc31-42de-a9b5-a3054eba5b41"),
                    City="Pune0",
                    Country="India0",
                    PostalCode="411072",
                    Region="Pune0"
                },
                new Addresses
                {
                    Id = Guid.Parse("c2b30590-bc31-42de-a9b5-a3054eba5b42"),
                    City="Pune1",
                    Country="India1",
                    PostalCode="411072",
                    Region="Pune1"
                },
                new Addresses
                {
                    Id = Guid.Parse("c2b30590-bc31-42de-a9b5-a3054eba5b43"),
                    City="Pune2",
                    Country="India2",
                    PostalCode="411072",
                    Region="Pune2"
                }
                ,new Addresses
                {
                    Id = Guid.Parse("c2b30590-bc31-42de-a9b5-a3054eba5b44"),
                    City="Pune0",
                    Country="India0",
                    PostalCode="411072",
                    Region="Pune0"
                },
                new Addresses
                {
                    Id = Guid.Parse("c2b30590-bc31-42de-a9b5-a3054eba5b46"),
                    City="Pune0",
                    Country="India0",
                    PostalCode="411072",
                    Region="Pune0"
                }
            };
            modelBuilder.Entity<Addresses>().HasData(addresses);
        }
    }
}
