//-------------------------------------------------------------------------------------------------
// Name        : CountryGetByIdQueryHandler
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
    public class CountryGetByIdQueryHandler : IRequestHandler<CountryGetByIdQueryRequest, CountryGetByIdQueryResponse>
    {
        private readonly ICountryRepository _countryRepo;
        private readonly IEntityMapper _entityMapper;

        public CountryGetByIdQueryHandler(ICountryRepository countryRepo, IEntityMapper entityMapper)
        {
            _countryRepo = countryRepo;
            _entityMapper = entityMapper;
        }

        public async Task<CountryGetByIdQueryResponse> Handle(CountryGetByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var response = new CountryGetByIdQueryResponse();
            var country = await _countryRepo.GetAsync(request.CountryId);
            response.Country = _entityMapper.Map(country, response.Country);

            return response;
        }
    }
}
