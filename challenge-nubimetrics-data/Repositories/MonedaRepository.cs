using challenge_nubimetrics_models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace challenge_nubimetrics_data.Repositories
{
    public interface MonedaRepository
    {
        Task SaveRange(IList<MonedaEntity> monedas);
    }
}
