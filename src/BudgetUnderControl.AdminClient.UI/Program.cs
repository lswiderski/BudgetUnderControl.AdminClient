using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BudgetUnderControl.AdminClient.Core;
using BudgetUnderControl.AdminClient.UI.Services;
using TabBlazor;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace BudgetUnderControl.AdminClient.UI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCore();
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddScoped<IApiResponseHandler, ApiResponseHandler>();
            builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
            //builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            var baseAddress = builder.Configuration.GetValue<string>("APIUrl");
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(baseAddress) });
            builder.Services.AddTabler();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");
            await app.RunAsync();
            var authenticationService = app.Services.GetRequiredService<IAuthenticationService>();
            await authenticationService.InitializeAsync();
            
        }
    }
}
