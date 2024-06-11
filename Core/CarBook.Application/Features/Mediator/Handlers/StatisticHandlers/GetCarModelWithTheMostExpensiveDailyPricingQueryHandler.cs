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
    public class GetCarModelWithTheMostExpensiveDailyPricingQueryHandler : IRequestHandler<GetCarModelWithTheMostExpensiveDailyPricingQuery, GetCarModelWithTheMostExpensiveDailyPricingQueryResult>
    {
        private readonly IStatisticRepository _repository;

        public GetCarModelWithTheMostExpensiveDailyPricingQueryHandler(IStatisticRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCarModelWithTheMostExpensiveDailyPricingQueryResult> Handle(GetCarModelWithTheMostExpensiveDailyPricingQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetCarModelWithTheMostExpensiveDailyPricing();
            return new GetCarModelWithTheMostExpensiveDailyPricingQueryResult { CarModel = values };
        }
    }
}
