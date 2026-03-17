using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SwiftPay.Repositories.Interfaces;
using SwiftPay.Configuration;
using SwiftPay.Constants.Enums;
using SwiftPay.Domain.Notification.Entities;

namespace SwiftPay.Repositories
{
    public class NotificationAlertRepository : INotificationAlertRepository
    {
        private readonly AppDbContext _db;

        public NotificationAlertRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<NotificationAlert> CreateAsync(NotificationAlert entity)
        {
            await _db.Set<NotificationAlert>().AddAsync(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<NotificationAlert> GetByIdAsync(int notificationId)
        {
            return await _db.Set<NotificationAlert>()
                .Include(n => n.User)
                .FirstOrDefaultAsync(n => n.NotificationID == notificationId && !n.IsDeleted);
        }

        public async Task<IEnumerable<NotificationAlert>> GetByUserIdAsync(int userId)
        {
            return await _db.Set<NotificationAlert>()
                .Include(n => n.User)
                .Where(n => n.UserID == userId && !n.IsDeleted)
                .OrderByDescending(n => n.CreatedAt)
                .ToListAsync();
        }

        public async Task<IEnumerable<NotificationAlert>> GetUnreadByUserIdAsync(int userId)
        {
            return await _db.Set<NotificationAlert>()
                .Include(n => n.User)
                .Where(n => n.UserID == userId && n.Status == NotificationStatus.Unread && !n.IsDeleted)
                .OrderByDescending(n => n.CreatedAt)
                .ToListAsync();
        }

        public async Task<IEnumerable<NotificationAlert>> GetAllAsync()
        {
            return await _db.Set<NotificationAlert>()
                .Include(n => n.User)
                .Where(n => !n.IsDeleted)
                .OrderByDescending(n => n.CreatedAt)
                .ToListAsync();
        }

        public async Task<NotificationAlert> UpdateAsync(NotificationAlert entity)
        {
            _db.Set<NotificationAlert>().Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(int notificationId)
        {
            var notification = await GetByIdAsync(notificationId);
            if (notification == null)
                return false;

            notification.IsDeleted = true;
            notification.UpdatedAt = DateTime.UtcNow;
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
