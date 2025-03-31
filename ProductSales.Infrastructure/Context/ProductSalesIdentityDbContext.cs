//-------------------------------------------------------------------------------------------------
// Name        : ProductSalesIdentityDbContext
// Type        : Class
// Author      : Kevin McGregor
// History     : 31-Mar-25 - Created
// Description :
// Copyright   : This is the property of Escape Software Solutions Limited and cannot be used, 
//               copied or modified without the express permission of the company in 
//               in writing. Copyright 2025 Escape Software Solutions Limited.
//-------------------------------------------------------------------------------------------------
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProductSales.Infrastructure.Identity;

namespace ProductSales.Infrastructure.Context;

/// <summary>
/// Configure the EF DbContext class used for Identity.
/// IdentityUser is the default implementation. To include custom properties in the corresponding IdentityUser table create 
/// a new user class which inherits from IdentityUser.
/// 'string' parameter indicates the data type of the primary key used for users and roles.
/// </summary>
public partial class ProductSalesIdentityDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
{
    private readonly ILogger<ProductSalesIdentityDbContext> _logger;

    public ProductSalesIdentityDbContext(DbContextOptions<ProductSalesIdentityDbContext> options, ILogger<ProductSalesIdentityDbContext> logger) : base(options)
    {
        _logger = logger;
    }

    /// <summary>
    /// Configure the IdentityDbContext to use SQLServer database for Identity tables.
    /// </summary>
    /// <param name="optionsBuilder"></param>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        => optionsBuilder.UseSqlServer("Name=IdentityConnection");


    /// <summary>
    /// Create the Identity DbContext model and apply initial seed data if enabled.
    /// </summary>
    /// <param name="builder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        try
        {
            // Apply seed data when creating the data model.
            //builder.Seed();
            base.OnModelCreating(modelBuilder);

            _logger.LogInformation("Created Product Sales Identity tables.");

            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while attempting to create ProductSales Identity tables.");
        }
    }
}
