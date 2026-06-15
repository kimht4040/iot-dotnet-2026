using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System;
using System.Diagnostics;

namespace Busan_Restaurant
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly RestaurantApiService _apiService = new RestaurantApiService();

       
        private List<Restaurant> _allRestaurants = new List<Restaurant>();

        public ObservableCollection<Restaurant> FilteredRestaurants { get; set; } = new ObservableCollection<Restaurant>();

        private string? _selectedDistrict;
        public string? SelectedDistrict
        {
            get => _selectedDistrict;
            set
            {
                _selectedDistrict = value;
                OnPropertyChanged();
                FilterData();
            }
        }

        public List<string> Districts { get; set; } = new List<string>
        { "전체", "해운대구", "수영구", "부산진구", "동래구", "중구", "기장군", "사하구", "영도구", "남구", "강서구", "연제구", "서구", "동구", "북구","사상구", "금정구" };

        public MainViewModel()
        {
          
            _ = InitializeDataAsync();
        }

        private async Task InitializeDataAsync()
        {
            _allRestaurants = await _apiService.GetRestaurantsAsync();
            SelectedDistrict = "전체";
        }

        private void FilterData()
        {
            FilteredRestaurants.Clear();

      
            var query = _selectedDistrict == "전체"
                        ? _allRestaurants
                        : _allRestaurants.Where(r => r.District == _selectedDistrict);

            foreach (var item in query)
            {
                FilteredRestaurants.Add(item);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private Restaurant _selectedRestaurant;
        public Restaurant SelectedRestaurant
        {
            get => _selectedRestaurant;
            set
            {
                _selectedRestaurant = value;
                OnPropertyChanged();
                if (_selectedRestaurant != null && !string.IsNullOrEmpty(_selectedRestaurant.Address))
                {
                    // 주소를url 변환하기
                    string? encoded = Uri.EscapeDataString(_selectedRestaurant.Address);
                    // 카카오맵 주소 변환
                    string? mapUrl = $"https://map.kakao.com/link/search/{encoded}";
                    try
                    {
                        Process.Start(new ProcessStartInfo
                        {
                            FileName = mapUrl,
                            UseShellExecute = true
                        });
                    }
                    catch (Exception ex)
                    {
                        System.Windows.MessageBox.Show($"지도를 여는 중 오류가 발생했습니다.\n{ex.Message}");
                    }


                    var temp = _selectedRestaurant;
                    System.Windows.Application.Current.Dispatcher.InvokeAsync(() =>
                    {
                        if (_selectedRestaurant == temp)
                        {
                            _selectedRestaurant = null;
                            OnPropertyChanged(nameof(SelectedRestaurant));
                        }
                    });
                }


            }
        }
    }
}