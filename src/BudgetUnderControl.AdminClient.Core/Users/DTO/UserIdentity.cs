using BudgetUnderControl.AdminClient.Core.Users.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetUnderControl.AdminClient.Core.Users.DTO
{
    public class UserIdentity
    {
        public Guid UserId { get; set; }

        public UserRole Role { get; set; }

        public bool IsAdmin { get; set; }

        public string RoleName { get; set; }

        public bool IsActivated { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public DateTime CreatedAt { get; set; }

        public string Username { get; set; }

        public bool IsDeleted { get; set; }
    }
}
