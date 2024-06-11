using CarBook.Application.Features.Mediator.Queries.CommentQueries;
using CarBook.Application.Features.Mediator.Results.CommentResults;
using CarBook.Application.Interfaces.CommentInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.CommentHandlers
{
    public class GetCommentCountByBlogIdQueryHandler : IRequestHandler<GetCommentCountByBlogIdQuery, GetCommentCountByBlogIdQueryResult>
    {
        private readonly ICommentRepository _repository;

        public GetCommentCountByBlogIdQueryHandler(ICommentRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCommentCountByBlogIdQueryResult> Handle(GetCommentCountByBlogIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetCommentCountByBlogId(request.ID);
            return new GetCommentCountByBlogIdQueryResult { CommentCount = values };
        }
    }
}
