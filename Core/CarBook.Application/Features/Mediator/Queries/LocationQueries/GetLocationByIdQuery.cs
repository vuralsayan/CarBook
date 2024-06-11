using CarBook.Application.Features.Mediator.Results.LocationResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.LocationQueries
{
    public class GetLocationByIdQuery : IRequest<GetLocationByIdQueryResult>
    {
        public GetLocationByIdQuery(int id)
        {
            ID = id;
        }

        public int ID { get; set; }
    }
}
