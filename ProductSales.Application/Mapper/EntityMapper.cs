//-------------------------------------------------------------------------------------------------
// Name        : EntityMapper
// Type        : Class
// Author      : Kevin McGregor
// History     : 31-Mar-25 - Created
// Description :
// Copyright   : This is the property of Escape Software Solutions Limited and cannot be used, 
//               copied or modified without the express permission of the company in 
//               in writing. Copyright 2025 Escape Software Solutions Limited.
//-------------------------------------------------------------------------------------------------
using AutoMapper;
using ProductSales.Application.CQRS.Requests.Commands;
using ProductSales.Application.DTOs;
using ProductSales.Domain.Entities;

namespace ProductSales.Application.Mapper;

/// <summary>
/// EntityMapper provides a wrapper API around AutoMapper Mapper methods and Mapper map 
/// configurations to convert between DTO and domain entity class types and vice versa.
/// </summary>
public class EntityMapper : IEntityMapper
{
    private readonly AutoMapper.Mapper mapper;

    public EntityMapper()
    {
        var mapperConfig = new MapperConfiguration(config =>
        {
            config.CreateMap<CountryDTO, Country>().ReverseMap();
            config.CreateMap<SegmentDTO, Segment>().ReverseMap();
            config.CreateMap<DiscountDTO, Discount>().ReverseMap();
            config.CreateMap<ProductDTO, Product>().ReverseMap();
            config.CreateMap<ProductSaleSummaryDTO, ProductSaleSummary>().ReverseMap();
        });

        mapper = new AutoMapper.Mapper(mapperConfig);
    }

    public Destination Map<Source, Destination>(Source source)
    {
        return mapper.Map<Destination>(source);
    }

    public Destination Map<Destination>(object source)
    {
        return mapper.Map<Destination>(source);
    }

    public Destination Map<Source, Destination>(Source source, Destination destination)
    {
        return mapper.Map(source, destination);
    }
}
