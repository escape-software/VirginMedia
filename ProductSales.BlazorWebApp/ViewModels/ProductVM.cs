﻿//-------------------------------------------------------------------------------------------------
// Name        : ProductVM
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

public class ProductVM
{
    [Required(ErrorMessage = "Product ID is required.")]
    public int ProductId { get; set; }

    [Required(ErrorMessage = "Product Name is required.")]
    [StringLength(20, ErrorMessage = "Product Name cannot exceed 20 chars.")]
    public string? ProductName { get; set; }
}
