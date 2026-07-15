using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using WpfCctvMonitorApp.Models;

namespace WpfCctvMonitorApp.Services
{
    public class ItsCctvService
    {
        private readonly HttpClient httpClient = new();

        public async Task<CctvResponse> GetCctvListAsync(string apiUrl)
        {
            try
            {
                string json = await httpClient.GetStringAsync(apiUrl);
                var result = JsonConvert.DeserializeObject<CctvResponse>(json);

                return result ?? new CctvResponse();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"API 통신/파싱 에러: {ex.Message}");
                return new CctvResponse(); // 에러 발생 시 빈 객체 반환
            }
        }

        //GetAllCctvListAsync는 나중에 전체 조회가 필요할 때 구현하세요
        public static async Task<ObservableCollection<CctvInfo>> GetAllCctvListAsync()
        {
            return await Task.FromResult(new ObservableCollection<CctvInfo>());
        }
    }
}