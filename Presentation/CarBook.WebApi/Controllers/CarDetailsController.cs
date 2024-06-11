using CarBook.Application.Features.Mediator.Queries.CarDetailQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CarDetailsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public CarDetailsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetCarDetailsByCarId(int id)
		{
			var result = await _mediator.Send(new GetCarDetailsByCarIdQuery(id));
			return Ok(result);
		}

		[HttpGet("GetCarDescriptionByCarId")]
        public async Task<IActionResult> GetCarDescriptionByCarId(int id)
		{
			var result = await _mediator.Send(new GetCarDescriptionByCarIdQuery(id));
            return Ok(result);
        }
    }
}
