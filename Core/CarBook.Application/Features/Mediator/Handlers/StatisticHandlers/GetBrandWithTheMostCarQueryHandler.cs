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
    public class GetBrandWithTheMostCarQueryHandler : IRequestHandler<GetBrandWithTheMostCarQuery, GetBrandWithTheMostCarQueryResult>
    {
        private readonly IStatisticRepository _repository;

        public GetBrandWithTheMostCarQueryHandler(IStatisticRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetBrandWithTheMostCarQueryResult> Handle(GetBrandWithTheMostCarQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetBrandWithTheMostCar();
            return new GetBrandWithTheMostCarQueryResult { BrandName = values };
        }
    }
}
