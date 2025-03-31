//-------------------------------------------------------------------------------------------------
// Name        : InfrastructureException
// Type        : Class
// Author      : Kevin McGregor
// History     : 31-Mar-25 - Created
// Description :
// Copyright   : This is the property of Escape Software Solutions Limited and cannot be used, 
//               copied or modified without the express permission of the company in 
//               in writing. Copyright 2025 Escape Software Solutions Limited.
//-------------------------------------------------------------------------------------------------

namespace ProductSales.Infrastructure.Exceptions;

public class InfrastructureException : Exception
{
    public InfrastructureException()
    {
    }

    public InfrastructureException(string message)
        : base(message)
    {
    }

    public InfrastructureException(string message, Exception inner)
        : base(message, inner)
    {
    }
}
