//-------------------------------------------------------------------------------------------------
// Name        : SegmentGetAllQueryHandler
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
using System.ComponentModel.DataAnnotations;

namespace ProductSales.Application.CQRS.Handlers
{
    public class SegmentGetAllQueryHandler : IRequestHandler<SegmentGetAllQueryRequest, SegmentGetAllQueryResponse>
    {
        private readonly ISegmentRepository _segmentRepo;
        private readonly IEntityMapper _entityMapper;

        public SegmentGetAllQueryHandler(ISegmentRepository segmentRepo, IEntityMapper entityMapper)
        {
            _segmentRepo = segmentRepo;
            _entityMapper = entityMapper;
        }

        public async Task<SegmentGetAllQueryResponse> Handle(SegmentGetAllQueryRequest request, CancellationToken cancellationToken)
        {
            SegmentGetAllQueryResponse response = new();
            var segments = await _segmentRepo.GetAllAsync();
            response.Segments = _entityMapper.Map(segments, response.Segments);

            return response;
        }
    }
}
