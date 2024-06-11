using CarBook.Dto.StatisticDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class AdminStatisticController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminStatisticController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7073/api/Statistics/GetCarCount");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData)!;
                ViewBag.CarCount = values.CarCount; 
            }

            var responseMessage2 = await client.GetAsync("https://localhost:7073/api/Statistics/GetLocationCount");
            if (responseMessage2.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage2.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData)!;
                ViewBag.LocationCount = values.LocationCount;
            }

            var responseMessage3 = await client.GetAsync("https://localhost:7073/api/Statistics/GetAuthorCount");
            if (responseMessage3.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage3.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData)!;
                ViewBag.AuthorCount = values.AuthorCount;
            }

            var responseMessage4 = await client.GetAsync("https://localhost:7073/api/Statistics/GetBlogCount");
            if (responseMessage4.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage4.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData)!;
                ViewBag.BlogCount = values.BlogCount;
            }

            var responseMessage5 = await client.GetAsync("https://localhost:7073/api/Statistics/GetBrandCount");
            if (responseMessage5.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage5.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData)!;
                ViewBag.BrandCount = values.BrandCount;
            }

            var responseMessage6 = await client.GetAsync("https://localhost:7073/api/Statistics/GetHourlyAvgPricing");
            if (responseMessage6.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage6.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData)!;
                ViewBag.HourlyAvgPricing = values.HourlyAvgPricing;
            }

            var responseMessage7 = await client.GetAsync("https://localhost:7073/api/Statistics/GetDailyAvgPricing");
            if (responseMessage7.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage7.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData)!;
                ViewBag.DailyAvgPricing = values.DailyAvgPricing;
            }

            var responseMessage8 = await client.GetAsync("https://localhost:7073/api/Statistics/GetWeeklyAvgPricing");
            if (responseMessage8.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage8.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData)!;
                ViewBag.WeeklyAvgPricing = values.WeeklyAvgPricing;
            }

            var responseMessage9 = await client.GetAsync("https://localhost:7073/api/Statistics/GetCarsWithAutomaticTransmission");
            if (responseMessage9.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage9.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData)!;
                ViewBag.AutomaticTransmissionCarCount = values.AutomaticTransmissionCarCount;
            }

            var responseMessage10 = await client.GetAsync("https://localhost:7073/api/Statistics/GetBrandWithTheMostCar");
            if (responseMessage10.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage10.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData)!;
                ViewBag.BrandName = values.BrandName;
            }

            var responseMessage11 = await client.GetAsync("https://localhost:7073/api/Statistics/GetBlogTitleWithTheMostComments");
            if (responseMessage11.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage11.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData)!;
                ViewBag.BlogTitle = values.BlogTitle;
            }

            var responseMessage12 = await client.GetAsync("https://localhost:7073/api/Statistics/GetCarWithLessThan1000Km");
            if (responseMessage12.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage12.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData)!;
                ViewBag.CarCountLessThan1000Km = values.CarCount;
            }

            var responseMessage13 = await client.GetAsync("https://localhost:7073/api/Statistics/GetGasolineOrDieselCar");
            if (responseMessage13.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage13.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData)!;
                ViewBag.GasolineOrDieselCarCount = values.GasolineOrDieselCarCount;
            }

            var responseMessage14 = await client.GetAsync("https://localhost:7073/api/Statistics/GetElectricCar");
            if (responseMessage14.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage14.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData)!;
                ViewBag.ElectricCarCount = values.ElectricCarCount;
            }

            var responseMessage15 = await client.GetAsync("https://localhost:7073/api/Statistics/GetCarModelWithTheMostExpensiveDailyPricing");
            if (responseMessage15.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage15.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData)!;
                ViewBag.MostExpensiveCarModel = values.CarModel;
            }

            var responseMessage16 = await client.GetAsync("https://localhost:7073/api/Statistics/GetCarModelWithTheCheapestDailyPricing");
            if (responseMessage16.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage16.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData)!;
                ViewBag.CheapestCarModel = values.CarModel;
            }

            return View();
        }
    }
}
