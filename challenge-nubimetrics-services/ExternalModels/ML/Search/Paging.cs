using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace challenge_nubimetrics_services.ExternalModels.ML.Search
{
    public class Paging
    {
        [JsonProperty("total")]
        public int Total { get; set; }
        
        [JsonProperty("primary_results")]
        public int Primary_Results { get; set; }

        [JsonProperty("offset")]
        public int Offset { get; set; }

        [JsonProperty("limit")]
        public int Limit { get; set; }
    }
}
