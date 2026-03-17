using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using SwiftPay.Services.Interfaces;
using SwiftPay.Repositories.Interfaces;
using SwiftPay.DTOs.UserCustomerDTO;
using SwiftPay.Constants.Enums;
using SwiftPay.Domain.Remittance.Entities;
using SwiftPay.Models;

namespace SwiftPay.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repo;
        private readonly IUserRepository _userRepo;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository repo, IUserRepository userRepo, IMapper mapper)
        {
            _repo = repo;
            _userRepo = userRepo;
            _mapper = mapper;
        }

        public async Task<CustomerProfile> CreateAsync(CreateCustomerDto dto)
        {
            // Validate that User exists
            var user = await _userRepo.GetByIdAsync(dto.UserID);
            if (user == null)
                throw new Exception($"User with ID {dto.UserID} does not exist. Cannot create customer profile without a valid user.");

            // Check if customer already exists for this user
            var existingCustomer = await _repo.GetByUserIdAsync(dto.UserID);
            if (existingCustomer != null)
                throw new Exception($"A customer profile already exists for User ID {dto.UserID}. Each user can have only one customer profile.");

            // Use AutoMapper to map DTO to entity
            var entity = _mapper.Map<CustomerProfile>(dto);

            // Audit fields (CreatedAt, UpdatedAt, IsDeleted) are configured in database configuration
            // Status and RiskRating are set by mapper profile (Ignore) - configured at DB level

            var created = await _repo.CreateAsync(entity);
            return created;
        }

        public async Task<CustomerProfile> GetByIdAsync(int customerId)
        {
            return await _repo.GetByIdAsync(customerId);
        }

        public async Task<CustomerProfile> GetByUserIdAsync(int userId)
        {
            return await _repo.GetByUserIdAsync(userId);
        }

        public async Task<IEnumerable<CustomerProfile>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<CustomerProfile> UpdateAsync(int customerId, UpdateCustomerDto dto)
        {
            var customer = await _repo.GetByIdAsync(customerId);
            if (customer == null)
                throw new Exception($"Customer with ID {customerId} not found");

            // Use AutoMapper to map only non-null fields
            _mapper.Map(dto, customer);

            // Update the UpdatedAt timestamp
            customer.UpdatedAt = DateTime.UtcNow;

            var updated = await _repo.UpdateAsync(customer);
            return updated;
        }

        public async Task<bool> DeleteAsync(int customerId)
        {
            return await _repo.DeleteAsync(customerId);
        }
    }
}
