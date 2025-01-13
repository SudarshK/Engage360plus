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
        public DbSet<ProductStatus> ProductStatuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Seed the data for Products
            var statuses = new List<ProductStatus>()
            {
                new ProductStatus()
                {
                    StatusId = 1,
                    Name = "In Discussion"
                },
                new ProductStatus()
                {
                    StatusId = 2,
                    Name = "Paid",
                },
                new ProductStatus()
                {
                    StatusId = 3,
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
                    AddressId = 1,
                    City="Pune0",
                    Country="India0",
                    PostalCode="411072",
                    Region="Pune0"
                },
                new Addresses
                {
                    AddressId = 2,
                    City="Pune1",
                    Country="India1",
                    PostalCode="411072",
                    Region="Pune1"
                },
                new Addresses
                {
                    AddressId = 3,
                    City="Pune2",
                    Country="India2",
                    PostalCode="411072",
                    Region="Pune2"
                }
                ,new Addresses
                {
                    AddressId = 4,
                    City="Pune0",
                    Country="India0",
                    PostalCode="411072",
                    Region="Pune0"
                },
                new Addresses
                {
                    AddressId = 5,
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
