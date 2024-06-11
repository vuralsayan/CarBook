using CarBook.WebApi.ViewModels;
using Microsoft.AspNetCore.SignalR;
using System.Text.Json;

namespace CarBook.WebApi.Hubs
{
    public class CarHub : Hub
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CarHub(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task SendCarCount()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7073/api/Statistics/GetCarCount");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonSerializer.Deserialize<CarCountResponse>(jsonData);
            if (value != null)
            {
                await Clients.All.SendAsync("ReceiveCarCount", value.CarCount);
            }
        }
    }
}
