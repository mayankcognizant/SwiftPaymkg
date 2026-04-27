using System.Threading.Tasks;
using SwiftPay.DTOs.SettlementDTO;
using SwiftPay.Models;

namespace SwiftPay.Services.Interfaces
{
    public interface ISettlementBatchService
    {
        Task<SettlementBatch> GenerateBatchAsync(GenerateBatchDto dto);
        Task<SettlementBatch> UpdateStatusAsync(UpdateBatchStatusDto dto);
        Task<SettlementBatch> GetByIdAsync(int id);
		Task<bool> DeleteAsync(int id);
	}
}