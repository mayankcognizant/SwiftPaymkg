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
    public class AuditLogRepository : IAuditLogRepository
    {
        private readonly AppDbContext _db;

        public AuditLogRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<AuditLog> CreateAsync(AuditLog entity)
        {
            await _db.Set<AuditLog>().AddAsync(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<AuditLog> GetByIdAsync(int auditId)
        {
            return await _db.Set<AuditLog>()
                .Include(a => a.User)
                .FirstOrDefaultAsync(a => a.AuditID == auditId && !a.IsDeleted);
        }

        public async Task<IEnumerable<AuditLog>> GetByUserIdAsync(int userId)
        {
            return await _db.Set<AuditLog>()
                .Include(a => a.User)
                .Where(a => a.UserID == userId && !a.IsDeleted)
                .OrderByDescending(a => a.Timestamp)
                .ToListAsync();
        }

        public async Task<IEnumerable<AuditLog>> GetByResourceAsync(string resource)
        {
            return await _db.Set<AuditLog>()
                .Include(a => a.User)
                .Where(a => a.Resource == resource && !a.IsDeleted)
                .OrderByDescending(a => a.Timestamp)
                .ToListAsync();
        }

        public async Task<IEnumerable<AuditLog>> GetAllAsync()
        {
            return await _db.Set<AuditLog>()
                .Include(a => a.User)
                .Where(a => !a.IsDeleted)
                .OrderByDescending(a => a.Timestamp)
                .ToListAsync();
        }

        public async Task<IEnumerable<AuditLog>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _db.Set<AuditLog>()
                .Include(a => a.User)
                .Where(a => a.Timestamp >= startDate && a.Timestamp <= endDate && !a.IsDeleted)
                .OrderByDescending(a => a.Timestamp)
                .ToListAsync();
        }

        public async Task<bool> DeleteAsync(int auditId)
        {
            var auditLog = await GetByIdAsync(auditId);
            if (auditLog == null)
                return false;

            auditLog.IsDeleted = true;
            auditLog.UpdatedAt = DateTime.UtcNow;
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
