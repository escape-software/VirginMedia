//-------------------------------------------------------------------------------------------------
// Name        : ApplicationUser
// Type        : Class
// Author      : Kevin McGregor
// History     : 31-Mar-25 - Created
// Description :
// Copyright   : This is the property of Escape Software Solutions Limited and cannot be used, 
//               copied or modified without the express permission of the company in 
//               in writing. Copyright 2025 Escape Software Solutions Limited.
//-------------------------------------------------------------------------------------------------
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ProductSales.Infrastructure.Identity;

public class ApplicationUser : IdentityUser
{
    /// <summary>
    /// Indicates whether the account is enabled or not.
    /// </summary>
    public bool ProfileEnabled { get; set; }

    [StringLength(36)]
    public string? AuthToken { get; set; }

    public DateTime? AuthTokenExpiryTime { get; set; }
}
