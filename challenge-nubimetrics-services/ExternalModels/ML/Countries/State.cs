using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace challenge_nubimetrics_services.ExternalModels.ML.Countries
{
    public class State
    {
        [JsonProperty("id")]
        public virtual string Id { get; set; }

        [JsonProperty("name")]
        public virtual string Name { get; set; }
    }
}
