using System;
using System.Collections.Generic;
using System.Text;

namespace challenge_nubimetrics_services.DTOs
{
    public class MonedaDTO
    {
        public string Id { get; set; }
        public string Symbol { get; set; }
        public string Description { get; set; }
        public int Decimal_Places { get; set; }
        public MonedaConversionDTO To_Dolar { get; set; }
    }
}
