using AutoMapper;
using SwiftPay.DTOs.UserCustomerDTO;
using SwiftPay.Domain.Notification.Entities;

namespace SwiftPay.Profiles
{
    public class NotificationAlertMapperProfile : Profile
    {
        public NotificationAlertMapperProfile()
        {
            // Map CreateNotificationDto -> NotificationAlert
            CreateMap<CreateNotificationDto, NotificationAlert>()
                .ForMember(dest => dest.NotificationID, opt => opt.Ignore())
                // Status uses database default - don't set from mapper
                .ForMember(dest => dest.Status, opt => opt.Ignore())
                .ForMember(dest => dest.ReadAt, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.IsDeleted, opt => opt.Ignore())
                .ForMember(dest => dest.User, opt => opt.Ignore());

            // Map UpdateNotificationDto -> NotificationAlert (partial update)
            CreateMap<UpdateNotificationDto, NotificationAlert>()
                .ForMember(dest => dest.NotificationID, opt => opt.Ignore())
                .ForMember(dest => dest.UserID, opt => opt.Ignore())
                .ForMember(dest => dest.RemitID, opt => opt.Ignore())
                .ForMember(dest => dest.Status, opt => opt.Ignore())
                .ForMember(dest => dest.ReadAt, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.IsDeleted, opt => opt.Ignore())
                .ForMember(dest => dest.User, opt => opt.Ignore());

            // Map NotificationAlert -> NotificationResponseDto
            CreateMap<NotificationAlert, NotificationResponseDto>()
                .ForMember(dest => dest.NotificationID, opt => opt.MapFrom(src => src.NotificationID))
                .ForMember(dest => dest.UserID, opt => opt.MapFrom(src => src.UserID))
                .ForMember(dest => dest.RemitID, opt => opt.MapFrom(src => src.RemitID))
                .ForMember(dest => dest.Message, opt => opt.MapFrom(src => src.Message))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.ReadAt, opt => opt.MapFrom(src => src.ReadAt))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => src.UpdatedAt));
        }
    }
}
