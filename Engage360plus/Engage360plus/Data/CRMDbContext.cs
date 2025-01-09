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
        public DbSet<CustomerProduct> CustomerProducts { get; set; }
        public DbSet<CustomerDetails> CustomerDetails { get; set; }
    }
}
