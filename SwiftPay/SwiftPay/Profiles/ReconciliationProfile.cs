using AutoMapper;
using SwiftPay.DTOs.ReconciliationDTO;
using SwiftPay.Models;

namespace SwiftPay.Profiles
{
    public class ReconciliationProfile : Profile
    {
        public ReconciliationProfile()
        {
            CreateMap<CreateReconciliationDto, ReconciliationRecord>()
                .ForMember(dest => dest.ReconID, opt => opt.Ignore())
                .ForMember(dest => dest.Result, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedDate, opt => opt.Ignore())
                .ForMember(dest => dest.UpdateDate, opt => opt.Ignore())
                .ForMember(dest => dest.IsDeleted, opt => opt.Ignore());
        }
    }
}
