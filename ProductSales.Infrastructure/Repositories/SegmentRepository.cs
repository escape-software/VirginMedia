//-------------------------------------------------------------------------------------------------
// Name        : SegmentRepository
// Type        : Class
// Author      : Kevin McGregor
// History     : 31-Mar-25 - Created
// Description :
// Copyright   : This is the property of Escape Software Solutions Limited and cannot be used, 
//               copied or modified without the express permission of the company in 
//               in writing. Copyright 2025 Escape Software Solutions Limited.
//-------------------------------------------------------------------------------------------------
using Microsoft.EntityFrameworkCore;
using ProductSales.Application.Interfaces;
using ProductSales.Domain.Entities;
using ProductSales.Infrastructure.Context;

namespace ProductSales.Infrastructure.Repositories;

public class SegmentRepository : BaseRepository<Segment>, ISegmentRepository
{
    public SegmentRepository(IDbContextFactory<ProductSalesDbContext> factory) : base(factory)
    {
    }
}
