using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BudgetUnderControl.AdminClient.Core.Clients;
using BudgetUnderControl.AdminClient.Core.Users.DTO;
using BudgetUnderControl.AdminClient.Core.Users.Requests;

namespace BudgetUnderControl.AdminClient.Core.Users
{
    public interface IUserService
    {
        Task<ApiResponse<AuthDto>> SignInAsync(SignInRequest request);

        Task<ApiResponse<UserIdentity>> GetUserIdentityAsync();

        Task<ApiResponse<ICollection<UsersListItemDto>>> GetUsersAsync();

        Task<ApiResponse<UserEditDto>> GetUserAsync(Guid userId);

        Task<ApiResponse> EditUserAsync(UserEditDto user);

        Task<ApiResponse> ResetActivationAsync(Guid userId);
    }
}