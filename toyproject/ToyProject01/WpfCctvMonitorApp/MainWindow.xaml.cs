using LibVLCSharp.Shared;
using System; // Uri를 사용하기 위해 필요합니다.
using System.Configuration;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfCctvMonitorApp.Common;
using WpfCctvMonitorApp.Services;

namespace WpfCctvMonitorApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly LibVLC libVLC;
        private readonly MediaPlayer mediaPlayer;
        // 지역 선택한 위경도 범위 저장할 변수
        private GeoBound selectedRegionBound;
        private ItsCctvService itsCctvService;

        public MainWindow()
        {
            InitializeComponent();

           
            Core.Initialize();

            InitComboItems();
            libVLC = new LibVLC();
            mediaPlayer = new MediaPlayer(libVLC);
            VideoView.MediaPlayer = mediaPlayer;
            itsCctvService = new Services.ItsCctvService();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // 나중에 지우셈
            var media = new Media(libVLC, new Uri("https://cctvsec.ktict.co.kr:8082/mgmt026/mgmtcctv00005799D/main_stream.m3u8?nimblesessionid=22611035&wmsAuthSign=c2VydmVyX3RpbWU9Ny8xLzIwMjYgNDozMzo1OSBBTSZoYXNoX3ZhbHVlPTZIaE9QVEx0REg4WU1WaVlvZG8zRUE9PSZ2YWxpZG1pbnV0ZXM9MTIwJmlkPW1sdG0jbnRpY2xpdmUjODc0Ng==\r\n"));

            mediaPlayer.Play(media);

            Common.AppCommon.ItsApiKey = ConfigurationManager.AppSettings["ItsApiKey"];
            MessageBox.Show(Common.AppCommon.ItsApiKey);

        }
        private void InitComboItems()
        {
            CmbRegion.Items.Clear();


            foreach (var region in AppCommon.Regions)
            {
                CmbRegion.Items.Add(region);
            }

            CmbRegion.SelectedIndex = 0;

        }
        private void BtnExpress_Click(object sender, RoutedEventArgs e)
        {
            Common.AppCommon.RoadType = "ex";
        }

        private void BtnNational_Click(object sender, RoutedEventArgs e)
        {
            Common.AppCommon.RoadType = "na";
        }

        private void BtnFavorites_Click(object sender, RoutedEventArgs e)
        {
            Common.AppCommon.RoadType = "fav";
        }

        private void CmbRegion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Debug.WriteLine(CmbRegion.SelectedItem);
            if (CmbRegion.SelectedIndex > 0)
            {
                //MessageBox.Show(CmbRegion.SelectedValue.ToString());
                selectedRegionBound = GetRegionBounds(CmbRegion.SelectedValue.ToString());
                Debug.WriteLine(selectedRegionBound.MinLat);
                Debug.WriteLine(selectedRegionBound.MaxLat);
                Debug.WriteLine(selectedRegionBound.MinLng);
                Debug.WriteLine(selectedRegionBound.MaxLng);

            }
        }

        private GeoBound GetRegionBounds(string regionName)
        {
            if (string.IsNullOrWhiteSpace(regionName))
            {
                return AppCommon.RegionBounds["서울"];

            }
            return AppCommon.RegionBounds.TryGetValue(regionName, out GeoBound bound)
                ? bound
                : AppCommon.RegionBounds["서울"];
        }

        // async 키워드 추가 필수!
        private async void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            // 1. 좌표 설정
            AppCommon.MinX = selectedRegionBound.MinLng;
            AppCommon.MaxX = selectedRegionBound.MaxLng;
            AppCommon.MinY = selectedRegionBound.MinLat;
            AppCommon.MaxY = selectedRegionBound.MaxLat;


            var totalApiUrl = AppCommon.BuildCctvApiUrl();

            var result = await itsCctvService.GetCctvListAsync(totalApiUrl);

            if (result != null && result.Response != null)
            {


                int count = result.Response.Data.Count;
                Debug.WriteLine($"검색 완료: 총 {count}건");
            }
            else
            {
                Debug.WriteLine("데이터가 없습니다.");
            }
        }
    }
}