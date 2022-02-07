using AutoMapper;
using challenge_nubimetrics_data.Repositories;
using challenge_nubimetrics_models.Entities;
using challenge_nubimetrics_services.DTOs;
using challenge_nubimetrics_services.ExternalModels.ML.Currencies;
using challenge_nubimetrics_services.Services;
using challenge_nubimetrics_services.Utils;
using Microsoft.Extensions.Options;
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
        private AppSettings _appSettings;
        public MonedaImplementation(MonedaRepository monedaRepository, IOptions<AppSettings> settings)
        {
            _monedaRepository = monedaRepository;
            _appSettings = settings.Value;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Currency, MonedaEntity>()
                    .ForMember(x => x.Cantidad_Decimales, opt => opt.MapFrom(y => y.Decimal_Places))
                    .ForMember(x => x.Descripcion, opt => opt.MapFrom(y => y.Description))
                    .ForMember(x => x.Id, opt => opt.MapFrom(y => y.Id))
                    .ForMember(x => x.Simbolo, opt => opt.MapFrom(y => y.Symbol));
                cfg.CreateMap<CurrencyConversion, MonedaConversionEntity>()
                    .ForMember(x => x.Fecha_Creacion, opt => opt.MapFrom(y => y.Creation_Date))
                    .ForMember(x => x.Moneda_Base, opt => opt.MapFrom(y => y.Currency_Base))
                    .ForMember(x => x.Moneda_Cotizacion, opt => opt.MapFrom(y => y.Currency_Quote))
                    .ForMember(x => x.Proporcion, opt => opt.MapFrom(y => y.Ratio))
                    .ForMember(x => x.Tarifa, opt => opt.MapFrom(y => y.Rate))
                    .ForMember(x => x.Proporcion_Inversa, opt => opt.MapFrom(y => y.Inv_Rate))
                    .ForMember(x => x.Valido_Hasta, opt => opt.MapFrom(y => y.Valid_Until));

            }
            );
            _mapper = config.CreateMapper();
        }
        public async Task Procesar()
        {
            var listCurrencies = await GetListCurrenciesFromApi();
            foreach (var currency in listCurrencies)
            {
                currency.Pasaje_Dolar = await GetCurrencyToDolarFromApi(currency.Id);
            }
            await _monedaRepository.SaveRange(listCurrencies);
            await _monedaRepository.SaveConversions(listCurrencies);
        }

        private async Task<IList<MonedaEntity>> GetListCurrenciesFromApi()
        {
            string url = _appSettings.MLEndpoints.Monedas;
            string parameters = null;
            return _mapper.Map<IList<Currency>, IList<MonedaEntity>>(await RestApiCaller.GetRequest<IList<Currency>>(url, parameters));
        }
        private async Task<MonedaConversionEntity> GetCurrencyToDolarFromApi(string country)
        {
            string url = _appSettings.MLEndpoints.MonedasConversion;
            string parameters = "?from=" + country + "&to=USD";
            return _mapper.Map<CurrencyConversion, MonedaConversionEntity>(await RestApiCaller.GetRequest<CurrencyConversion>(url, parameters));
        }
    }
}
