//-------------------------------------------------------------------------------------------------
// Name        : ProductSaleSummaryDTO
// Type        : Class
// Author      : Kevin McGregor
// History     : 31-Mar-25 - Created
// Description :
// Copyright   : This is the property of Escape Software Solutions Limited and cannot be used, 
//               copied or modified without the express permission of the company in 
//               in writing. Copyright 2025 Escape Software Solutions Limited.
//-------------------------------------------------------------------------------------------------
using System.ComponentModel.DataAnnotations;

namespace ProductSales.Application.DTOs;

public class ProductSaleSummaryDTO
{
    public int SaleId { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "SegmentId is required >= 1.")]
    public int SegmentId { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "CountryId is required >= 1.")]
    public int CountryId { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "ProductId is required >= 1.")]
    public int ProductId { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "DiscountId is required >= 1.")]
    public int DiscountId { get; set; }

    public decimal? UnitsSold { get; set; }

    public decimal? ManufacturingPrice { get; set; }

    public decimal? SalePrice { get; set; }

    [Required(ErrorMessage = "Created Date is required.")]
    public DateOnly CreatedDate { get; set; }
}
