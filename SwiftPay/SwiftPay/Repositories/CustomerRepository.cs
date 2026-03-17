using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SwiftPay.Repositories.Interfaces;
using SwiftPay.Configuration;
using SwiftPay.Domain.Remittance.Entities;

namespace SwiftPay.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _db;

        public CustomerRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<CustomerProfile> CreateAsync(CustomerProfile entity)
        {
            await _db.Set<CustomerProfile>().AddAsync(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<CustomerProfile> GetByIdAsync(int customerId)
        {
            return await _db.Set<CustomerProfile>()
                .Include(c => c.User)
                .FirstOrDefaultAsync(c => c.CustomerID == customerId && !c.IsDeleted);
        }

        public async Task<CustomerProfile> GetByUserIdAsync(int userId)
        {
            return await _db.Set<CustomerProfile>()
                .Include(c => c.User)
                .FirstOrDefaultAsync(c => c.UserID == userId && !c.IsDeleted);
        }

        public async Task<IEnumerable<CustomerProfile>> GetAllAsync()
        {
            return await _db.Set<CustomerProfile>()
                .Include(c => c.User)
                .Where(c => !c.IsDeleted)
                .ToListAsync();
        }

        public async Task<CustomerProfile> UpdateAsync(CustomerProfile entity)
        {
            _db.Set<CustomerProfile>().Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(int customerId)
        {
            var customer = await GetByIdAsync(customerId);
            if (customer == null)
                return false;

            customer.IsDeleted = true;
            customer.UpdatedAt = DateTime.UtcNow;
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
