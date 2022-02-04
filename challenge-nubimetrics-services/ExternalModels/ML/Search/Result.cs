using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace challenge_nubimetrics_services.ExternalModels.ML.Search
{
    public class Result
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        
        [JsonProperty("site_id")]
        public string Site_Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("seller")]
        public Seller Seller { get; set; }

        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("permalink")]
        public string Permalink { get; set; }
        
    }
}
