using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace WpfCctvMonitorApp.Models
{
    public class CctvResponse
    {
        [JsonProperty("response")]
        public ResponseData Response { get; set; } = new();
    }

    public class ResponseData
    {
        [JsonProperty("coordtype")]
        public int CoordType { get; set; } = 0;

        [JsonProperty("Data")]
       public List<CctvInfo> Data { get; set; } = new();

        [JsonProperty("datacount")]
        public int DataCount { get; set; } = 0;
    }
}
