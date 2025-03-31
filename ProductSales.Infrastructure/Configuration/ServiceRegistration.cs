//-------------------------------------------------------------------------------------------------
// Name        : ServiceRegistration
// Type        : Class
// Author      : Kevin McGregor
// History     : 31-Mar-25 - Created
// Description :
// Copyright   : This is the property of Escape Software Solutions Limited and cannot be used, 
//               copied or modified without the express permission of the company in 
//               in writing. Copyright 2025 Escape Software Solutions Limited.
//-------------------------------------------------------------------------------------------------
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductSales.Application.Interfaces;
using ProductSales.Infrastructure.Context;
using ProductSales.Infrastructure.Exceptions;
using ProductSales.Infrastructure.Repositories;

namespace ProductSales.Infrastructure.Configuration;

/// <summary>
/// Register services specific to Infrastructure project.
/// </summary>
public static class ServiceRegistration
{
    public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        string? dbConnString = configuration.GetConnectionString("ProductSalesConnection") ?? throw new InfrastructureException("ProductSales database connection string was not provided in Infrastructure initialisation.");

        // Register ProductSales DbContext service.
        serviceCollection.AddDbContextFactory<ProductSalesDbContext>(options =>
        {
            options.UseSqlServer(dbConnString);
        });

        string? identityDbConnString = configuration.GetConnectionString("IdentityConnection") ?? throw new InfrastructureException("Identity database connection string was not provided in Infrastructure initialisation.");

        // Register ProductSales IdentityDbContext service.
        serviceCollection.AddDbContextFactory<ProductSalesIdentityDbContext>(options =>
        {
            options.UseSqlServer(identityDbConnString);
        });

        // Add repository types.
        serviceCollection.AddScoped<ICountryRepository, CountryRepository>();
        serviceCollection.AddScoped<ISegmentRepository, SegmentRepository>();
        serviceCollection.AddScoped<IDiscountRepository, DiscountRepository>();
        serviceCollection.AddScoped<IProductRepository, ProductRepository>();
        serviceCollection.AddScoped<IProductSaleSummaryRepository, ProductSaleSummaryRepository>();

        return serviceCollection;
    }
}
