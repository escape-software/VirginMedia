//-------------------------------------------------------------------------------------------------
// Name        : ImportProductSalesMap
// Type        : Class
// Author      : Kevin McGregor
// History     : 31-Mar-25 - Created
// Description :
// Copyright   : This is the property of Escape Software Solutions Limited and cannot be used, 
//               copied or modified without the express permission of the company in 
//               in writing. Copyright 2025 Escape Software Solutions Limited.
//-------------------------------------------------------------------------------------------------
using ExcelMapper;
using ProductSales.BlazorWebApp.ViewModels;
using System.Globalization;

namespace ProductSales.BlazorWebApp.ExcelMapper;

/// <summary>
/// ExcelImporter mapping class which is used to instruct how to map spreadsheet column cells onto corresponding ImportProductSalesVM properties.
/// Allocation Units cell is converted to an integer. If the cell is empty or conversion fails then 0 is returned.
/// Conversion exceptions should be handled by the WithInvalidFallback method.
/// Note: Date column (USA date format) is mapped to a string property which is subsequently converted to a UK datetime for CreatedDate property 
/// because the ExcelMapper Map function is using the current culture info (en-GB) as the Date column date format when in fact it is en-US.
/// </summary>
public class ImportProductSalesMap : ExcelClassMap<ImportProductSalesVM>
{
    public ImportProductSalesMap()
    {
        try
        {
            Map(item => item.SegmentName).WithColumnIndex(0).WithTrim();
            Map(item => item.CountryName).WithColumnIndex(1).WithTrim();
            Map(item => item.ProductName).WithColumnIndex(2).WithTrim();
            Map(item => item.DiscountName).WithColumnIndex(3).WithTrim();
            Map(item => item.UnitsSold).WithColumnIndex(4).WithConverter(value => ConvertToDouble(value.ToString())).WithEmptyFallback(0).WithInvalidFallback(0);
            Map(item => item.ManufacturingPrice).WithColumnIndex(5).WithConverter(value => ConvertToDouble(value.ToString())).WithEmptyFallback(0).WithInvalidFallback(0);
            Map(item => item.SalePrice).WithColumnIndex(6).WithConverter(value => ConvertToDouble(value.ToString())).WithEmptyFallback(0).WithInvalidFallback(0);
            Map(item => item.SaleDate).WithColumnIndex(7).WithEmptyFallback("01/01/1900").WithInvalidFallback("01/01/1900");
            //Map(item => item.CreatedDate).WithColumnIndex(7).WithConverter(value => ConvertToDateTime(value.ToString().Trim())).WithEmptyFallback(new DateTime(1900, 01, 01)).WithInvalidFallback(new DateTime(1900, 01, 01));
        }
        catch (Exception ex) 
        {
            string temp = ex.Message;
        }
    }

    private double ConvertToDouble(string s)
    {
        double result = 0;
        if (s != null)
        {
            double.TryParse(s, out result);
        }
        return result;
    }

    private DateTime ConvertToDateTime(string s)
    {
        DateTime result = new DateTime(1900,01,01);
        if (s != null)
        {
            try
            {
                var temp = DateTime.ParseExact(s.Trim(), "MM/dd/yyyy", new CultureInfo("en-US"));
                result = DateTime.ParseExact(temp.ToString("dd/MM/yyyy"), "dd/MM/yyyy", new CultureInfo("en-GB"));

                //result = DateTime.ParseExact(result.ToString("dd/MM/yyyy"), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            catch { }
        }
        return result;
    }
}
