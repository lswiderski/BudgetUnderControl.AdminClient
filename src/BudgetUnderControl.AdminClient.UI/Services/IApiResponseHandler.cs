using System.Threading.Tasks;
using BudgetUnderControl.AdminClient.Core.Clients;

namespace BudgetUnderControl.AdminClient.UI.Services
{
    public interface IApiResponseHandler
    {
        Task<ApiResponse> HandleAsync(Task<ApiResponse> request);
        Task<T> HandleAsync<T>(Task<ApiResponse<T>> request);
    }
}