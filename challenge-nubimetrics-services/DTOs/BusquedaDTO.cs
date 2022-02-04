using System;
using System.Collections.Generic;
using System.Text;

namespace challenge_nubimetrics_services.DTOs
{
    public class BusquedaDTO
    {
        public string Site_Id { get; set; }
        public string Country_Default_Time_Zone { get; set; }
        public string Query { get; set; }        
        public PaginacionDTO Paging { get; set; }
        public IList<ResultadoDTO> Results { get; set; }
        public OrdenDTO Sort { get; set; }
        public IList<OrdenDisponibleDTO> Available_Sorts { get; set; }
        public IList<FiltroDTO> Filters { get; set; }
        public IList<FiltroDisponibleDTO> Available_Filters { get; set; }
    }
}
