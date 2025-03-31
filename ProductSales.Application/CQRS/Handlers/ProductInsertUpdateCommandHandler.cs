//-------------------------------------------------------------------------------------------------
// Name        : ProductInsertUpdateCommandHandler
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
    public class ProductInsertUpdateCommandHandler : IRequestHandler<ProductInsertUpdateCommandRequest, GenericResponse>
    {
        private readonly IProductRepository _productRepo;
        private readonly IEntityMapper _entityMapper;

        public ProductInsertUpdateCommandHandler(IProductRepository productRepo, IEntityMapper entityMapper)
        {
            _productRepo = productRepo;
            _entityMapper = entityMapper;
        }

        public async Task<GenericResponse> Handle(ProductInsertUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                Product product = new();
                product = _entityMapper.Map(request, product);

                if (product?.ProductId > 0)
                {
                    await _productRepo.UpdateAsync(product, product.ProductId);
                }
                else if (product != null)
                {
                    await _productRepo.InsertAsync(product);
                }
                else
                {
                    throw new Exception("Could not convert request data into product entity to perform insert or update command.");
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
