using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using SwiftPay.Services.Interfaces;
using SwiftPay.Repositories.Interfaces;
using SwiftPay.DTOs.UserCustomerDTO;
using SwiftPay.Constants.Enums;
using SwiftPay.Domain.Remittance.Entities;

namespace SwiftPay.Services
{
    public class BeneficiaryService : IBeneficiaryService
    {
        private readonly IBeneficiaryRepository _repo;
        private readonly ICustomerRepository _customerRepo;
        private readonly IMapper _mapper;

        public BeneficiaryService(IBeneficiaryRepository repo, ICustomerRepository customerRepo, IMapper mapper)
        {
            _repo = repo;
            _customerRepo = customerRepo;
            _mapper = mapper;
        }

        public async Task<Beneficiary> CreateAsync(CreateBeneficiaryDto dto)
        {
            // Validate that Customer exists
            var customer = await _customerRepo.GetByIdAsync(dto.CustomerID);
            if (customer == null)
                throw new Exception($"Customer with ID {dto.CustomerID} does not exist. Cannot create beneficiary without a valid customer.");

            // Use AutoMapper to map DTO to entity
            var entity = _mapper.Map<Beneficiary>(dto);

            // Audit fields (CreatedAt, UpdatedAt, IsDeleted) are configured in database configuration
            // AddedDate, Status, VerificationStatus are set by mapper profile (Ignore) - configured at DB level

            var created = await _repo.CreateAsync(entity);
            return created;
        }

        public async Task<Beneficiary> GetByIdAsync(int beneficiaryId)
        {
            return await _repo.GetByIdAsync(beneficiaryId);
        }

        public async Task<IEnumerable<Beneficiary>> GetByCustomerIdAsync(int customerId)
        {
            return await _repo.GetByCustomerIdAsync(customerId);
        }

        public async Task<IEnumerable<Beneficiary>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<Beneficiary> UpdateAsync(int beneficiaryId, UpdateBeneficiaryDto dto)
        {
            var beneficiary = await _repo.GetByIdAsync(beneficiaryId);
            if (beneficiary == null)
                throw new Exception($"Beneficiary with ID {beneficiaryId} not found");

            // Use AutoMapper to map only non-null fields
            _mapper.Map(dto, beneficiary);

            // Update the UpdatedAt timestamp
            beneficiary.UpdatedAt = DateTime.UtcNow;

            var updated = await _repo.UpdateAsync(beneficiary);
            return updated;
        }

        public async Task<bool> DeleteAsync(int beneficiaryId)
        {
            return await _repo.DeleteAsync(beneficiaryId);
        }
    }
}
