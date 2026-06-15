using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using MQTTnet;
using Newtonsoft.Json;
using WpfMqttsubscriber.Models;
using MahApps.Metro.Controls;

namespace WpfMqttsubscriber
{
    public partial class MainWindow : MetroWindow
    {
        private IMqttClient _mqttClient;

        public MainWindow()
        {
            InitializeComponent();
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

            _mqttClient.ApplicationMessageReceivedAsync += e =>
            {
                var payload = Encoding.UTF8.GetString(e.ApplicationMessage.Payload);
                Log($"Received message on topic '{e.ApplicationMessage.Topic}': {payload}");

                try
                {
                    var sensorData = JsonConvert.DeserializeObject<SensorData>(payload);
                    if (sensorData != null)
                    {
                        Log($"Parsed Data: Room={sensorData.RoomName}, Temp={sensorData.Temp}, Humid={sensorData.Humid}");
                    }
                }
                catch (Exception ex)
                {
                    Log($"Parsing failed: {ex.Message}");
                }

                return Task.CompletedTask;
            };

            try
            {
                var result = await _mqttClient.ConnectAsync(options, CancellationToken.None);
                
                if (result.ResultCode == MqttClientConnectResultCode.Success)
                {
                    Log("Connected to MQTT broker.");
                    TxtStatus.Text = "Connected";
                    TxtStatus.Foreground = Brushes.Green;

                    var subscribeOptions = mqttFactory.CreateSubscribeOptionsBuilder()
                        .WithTopicFilter(f => f.WithTopic(TxtTopic.Text))
                        .Build();

                    await _mqttClient.SubscribeAsync(subscribeOptions, CancellationToken.None);
                    Log($"Subscribed to topic: {TxtTopic.Text}");

                    BtnConnect.IsEnabled = false;
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

        private void Log(string message)
        {
            Dispatcher.Invoke(() =>
            {
                LstLog.Items.Insert(0, $"[{DateTime.Now:HH:mm:ss}] {message}");
            });
        }
    }
}