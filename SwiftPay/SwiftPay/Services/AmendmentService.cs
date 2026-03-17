using AutoMapper;
using SwiftPay.Domain.Remittance.Entities;
using SwiftPay.DTOs.AmendmentDTO;
using SwiftPay.Repositories.Interfaces;
using SwiftPay.Services.Interfaces;
using System.Threading.Tasks;

namespace SwiftPay.Services
{
    public class AmendmentService : IAmendmentService
    {
        private readonly IAmendmentRepository _repo;
        private readonly IMapper _mapper;

        public AmendmentService(IAmendmentRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<Amendment> CreateAsync(CreateAmendmentDto dto)
        {
            // Use AutoMapper to map DTO to entity
            var entity = _mapper.Map<Amendment>(dto);

            // Persist to database via repository
            var created = await _repo.CreateAsync(entity);

            return created;
        }
    }
}