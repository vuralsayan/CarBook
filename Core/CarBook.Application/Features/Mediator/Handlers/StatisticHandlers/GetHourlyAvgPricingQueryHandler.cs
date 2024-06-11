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
    public class GetHourlyAvgPricingQueryHandler : IRequestHandler<GetHourlyAvgPricingQuery, GetHourlyAvgPricingQueryResult>
    {
        private readonly IStatisticRepository _repository;

        public GetHourlyAvgPricingQueryHandler(IStatisticRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetHourlyAvgPricingQueryResult> Handle(GetHourlyAvgPricingQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetHourlyAvgPricing();
            return new GetHourlyAvgPricingQueryResult { HourlyAvgPricing = values };
        }
    }
}
