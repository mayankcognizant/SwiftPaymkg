using System.Collections.Generic;
using System.Threading.Tasks;
using SwiftPay.Domain.Remittance.Entities;

namespace SwiftPay.Repositories.Interfaces
{
    public interface IBeneficiaryRepository
    {
        Task<Beneficiary> CreateAsync(Beneficiary entity);
        Task<Beneficiary> GetByIdAsync(int beneficiaryId);
        Task<IEnumerable<Beneficiary>> GetByCustomerIdAsync(int customerId);
        Task<IEnumerable<Beneficiary>> GetAllAsync();
        Task<Beneficiary> UpdateAsync(Beneficiary entity);
        Task<bool> DeleteAsync(int beneficiaryId);
    }
}
