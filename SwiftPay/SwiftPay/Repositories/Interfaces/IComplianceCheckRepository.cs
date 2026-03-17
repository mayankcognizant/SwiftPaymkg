using System.Threading.Tasks;
using SwiftPay.Domain.Remittance.Entities;

namespace SwiftPay.Repositories.Interfaces
{
    public interface IComplianceCheckRepository
    {
        Task<ComplianceCheck> CreateAsync(ComplianceCheck entity);
    }
}