//-------------------------------------------------------------------------------------------------
// Name        : DiscountInsertUpdateCommandHandler
// Type        : Class
// Author      : Kevin McGregor
// History     : 31-Mar-25 - Created
// Description :
// Copyright   : This is the property of Escape Software Solutions Limited and cannot be used, 
//               copied or modified without the express permission of the company in 
//               in writing. Copyright 2025 Escape Software Solutions Limited.
//-------------------------------------------------------------------------------------------------
using MediatR;
using ProductSales.Application.CQRS.Requests.Commands;
using ProductSales.Application.CQRS.Responses;
using ProductSales.Application.Interfaces;
using ProductSales.Application.Mapper;
using ProductSales.Domain.Entities;

namespace ProductSales.Application.CQRS.Handlers
{
    public class DiscountInsertUpdateCommandHandler : IRequestHandler<DiscountInsertUpdateCommandRequest, GenericResponse>
    {
        private readonly IDiscountRepository _discountRepo;
        private readonly IEntityMapper _entityMapper;

        public DiscountInsertUpdateCommandHandler(IDiscountRepository discountRepo, IEntityMapper entityMapper)
        {
            _discountRepo = discountRepo;
            _entityMapper = entityMapper;
        }

        public async Task<GenericResponse> Handle(DiscountInsertUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                Discount discount = new();
                discount = _entityMapper.Map(request.Discount, discount);

                if (discount?.DiscountId > 0)
                {
                    await _discountRepo.UpdateAsync(discount, discount.DiscountId);
                }
                else if (discount != null)
                {
                    await _discountRepo.InsertAsync(discount);
                }
                else
                {
                    throw new Exception("Could not convert request data into discount entity to perform insert or update command.");
                }
            }
            catch (Exception exception)
            {
                return GenericResponse.Failure(exception);
            }

            return GenericResponse.Success();
        }
    }
}
