using System.Collections.Generic;

namespace challenge_nubimetrics_services.DTOs
{
    public class FiltroDTO
    {
        public string Id { get; set; }
        public IList<ValorFiltroDTO> Values { get; set; }
    }
}