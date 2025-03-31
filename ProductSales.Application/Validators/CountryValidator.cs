//-------------------------------------------------------------------------------------------------
// Name        : CountryValidator
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
using ProductSales.Application.DTOs;

namespace ProductSales.Application.Validators;

public class CountryValidator : AbstractValidator<CountryInsertUpdateCommandRequest>
{
    public CountryValidator()
    {
        RuleFor(p => p.Country.CountryName).NotEmpty().WithMessage("Country Name must be provided.");
        RuleFor(p => p.Country.CountryName).MaximumLength(30).WithMessage("Country Name cannot exceed 30 chars.");
    }
}
