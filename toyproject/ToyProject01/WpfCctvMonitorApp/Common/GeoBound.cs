using System;
using System.Collections.Generic;
using System.Text;

namespace WpfCctvMonitorApp.Common
{
    public class GeoBound
    {
        public double MinLat { get; }
        public double MaxLat { get; }

        public double MinLng { get; }
        public double MaxLng { get; }


        //파라미터 할당 생성자
        public GeoBound(double minLat, double maxLat, double minLng, double maxLng)
        {
            MinLat = minLat;
            MaxLat = maxLat;
            MinLng = minLng;
            MaxLng = maxLng;
        }
        //todo
        public static string BuildGetQueryString(GeoBound geoBound)
        {
            return "";
        }
        public static readonly Dictionary<string, GeoBound> RegionBounds = new()
        {
            ["인천"] = new GeoBound(37.0000, 37.9500, 124.6000, 126.8500),
            ["경기"] = new GeoBound(36.8900, 38.3000, 126.3700, 127.8500),
            ["강원"] = new GeoBound(37.0200, 38.6200, 127.0500, 129.3700),

            ["충북"] = new GeoBound(36.0000, 37.2500, 127.2500, 128.7300),
            ["충남"] = new GeoBound(35.9800, 37.0600, 126.1000, 127.6400),
            ["세종"] = new GeoBound(36.4000, 36.7500, 127.1500, 127.4500),
            ["대전"] = new GeoBound(36.1800, 36.5000, 127.2500, 127.5500),

            ["전북"] = new GeoBound(35.3000, 36.1700, 126.4300, 127.8800),
            ["전남"] = new GeoBound(33.9000, 35.5000, 125.0000, 127.9000),
            ["광주"] = new GeoBound(35.0000, 35.3000, 126.6500, 127.0500),

            ["경북"] = new GeoBound(35.6000, 37.5600, 128.0000, 130.9000),
            ["대구"] = new GeoBound(35.6090, 36.0100, 128.3490, 128.7780),
            ["울산"] = new GeoBound(35.3200, 35.7500, 129.0000, 129.4700),
            ["부산"] = new GeoBound(34.8799, 35.3959, 128.7384, 129.3729),
            ["경남"] = new GeoBound(34.5600, 35.9200, 127.5600, 129.3100),

            ["제주"] = new GeoBound(33.1000, 33.6000, 126.1000, 126.9500),

        };
    }
}
