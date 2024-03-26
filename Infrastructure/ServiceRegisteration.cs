using Infrastructure.Context;
using Infrastructure.Models.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class ServiceRegisteration
{
    public static IServiceCollection AddServiceRegisteration(this IServiceCollection services, IConfiguration configuration)
    {
        // Add services to the container.
        services.AddIdentity<ApplicationUser, IdentityRole>(options =>
        {
            // Configure Identity options if needed
            options.Password.RequireDigit = true;
            options.Password.RequiredLength = 8;
            // Add other options...
        })
        .AddEntityFrameworkStores<AppDbContext>() // Use your DbContext
        .AddDefaultTokenProviders();

        services.AddAuthentication(
            options => {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;

            }
            )

            .AddCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                options.SlidingExpiration = true;
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.LoginPath = "/Account/Login";
                options.LogoutPath = "/Account/Logout";
                options.ReturnUrlParameter = "returnUrl";
            })
            .AddMicrosoftAccount(options =>
            {
                IConfigurationSection googleAuthSection = configuration.GetSection("Authentication:Microsoft");

                options.ClientId = googleAuthSection["ClientId"];
                options.ClientSecret = googleAuthSection["ClientSecret"];
            })
            .AddGoogle(options =>
            {
                IConfigurationSection googleAuthSection = configuration.GetSection("Authentication:Google");

                options.ClientId = googleAuthSection["ClientId"];
                options.ClientSecret = googleAuthSection["ClientSecret"];
            });
        return services;
    }
}