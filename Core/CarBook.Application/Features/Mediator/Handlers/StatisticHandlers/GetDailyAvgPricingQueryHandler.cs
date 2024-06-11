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
    public class GetDailyAvgPricingQueryHandler : IRequestHandler<GetDailyAvgPricingQuery, GetDailyAvgPricingQueryResult>
    {
        private readonly IStatisticRepository _repository;

        public GetDailyAvgPricingQueryHandler(IStatisticRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetDailyAvgPricingQueryResult> Handle(GetDailyAvgPricingQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetDailyAvgPricing();
            return new GetDailyAvgPricingQueryResult { DailyAvgPricing = values };
        }
    }
}
