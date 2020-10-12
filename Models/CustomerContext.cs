using Microsoft.EntityFrameworkCore;

namespace CustomerApi.Models
{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> options) :base (options)
        {

        }

        public DbSet<Customer> CommandItems { get; set; }
        
    }
}