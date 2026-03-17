using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SwiftPay.Domain.Notification.Entities;

namespace SwiftPay.Repositories.Interfaces
{
    public interface INotificationAlertRepository
    {
        Task<NotificationAlert> CreateAsync(NotificationAlert entity);
        Task<NotificationAlert> GetByIdAsync(int notificationId);
        Task<IEnumerable<NotificationAlert>> GetByUserIdAsync(int userId);
        Task<IEnumerable<NotificationAlert>> GetUnreadByUserIdAsync(int userId);
        Task<IEnumerable<NotificationAlert>> GetAllAsync();
        Task<NotificationAlert> UpdateAsync(NotificationAlert entity);
        Task<bool> DeleteAsync(int notificationId);
    }
}
