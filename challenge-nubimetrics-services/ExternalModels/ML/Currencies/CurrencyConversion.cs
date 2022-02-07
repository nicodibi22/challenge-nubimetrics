using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace challenge_nubimetrics_services.ExternalModels.ML.Currencies
{
    public class CurrencyConversion
    {
        [JsonProperty("currency_base")]
        public string Currency_Base { get; set; }

        [JsonProperty("currency_quote")]
        public string Currency_Quote { get; set; }

        [JsonProperty("ratio")]
        public float Ratio { get; set; }
        
        [JsonProperty("rate")]
        public float Rate { get; set; }

        [JsonProperty("inv_rate")]
        public float Inv_Rate { get; set; }

        [JsonProperty("creation_date")]
        public string Creation_Date { get; set; }

        [JsonProperty("valid_until")]
        public string Valid_Until { get; set; }

    }
}
