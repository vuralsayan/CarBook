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
    public class GetElectricCarQueryHandler : IRequestHandler<GetElectricCarQuery, GetElectricCarQueryResult>
    {
        private readonly IStatisticRepository _repository;

        public GetElectricCarQueryHandler(IStatisticRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetElectricCarQueryResult> Handle(GetElectricCarQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetElectricCar();
            return new GetElectricCarQueryResult { ElectricCarCount = values };
        }
    }
}
