using SwiftPay.Domain.Remittance.Entities;

namespace SwiftPay.Repositories.Interfaces
{
    public interface IAmendmentRepository
    {
        Task<Amendment> CreateAsync(Amendment entity);
    }
}