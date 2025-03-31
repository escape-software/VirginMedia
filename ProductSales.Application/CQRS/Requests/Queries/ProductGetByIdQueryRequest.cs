//-------------------------------------------------------------------------------------------------
// Name        : ProductGetByIdQueryRequest
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

namespace ProductSales.Application.CQRS.Requests.Queries
{
    public class ProductGetByIdQueryRequest : IRequest<ProductGetByIdQueryResponse>
    {
        public int ProductId { get; set; }
    }
}
