
using Bogus;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Microsoft.Win32;
using MQTTnet;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfSmartHomeSensingApp.Helpers;
using WpfSmartHomeSensingApp.Models;

namespace WpfSmartHomeSensingApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private bool IsConnected {  get; set; }
        private string[] Rooms { get; set; }
        private string HomeID { get; set; }
        private Faker SmartHomeFaker { get; set; }


        private CancellationTokenSource? _cts; //스레드 캔슬 객체 : 비동기 작업 중지 시키는 객체

        private IMqttClient? MqttClient { get; set; }
        private string MqttHost { get; set; } = "localhost";
        private int MqttPort { get; set; } = 1883;
        private string MqttUser { get; set; } = "root";
        private string MqttPassword { get; set; } = "mqtt123456";

        private string MqttTopic { get; set; } = "home/sensor";
        public MainWindow()
        {
            
            InitializeComponent();
            // 커스텀 초기화
            IsConnected = false;
            InitFakeData();
        }

        private void InitFakeData()
        {
            Rooms = [ "bed", "living", "kitchen", "bath" ];
            HomeID = "qweqwe";
            SmartHomeFaker = new Faker();
          
        }

        private async void BtnConnect_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(TxtMqttBrokerIp.Text))
            {
                await this.ShowMessageAsync("오류", "MQTT브로커 주소를 입력하세요.");
               
                return;
            }
            if (IsConnected == false)
            {
                IsConnected = true;
                TxtStatus.Text = "disconnected";
                // 센싱 시작
                SbiStatus.Text = "연결시작";
                StartSensing();
            }
            else
            {
                IsConnected = false;
                TxtStatus.Text = "connected";
                SbiStatus.Text = "연결종료";
                StopSensing();
               
            }
            

        }

        private void StopSensing()
        {
            _cts?.Cancel();
        }

        private async void StartSensing()
        {
            _cts = new CancellationTokenSource();
            try
            {
                while (!_cts.Token.IsCancellationRequested)
                {

                    List<SensorData> lists = Rooms.Select(room => new SensorData
                    {
                        HomeId = HomeID,
                        RoomName = room,
                        SensingDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                        Temp = Math.Round(SmartHomeFaker.Random.Double(15.0, 30.0), 1),
                        Humid = Math.Round(SmartHomeFaker.Random.Double(30.0, 70.0), 1),
                    }).ToList();

                    string json = JsonSerializer.Serialize(lists, new JsonSerializerOptions { WriteIndented = true });

                    AddLogs("home/sensor", json);
                    Console.WriteLine(json);

                    await Task.Delay(TimeSpan.FromSeconds(1));

                }
            }
            catch(Exception)
            { 
            
            }

        }

        private void AddLogs(string v, string json)
        {

            //RtbLog.AppendText($"{v} : { json}\r\n");// 이방식으로 입력가능
            Dispatcher.Invoke(() =>
            {
                Paragraph p = new Paragraph();
                p.Margin = new Thickness(0, 0, 0, 0);
                p.Inlines.Add(
                    new Run($"TOPIC : {json}\n"){
                    FontWeight = FontWeights.Bold,
                    });
                p.Inlines.Add(
                    new Run($"[{DateTime.Now: HH:mm:ss}]")
                    {
                        FontWeight = FontWeights.Bold,
                        Foreground = new SolidColorBrush(Colors.Blue)
                    });
                p.Inlines.Add(
                    new Run(v)
                    {
                        FontWeight = FontWeights.Bold,
                    }
                    
                    );
                RtbLog.Document.Blocks.Add(p);
                if (RtbLog.Document.Blocks.Count > 10)
                {
                    RtbLog.Document.Blocks.Remove(
                        RtbLog.Document.Blocks.FirstBlock);
                }
            });

            RtbLog.ScrollToEnd();

        }
    }
}