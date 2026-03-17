using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SwiftPay.Repositories.Interfaces;
using SwiftPay.Configuration;
using SwiftPay.Domain.Remittance.Entities;

namespace SwiftPay.Repositories
{
    public class KYCRecordRepository : IKYCRecordRepository
    {
        private readonly AppDbContext _db;

        public KYCRecordRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<KYCRecord> CreateAsync(KYCRecord entity)
        {
            await _db.Set<KYCRecord>().AddAsync(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<KYCRecord> GetByIdAsync(int kycId)
        {
            return await _db.Set<KYCRecord>()
                .Include(k => k.User)
                .FirstOrDefaultAsync(k => k.KYCID == kycId && !k.IsDeleted);
        }

        public async Task<KYCRecord> GetByUserIdAsync(int userId)
        {
            return await _db.Set<KYCRecord>()
                .Include(k => k.User)
                .FirstOrDefaultAsync(k => k.UserID == userId && !k.IsDeleted);
        }

        public async Task<IEnumerable<KYCRecord>> GetAllAsync()
        {
            return await _db.Set<KYCRecord>()
                .Include(k => k.User)
                .Where(k => !k.IsDeleted)
                .ToListAsync();
        }

        public async Task<KYCRecord> UpdateAsync(KYCRecord entity)
        {
            _db.Set<KYCRecord>().Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(int kycId)
        {
            var kyc = await GetByIdAsync(kycId);
            if (kyc == null)
                return false;

            kyc.IsDeleted = true;
            kyc.UpdatedAt = DateTime.UtcNow;
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
