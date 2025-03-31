//-------------------------------------------------------------------------------------------------
// Name        : CountryDTO
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

public class CountryDTO
{
    public int CountryId { get; set; }

    [Required(ErrorMessage = "Country Name is required.")]
    [StringLength(30, ErrorMessage = "Country Name cannot exceed 30 chars.")]
    public string? CountryName { get; set; }
}
