using System.Collections.Generic;
using System.Threading.Tasks;
using SwiftPay.Domain.Remittance.Entities;

namespace SwiftPay.Services.Interfaces
{
    public interface IAuditLogService
    {
        Task<AuditLog> LogActionAsync(int userId, string action, string resource);
        Task<AuditLog> GetByIdAsync(int auditId);
        Task<IEnumerable<AuditLog>> GetByUserIdAsync(int userId);
        Task<IEnumerable<AuditLog>> GetByResourceAsync(string resource);
        Task<IEnumerable<AuditLog>> GetAllAsync();
        Task<IEnumerable<AuditLog>> GetByDateRangeAsync(System.DateTime startDate, System.DateTime endDate);
        Task<bool> DeleteAsync(int auditId);
    }
}
