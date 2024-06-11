using CarBook.Application.Features.Mediator.Commands.ReviewCommands;
using CarBook.Application.Features.Mediator.Queries.ReviewQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReviewsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetReviewListByCarId")]
        public async Task<IActionResult> GetReviewListByCarId(int id)
        {
            var result = await _mediator.Send(new GetReviewListByCarIdQuery(id));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateReview(CreateReviewCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _mediator.Send(command);
            return Ok("Ekleme işlemi gerçekleşti");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateReview(UpdateReviewCommand command)
        {
            await _mediator.Send(command);
            return Ok("Güncelleme işlemi gerçekleşti");
        }
    }
}
