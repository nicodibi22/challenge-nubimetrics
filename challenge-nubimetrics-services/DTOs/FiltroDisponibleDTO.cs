using System.Collections.Generic;

namespace challenge_nubimetrics_services.DTOs
{
    public class FiltroDisponibleDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public IList<ValorDTO> Values { get; set; }
    }
}