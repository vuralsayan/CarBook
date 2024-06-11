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
    public class GetCarModelWithTheCheapestDailyPricingQueryHandler : IRequestHandler<GetCarModelWithTheCheapestDailyPricingQuery, GetCarModelWithTheCheapestDailyPricingQueryResult>
    {
        private readonly IStatisticRepository _repository;

        public GetCarModelWithTheCheapestDailyPricingQueryHandler(IStatisticRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCarModelWithTheCheapestDailyPricingQueryResult> Handle(GetCarModelWithTheCheapestDailyPricingQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetCarModelWithTheCheapestDailyPricing();
            return new GetCarModelWithTheCheapestDailyPricingQueryResult { CarModel = values };
        }
    }
}
