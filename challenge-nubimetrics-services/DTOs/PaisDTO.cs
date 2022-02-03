using System;
using System.Collections.Generic;
using System.Text;

namespace challenge_nubimetrics_services.DTOs
{
    public class PaisDTO
    {
        public virtual string Id { get; set; }
        public virtual string Nombre { get; set; }
        public virtual string Configuracion_Regional { get; set; }
        public virtual string Moneda_Id { get; set; }
        public virtual string Separador_Decimales { get; set; }
        public virtual string Separador_Miles { get; set; }
        public virtual string Zona_Horaria { get; set; }
        public virtual GeoInformacionDTO Geo_Informacion { get; set; }
        public virtual IList<EstadoDTO> Estados { get; set; }
    }
}
