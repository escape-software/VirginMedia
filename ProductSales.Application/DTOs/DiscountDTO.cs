//-------------------------------------------------------------------------------------------------
// Name        : DiscountDTO
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

public class DiscountDTO
{
    public int DiscountId { get; set; }

    [Required(ErrorMessage = "Discount Name is required.")]
    public string? DiscountName { get; set; }
}
