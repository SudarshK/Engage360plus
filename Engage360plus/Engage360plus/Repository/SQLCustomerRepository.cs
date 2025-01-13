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
            var customerModel= await dbContext.CustomerDetails.Include("ProductStatus").Include("Addresses").ToListAsync();
            return customerModel;
        }

        public Task<CustomerDetails> GetCustomerByIdAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<CustomerDetails> RegisterCustomerAsync(CustomerDetails customerDetails)
        {
            await dbContext.CustomerDetails.AddAsync(customerDetails);
            await dbContext.SaveChangesAsync();
            return customerDetails;
        }
    }
}
