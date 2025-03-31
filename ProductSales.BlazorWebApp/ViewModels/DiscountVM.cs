//-------------------------------------------------------------------------------------------------
// Name        : DiscountVM
// Type        : Class
// Author      : Kevin McGregor
// History     : 31-Mar-25 - Created
// Description :
// Copyright   : This is the property of Escape Software Solutions Limited and cannot be used, 
//               copied or modified without the express permission of the company in 
//               in writing. Copyright 2025 Escape Software Solutions Limited.
//-------------------------------------------------------------------------------------------------
using System.ComponentModel.DataAnnotations;

namespace ProductSales.BlazorWebApp.ViewModels;

public class DiscountVM
{
    [Required(ErrorMessage = "Discount ID is required.")]
    public int DiscountId { get; set; }

    [Required(ErrorMessage = "Discount Name is required.")]
    [StringLength(10, ErrorMessage = "Discount Name cannot exceed 10 chars.")]
    public string? DiscountName { get; set; }
}
