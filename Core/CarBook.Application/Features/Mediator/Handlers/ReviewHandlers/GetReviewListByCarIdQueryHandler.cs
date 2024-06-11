using CarBook.Application.Features.Mediator.Queries.ReviewQueries;
using CarBook.Application.Features.Mediator.Results.ReviewResults;
using CarBook.Application.Interfaces.ReviewInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.ReviewHandlers
{
    public class GetReviewListByCarIdQueryHandler : IRequestHandler<GetReviewListByCarIdQuery, List<GetReviewListByCarIdQueryResult>>
    {
        private readonly IReviewRepository _repository;

        public GetReviewListByCarIdQueryHandler(IReviewRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetReviewListByCarIdQueryResult>> Handle(GetReviewListByCarIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetReviewListByCarId(request.ID);
            return values.Select(x => new GetReviewListByCarIdQueryResult
            {
                ReviewID = x.ReviewID,
                CustomerName = x.CustomerName,
                CustomerImage = x.CustomerImage,
                Comment = x.Comment,
                Star = x.Star,
                ReviewDate = x.ReviewDate,
                CarID = x.CarID
            }).ToList();
        }
    }
}
