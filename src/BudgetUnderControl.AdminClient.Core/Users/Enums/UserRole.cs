using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetUnderControl.AdminClient.Core.Users.Enums
{
    public enum UserRole : int
    {
        User = 1,

        LimitedUser = 2,

        PremiumUser = 3,

        Admin = 99
    }
}
