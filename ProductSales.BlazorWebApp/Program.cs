//-------------------------------------------------------------------------------------------------
// Name        : Program
// Type        : Class
// Author      : Kevin McGregor
// History     : 31-Mar-25 - Created
// Description :
// Copyright   : This is the property of Escape Software Solutions Limited and cannot be used, 
//               copied or modified without the express permission of the company in 
//               in writing. Copyright 2025 Escape Software Solutions Limited.
//-------------------------------------------------------------------------------------------------
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using ProductSales.Application.Configuration;
using ProductSales.BlazorWebApp.Account;
using ProductSales.BlazorWebApp.Components;
using ProductSales.BlazorWebApp.Configuration;
using ProductSales.BlazorWebApp.Mapper;
using ProductSales.Infrastructure.Configuration;
using ProductSales.Infrastructure.Context;
using ProductSales.Infrastructure.Identity;

namespace ProductSales;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents();

        // Register Application project services.
        builder.Services.RegisterApplicationServices();

        // Register Infrastructure project services.
        builder.Services.RegisterInfrastructureServices(builder.Configuration);

        // Make authentication state available to all components.
        builder.Services.AddCascadingAuthenticationState();

        builder.Services.AddScoped<IdentityUserAccessor>();
        builder.Services.AddScoped<IdentityRedirectManager>();
        builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

        builder.Services.AddAuthentication(options =>
        {
            options.DefaultScheme = IdentityConstants.ApplicationScheme;
            options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
        })
        .AddIdentityCookies();

        // An example of how to configure application cookies to override the Identity defaults. e.g. AccessDenied page.
        builder.Services.ConfigureApplicationCookie(options =>
        {
            options.AccessDeniedPath = "/Account/NoAccess";
        });

        // Register and configure Identity services. Cannot do this fully within Infrastructure services configuration.
        builder.Services.AddIdentityCore<ApplicationUser>(
            options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.User.RequireUniqueEmail = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 8;
            }
            )
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ProductSalesIdentityDbContext>()
            .AddSignInManager()
            .AddDefaultTokenProviders();

        // Register all AutoMapper type conversions used in BlazorWebApp project.
        builder.Services.AddTransient<IViewModelMapper, ViewModelMapper>();

        builder.Services.TryAddScoped<IWebAssemblyHostEnvironment, ServerHostEnvironment>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        // Should re-execute the request pipeline with new URL but displays the original URL in Browser.
        // Should display the StatusCode component with custom content but Blazor instead uses the NotFound component in Routes
        // if provided, else the default middleware for handling HTTP errors is used to display a standard text message.
        app.UseStatusCodePagesWithReExecute("/StatusCode/{0}");

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseAntiforgery();

        app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

        // Add additional endpoints required by the Identity /Account Razor components.
        app.MapAdditionalIdentityEndpoints();

        app.Run();
    }
}
