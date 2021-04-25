using System.Threading.Tasks;
using BudgetUnderControl.AdminClient.Core.Models;
using BudgetUnderControl.AdminClient.Core.Storage;
using BudgetUnderControl.AdminClient.Core.Users;
using BudgetUnderControl.AdminClient.Core.Users.Requests;
using Microsoft.AspNetCore.Components;

namespace BudgetUnderControl.AdminClient.UI.Services
{
    internal class AuthenticationService : IAuthenticationService
    {
        private readonly IUserService _userService;
        private readonly ILocalStorageService _localStorageService;
        private readonly NavigationManager _navigationManager;

        public UserIdentity User { get; private set; }

        public AuthenticationService(IUserService userService, ILocalStorageService localStorageService,
            NavigationManager navigationManager)
        {
            _userService = userService;
            _localStorageService = localStorageService;
            _navigationManager = navigationManager;
        }

        public async Task InitializeAsync()
        {
            User = await _localStorageService.GetItemAsync<UserIdentity>("user");
        }

        public async Task<bool?> SignInAsync(string username, string password)
        {
            var response = await _userService.SignInAsync(new SignInRequest
            {
                Username = username,
                Password = password
            });

            if (response?.HttpResponse is null)
            {
                return null;
            }

            if (!response.Succeeded)
            {
                return false;
            }

            await _localStorageService.SetItemAsync("jwt-token", response.Value.AccessToken);

            return true;
        }

        public async Task SignOutAsync()
        {
            User = null;
            await _localStorageService.RemoveItemAsync("user");
            await _localStorageService.RemoveItemAsync("jwt-token");
            _navigationManager.NavigateTo("sign-in");
        }

        public async Task LoadUserIdentityAsync()
        {
            var response = await _userService.GetUserIdentityAsync();

            User = new UserIdentity
            {
                UserId = response.Value.UserId,
                Email = response.Value.Email,
                Username = response.Value.Username,
                FirstName = response.Value.FirstName,
                LastName = response.Value.LastName,
                CreatedAt = response.Value.CreatedAt,
                IsActivated = response.Value.IsActivated,
                IsAdmin = response.Value.IsAdmin,
                IsDeleted = response.Value.IsDeleted,
                ModifiedOn = response.Value.ModifiedOn,
                Role = response.Value.Role,
                RoleName = response.Value.RoleName,
            };
            await _localStorageService.SetItemAsync("user", User);


        }
    }
}