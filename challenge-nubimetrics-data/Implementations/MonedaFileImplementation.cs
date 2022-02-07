using challenge_nubimetrics_data.Repositories;
using challenge_nubimetrics_data.Utils;
using challenge_nubimetrics_models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace challenge_nubimetrics_data.Implementations
{
    public class MonedaFileImplementation : MonedaRepository
    {
        public async Task SaveRange(IList<MonedaEntity> monedas)
        {
            await FactoryWriterTextFile.GetWriter("currencies.json").Write(monedas);
        }
    }
}
