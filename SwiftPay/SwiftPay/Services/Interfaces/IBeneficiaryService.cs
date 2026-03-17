using System.Collections.Generic;
using System.Threading.Tasks;
using SwiftPay.DTOs.UserCustomerDTO;
using SwiftPay.Domain.Remittance.Entities;

namespace SwiftPay.Services.Interfaces
{
    public interface IBeneficiaryService
    {
        Task<Beneficiary> CreateAsync(CreateBeneficiaryDto dto);
        Task<Beneficiary> GetByIdAsync(int beneficiaryId);
        Task<IEnumerable<Beneficiary>> GetByCustomerIdAsync(int customerId);
        Task<IEnumerable<Beneficiary>> GetAllAsync();
        Task<Beneficiary> UpdateAsync(int beneficiaryId, UpdateBeneficiaryDto dto);
        Task<bool> DeleteAsync(int beneficiaryId);
    }
}
