//-------------------------------------------------------------------------------------------------
// Name        : ProductSaleSummary
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

public partial class ProductSaleSummary
{
    public int SaleId { get; set; }

    public int SegmentId { get; set; }

    public int CountryId { get; set; }

    public int ProductId { get; set; }

    public int DiscountId { get; set; }

    public decimal? UnitsSold { get; set; }

    public decimal? ManufacturingPrice { get; set; }

    public decimal? SalePrice { get; set; }

    public DateOnly CreatedDate { get; set; }

    public virtual Country Country { get; set; } = null!;

    public virtual Discount Discount { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;

    public virtual Segment Segment { get; set; } = null!;
}
