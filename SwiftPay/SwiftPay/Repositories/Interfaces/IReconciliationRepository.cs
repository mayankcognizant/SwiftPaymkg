using System.Collections.Generic;
using System.Threading.Tasks;
using SwiftPay.Models;
using SwiftPay.Constants.Enums;

namespace SwiftPay.Repositories.Interfaces
{
    public interface IReconciliationRepository
    {
        Task<ReconciliationRecord> CreateAsync(ReconciliationRecord record);
        Task<ReconciliationRecord> GetByIdAsync(int id);
        Task<IEnumerable<ReconciliationRecord>> GetAllAsync();
        Task<IEnumerable<ReconciliationRecord>> GetByResultAsync(Result result);
        Task<IEnumerable<ReconciliationRecord>> GetByReferenceTypeAsync(ReferenceType type);
        Task<ReconciliationRecord> UpdateAsync(ReconciliationRecord record);
    }
}