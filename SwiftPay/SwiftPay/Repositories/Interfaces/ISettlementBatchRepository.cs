using System.Collections.Generic;
using System.Threading.Tasks;
using SwiftPay.Models;

namespace SwiftPay.Repositories.Interfaces
{
    public interface ISettlementBatchRepository
    {
        Task<SettlementBatch> CreateAsync(SettlementBatch batch);
        Task<SettlementBatch> GetByIdAsync(int id);
        Task<IEnumerable<SettlementBatch>> GetAllAsync();
        Task<SettlementBatch> UpdateAsync(SettlementBatch batch);
    }
}