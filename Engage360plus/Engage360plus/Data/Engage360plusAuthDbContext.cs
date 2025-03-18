using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Engage360plus.Data
{
    public class Engage360plusAuthDbContext : IdentityDbContext
    {
        public Engage360plusAuthDbContext(DbContextOptions<Engage360plusAuthDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            var readerRoleId = "5394b8c7-5b4a-4961-8fbf-6c2e8cadedf8";
            var writerRoleId = "104c089d-11e5-4f3b-a892-048a9c263e44";
            var roles = new List<IdentityRole>
            {

                new IdentityRole()
                {
                    Id = readerRoleId,
                    ConcurrencyStamp= readerRoleId,
                    Name = "Reader",
                    NormalizedName = "Reader".ToUpper()
                },
                
                new IdentityRole()
                {
                    Id = writerRoleId,
                    ConcurrencyStamp= writerRoleId,
                    Name = "Writer",
                    NormalizedName = "Writer".ToUpper()
                }
            };
            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
