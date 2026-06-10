using MahApps.Metro.Controls;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using WpfBusanFestivalApp.Models;

namespace WpfBusanFestivalApp
{
    public partial class MainWindow : MetroWindow
    {
        private readonly FestivalApiService _apiService;

        public MainWindow()
        {
            InitializeComponent();
            _apiService = new FestivalApiService();
            this.Loaded += MetroWindow_Loaded;
            BtnSearch.Click += BtnSearch_Click;
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // Initial load if needed
        }

        private async void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            int pageNo = (int)NumPageNo.Value;
            int numOfRows = (int)NumRows.Value;

            try
            {
                PgbLoading.Visibility = Visibility.Visible;
                BtnSearch.IsEnabled = false;

                var festivals = await _apiService.GetFestivalsAsync(pageNo, numOfRows);
                if (festivals != null)
                {
                    DgFestival.ItemsSource = festivals;
                    TxtStatus.Text = $"{festivals.Count}건 조회됨";
                }
                else
                {
                    MessageBox.Show("API 키가 설정되지 않았거나 데이터를 가져올 수 없습니다. 환경변수 'BUSAN_FESTIVAL_API_KEY'를 확인하세요.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"데이터를 가져오는 중 오류가 발생했습니다: {ex.Message}");
            }
            finally
            {
                PgbLoading.Visibility = Visibility.Collapsed;
                BtnSearch.IsEnabled = true;
            }
        }

        private void DgFestival_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DgFestival.SelectedItem is FestivalItem item)
            {
                // 주소나 위경도를 이용하여 지도를 표시하거나 홈페이지를 표시
                if (!string.IsNullOrEmpty(item.HomepageUrl))
                {
                    BrsFestival.Address = item.HomepageUrl;
                }
                else
                {
                    // 홈페이지가 없는 경우 구글 지도에서 장소 검색
                    string searchUrl = $"https://www.google.com/maps/search/{Uri.EscapeDataString(item.Place)}";
                    BrsFestival.Address = searchUrl;
                }
            }
        }
    }
}