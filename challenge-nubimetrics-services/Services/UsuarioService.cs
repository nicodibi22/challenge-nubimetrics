using challenge_nubimetrics_services.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace challenge_nubimetrics_services.Services
{
    public interface UsuarioService
    {
        Task<IList<UsuarioDTO>> GetAsync();
        Task<UsuarioDTO> GetById(int id);
        Task<int> Add(UsuarioDTO entry);
        Task Update(UsuarioDTO entry);
        Task Remove(int id);
    }
}
