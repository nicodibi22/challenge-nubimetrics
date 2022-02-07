using System;
using System.Collections.Generic;
using System.Text;

namespace challenge_nubimetrics_services.Utils
{
    public class AppSettings
    {
        public IList<Pais> Paises { get; set; }
        public MLEndpoints MLEndpoints { get; set; }
    }
    public class Pais
    {
        public string Id { get; set; }
        public bool Habilitado { get; set; }
    }
    public class MLEndpoints
    {
        public string Paises { get; set; }
        public string Busqueda { get; set; }
        public string Monedas { get; set; }
        public string MonedasConversion { get; set; }
    }
}
