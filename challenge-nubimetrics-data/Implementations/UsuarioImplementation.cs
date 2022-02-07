using challenge_nubimetrics_data.Repositories;
using challenge_nubimetrics_data.Utils;
using challenge_nubimetrics_models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace challenge_nubimetrics_data.Implementations
{
    public class UsuarioImplementation : UsuarioRepository
    {
        private IHelper _dataBase;
        public UsuarioImplementation(IHelper helper)
        {
            _dataBase = helper;
        }

        public async Task<int> Create(UsuarioEntity user)
        {            
            return (int)await _dataBase.GetCurrentSession().SaveAsync(user);            
        }

        public async Task Delete(int id)
        {
            await _dataBase.GetCurrentSession().DeleteAsync(id);
        }

        public Task<IList<UsuarioEntity>> GetAll()
        {
            var criteria = _dataBase.GetCurrentSession().CreateCriteria<UsuarioEntity>();
            return criteria.ListAsync<UsuarioEntity>();
        }

        public async Task<UsuarioEntity> GetById(int id)
        {
            return await _dataBase.GetCurrentSession().GetAsync<UsuarioEntity>(id);
        }

        public async Task Update(UsuarioEntity user)
        {
            await _dataBase.GetCurrentSession().UpdateAsync(user);
        }
    }
}
