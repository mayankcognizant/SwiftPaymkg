using System.Collections.Generic;
using System.Threading.Tasks;
using SwiftPay.Domain.Remittance.Entities;
using SwiftPay.DTOs.UserCustomerDTO;

namespace SwiftPay.Services.Interfaces
{
    public interface IKYCRecordService
    {
        Task<KYCRecord> CreateAsync(CreateKYCRecordDto dto);
        Task<KYCRecord> GetByIdAsync(int kycId);
        Task<KYCRecord> GetByUserIdAsync(int userId);
        Task<IEnumerable<KYCRecord>> GetAllAsync();
        Task<KYCRecord> UpdateAsync(int kycId, UpdateKYCRecordDto dto);
        Task<KYCRecord> MarkAsVerifiedAsync(int kycId);
        Task<bool> DeleteAsync(int kycId);
    }
}
