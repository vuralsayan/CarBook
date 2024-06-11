using CarBook.Application.Features.Mediator.Queries.CarPricingQueries;
using CarBook.Application.Features.Mediator.Results.CarPricingResults;
using CarBook.Application.Interfaces.CarPricingInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.CarPricingHandlers
{
	public class GetCarPricingWithTimePeriodQueryHandler : IRequestHandler<GetCarPricingWithTimePeriodQuery, List<GetCarPricingWithTimePeriodQueryResult>>
	{
		private readonly ICarPricingRepository _repository;

		public GetCarPricingWithTimePeriodQueryHandler(ICarPricingRepository repository)
		{
			_repository = repository;
		}

		public async Task<List<GetCarPricingWithTimePeriodQueryResult>> Handle(GetCarPricingWithTimePeriodQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetCarPricingWithTimePeriod();
			return values.Select(x => new GetCarPricingWithTimePeriodQueryResult
			{
				Model = x.Model,
				BrandName = x.BrandName,
				CoverImageUrl = x.CoverImageUrl,
				DailyPrice = x.Amounts[0],
				WeeklyPrice = x.Amounts[1],
				MonthlyPrice = x.Amounts[2]
			}).ToList();
		}
	}


}
