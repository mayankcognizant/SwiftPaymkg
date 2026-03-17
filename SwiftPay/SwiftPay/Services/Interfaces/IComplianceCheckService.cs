using System.Threading.Tasks;
using SwiftPay.DTOs.ComplianceDTO;
using SwiftPay.Domain.Remittance.Entities;

namespace SwiftPay.Services.Interfaces
{
    public interface IComplianceCheckService
    {
        Task<ComplianceCheck> CreateAsync(CreateComplianceCheckDto dto);
    }
}