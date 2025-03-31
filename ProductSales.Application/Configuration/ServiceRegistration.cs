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
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ProductSales.Application.Behaviours;
using ProductSales.Application.Mapper;
using System.Reflection;

namespace ProductSales.Application.Configuration
{
    /// <summary>
    /// Register services specific to Application project.
    /// </summary>
    public static class ServiceRegistration
    {
        public static IServiceCollection RegisterApplicationServices(this IServiceCollection serviceCollection)
        {
            // Register all AutoMapper type conversions in Application project.
            serviceCollection.AddTransient<IEntityMapper, EntityMapper>();

            // Register MediatR class types.
            serviceCollection.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            // Register FluentValidation class types.
            serviceCollection.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            serviceCollection.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

            return serviceCollection;
        }
    }
}
