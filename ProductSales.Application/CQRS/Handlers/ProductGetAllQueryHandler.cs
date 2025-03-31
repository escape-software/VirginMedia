//-------------------------------------------------------------------------------------------------
// Name        : ProductGetAllQueryHandler
// Type        : Class
// Author      : Kevin McGregor
// History     : 31-Mar-25 - Created
// Description :
// Copyright   : This is the property of Escape Software Solutions Limited and cannot be used, 
//               copied or modified without the express permission of the company in 
//               in writing. Copyright 2025 Escape Software Solutions Limited.
//-------------------------------------------------------------------------------------------------
using MediatR;
using ProductSales.Application.CQRS.Requests.Queries;
using ProductSales.Application.CQRS.Responses;
using ProductSales.Application.Interfaces;
using ProductSales.Application.Mapper;

namespace ProductSales.Application.CQRS.Handlers
{
    public class ProductGetAllQueryHandler : IRequestHandler<ProductGetAllQueryRequest, ProductGetAllQueryResponse>
    {
        private readonly IProductRepository _productRepo;
        private readonly IEntityMapper _entityMapper;

        public ProductGetAllQueryHandler(IProductRepository productRepo, IEntityMapper entityMapper)
        {
            _productRepo = productRepo;
            _entityMapper = entityMapper;
        }

        public async Task<ProductGetAllQueryResponse> Handle(ProductGetAllQueryRequest request, CancellationToken cancellationToken)
        {
            ProductGetAllQueryResponse response = new();
            var products = await _productRepo.GetAllAsync();
            response.Products = _entityMapper.Map(products, response.Products);

            return response;
        }
    }
}
