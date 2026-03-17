using System;
using System.Collections.Generic;
using SwiftPay.Constants.Enums;
using SwiftPay.Models;

namespace SwiftPay.DTOs.UserCustomerDTO
{
    // DTO for user response data
    public class UserResponseDto
    {
        public int UserId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public UserStatus Status { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        // Include user roles for frontend permission handling
        public ICollection<UserRoleDto> Roles { get; set; } = new List<UserRoleDto>();
    }

    // DTO for role information in user response
    public class UserRoleDto
    {
        public int UserRoleId { get; set; }

        public int RoleId { get; set; }

        public RoleType RoleType { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
