using System.Threading.Tasks;
using SwiftPay.Repositories.Interfaces;
using SwiftPay.Domain.Remittance.Entities;
using SwiftPay.Configuration; // This is where your friend's AppDbContext lives

namespace SwiftPay.Repositories
{
    public class ComplianceCheckRepository : IComplianceCheckRepository
    {
        private readonly AppDbContext _db;

        public ComplianceCheckRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<ComplianceCheck> CreateAsync(ComplianceCheck entity)
        {
            // This follows your friend's exact syntax for adding to the DB
            await _db.Set<ComplianceCheck>().AddAsync(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}