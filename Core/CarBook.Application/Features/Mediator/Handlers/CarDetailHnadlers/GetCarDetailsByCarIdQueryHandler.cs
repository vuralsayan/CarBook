using CarBook.Application.Features.Mediator.Queries.CarDetailQueries;
using CarBook.Application.Features.Mediator.Results.CarDetailResults;
using CarBook.Application.Interfaces.CarInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.CarDetailHnadlers
{
	public class GetCarDetailsByCarIdQueryHandler : IRequestHandler<GetCarDetailsByCarIdQuery, GetCarDetailsByCarIdQueryResult>
	{
		private readonly ICarRepository _repository;

		public GetCarDetailsByCarIdQueryHandler(ICarRepository repository)
		{
			_repository = repository;
		}

		public async Task<GetCarDetailsByCarIdQueryResult> Handle(GetCarDetailsByCarIdQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetCarDetailsByCarId(request.ID);
			return new GetCarDetailsByCarIdQueryResult
			{
				CarID = values.CarID,
				BrandName = values.Brand.Name,
				Model = values.Model,
				CoverImageUrl = values.CoverImageUrl,
				Km = values.Km,
				Transmission = values.Transmission,
				Seat = values.Seat,
				Luggage = values.Luggage,
				Fuel = values.Fuel,
				BigImageUrl = values.BigImageUrl,
			};
		}
	}
}
