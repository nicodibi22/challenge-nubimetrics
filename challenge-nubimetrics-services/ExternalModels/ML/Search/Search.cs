using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace challenge_nubimetrics_services.ExternalModels.ML.Search
{
    public class Search
    {
        [JsonProperty("site_id")]
        public string Site_Id { get; set; }

        [JsonProperty("country_default_time_zone")]
        public string Country_Default_Time_Zone { get; set; }

        [JsonProperty("query")]
        public string Query { get; set; }

        [JsonProperty("paging")]
        public Paging Paging { get; set; }

        [JsonProperty("results")]
        public List<Result> Results { get; set; }

        [JsonProperty("sort")]
        public Sort Sort { get; set; }
        
        [JsonProperty("available_sorts")]
        public List<AvailableSort> Available_Sorts { get; set; }

        [JsonProperty("filters")]
        public List<Filter> Filters { get; set; }

        [JsonProperty("available_filters")]
        public List<AvailableFilter> Available_Filters { get; set; }
    }
}
