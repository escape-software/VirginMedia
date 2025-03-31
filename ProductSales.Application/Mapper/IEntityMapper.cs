//-------------------------------------------------------------------------------------------------
// Name        : IEntityMapper
// Type        : Interface
// Author      : Kevin McGregor
// History     : 31-Mar-25 - Created
// Description :
// Copyright   : This is the property of Escape Software Solutions Limited and cannot be used, 
//               copied or modified without the express permission of the company in 
//               in writing. Copyright 2025 Escape Software Solutions Limited.
//-------------------------------------------------------------------------------------------------

namespace ProductSales.Application.Mapper;

/// <summary>
/// IEntityMapper provides a wrapper API around AutoMapper Mapper methods and Mapper map 
/// configurations to convert between CQRS command request and entity class types.
/// </summary>
public interface IEntityMapper
{
    Destination Map<Source, Destination>(Source source);

    Destination Map<Source, Destination>(Source source, Destination destination);

    Destination Map<Destination>(object source);
}
