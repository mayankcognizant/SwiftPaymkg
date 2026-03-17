using System.Collections.Generic;
using System.Threading.Tasks;
using SwiftPay.Models;

namespace SwiftPay.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> CreateAsync(User entity);
        Task<User> GetByIdAsync(int userId);
        Task<User> GetByEmailAsync(string email);
        Task<User> GetByPhoneAsync(string phone);
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> UpdateAsync(User entity);
        Task<bool> DeleteAsync(int userId);
    }
}
