using CarBook.Application.Features.Mediator.Queries.StatisticQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StatisticsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetCarCount")]
        public async Task<IActionResult> GetCarCount()
        {
            var result = await _mediator.Send(new GetCarCountQuery());
            return Ok(result);
        }

        [HttpGet("GetLocationCount")]
        public async Task<IActionResult> GetLocationCount()
        {
            var result = await _mediator.Send(new GetLocationCountQuery());
            return Ok(result);
        }

        [HttpGet("GetAuthorCount")]
        public async Task<IActionResult> GetAuthorCount()
        {
            var result = await _mediator.Send(new GetAuthorCountQuery());
            return Ok(result);
        }

        [HttpGet("GetBlogCount")]
        public async Task<IActionResult> GetBlogCount()
        {
            var result = await _mediator.Send(new GetBlogCountQuery());
            return Ok(result);
        }

        [HttpGet("GetBrandCount")]
        public async Task<IActionResult> GetBrandCount()
        {
            var result = await _mediator.Send(new GetBrandCountQuery());
            return Ok(result);
        }

        [HttpGet("GetHourlyAvgPricing")]
        public async Task<IActionResult> GetHourlyAvgPricing()
        {
            var result = await _mediator.Send(new GetHourlyAvgPricingQuery());
            return Ok(result);
        }

        [HttpGet("GetDailyAvgPricing")]
        public async Task<IActionResult> GetDailyAvgPricing()
        {
            var result = await _mediator.Send(new GetDailyAvgPricingQuery());
            return Ok(result);
        }

        [HttpGet("GetWeeklyAvgPricing")]
        public async Task<IActionResult> GetWeeklyAvgPricing()
        {
            var result = await _mediator.Send(new GetWeeklyAvgPricingQuery());
            return Ok(result);
        }

        [HttpGet("GetCarsWithAutomaticTransmission")]
        public async Task<IActionResult> GetCarsWithAutomaticTransmission()
        {
            var result = await _mediator.Send(new GetCarsWithAutomaticTransmissionQuery());
            return Ok(result);
        }

        [HttpGet("GetBrandWithTheMostCar")]
        public async Task<IActionResult> GetBrandWithTheMostCar()
        {
            var result = await _mediator.Send(new GetBrandWithTheMostCarQuery());
            return Ok(result);
        }

        [HttpGet("GetBlogTitleWithTheMostComments")]
        public async Task<IActionResult> GetBlogTitleWithTheMostComments()
        {
            var result = await _mediator.Send(new GetBlogTitleWithTheMostCommentsQuery());
            return Ok(result);
        }

        [HttpGet("GetCarWithLessThan1000Km")]
        public async Task<IActionResult> GetCarWithLessThan1000Km()
        {
            var result = await _mediator.Send(new GetCarWithLessThan1000KmQuery());
            return Ok(result);
        }

        [HttpGet("GetGasolineOrDieselCar")]
        public async Task<IActionResult> GetGasolineOrDieselCar()
        {
            var result = await _mediator.Send(new GetGasolineOrDieselCarQuery());
            return Ok(result);
        }

        [HttpGet("GetElectricCar")]
        public async Task<IActionResult> GetElectricCar()
        {
            var result = await _mediator.Send(new GetElectricCarQuery());
            return Ok(result);
        }

        [HttpGet("GetCarModelWithTheMostExpensiveDailyPricing")]
        public async Task<IActionResult> GetCarModelWithTheMostExpensiveDailyPricing()
        {
            var result = await _mediator.Send(new GetCarModelWithTheMostExpensiveDailyPricingQuery());
            return Ok(result);
        }

        [HttpGet("GetCarModelWithTheCheapestDailyPricing")]
        public async Task<IActionResult> GetCarModelWithTheCheapestDailyPricing()
        {
            var result = await _mediator.Send(new GetCarModelWithTheCheapestDailyPricingQuery());
            return Ok(result);
        }
    }
}
