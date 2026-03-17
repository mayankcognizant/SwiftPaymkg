using System.Collections.Generic;
using System.Threading.Tasks;
using SwiftPay.Domain.Notification.Entities;
using SwiftPay.DTOs.UserCustomerDTO;

namespace SwiftPay.Services.Interfaces
{
    public interface INotificationAlertService
    {
        Task<NotificationAlert> CreateAsync(CreateNotificationDto dto);
        Task<NotificationAlert> GetByIdAsync(int notificationId);
        Task<IEnumerable<NotificationAlert>> GetByUserIdAsync(int userId);
        Task<IEnumerable<NotificationAlert>> GetUnreadByUserIdAsync(int userId);
        Task<IEnumerable<NotificationAlert>> GetAllAsync();
        Task<NotificationAlert> MarkAsReadAsync(int notificationId);
        Task<IEnumerable<NotificationAlert>> MarkAllAsReadAsync(int userId);
        Task<bool> DeleteAsync(int notificationId);
    }
}
