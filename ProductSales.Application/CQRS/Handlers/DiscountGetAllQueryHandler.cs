//-------------------------------------------------------------------------------------------------
// Name        : DiscountGetAllQueryHandler
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
    public class DiscountGetAllQueryHandler : IRequestHandler<DiscountGetAllQueryRequest, DiscountGetAllQueryResponse>
    {
        private readonly IDiscountRepository _discountRepo;
        private readonly IEntityMapper _entityMapper;

        public DiscountGetAllQueryHandler(IDiscountRepository discountRepo, IEntityMapper entityMapper)
        {
            _discountRepo = discountRepo;
            _entityMapper = entityMapper;
        }

        public async Task<DiscountGetAllQueryResponse> Handle(DiscountGetAllQueryRequest request, CancellationToken cancellationToken)
        {
            DiscountGetAllQueryResponse response = new DiscountGetAllQueryResponse();
            var discounts = await _discountRepo.GetAllAsync();
            response.Discounts = _entityMapper.Map(discounts, response.Discounts);

            return response;
        }
    }
}
