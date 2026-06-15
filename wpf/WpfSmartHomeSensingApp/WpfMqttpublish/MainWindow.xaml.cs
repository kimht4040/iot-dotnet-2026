using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;
using Bogus;
using MQTTnet;
using Newtonsoft.Json;
using WpfMqttpublish.Models;
using MahApps.Metro.Controls;

namespace WpfMqttpublish
{
    public partial class MainWindow : MetroWindow
    {
        private IMqttClient _mqttClient;
        private DispatcherTimer _timer;
        private Faker<SensorData> _sensorFaker;

        public MainWindow()
        {
            InitializeComponent();
            InitializeFaker();
            
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(2);
            _timer.Tick += Timer_Tick;
        }

        private void InitializeFaker()
        {
            _sensorFaker = new Faker<SensorData>()
                .RuleFor(s => s.HomeId, f => "HOME01")
                .RuleFor(s => s.RoomName, f => f.PickRandom("Living Room", "Bedroom", "Kitchen", "Bathroom"))
                .RuleFor(s => s.SensingDateTime, f => DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                .RuleFor(s => s.Temp, f => Math.Round(f.Random.Double(18, 30), 1))
                .RuleFor(s => s.Humid, f => Math.Round(f.Random.Double(30, 70), 1));
        }

        private async void BtnConnect_Click(object sender, RoutedEventArgs e)
        {
            var mqttFactory = new MqttClientFactory();
            _mqttClient = mqttFactory.CreateMqttClient();

            int port = 1883;
            int.TryParse(TxtPort.Text, out port);

            var optionsBuilder = new MqttClientOptionsBuilder()
                .WithTcpServer(TxtBrokerAddress.Text, port)
                .WithCleanSession();

            if (!string.IsNullOrEmpty(TxtUser.Text))
            {
                optionsBuilder.WithCredentials(TxtUser.Text, TxtPassword.Password);
            }

            var options = optionsBuilder.Build();

            try
            {
                var result = await _mqttClient.ConnectAsync(options, CancellationToken.None);
                
                if (result.ResultCode == MqttClientConnectResultCode.Success)
                {
                    Log("Connected to MQTT broker.");
                    TxtStatus.Text = "Connected";
                    TxtStatus.Foreground = Brushes.Green;
                    BtnConnect.IsEnabled = false;
                    BtnStartPublish.IsEnabled = true;
                }
                else
                {
                    Log($"Connection failed: {result.ResultCode}");
                }
            }
            catch (Exception ex)
            {
                Log($"Connection error: {ex.Message}");
                if (ex.InnerException != null)
                    Log($"Inner error: {ex.InnerException.Message}");
            }
        }

        private void BtnStartPublish_Click(object sender, RoutedEventArgs e)
        {
            if (_timer.IsEnabled)
            {
                _timer.Stop();
                BtnStartPublish.Content = "Start Publishing";
                Log("Stopped publishing.");
            }
            else
            {
                _timer.Start();
                BtnStartPublish.Content = "Stop Publishing";
                Log("Started publishing.");
            }
        }

        private async void Timer_Tick(object? sender, EventArgs e)
        {
            if (_mqttClient != null && _mqttClient.IsConnected)
            {
                var sensorData = _sensorFaker.Generate();
                sensorData.SensingDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                
                var json = JsonConvert.SerializeObject(sensorData);
                var message = new MqttApplicationMessageBuilder()
                    .WithTopic(TxtTopic.Text)
                    .WithPayload(json)
                    .WithQualityOfServiceLevel(MQTTnet.Protocol.MqttQualityOfServiceLevel.AtMostOnce)
                    .Build();

                await _mqttClient.PublishAsync(message, CancellationToken.None);
                Log($"Published: {json}");
            }
            else
            {
                _timer.Stop();
                BtnStartPublish.Content = "Start Publishing";
                Log("Connection lost. Stopped publishing.");
                TxtStatus.Text = "Disconnected";
                TxtStatus.Foreground = Brushes.Red;
                BtnConnect.IsEnabled = true;
                BtnStartPublish.IsEnabled = false;
            }
        }

        private void Log(string message)
        {
            Dispatcher.Invoke(() =>
            {
                LstLog.Items.Insert(0, $"[{DateTime.Now:HH:mm:ss}] {message}");
            });
        }
    }
}