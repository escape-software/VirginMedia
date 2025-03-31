﻿//-------------------------------------------------------------------------------------------------
// Name        : ProductInsertUpdateCommandRequest
// Type        : Class
// Author      : Kevin McGregor
// History     : 31-Mar-25 - Created
// Description :
// Copyright   : This is the property of Escape Software Solutions Limited and cannot be used, 
//               copied or modified without the express permission of the company in 
//               in writing. Copyright 2025 Escape Software Solutions Limited.
//-------------------------------------------------------------------------------------------------
using MediatR;
using ProductSales.Application.CQRS.Responses;
using ProductSales.Application.DTOs;
using System.ComponentModel.DataAnnotations;

namespace ProductSales.Application.CQRS.Requests.Commands
{
    public class ProductInsertUpdateCommandRequest : IRequest<GenericResponse>
    {
        [Required(ErrorMessage = "Product is required.")]
        public ProductDTO? Product { get; set; }
    }
}
