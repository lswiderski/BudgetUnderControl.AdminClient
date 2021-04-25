using BudgetUnderControl.AdminClient.Core.Clients;
using BudgetUnderControl.AdminClient.Core.Storage;
using BudgetUnderControl.AdminClient.Core.Users;
using BudgetUnderControl.AdminClient.Core.Users.Services.UserService;
using Microsoft.Extensions.DependencyInjection;

namespace BudgetUnderControl.AdminClient.Core
{
    public static class Extensions
    {
        public static IServiceCollection AddCore(this IServiceCollection services)
        {
            services.AddScoped<IHttpClient, CustomHttpClient>();
            services.AddScoped<ILocalStorageService, LocalStorageService>();
            services.AddScoped<IUserService, UserService>();
            return services;
        }
    }
}