using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace WpfBusanFestivalApp.Models
{
    class FestivalData
    {
        [JsonProperty("item")]
        public ObservableCollection<FestivalItem> Items { get; set; }
    }
}
