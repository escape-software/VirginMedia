//-------------------------------------------------------------------------------------------------
// Name        : ProductValidator
// Type        : Class
// Author      : Kevin McGregor
// History     : 31-Mar-25 - Created
// Description :
// Copyright   : This is the property of Escape Software Solutions Limited and cannot be used, 
//               copied or modified without the express permission of the company in 
//               in writing. Copyright 2025 Escape Software Solutions Limited.
//-------------------------------------------------------------------------------------------------
using FluentValidation;
using ProductSales.Application.CQRS.Requests.Commands;

namespace ProductSales.Application.Validators;

public class ProductValidator : AbstractValidator<ProductInsertUpdateCommandRequest>
{
    public ProductValidator()
    {
        RuleFor(p => p.Product.ProductName).NotEmpty().WithMessage("Product Name must be provided.");
        RuleFor(p => p.Product.ProductName).MaximumLength(30).WithMessage("Product Name cannot exceed 20 chars.");
    }
}
