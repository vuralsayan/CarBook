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
    public class GetBlogTitleWithTheMostCommentsQueryHandler : IRequestHandler<GetBlogTitleWithTheMostCommentsQuery, GetBlogTitleWithTheMostCommentsQueryResult>
    {
        private readonly IStatisticRepository _repository;

        public GetBlogTitleWithTheMostCommentsQueryHandler(IStatisticRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetBlogTitleWithTheMostCommentsQueryResult> Handle(GetBlogTitleWithTheMostCommentsQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetBlogTitleWithTheMostComments();
            return new GetBlogTitleWithTheMostCommentsQueryResult { BlogTitle = values };
        }
    }
}
