//-------------------------------------------------------------------------------------------------
// Name        : ServerHostEnvironment
// Type        : Class
// Author      : Kevin McGregor
// History     : 31-Mar-25 - Created
// Description :
// Copyright   : This is the property of Escape Software Solutions Limited and cannot be used, 
//               copied or modified without the express permission of the company in 
//               in writing. Copyright 2025 Escape Software Solutions Limited.
//-------------------------------------------------------------------------------------------------
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Components;

namespace ProductSales.BlazorWebApp.Configuration;

/// <summary>
/// Custom service implementation for IWebAssemblyHostEnvironment on the server.
/// Allows components and classes to access the current host environment after injecting IWebAssemblyHostEnvironment.
/// </summary>
/// <param name="env"></param>
/// <param name="nav"></param>
public class ServerHostEnvironment(IWebHostEnvironment env, NavigationManager nav) : IWebAssemblyHostEnvironment
{
    public string Environment => env.EnvironmentName;

    public string BaseAddress => nav.BaseUri;
}
