using challenge_nubimetrics_services.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace challenge_nubimetrics_services.Services
{
    public interface IPaisesService
    {
        Task<PaisDTO> GetPaisInfo(string pais);
    }
}
