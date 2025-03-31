//-------------------------------------------------------------------------------------------------
// Name        : SegmentInsertUpdateCommandHandler
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
    public class SegmentInsertUpdateCommandHandler : IRequestHandler<SegmentInsertUpdateCommandRequest, GenericResponse>
    {
        private readonly ISegmentRepository _segmentRepo;
        private readonly IEntityMapper _entityMapper;

        public SegmentInsertUpdateCommandHandler(ISegmentRepository segmentRepo, IEntityMapper entityMapper)
        {
            _segmentRepo = segmentRepo;
            _entityMapper = entityMapper;
        }

        public async Task<GenericResponse> Handle(SegmentInsertUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                Segment segment = new();
                segment = _entityMapper.Map(request.Segment, segment);

                if (segment?.SegmentId > 0)
                {
                    await _segmentRepo.UpdateAsync(segment, segment.SegmentId);
                }
                else if (segment != null)
                {
                    await _segmentRepo.InsertAsync(segment);
                }
                else
                {
                    throw new Exception("Could not convert request data into segment entity to perform insert or update command.");
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
