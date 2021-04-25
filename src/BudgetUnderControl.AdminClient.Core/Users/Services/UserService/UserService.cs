using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BudgetUnderControl.AdminClient.Core.Clients;
using BudgetUnderControl.AdminClient.Core.Users.DTO;
using BudgetUnderControl.AdminClient.Core.Users.Requests;

namespace BudgetUnderControl.AdminClient.Core.Users.Services.UserService
{
    internal class UserService : IUserService
    {
        private readonly IHttpClient _client;

        public UserService(IHttpClient client)
        {
            _client = client;
        }

        public Task<ApiResponse<AuthDto>> SignInAsync(SignInRequest request)
            => _client.PostAsync<AuthDto>("api/login/adminAuthenticate", request);

        public Task<ApiResponse<UserIdentity>> GetUserIdentityAsync()
           => _client.GetAsync<UserIdentity>("api/users/identityContext");

        public Task<ApiResponse<ICollection<UsersListItemDto>>> GetUsersAsync()
            => _client.GetAsync<ICollection<UsersListItemDto>>("api/users");

        public Task<ApiResponse<UserEditDto>> GetUserAsync(Guid userId)
           => _client.GetAsync<UserEditDto>($"api/users/{userId}");

        public Task<ApiResponse> EditUserAsync(UserEditDto user)
          => _client.PutAsync($"api/users/{user.UserId}", user);

        public Task<ApiResponse> ResetActivationAsync(Guid userId)
          => _client.PostAsync($"api/users/{userId}/ResetActivation",userId);

    }
}