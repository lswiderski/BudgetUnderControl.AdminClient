using System.Net;
using System.Threading.Tasks;
using BudgetUnderControl.AdminClient.Core.Clients;

namespace BudgetUnderControl.AdminClient.UI.Services
{
    internal class ApiResponseHandler : IApiResponseHandler
    {
        private readonly IAuthenticationService _authenticationService;

        public ApiResponseHandler( IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public async Task<ApiResponse> HandleAsync(Task<ApiResponse> request)
        {
            var response = await request;
            if (response.Succeeded)
            {
                return response;
            }

            await HandleErrorAsync(response);
            return default;
        }

        public async Task<T> HandleAsync<T>(Task<ApiResponse<T>> request)
        {
            var response = await request;
            if (response.Succeeded)
            {
                return response.Value;
            }

            await HandleErrorAsync(response);
            return default;
        }

        private async Task HandleErrorAsync(ApiResponse response)
        {
            if (response.HttpResponse.StatusCode == HttpStatusCode.Unauthorized)
            {
                await _authenticationService.SignOutAsync();
                return;
            }

            if (response.Errors?.Errors is {})
            {
                foreach (var error in response.Errors.Errors)
                {
                    
                }
            }
        }
    }
}