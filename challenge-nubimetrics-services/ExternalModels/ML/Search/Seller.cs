using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace challenge_nubimetrics_services.ExternalModels.ML.Search
{
    public class Seller
    {
        [JsonProperty("id")]
        public int Id { get; set; }
    }
}
