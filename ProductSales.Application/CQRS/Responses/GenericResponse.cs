//-------------------------------------------------------------------------------------------------
// Name        : GenericResponse
// Type        : Class
// Author      : Kevin McGregor
// History     : 31-Mar-25 - Created
// Description :
// Copyright   : This is the property of Escape Software Solutions Limited and cannot be used, 
//               copied or modified without the express permission of the company in 
//               in writing. Copyright 2025 Escape Software Solutions Limited.
//-------------------------------------------------------------------------------------------------

namespace ProductSales.Application.CQRS.Responses;

public class GenericResponse
{
    public bool IsSuccess { get; set; }

    public string? Message { get; set; }

    public GenericResponse()
    {
    }

    public static GenericResponse Success()
    {
        return new GenericResponse() { IsSuccess = true };
    }

    public static GenericResponse Success(string message)
    {
        GenericResponse response = Success();
        response.Message = message;
        return response;
    }

    public static GenericResponse Failure()
    {
        return new GenericResponse() { IsSuccess = false };
    }

    public static GenericResponse Failure(Exception exception)
    {
        GenericResponse response = Failure();
        response.Message = exception.Message;

        if (exception.InnerException != null)
        {
            response.Message += $" Inner Exception: {exception.InnerException.Message}";
        }

        return response;
    }
}
