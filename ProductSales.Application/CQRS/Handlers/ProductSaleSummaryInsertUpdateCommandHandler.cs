//-------------------------------------------------------------------------------------------------
// Name        : ProductSaleSummaryInsertUpdateCommandHandler
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

namespace ProductSaleSummarySales.Application.CQRS.Handlers
{
    public class ProductSaleSummaryInsertUpdateCommandHandler : IRequestHandler<ProductSaleSummaryInsertUpdateCommandRequest, GenericResponse>
    {
        private readonly IProductSaleSummaryRepository _prodSaleSummaryRepo;
        private readonly IEntityMapper _entityMapper;

        public ProductSaleSummaryInsertUpdateCommandHandler(IProductSaleSummaryRepository prodSaleSummaryRepo, IEntityMapper entityMapper)
        {
            _prodSaleSummaryRepo = prodSaleSummaryRepo;
            _entityMapper = entityMapper;
        }

        public async Task<GenericResponse> Handle(ProductSaleSummaryInsertUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                ProductSaleSummary prodSaleSummary = new();
                prodSaleSummary = _entityMapper.Map(request.ProductSaleSummary, prodSaleSummary);

                if (prodSaleSummary?.SaleId > 0)
                {
                    await _prodSaleSummaryRepo.UpdateAsync(prodSaleSummary, prodSaleSummary.SaleId);
                }
                else if (prodSaleSummary != null)
                {
                    await _prodSaleSummaryRepo.InsertAsync(prodSaleSummary);
                }
                else
                {
                    throw new Exception("Could not convert request data into ProductSaleSummary entity to perform insert or update command.");
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
