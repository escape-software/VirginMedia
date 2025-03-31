//-------------------------------------------------------------------------------------------------
// Name        : CountryInsertUpdateCommandHandler
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
    public class CountryInsertUpdateCommandHandler : IRequestHandler<CountryInsertUpdateCommandRequest, GenericResponse>
    {
        private readonly ICountryRepository _countryRepo;
        private readonly IEntityMapper _entityMapper;

        public CountryInsertUpdateCommandHandler(ICountryRepository countryRepo, IEntityMapper entityMapper)
        {
            _countryRepo = countryRepo;
            _entityMapper = entityMapper;
        }

        public async Task<GenericResponse> Handle(CountryInsertUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                Country country = new();
                country = _entityMapper.Map(request.Country, country);

                if (country == null)
                {
                    throw new Exception("Could not convert request data into country entity to perform insert or update command.");
                }

                if (country?.CountryId > 0)
                {
                    await _countryRepo.UpdateAsync(country, country.CountryId);
                }
                else if (country != null)
                {
                    await _countryRepo.InsertAsync(country);
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
