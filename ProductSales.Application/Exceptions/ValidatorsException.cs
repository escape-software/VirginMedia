//-------------------------------------------------------------------------------------------------
// Name        : ValidatorsException
// Type        : Class
// Author      : Kevin McGregor
// History     : 31-Mar-25 - Created
// Description :
// Copyright   : This is the property of Escape Software Solutions Limited and cannot be used, 
//               copied or modified without the express permission of the company in 
//               in writing. Copyright 2025 Escape Software Solutions Limited.
//-------------------------------------------------------------------------------------------------

namespace ProductSales.Application.Exceptions;

public class ValidatorsException : Exception
{
    public IReadOnlyDictionary<string, string[]> ValidatorErrors { get; }

    public ValidatorsException(IReadOnlyDictionary<string, string[]> errors) : base("One or more validation errors occurred.")
    {
        ValidatorErrors = errors;
    }
}
