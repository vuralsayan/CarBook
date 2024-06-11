using CarBook.Dto.LocationDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace CarBook.WebUI.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DefaultController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var token = User.Claims.FirstOrDefault(x => x.Type == "accessToken")?.Value;
            if (token != null)
            {
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var reponseMessage = await client.GetAsync("https://localhost:7073/api/Locations");
                if (reponseMessage.IsSuccessStatusCode)
                {
                    var jsonData = await reponseMessage.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<List<ResultLocationDto>>(jsonData);
                    List<SelectListItem> locations = (from x in values
                                                      select new SelectListItem
                                                      {
                                                          Text = x.Name,
                                                          Value = x.LocationID.ToString()
                                                      }).ToList();
                    ViewBag.Locations = locations;

                }
            }


            return View();
        }

        [HttpPost]
        public IActionResult Index(int pickUpLocation, string pickUpDate, string dropOffDate, string pickUpTime, string dropOffTime)
        {
            TempData["pickUpLocation"] = pickUpLocation;
            TempData["pickUpDate"] = pickUpDate;
            TempData["dropOffDate"] = dropOffDate;
            TempData["pickUpTime"] = pickUpTime;
            TempData["dropOffTime"] = dropOffTime;
            return RedirectToAction("Index", "RentACarList");
        }
    }
}
