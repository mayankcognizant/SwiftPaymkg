using System.Collections.Generic;
using System.Threading.Tasks;
using SwiftPay.Domain.Remittance.Entities;

namespace SwiftPay.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        Task<CustomerProfile> CreateAsync(CustomerProfile entity);
        Task<CustomerProfile> GetByIdAsync(int customerId);
        Task<CustomerProfile> GetByUserIdAsync(int userId);
        Task<IEnumerable<CustomerProfile>> GetAllAsync();
        Task<CustomerProfile> UpdateAsync(CustomerProfile entity);
        Task<bool> DeleteAsync(int customerId);
    }
}
