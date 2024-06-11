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
    public class GetCarWithLessThan1000KmQueryHandler : IRequestHandler<GetCarWithLessThan1000KmQuery, GetCarWithLessThan1000KmQueryResult>
    {
        private readonly IStatisticRepository _repository;

        public GetCarWithLessThan1000KmQueryHandler(IStatisticRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCarWithLessThan1000KmQueryResult> Handle(GetCarWithLessThan1000KmQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetCarWithLessThan1000Km();
            return new GetCarWithLessThan1000KmQueryResult { CarCount = values };
        }
    }
}
