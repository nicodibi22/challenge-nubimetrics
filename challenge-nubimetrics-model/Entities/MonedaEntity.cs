using System;
using System.Collections.Generic;
using System.Text;

namespace challenge_nubimetrics_models.Entities
{
    public class MonedaEntity
    {
        public string Id { get; set; }
        public string Simbolo { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad_Decimales { get; set; }
        public MonedaConversionEntity Pasaje_Dolar { get; set; }
    }
}
