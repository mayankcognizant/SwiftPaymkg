using AutoMapper;
using SwiftPay.Constants.Enums;
using SwiftPay.Domain.Notification.Entities;
using SwiftPay.DTOs.UserCustomerDTO;
using SwiftPay.Repositories.Interfaces;
using SwiftPay.Services.Interfaces;

namespace SwiftPay.Services
{
	public class NotificationAlertService : INotificationAlertService
	{
		private readonly INotificationAlertRepository _repo;
		private readonly IUserRepository _userRepo;
		private readonly IMapper _mapper;

		public NotificationAlertService(INotificationAlertRepository repo, IUserRepository userRepo, IMapper mapper)
		{
			_repo = repo;
			_userRepo = userRepo;
			_mapper = mapper;
		}

		public async Task<NotificationAlert> CreateAsync(CreateNotificationDto dto)
		{
			// Validate that User exists
			var user = await _userRepo.GetByIdAsync(dto.UserID);
			if (user == null)
				throw new Exception($"User with ID {dto.UserID} does not exist. Cannot create notification without a valid user.");

			// Use AutoMapper to map DTO to entity
			var entity = _mapper.Map<NotificationAlert>(dto);

			// Audit fields and defaults are configured in database configuration
			// Status is set by DB default (NotificationStatus.Unread)

			var created = await _repo.CreateAsync(entity);
			return created;
		}

		public async Task<NotificationAlert> GetByIdAsync(int notificationId)
		{
			return await _repo.GetByIdAsync(notificationId);
		}

		public async Task<IEnumerable<NotificationAlert>> GetByUserIdAsync(int userId)
		{
			return await _repo.GetByUserIdAsync(userId);
		}

		public async Task<IEnumerable<NotificationAlert>> GetUnreadByUserIdAsync(int userId)
		{
			return await _repo.GetUnreadByUserIdAsync(userId);
		}

		public async Task<IEnumerable<NotificationAlert>> GetAllAsync()
		{
			return await _repo.GetAllAsync();
		}

		public async Task<NotificationAlert> MarkAsReadAsync(int notificationId)
		{
			var notification = await _repo.GetByIdAsync(notificationId);
			if (notification == null)
				throw new Exception($"Notification with ID {notificationId} not found");

			notification.Status = NotificationStatus.Read;
			notification.ReadAt = DateTime.UtcNow;
			notification.UpdatedAt = DateTime.UtcNow;

			var updated = await _repo.UpdateAsync(notification);
			return updated;
		}

		public async Task<IEnumerable<NotificationAlert>> MarkAllAsReadAsync(int userId)
		{
			var notifications = (await _repo.GetUnreadByUserIdAsync(userId)).ToList();

			foreach (var notification in notifications)
			{
				notification.Status = NotificationStatus.Read;
				notification.ReadAt = DateTime.UtcNow;
				notification.UpdatedAt = DateTime.UtcNow;
				await _repo.UpdateAsync(notification);
			}

			return notifications;
		}

		public async Task<bool> DeleteAsync(int notificationId)
		{
			return await _repo.DeleteAsync(notificationId);
		}
	}
}
