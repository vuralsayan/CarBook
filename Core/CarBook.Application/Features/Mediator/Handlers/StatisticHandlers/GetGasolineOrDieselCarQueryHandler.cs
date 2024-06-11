using CarBook.Application.Features.Mediator.Queries.StatisticQueries;
using CarBook.Application.Features.Mediator.Results.StatisticResults;
using CarBook.Application.Interfaces.StatisticInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.StatisticHandlers
{
    public class GetGasolineOrDieselCarQueryHandler : IRequestHandler<GetGasolineOrDieselCarQuery, GetGasolineOrDieselCarQueryResult>
    {
        private readonly IStatisticRepository _repository;

        public GetGasolineOrDieselCarQueryHandler(IStatisticRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetGasolineOrDieselCarQueryResult> Handle(GetGasolineOrDieselCarQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetGasolineOrDieselCar();
            return new GetGasolineOrDieselCarQueryResult { GasolineOrDieselCarCount = values };
        }
    }
}
