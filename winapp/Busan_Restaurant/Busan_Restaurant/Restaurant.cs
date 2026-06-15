using System.Text.Json.Serialization;

namespace Busan_Restaurant
{
    public class Restaurant
    {
        [JsonPropertyName("MAIN_TITLE")]
        public string? Name { get; set; }

        [JsonPropertyName("GUGUN_NM")]
        public string? District { get; set; }

        [JsonPropertyName("TITLE")]
        public string? Title { get; set; }

        [JsonPropertyName("ADDR1")]
        public string? Address { get; set; }

        [JsonPropertyName("CNTCT_TEL")]
        public string? PhoneNumber { get; set; }

        [JsonPropertyName("MAIN_IMG_THUMB")]
        public string? ImageUrl { get; set; }
    }
}