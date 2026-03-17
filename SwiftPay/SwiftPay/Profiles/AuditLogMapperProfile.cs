using AutoMapper;
using SwiftPay.DTOs.UserCustomerDTO;
using SwiftPay.Domain.Remittance.Entities;

namespace SwiftPay.Profiles
{
    public class AuditLogMapperProfile : Profile
    {
        public AuditLogMapperProfile()
        {
            // Note: AuditLog is created directly in services without DTO mapping
            // This profile is only used for response mapping

            // Map AuditLog -> AuditLogResponseDto
            CreateMap<AuditLog, AuditLogResponseDto>()
                .ForMember(dest => dest.AuditID, opt => opt.MapFrom(src => src.AuditID))
                .ForMember(dest => dest.UserID, opt => opt.MapFrom(src => src.UserID))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.Name))
                .ForMember(dest => dest.Action, opt => opt.MapFrom(src => src.Action))
                .ForMember(dest => dest.Resource, opt => opt.MapFrom(src => src.Resource))
                .ForMember(dest => dest.Timestamp, opt => opt.MapFrom(src => src.Timestamp))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt));
        }
    }
}
