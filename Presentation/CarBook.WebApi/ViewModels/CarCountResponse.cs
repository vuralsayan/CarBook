using System.Text.Json.Serialization;

namespace CarBook.WebApi.ViewModels
{
    public class CarCountResponse
    {
        [JsonPropertyName("carCount")]
        public int CarCount { get; set; }

    }
}
