using CarBook.Application.Features.Mediator.Results.BlogResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.BlogQueries
{
    public class GetAuthorByBlogIdQuery : IRequest<GetAuthorByBlogIdQueryResult>
    {
        public GetAuthorByBlogIdQuery(int id)
        {
            ID = id;
        }

        public int ID { get; set; } 
    }
}
