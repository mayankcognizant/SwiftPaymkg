using SwiftPay.Configuration;
using SwiftPay.Domain.Remittance.Entities;
using SwiftPay.Repositories.Interfaces;

namespace SwiftPay.Repositories
{
    public class AmendmentRepository : IAmendmentRepository
    {
        private readonly AppDbContext _db;

        public AmendmentRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Amendment> CreateAsync(Amendment entity)
        {
            await _db.Set<Amendment>().AddAsync(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}