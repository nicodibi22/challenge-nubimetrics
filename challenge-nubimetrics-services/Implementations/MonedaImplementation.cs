using AutoMapper;
using challenge_nubimetrics_data.Repositories;
using challenge_nubimetrics_models.Entities;
using challenge_nubimetrics_services.DTOs;
using challenge_nubimetrics_services.ExternalModels.ML.Currencies;
using challenge_nubimetrics_services.Services;
using challenge_nubimetrics_services.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace challenge_nubimetrics_services.Implementations
{
    public class MonedaImplementation : MonedaService
    {
        private readonly IMapper _mapper;
        private readonly MonedaRepository _monedaRepository;
        public MonedaImplementation(MonedaRepository monedaRepository)
        {
            _monedaRepository = monedaRepository;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Currency, MonedaEntity>()
                    .ForMember(x => x.Cantidad_Decimales, opt => opt.MapFrom(y => y.Decimal_Places))
                    .ForMember(x => x.Descripcion, opt => opt.MapFrom(y => y.Description))
                    .ForMember(x => x.Id, opt => opt.MapFrom(y => y.Id))
                    .ForMember(x => x.Simbolo, opt => opt.MapFrom(y => y.Symbol));
                cfg.CreateMap<CurrencyConversion, MonedaConversionEntity>();
                
            }
            );
            _mapper = config.CreateMapper();
        }
        public async Task Procesar()
        {
            var listCurrencies = await GetResultFromApi();
            await _monedaRepository.SaveRange(listCurrencies);
            //FactoryWriterTextFile.GetWriter("currencies.json").Write(listCurrencies);
        }

        private async Task<IList<MonedaEntity>> GetResultFromApi()
        {
            string url = "https://api.mercadolibre.com/currencies/";
            string parameters = null;
            return _mapper.Map<IList<Currency>, IList<MonedaEntity>>(await RestApiCaller.GetRequest<IList<Currency>>(url, parameters));
        }
    }
}
