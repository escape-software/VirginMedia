//-------------------------------------------------------------------------------------------------
// Name        : ImportProductSalesVM
// Type        : Class
// Author      : Kevin McGregor
// History     : 31-Mar-25 - Created
// Description :
// Copyright   : This is the property of Escape Software Solutions Limited and cannot be used, 
//               copied or modified without the express permission of the company in 
//               in writing. Copyright 2025 Escape Software Solutions Limited.
//-------------------------------------------------------------------------------------------------
using ExcelMapper;
using System.ComponentModel.DataAnnotations;

namespace ProductSales.BlazorWebApp.ViewModels;

/// <summary>
/// ImportProductSales view model used to map imported data rows from product sales spreadsheet.
/// </summary>
public class ImportProductSalesVM
{
    public ImportProductSalesVM() 
    {
        ProductName = "";
        SegmentName = "";
        CountryName = "";
        DiscountName = "";
        IsEnabled = false; // Set to true if ImportProductSalesVM passes import validation.
        IsImported = false; // Set to true if ProductSaleSummary with import data created in database.
    }

    [ExcelIgnore]
    public int RowId { get; set; }

    [ExcelIgnore]
    public int ProductId { get; set; }

    [ExcelColumnName("Product")]
    public string ProductName { get; set; }

    [ExcelIgnore]
    public int SegmentId { get; set; }

    [ExcelColumnName("Segment")]
    public string SegmentName { get; set; }

    [ExcelIgnore]
    public int CountryId { get; set; }

    [ExcelColumnName("Country")]
    public string CountryName { get; set; }

    [ExcelIgnore]
    public int DiscountId { get; set; }

    [ExcelColumnName("Discount")]
    public string DiscountName { get; set; }

    [ExcelColumnName("Units Sold")]
    public double UnitsSold { get; set; }

    [ExcelColumnName("Manufacturing Price")]
    public double ManufacturingPrice { get; set; }

    [ExcelColumnName("Sale Price")]
    public double SalePrice { get; set; }

    [ExcelColumnName("Date")]
    public DateOnly CreatedDate {  get; set; }

    [ExcelIgnore]
    public string? SaleDate { get; set; }

    [ExcelIgnore]
    public bool IsEnabled { get; set; }

    [ExcelIgnore]
    public bool IsImported { get; set; }
}
