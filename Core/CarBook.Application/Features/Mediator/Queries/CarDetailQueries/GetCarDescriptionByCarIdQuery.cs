using CarBook.Application.Features.Mediator.Results.CarDetailResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.CarDetailQueries
{
    public class GetCarDescriptionByCarIdQuery : IRequest<GetCarDescriptionByCarIdQueryResult>
    {
        public int ID { get; set; }

        public GetCarDescriptionByCarIdQuery(int id)
        {
            ID = id;
        }
    }
}
