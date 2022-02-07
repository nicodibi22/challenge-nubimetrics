using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace challenge_nubimetrics_services.ExternalModels.ML.Currencies
{
    public class Currency
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("decimal_places")]
        public int Decimal_Places { get; set; }
    
    }
}
