//-------------------------------------------------------------------------------------------------
// Name        : DiscountGetByIdQueryHandler
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
    public class DiscountGetByIdQueryHandler : IRequestHandler<DiscountGetByIdQueryRequest, DiscountGetByIdQueryResponse>
    {
        private readonly IDiscountRepository _discountRepo;
        private readonly IEntityMapper _entityMapper;

        public DiscountGetByIdQueryHandler(IDiscountRepository discountRepo, IEntityMapper entityMapper)
        {
            _discountRepo = discountRepo;
            _entityMapper = entityMapper;
        }

        public async Task<DiscountGetByIdQueryResponse> Handle(DiscountGetByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var response = new DiscountGetByIdQueryResponse();
            var discount = await _discountRepo.GetAsync(request.DiscountId);
            response.Discount = _entityMapper.Map(discount, response.Discount);

            return response;
        }
    }
}
