//-------------------------------------------------------------------------------------------------
// Name        : ViewModelMapper
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
using ProductSales.BlazorWebApp.ViewModels;
using ProductSales.Domain.Entities;

namespace ProductSales.BlazorWebApp.Mapper;

/// <summary>
/// ViewModelMapper provides a wrapper API around specific AutoMapper Mapper methods and Mapper map 
/// configurations to convert between view model and DTO class types and vice versa.
/// </summary>
public class ViewModelMapper : IViewModelMapper
{
    private readonly AutoMapper.Mapper mapper;

    public ViewModelMapper()
    {
        var mapperConfig = new MapperConfiguration(config =>
        {
            config.CreateMap<CountryVM, CountryDTO>().ReverseMap();
            config.CreateMap<SegmentVM, SegmentDTO>().ReverseMap();
            config.CreateMap<DiscountVM, DiscountDTO>().ReverseMap();
            config.CreateMap<ProductVM, ProductDTO>().ReverseMap();
            config.CreateMap<ProductSaleSummaryVM, ProductSaleSummaryDTO>().ReverseMap();
            config.CreateMap<ImportProductSalesVM, ProductSaleSummaryDTO>().ReverseMap();
        });

        mapper = new AutoMapper.Mapper(mapperConfig);
    }

    public Destination Map<Source, Destination>(Source source)
    {
        return mapper.Map<Destination>(source);
    }

    public Destination Map<Source, Destination>(Source source, Destination destination)
    {
        return mapper.Map(source, destination);
    }
}
