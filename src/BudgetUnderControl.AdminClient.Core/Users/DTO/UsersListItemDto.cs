using BudgetUnderControl.AdminClient.Core.Users.Enums;
using System;

namespace BudgetUnderControl.AdminClient.Core.Users.DTO
{
    public class UsersListItemDto
    {
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserRole Role { get; set; }
        public string RoleName { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActivated { get; set; }
        public DateTime? ActivatedOn { get; set; }
    }
}
