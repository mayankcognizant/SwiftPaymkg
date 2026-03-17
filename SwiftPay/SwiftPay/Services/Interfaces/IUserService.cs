using System.Collections.Generic;
using System.Threading.Tasks;
using SwiftPay.DTOs.UserCustomerDTO;
using SwiftPay.Models;

namespace SwiftPay.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> CreateAsync(CreateUserDto dto);
        Task<User> GetByIdAsync(int userId);
        Task<User> GetByEmailAsync(string email);
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> UpdateAsync(int userId, UpdateUserDto dto);
        Task<bool> DeleteAsync(int userId);
    }
}
