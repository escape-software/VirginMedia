//-------------------------------------------------------------------------------------------------
// Name        : SegmentGetByIdQueryHandler
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
    public class SegmentGetByIdQueryHandler : IRequestHandler<SegmentGetByIdQueryRequest, SegmentGetByIdQueryResponse>
    {
        private readonly ISegmentRepository _segmentRepo;
        private readonly IEntityMapper _entityMapper;

        public SegmentGetByIdQueryHandler(ISegmentRepository segmentRepo, IEntityMapper entityMapper)
        {
            _segmentRepo = segmentRepo;
            _entityMapper = entityMapper;
        }

        public async Task<SegmentGetByIdQueryResponse> Handle(SegmentGetByIdQueryRequest request, CancellationToken cancellationToken)
        {
            SegmentGetByIdQueryResponse segmentGetByIdResponse = new();
            var segment = await _segmentRepo.GetAsync(request.SegmentId);
            segmentGetByIdResponse.Segment = _entityMapper.Map(segment, segmentGetByIdResponse.Segment);

            return segmentGetByIdResponse;
        }
    }
}
