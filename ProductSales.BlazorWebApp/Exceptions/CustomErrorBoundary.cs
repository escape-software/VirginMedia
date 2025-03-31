//-------------------------------------------------------------------------------------------------
// Name        : CustomErrorBoundary
// Type        : Class
// Author      : Kevin McGregor
// History     : 31-Mar-25 - Created
// Description :
// Copyright   : This is the property of Escape Software Solutions Limited and cannot be used, 
//               copied or modified without the express permission of the company in 
//               in writing. Copyright 2025 Escape Software Solutions Limited.
//-------------------------------------------------------------------------------------------------
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace ProductSales.BlazorWebApp.Exceptions;

/// <summary>
/// Custom ErrorBoundary class to override default functionality depending on current environ.
/// </summary>
public class CustomErrorBoundary : ErrorBoundary
{
    [Inject]
    private IWebAssemblyHostEnvironment? env { get; set; }

    protected override Task OnErrorAsync(Exception exception)
    {
        if (env!.IsDevelopment())
        {
            // Only log exception details to console in dev environ.
            return base.OnErrorAsync(exception);
        }
        else
        {
            return Task.CompletedTask;
        }
    }
}
