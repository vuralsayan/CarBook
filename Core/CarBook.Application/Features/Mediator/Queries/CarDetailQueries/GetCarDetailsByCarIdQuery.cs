using CarBook.Application.Features.Mediator.Results.CarDetailResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.CarDetailQueries
{
	public class GetCarDetailsByCarIdQuery : IRequest<GetCarDetailsByCarIdQueryResult>
	{
		public GetCarDetailsByCarIdQuery(int id)
		{
			ID = id;
		}

		public int ID { get; set; }
	}
}
