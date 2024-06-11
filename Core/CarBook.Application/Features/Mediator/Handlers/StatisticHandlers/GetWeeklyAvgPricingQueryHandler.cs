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
    public class GetWeeklyAvgPricingQueryHandler : IRequestHandler<GetWeeklyAvgPricingQuery, GetWeeklyAvgPricingQueryResult>
    {
        private readonly IStatisticRepository _repository;

        public GetWeeklyAvgPricingQueryHandler(IStatisticRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetWeeklyAvgPricingQueryResult> Handle(GetWeeklyAvgPricingQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetWeeklyAvgPricing();
            return new GetWeeklyAvgPricingQueryResult { WeeklyAvgPricing = values };
        }
    }
}
