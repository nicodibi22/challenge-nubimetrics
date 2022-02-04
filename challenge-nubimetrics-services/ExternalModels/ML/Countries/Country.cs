using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace challenge_nubimetrics_services.ExternalModels.ML.Countries
{
    [Serializable]
    public class Country
    {
        [JsonProperty("id")]
        public virtual string Id { get; set; }

        [JsonProperty("name")]
        public virtual string Name { get; set; }

        [JsonProperty("locale")]
        public virtual string Locale { get; set; }
        
        [JsonProperty("currency_id")]
        public virtual string Currency_Id { get; set; }
        
        [JsonProperty("decimal_separator")]
        public virtual string Decimal_Separator { get; set; }
        
        [JsonProperty("thousands_separator")]
        public virtual string Thousands_Separator { get; set; }

        [JsonProperty("time_zone")]
        public virtual string Time_Zone { get; set; }

        [JsonProperty("geo_information")]
        public virtual GeoInformation Geo_Information { get; set; }

        public virtual IList<State> States { get; set; }
    }
}
