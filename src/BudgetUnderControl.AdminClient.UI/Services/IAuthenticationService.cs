using System.Threading.Tasks;
using BudgetUnderControl.AdminClient.Core.Models;

namespace BudgetUnderControl.AdminClient.UI.Services
{
    public interface IAuthenticationService
    {
        UserIdentity User { get; }
        Task InitializeAsync();
        Task<bool?> SignInAsync(string email, string password);
        Task SignOutAsync();
        Task LoadUserIdentityAsync();
    }
}