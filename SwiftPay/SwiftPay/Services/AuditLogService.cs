using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using SwiftPay.Services.Interfaces;
using SwiftPay.Repositories.Interfaces;
using SwiftPay.DTOs.UserCustomerDTO;
using SwiftPay.Domain.Remittance.Entities;

namespace SwiftPay.Services
{
    public class AuditLogService : IAuditLogService
    {
        private readonly IAuditLogRepository _repo;
        private readonly IMapper _mapper;

        public AuditLogService(IAuditLogRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<AuditLog> LogActionAsync(int userId, string action, string resource)
        {
            var auditLog = new AuditLog
            {
                UserID = userId,
                Action = action,
                Resource = resource,
                // Timestamp and audit fields (CreatedAt, UpdatedAt, IsDeleted) are configured 
                // in database configuration with default values
            };

            return await _repo.CreateAsync(auditLog);
        }

        public async Task<AuditLog> GetByIdAsync(int auditId)
        {
            return await _repo.GetByIdAsync(auditId);
        }

        public async Task<IEnumerable<AuditLog>> GetByUserIdAsync(int userId)
        {
            return await _repo.GetByUserIdAsync(userId);
        }

        public async Task<IEnumerable<AuditLog>> GetByResourceAsync(string resource)
        {
            return await _repo.GetByResourceAsync(resource);
        }

        public async Task<IEnumerable<AuditLog>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<IEnumerable<AuditLog>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _repo.GetByDateRangeAsync(startDate, endDate);
        }

        public async Task<bool> DeleteAsync(int auditId)
        {
            return await _repo.DeleteAsync(auditId);
        }
    }
}
