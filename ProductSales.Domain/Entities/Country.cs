//-------------------------------------------------------------------------------------------------
// Name        : Country
// Type        : Class
// Author      : Kevin McGregor
// History     : 31-Mar-25 - Created
// Description :
// Copyright   : This is the property of Escape Software Solutions Limited and cannot be used, 
//               copied or modified without the express permission of the company in 
//               in writing. Copyright 2025 Escape Software Solutions Limited.
//-------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace ProductSales.Domain.Entities;

public partial class Country
{
    public int CountryId { get; set; }

    public string? CountryName { get; set; }

    public virtual ICollection<ProductSaleSummary> ProductSaleSummaries { get; set; } = new List<ProductSaleSummary>();
}
