using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace challenge_nubimetrics_services.ExternalModels.ML.Search
{
    public class Struct
    {
        [JsonProperty("number")]
        public double Number { get; set; }

        [JsonProperty("unit")]
        public string Unit { get; set; }
    }
}
