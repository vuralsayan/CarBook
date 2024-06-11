using CarBook.Dto.CarPricingDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Controllers
{
	[AllowAnonymous]
    public class CarPricingController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

		public CarPricingController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
        {
            ViewBag.v = "Paketler";
            ViewBag.v2 = "Araç Fiyat Paketleri";

            var client = _httpClientFactory.CreateClient();
			var reponseMessage = await client.GetAsync("https://localhost:7073/api/CarPricings/GetCarPricingWithTimePeriod");
			if (reponseMessage.IsSuccessStatusCode)
			{
				var jsonData = await reponseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultCarPricingListWithModelDto>>(jsonData);
				return View(values);

			}

			return View();
        }
    }
}
