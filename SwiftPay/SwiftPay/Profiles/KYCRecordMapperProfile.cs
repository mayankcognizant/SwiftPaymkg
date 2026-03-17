using AutoMapper;
using SwiftPay.DTOs.UserCustomerDTO;
using SwiftPay.Domain.Remittance.Entities;

namespace SwiftPay.Profiles
{
    public class KYCRecordMapperProfile : Profile
    {
        public KYCRecordMapperProfile()
        {
            // Map CreateKYCRecordDto -> KYCRecord
            CreateMap<CreateKYCRecordDto, KYCRecord>()
                .ForMember(dest => dest.KYCID, opt => opt.Ignore())
                // VerificationStatus uses database default - don't set from mapper
                .ForMember(dest => dest.VerificationStatus, opt => opt.Ignore())
                .ForMember(dest => dest.VerifiedDate, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.IsDeleted, opt => opt.Ignore())
                .ForMember(dest => dest.User, opt => opt.Ignore());

            // Map UpdateKYCRecordDto -> KYCRecord (partial update)
            CreateMap<UpdateKYCRecordDto, KYCRecord>()
                .ForMember(dest => dest.KYCID, opt => opt.Ignore())
                .ForMember(dest => dest.UserID, opt => opt.Ignore())
                .ForMember(dest => dest.VerificationStatus, opt => opt.Ignore())
                .ForMember(dest => dest.VerifiedDate, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.IsDeleted, opt => opt.Ignore())
                .ForMember(dest => dest.User, opt => opt.Ignore());

            // Map KYCRecord -> KYCRecordResponseDto
            CreateMap<KYCRecord, KYCRecordResponseDto>()
                .ForMember(dest => dest.KYCID, opt => opt.MapFrom(src => src.KYCID))
                .ForMember(dest => dest.UserID, opt => opt.MapFrom(src => src.UserID))
                .ForMember(dest => dest.KYCLevel, opt => opt.MapFrom(src => src.KYCLevel))
                .ForMember(dest => dest.VerificationStatus, opt => opt.MapFrom(src => src.VerificationStatus))
                .ForMember(dest => dest.VerifiedDate, opt => opt.MapFrom(src => src.VerifiedDate))
                .ForMember(dest => dest.Notes, opt => opt.MapFrom(src => src.Notes))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => src.UpdatedAt));
        }
    }
}
