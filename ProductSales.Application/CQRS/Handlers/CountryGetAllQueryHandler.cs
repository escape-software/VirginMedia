//-------------------------------------------------------------------------------------------------
// Name        : CountryGetAllQueryHandler
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
    public class CountryGetAllQueryHandler : IRequestHandler<CountryGetAllQueryRequest, CountryGetAllQueryResponse>
    {
        private readonly ICountryRepository _countryRepo;
        private readonly IEntityMapper _entityMapper;

        public CountryGetAllQueryHandler(ICountryRepository countryRepo, IEntityMapper entityMapper)
        {
            _countryRepo = countryRepo;
            _entityMapper = entityMapper;
        }

        public async Task<CountryGetAllQueryResponse> Handle(CountryGetAllQueryRequest request, CancellationToken cancellationToken)
        {
            CountryGetAllQueryResponse response = new CountryGetAllQueryResponse();
            var countries = await _countryRepo.GetAllAsync();
            response.Countries = _entityMapper.Map(countries, response.Countries);

            return response;
        }
    }
}
