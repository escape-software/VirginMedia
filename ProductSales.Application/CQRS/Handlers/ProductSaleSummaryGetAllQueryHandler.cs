//-------------------------------------------------------------------------------------------------
// Name        : ProductSaleSummaryGetAllQueryHandler
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
    public class ProductSaleSummaryGetAllQueryHandler : IRequestHandler<ProductSaleSummaryGetAllQueryRequest, ProductSaleSummaryGetAllQueryResponse>
    {
        private readonly IProductSaleSummaryRepository _prodSaleSummaryRepo;
        private readonly IEntityMapper _entityMapper;

        public ProductSaleSummaryGetAllQueryHandler(IProductSaleSummaryRepository prodSaleSummaryRepo, IEntityMapper entityMapper)
        {
            _prodSaleSummaryRepo = prodSaleSummaryRepo;
            _entityMapper = entityMapper;
        }

        public async Task<ProductSaleSummaryGetAllQueryResponse> Handle(ProductSaleSummaryGetAllQueryRequest request, CancellationToken cancellationToken)
        {
            ProductSaleSummaryGetAllQueryResponse response = new();
            var prodSaleSummaries = await _prodSaleSummaryRepo.GetAllAsync();
            response.ProductSaleSummaries = _entityMapper.Map(prodSaleSummaries, response.ProductSaleSummaries);

            return response;
        }
    }
}
