using Microsoft.EntityFrameworkCore;

namespace SwiftPay.Configuration
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }


        
    }
}
