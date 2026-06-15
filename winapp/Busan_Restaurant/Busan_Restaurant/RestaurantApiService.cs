using System;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Busan_Restaurant
{
    internal class RestaurantApiService
    {
 
        private readonly HttpClient _httpClient = new HttpClient();

        private readonly string _serviceKey = string.Empty;

        public RestaurantApiService()
        {
            try
            {
           
                string path = @"C:\Users\User\Desktop\code\key.txt";
                string content = File.ReadAllText(path);
                
                _serviceKey = content.Trim();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"API 키 읽기 실패: {ex.Message}");
            }
        }
        public async Task<List<Restaurant>> GetRestaurantsAsync()
        {
            
            string url = $"http://apis.data.go.kr/6260000/FoodService/getFoodKr?serviceKey={_serviceKey}&pageNo=1&numOfRows=200&resultType=json";

            try
            {
                var response = await _httpClient.GetStringAsync(url);

    
                System.Diagnostics.Debug.WriteLine("===== API 응답 원본 =====");
                System.Diagnostics.Debug.WriteLine(response);
                System.Diagnostics.Debug.WriteLine("=========================");
                if (response.Trim().StartsWith("<"))
                {
                    System.Windows.MessageBox.Show("API 통신 실패: JSON이 아닌 XML 에러가 반환되었습니다. 디버그 창을 확인하세요.");
                    return new List<Restaurant>();
                }

                using JsonDocument doc = JsonDocument.Parse(response);
                JsonElement root = doc.RootElement;

                if (root.TryGetProperty("getFoodKr", out JsonElement getFoodKr) &&
                    getFoodKr.TryGetProperty("item", out JsonElement itemArray))
                {
                    var result = JsonSerializer.Deserialize<List<Restaurant>>(itemArray.GetRawText());
                    System.Diagnostics.Debug.WriteLine($"성공적으로 파싱된 데이터 개수: {result?.Count ?? 0}");
                    return result ?? new List<Restaurant>();
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("JSON 구조에 'getFoodKr' 또는 'item' 노드가 없습니다.");
                }

                return new List<Restaurant>();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"에러 발생: {ex.Message}");
                return new List<Restaurant>();
            }
        }
    }
}
