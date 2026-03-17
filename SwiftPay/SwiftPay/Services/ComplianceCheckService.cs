using System.Threading.Tasks;
using AutoMapper;
using SwiftPay.Services.Interfaces;
using SwiftPay.Repositories.Interfaces;
using SwiftPay.DTOs.ComplianceDTO;
using SwiftPay.Domain.Remittance.Entities;

namespace SwiftPay.Services
{
    public class ComplianceCheckService : IComplianceCheckService
    {
        private readonly IComplianceCheckRepository _repo;
        private readonly IMapper _mapper;

        public ComplianceCheckService(IComplianceCheckRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<ComplianceCheck> CreateAsync(CreateComplianceCheckDto dto)
        {
            // 1. Map the DTO (the form) to the Entity (the database row)
            var entity = _mapper.Map<ComplianceCheck>(dto);

            // 2. Set the "System" fields that the user shouldn't touch
            entity.CreatedDate = System.DateTime.UtcNow;
            entity.UpdateDate = System.DateTime.UtcNow;
            entity.IsDeleted = false;

            // 3. Tell the Repository to save it to SQL Server
            var created = await _repo.CreateAsync(entity);

            return created;
        }
    }
}