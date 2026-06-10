using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Net.Http;
using WpfBusanFestivalApp.Models;

namespace WpfBusanFestivalApp.Models
{
    public class FestivalApiService
    {
        private string? ServiceKey { get; set; }

        public FestivalApiService()
        {
            ServiceKey = Environment.GetEnvironmentVariable("BUSAN_FESTIVAL_API_KEY");
        }

        public async Task<ObservableCollection<FestivalItem>?> GetFestivalsAsync(int pageNo = 1, int numOfRows = 10)
        {
            if (string.IsNullOrEmpty(ServiceKey))
            {
                return null;
            }

            // resultType=json 추가
            string serviceUrl = $"https://apis.data.go.kr/6260000/FestivalService/getFestivalKr?serviceKey={ServiceKey}&pageNo={pageNo}&numOfRows={numOfRows}&resultType=json";

            using HttpClient client = new HttpClient();
            try
            {
                string json = await client.GetStringAsync(serviceUrl);
                var response = JsonConvert.DeserializeObject<FestivalResponse>(json);
                return response?.FestivalData?.Items;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
