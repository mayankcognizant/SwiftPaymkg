using System;
using System.ComponentModel.DataAnnotations;
using SwiftPay.Constants.Enums;

namespace SwiftPay.DTOs.UserCustomerDTO
{
    public class CreateNotificationDto
    {
        [Required(ErrorMessage = "UserID is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "UserID must be a valid positive integer.")]
        public int UserID { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "RemitID must be a valid positive integer or null.")]
        public int? RemitID { get; set; }

        [Required(ErrorMessage = "Message is required.")]
        [StringLength(1000, MinimumLength = 5, ErrorMessage = "Message must be between 5 and 1000 characters.")]
        public string Message { get; set; }

        [Required(ErrorMessage = "Category is required.")]
        public NotificationCategory Category { get; set; }
    }

    public class UpdateNotificationDto
    {
        [StringLength(1000, ErrorMessage = "Message cannot exceed 1000 characters.")]
        public string? Message { get; set; }

        public NotificationCategory? Category { get; set; }
    }

    public class NotificationResponseDto
    {
        public int NotificationID { get; set; }

        public int UserID { get; set; }

        public int? RemitID { get; set; }

        public string Message { get; set; }

        public NotificationCategory Category { get; set; }

        public NotificationStatus Status { get; set; }

        public DateTime? ReadAt { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
