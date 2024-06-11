using CarBook.Dto.StatisticDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.DashboardComponents
{
    public class _AdminDashboardStatisticComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _AdminDashboardStatisticComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            // Toplam araç sayısı
            var responseMessage = await client.GetAsync("https://localhost:7073/api/Statistics/GetCarCount");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData);
                ViewBag.CarCount = values?.CarCount ?? 0;   
            }

            //Mevcut lokasyon sayısı
            var responseMessage2 = await client.GetAsync("https://localhost:7073/api/Statistics/GetLocationCount");
            if (responseMessage2.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage2.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData);
                ViewBag.LocationCount = values?.LocationCount ?? 0;
            }

            //Toplam yazar sayısı
            var responseMessage3 = await client.GetAsync("https://localhost:7073/api/Statistics/GetAuthorCount");
            if (responseMessage3.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage3.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData);
                ViewBag.AuthorCount = values?.AuthorCount ?? 0;
            }

            //Toplam blog sayısı
            var responseMessage4 = await client.GetAsync("https://localhost:7073/api/Statistics/GetBlogCount");
            if (responseMessage4.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage4.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData);
                ViewBag.BlogCount = values?.BlogCount ?? 0;
            }
            return View();
        }
    }
}
