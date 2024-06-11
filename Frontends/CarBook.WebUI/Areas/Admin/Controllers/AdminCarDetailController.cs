using CarBook.Dto.CarFeatureDtos;
using CarBook.Dto.FeatureDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class AdminCarDetailController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminCarDetailController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var respponseMessage = await client.GetAsync($"https://localhost:7073/api/CarFeatures/GetCarFeaturesByCarId?carId={id}");
            if (respponseMessage.IsSuccessStatusCode)
            {
                var jsonData = await respponseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarFeatureByCarIdDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(List<ResultCarFeatureByCarIdDto> resultCarFeatureByCarIdDto)
        {
            foreach (var item in resultCarFeatureByCarIdDto)
            {
                if (item.Available)
                {
                    var client = _httpClientFactory.CreateClient();
                    await client.GetAsync($"https://localhost:7073/api/CarFeatures/UpdateCarFeatureAvailableChangeToTrue?id={item.CarFeatureID}");
                }
                else
                {
                    var client = _httpClientFactory.CreateClient();
                    await client.GetAsync($"https://localhost:7073/api/CarFeatures/UpdateCarFeatureAvailableChangeToFalse?id={item.CarFeatureID}");
                }
            }

            return RedirectToAction("Index", "AdminCar");

        }

        [HttpGet]
        public async Task<IActionResult> CreateFeatureByCarId()
        {
            var client = _httpClientFactory.CreateClient();
            var respponseMessage = await client.GetAsync($"https://localhost:7073/api/Features");
            if (respponseMessage.IsSuccessStatusCode)
            {
                var jsonData = await respponseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(jsonData);
                return View(values);
            }
            return View();
        }

    }
}
