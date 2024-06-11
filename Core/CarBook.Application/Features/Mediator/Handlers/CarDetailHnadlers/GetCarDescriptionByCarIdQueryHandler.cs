using CarBook.Application.Features.Mediator.Queries.CarDetailQueries;
using CarBook.Application.Features.Mediator.Results.CarDetailResults;
using CarBook.Application.Interfaces.CarInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.CarDetailHnadlers
{
    public class GetCarDescriptionByCarIdQueryHandler : IRequestHandler<GetCarDescriptionByCarIdQuery, GetCarDescriptionByCarIdQueryResult>
    {
        private readonly ICarRepository _repository;

        public GetCarDescriptionByCarIdQueryHandler(ICarRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCarDescriptionByCarIdQueryResult> Handle(GetCarDescriptionByCarIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetCarDescriptionByCarId(request.ID);
            return new GetCarDescriptionByCarIdQueryResult
            {
                CarDescriptionID = values.CarDescriptionID,
                CarID = values.CarID,
                Details = values.Details
            };
        }
    }
}
