using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SwiftPay.Repositories.Interfaces;
using SwiftPay.Configuration;
using SwiftPay.Domain.Remittance.Entities;

namespace SwiftPay.Repositories
{
    public class BeneficiaryRepository : IBeneficiaryRepository
    {
        private readonly AppDbContext _db;

        public BeneficiaryRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Beneficiary> CreateAsync(Beneficiary entity)
        {
            await _db.Set<Beneficiary>().AddAsync(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<Beneficiary> GetByIdAsync(int beneficiaryId)
        {
            return await _db.Set<Beneficiary>()
                .Include(b => b.Customer)
                .FirstOrDefaultAsync(b => b.BeneficiaryID == beneficiaryId && !b.IsDeleted);
        }

        public async Task<IEnumerable<Beneficiary>> GetByCustomerIdAsync(int customerId)
        {
            return await _db.Set<Beneficiary>()
                .Include(b => b.Customer)
                .Where(b => b.CustomerID == customerId && !b.IsDeleted)
                .ToListAsync();
        }

        public async Task<IEnumerable<Beneficiary>> GetAllAsync()
        {
            return await _db.Set<Beneficiary>()
                .Include(b => b.Customer)
                .Where(b => !b.IsDeleted)
                .ToListAsync();
        }

        public async Task<Beneficiary> UpdateAsync(Beneficiary entity)
        {
            _db.Set<Beneficiary>().Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(int beneficiaryId)
        {
            var beneficiary = await GetByIdAsync(beneficiaryId);
            if (beneficiary == null)
                return false;

            beneficiary.IsDeleted = true;
            beneficiary.UpdatedAt = DateTime.UtcNow;
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
