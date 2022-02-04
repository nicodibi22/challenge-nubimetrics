﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace challenge_nubimetrics_services.ExternalModels.ML.Search
{
    public class Filter
    {
        [JsonProperty("id")]
        public string Id { get; set; }        

        [JsonProperty("values")]
        public IList<ValueFilter> Values { get; set; }
    }
}
