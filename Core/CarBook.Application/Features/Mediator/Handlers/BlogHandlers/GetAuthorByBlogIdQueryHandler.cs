using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Application.Interfaces.BlogInterfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetAuthorByBlogIdQueryHandler : IRequestHandler<GetAuthorByBlogIdQuery, GetAuthorByBlogIdQueryResult>
    {
        private readonly IBlogRepository _repository;

        public GetAuthorByBlogIdQueryHandler(IBlogRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAuthorByBlogIdQueryResult> Handle(GetAuthorByBlogIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAuthorByBlogId(request.ID);
            return new GetAuthorByBlogIdQueryResult
            {
                AuthorDescription = values.Author.Description,
                AuthorID = values.AuthorID,
                AuthorImageUrl = values.Author.ImageUrl,
                AuthorName = values.Author.Name,
                BlogID = values.BlogID
            }; 
        }
    }
}
