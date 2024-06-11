using CarBook.Application.Features.Mediator.Commands.CarFeatureCommands;
using CarBook.Application.Features.Mediator.Queries.CarFeatureQueries;
using CarBook.Application.Features.Mediator.Queries.CarPricingQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarFeaturesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarFeaturesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetCarFeaturesByCarId")]
        public async Task<IActionResult> GetCarFeaturesByCarId(int carId)
        {
            var values = await _mediator.Send(new GetCarFeatureByCarIdQuery(carId));
            return Ok(values);
        }

        [HttpGet("UpdateCarFeatureAvailableChangeToFalse")]
        public async Task<IActionResult> UpdateCarFeatureAvailableChangeToFalse(int id)
        {
            await _mediator.Send(new UpdateCarFeatureAvailableChangeToFalseCommand(id));
            return Ok($"{id} id li araba özelliğinin durumu false olarak değiştirildi"); 
        }

        [HttpGet("UpdateCarFeatureAvailableChangeToTrue")]
        public async Task<IActionResult> UpdateCarFeatureAvailableChangeToTrue(int id)
        {
            await _mediator.Send(new UpdateCarFeatureAvailableChangeToTrueCommand(id));
            return Ok($"{id} id li araba özelliğinin durumu true olarak değiştirildi");
        }

        [HttpPost("CreateCarFeatureByCarId")]
        public async Task<IActionResult> CreateCarFeatureByCarId(CreateCarFeatureByCarIdCommand command)
        {
            await _mediator.Send(command);
            return Ok($"{command.CarID} id li araba için {command.FeatureID} id li özellik eklendi");
        }
    }
}
