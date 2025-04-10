﻿//-------------------------------------------------------------------------------------------------
// Name        : UploadFileVM
// Type        : Class
// Author      : Kevin McGregor
// History     : 31-Mar-25 - Created
// Description :
// Copyright   : This is the property of Escape Software Solutions Limited and cannot be used, 
//               copied or modified without the express permission of the company in 
//               in writing. Copyright 2025 Escape Software Solutions Limited.
//-------------------------------------------------------------------------------------------------
using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel.DataAnnotations;

namespace ProductSales.BlazorWebApp.ViewModels;

public class UploadFileVM
{
    [Required]
    public string? FileName { get; set; }

    [Required]
    public IFormFile? FormFile { get; set; }
}
