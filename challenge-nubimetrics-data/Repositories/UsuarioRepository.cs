using challenge_nubimetrics_models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace challenge_nubimetrics_data.Repositories
{
    public interface UsuarioRepository
    {
        Task<UsuarioEntity> GetById(int id);
        Task<int> Create(UsuarioEntity user);
        Task Delete(int id);
        Task Update(UsuarioEntity user);
        Task<IList<UsuarioEntity>> GetAll();
    }
}
