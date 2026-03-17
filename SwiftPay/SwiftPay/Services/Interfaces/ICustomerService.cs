using System.Collections.Generic;
using System.Threading.Tasks;
using SwiftPay.DTOs.UserCustomerDTO;
using SwiftPay.Domain.Remittance.Entities;

namespace SwiftPay.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<CustomerProfile> CreateAsync(CreateCustomerDto dto);
        Task<CustomerProfile> GetByIdAsync(int customerId);
        Task<CustomerProfile> GetByUserIdAsync(int userId);
        Task<IEnumerable<CustomerProfile>> GetAllAsync();
        Task<CustomerProfile> UpdateAsync(int customerId, UpdateCustomerDto dto);
        Task<bool> DeleteAsync(int customerId);
    }
}
