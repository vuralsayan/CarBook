using CarBook.Application.Features.Mediator.Results.FeatureResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.FeatureQueries
{
    public class GetFeatureByIdQuery : IRequest<GetFeatureByIdQueryResult>
    {
        public GetFeatureByIdQuery(int id)
        {
            ID = id;
        }

        public int ID { get; set; }
    }
}
