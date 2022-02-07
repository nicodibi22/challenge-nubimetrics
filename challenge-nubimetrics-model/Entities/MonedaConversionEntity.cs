using System;
using System.Collections.Generic;
using System.Text;

namespace challenge_nubimetrics_models.Entities
{
    public class MonedaConversionEntity
    {
        public string Moneda_Base { get; set; }
        public string Moneda_Cotizacion { get; set; }
        public float Proporcion { get; set; }
        public float Tarifa { get; set; }
        public float Proporcion_Inversa { get; set; }
        public string Fecha_Creacion { get; set; }
        public string Valido_Hasta { get; set; }
    }
}
