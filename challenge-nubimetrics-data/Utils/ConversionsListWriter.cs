using challenge_nubimetrics_models.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace challenge_nubimetrics_data.Utils
{
    public class ConversionsListWriter : StrategyCsvWriter
    {
        public string Write(object content)
        {
            if (content.GetType() != typeof(List<MonedaEntity>))
                throw new ArgumentException();

            IList<MonedaEntity> monedas = (IList<MonedaEntity>)content;
            StringBuilder sb = new StringBuilder();
            for(int i = 0; i < monedas.Count; i++)
            {
                if (monedas[i].Pasaje_Dolar != null)
                {
                    sb.Append(monedas[i].Pasaje_Dolar.Proporcion);
                    if (i < monedas.Count - 1)
                    {
                        sb.Append(";");
                    }
                }
                
            }
            return sb.ToString();
        }

    }
}
