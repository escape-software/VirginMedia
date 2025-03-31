//-------------------------------------------------------------------------------------------------
// Name        : ViewModelMapper
// Type        : Interface
// Author      : Kevin McGregor
// History     : 31-Mar-25 - Created
// Description :
// Copyright   : This is the property of Escape Software Solutions Limited and cannot be used, 
//               copied or modified without the express permission of the company in 
//               in writing. Copyright 2025 Escape Software Solutions Limited.
//-------------------------------------------------------------------------------------------------

namespace ProductSales.BlazorWebApp.Mapper;

/// <summary>
/// IViewModelMapper provides a wrapper API around specific AutoMapper Mapper methods and Mapper map 
/// configurations to convert between entity class and view model types, and between view model types 
/// and CQRS command request types.
/// </summary>
public interface IViewModelMapper
{
    Destination Map<Source, Destination>(Source source);
    Destination Map<Source, Destination>(Source source, Destination destination);
}
