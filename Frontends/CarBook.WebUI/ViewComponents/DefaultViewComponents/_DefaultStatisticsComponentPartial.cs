using CarBook.Dto.StatisticDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultStatisticsComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultStatisticsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();

            // Araç Sayısı
            var responseMessage = await client.GetAsync("https://localhost:7073/api/Statistics/GetCarCount");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData);
                ViewBag.CarCount = values?.CarCount ?? 0;
                
            }

            // Lokasyon Sayısı
            var responseMessage2 = await client.GetAsync("https://localhost:7073/api/Statistics/GetLocationCount");
            if (responseMessage2.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage2.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData);
                ViewBag.LocationCount = values?.LocationCount ?? 0; 
            }

            // Marka Sayısı
            var responseMessage3 = await client.GetAsync("https://localhost:7073/api/Statistics/GetBrandCount");
            if (responseMessage3.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage3.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData);
                ViewBag.BrandCount = values?.BrandCount ?? 0;
            }

            // Elektirikli Araç Sayısı
            var responseMessage4 = await client.GetAsync("https://localhost:7073/api/Statistics/GetElectricCar");
            if (responseMessage4.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage4.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData);
                ViewBag.ElectricCarCount = values?.ElectricCarCount ?? 0;
            }

            return View();
        }
    }
}
