//-------------------------------------------------------------------------------------------------
// Name        : ProductSaleSummaryVM
// Type        : Class
// Author      : Kevin McGregor
// History     : 31-Mar-25 - Created
// Description :
// Copyright   : This is the property of Escape Software Solutions Limited and cannot be used, 
//               copied or modified without the express permission of the company in 
//               in writing. Copyright 2025 Escape Software Solutions Limited.
//-------------------------------------------------------------------------------------------------
using ProductSales.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace ProductSales.BlazorWebApp.ViewModels;

public class ProductSaleSummaryVM
{
    [Required(ErrorMessage = "Sale Id is required.")]
    public int SaleId { get; set; }

    [Required(ErrorMessage = "Segment Id is required.")]
    public int SegmentId { get; set; }

    [Required(ErrorMessage = "Country Id is required.")]
    public int CountryId { get; set; }

    [Required(ErrorMessage = "Product Id is required.")]
    public int ProductId { get; set; }

    [Required(ErrorMessage = "Discount Id is required.")]
    public int DiscountId { get; set; }

    public decimal? UnitsSold { get; set; }

    public decimal? ManufacturingPrice { get; set; }

    public decimal? SalePrice { get; set; }

    [Required(ErrorMessage = "Created Date is required.")]
    public DateOnly CreatedDate { get; set; }

    public virtual Country Country { get; set; } = null!;

    public virtual Discount Discount { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;

    public virtual Segment Segment { get; set; } = null!;
}
