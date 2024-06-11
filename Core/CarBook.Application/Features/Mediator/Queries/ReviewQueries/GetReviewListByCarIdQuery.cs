using CarBook.Application.Features.Mediator.Results.ReviewResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.ReviewQueries
{
    public class GetReviewListByCarIdQuery : IRequest<List<GetReviewListByCarIdQueryResult>>
    {
        public GetReviewListByCarIdQuery(int id)
        {
            ID = id;
        }
        public int ID { get; set; }
    }
}
