using SwiftPay.Domain.Remittance.Entities;
using SwiftPay.DTOs.AmendmentDTO;

namespace SwiftPay.Services.Interfaces
{
    public interface IAmendmentService
    {
        Task<Amendment> CreateAsync(CreateAmendmentDto dto);
    }
}