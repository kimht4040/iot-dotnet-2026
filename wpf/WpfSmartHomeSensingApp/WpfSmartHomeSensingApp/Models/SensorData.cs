using System;
using System.Diagnostics;
using Bogus;

namespace WpfSmartHomeSensingApp.Models
{
    public class SensorData
    {
        public string HomeId { get; set; }
        public string RoomName { get; set; }
        public string SensingDateTime { get; set; }
        public double Temp { get; set; }
        public double Humid { get; set; }
    }
}