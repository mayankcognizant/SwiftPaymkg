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
    public class KYCRecordService : IKYCRecordService
    {
        private readonly IKYCRecordRepository _repo;
        private readonly IUserRepository _userRepo;
        private readonly IAuditLogRepository _auditLogRepo;
        private readonly IMapper _mapper;

        public KYCRecordService(IKYCRecordRepository repo, IUserRepository userRepo, IAuditLogRepository auditLogRepo, IMapper mapper)
        {
            _repo = repo;
            _userRepo = userRepo;
            _auditLogRepo = auditLogRepo;
            _mapper = mapper;
        }

        public async Task<KYCRecord> CreateAsync(CreateKYCRecordDto dto)
        {
            // Validate that User exists
            var user = await _userRepo.GetByIdAsync(dto.UserID);
            if (user == null)
                throw new Exception($"User with ID {dto.UserID} does not exist. Cannot create KYC record without a valid user.");

            // Check if KYC record already exists for this user
            var existingKyc = await _repo.GetByUserIdAsync(dto.UserID);
            if (existingKyc != null)
                throw new Exception($"A KYC record already exists for User ID {dto.UserID}. Each user can have only one KYC record.");

            // Use AutoMapper to map DTO to entity
            var entity = _mapper.Map<KYCRecord>(dto);

            // Audit fields (CreatedAt, UpdatedAt, IsDeleted) are configured in database configuration
            // VerificationStatus is set by mapper profile (Ignore) - configured at DB level

            var created = await _repo.CreateAsync(entity);

            // Log the action - audit fields configured at DB level
            var auditLog = new AuditLog
            {
                UserID = dto.UserID,
                Action = "CREATE",
                Resource = $"KYCRecord:{created.KYCID}"
            };
            await _auditLogRepo.CreateAsync(auditLog);

            return created;
        }

        public async Task<KYCRecord> GetByIdAsync(int kycId)
        {
            return await _repo.GetByIdAsync(kycId);
        }

        public async Task<KYCRecord> GetByUserIdAsync(int userId)
        {
            return await _repo.GetByUserIdAsync(userId);
        }

        public async Task<IEnumerable<KYCRecord>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<KYCRecord> UpdateAsync(int kycId, UpdateKYCRecordDto dto)
        {
            var kyc = await _repo.GetByIdAsync(kycId);
            if (kyc == null)
                throw new Exception($"KYC Record with ID {kycId} not found");

            // Use AutoMapper to map only non-null fields
            _mapper.Map(dto, kyc);

            // UpdatedAt is set on the application side (mapped at DB configuration level)
            kyc.UpdatedAt = DateTime.UtcNow;
            var updated = await _repo.UpdateAsync(kyc);

            // Log the action - audit fields configured at DB level
            var auditLog = new AuditLog
            {
                UserID = kyc.UserID,
                Action = "UPDATE",
                Resource = $"KYCRecord:{kycId}"
            };
            await _auditLogRepo.CreateAsync(auditLog);

            return updated;
        }

        public async Task<KYCRecord> MarkAsVerifiedAsync(int kycId)
        {
            var kyc = await _repo.GetByIdAsync(kycId);
            if (kyc == null)
                throw new Exception($"KYC Record with ID {kycId} not found");

            kyc.VerificationStatus = KycVerificationStatus.Verified;
            kyc.VerifiedDate = DateTime.UtcNow;
            kyc.UpdatedAt = DateTime.UtcNow;
            var updated = await _repo.UpdateAsync(kyc);

            // Log the verification action - audit fields configured at DB level
            var auditLog = new AuditLog
            {
                UserID = kyc.UserID,
                Action = "VERIFY",
                Resource = $"KYCRecord:{kycId}"
            };
            await _auditLogRepo.CreateAsync(auditLog);

            return updated;
        }

        public async Task<bool> DeleteAsync(int kycId)
        {
            return await _repo.DeleteAsync(kycId);
        }
    }
}
