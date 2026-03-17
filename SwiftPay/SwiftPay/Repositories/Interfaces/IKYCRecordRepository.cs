using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SwiftPay.Domain.Remittance.Entities;

namespace SwiftPay.Repositories.Interfaces
{
    public interface IKYCRecordRepository
    {
        Task<KYCRecord> CreateAsync(KYCRecord entity);
        Task<KYCRecord> GetByIdAsync(int kycId);
        Task<KYCRecord> GetByUserIdAsync(int userId);
        Task<IEnumerable<KYCRecord>> GetAllAsync();
        Task<KYCRecord> UpdateAsync(KYCRecord entity);
        Task<bool> DeleteAsync(int kycId);
    }
}
