using Engage360plus.Data;
using Engage360plus.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Engage360plus.Repository
{
    public class SQLCustomerRepository : ICustomerRepository
    {
        private readonly CRMDbContext dbContext;

        public SQLCustomerRepository(CRMDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<CustomerDetails>> GetAllCustomerAsync()
        {
            var customerModel= await dbContext.CustomerDetails.Include(c=>c.Address).Include("ProductStatus").ToListAsync();
            return customerModel;
        }

        public async Task<CustomerDetails?> GetCustomerByIdAsync(Guid id)
        {
            var customerModel = await dbContext.CustomerDetails.Include(c=>c.Address)
                .Include("ProductStatus")
                .FirstOrDefaultAsync(x => x.Id == id);
            return customerModel;
        }

        public async Task<CustomerDetails> RegisterCustomerAsync(CustomerDetails customerDetails)
        {
            await dbContext.CustomerDetails.AddAsync(customerDetails);
            await dbContext.SaveChangesAsync();
            return customerDetails;
        }
    }
}
