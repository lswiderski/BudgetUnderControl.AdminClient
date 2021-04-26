using BudgetUnderControl.AdminClient.Core.Users.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetUnderControl.AdminClient.Core.Users.Requests
{
    public class UpdateUserRequest
    {
        public UpdateUserRequest(string username, string firstname, string lastname, UserRole role, string email, Guid userId, bool isActivated)
        {
            Username = username;
            FirstName = firstname;
            LastName = lastname;
            Role = role;
            Email = email;
            UserId = userId;
            IsActivated = isActivated;
        }


        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserRole Role { get; set; }
        public string Email { get; set; }
        public Guid UserId { get; set; }
        public bool IsActivated { get; set; }
    }
}
