using AutoMapper;
using challenge_nubimetrics_services.DTOs;
using challenge_nubimetrics_services.ExternalModels;
using challenge_nubimetrics_services.ExternalModels.ML.Countries;
using challenge_nubimetrics_services.Services;
using challenge_nubimetrics_services.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace challenge_nubimetrics_services.Implementations
{
    public class PaisImplementation : PaisService
    {
        private readonly IMapper _mapper;
        public PaisImplementation()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Country, PaisDTO>()
                    .ForPath(x => x.Estados, opt => opt.MapFrom(y => y.States))
                    .ForPath(x => x.Geo_Informacion, opt => opt.MapFrom(y => y.Geo_Information))
                    .ForMember(x => x.Configuracion_Regional, opt => opt.MapFrom(y => y.Locale))
                    .ForMember(x => x.Moneda_Id, opt => opt.MapFrom(y => y.Currency_Id))
                    .ForMember(x => x.Nombre, opt => opt.MapFrom(y => y.Name))
                    .ForMember(x => x.Separador_Decimales, opt => opt.MapFrom(y => y.Decimal_Separator))
                    .ForMember(x => x.Separador_Miles, opt => opt.MapFrom(y => y.Thousands_Separator))
                    .ForMember(x => x.Zona_Horaria, opt => opt.MapFrom(y => y.Time_Zone));
                cfg.CreateMap<GeoInformation, GeoInformacionDTO>()
                    .ForPath(x => x.Locacion, opt => opt.MapFrom(y => y.Location));
                cfg.CreateMap<State, EstadoDTO>()
                    .ForMember(x => x.Nombre, opt => opt.MapFrom(y => y.Name));
                cfg.CreateMap<Location, LocacionDTO>()
                    .ForMember(x => x.Latitud, opt => opt.MapFrom(y => y.Latitude))
                    .ForMember(x => x.Longitud, opt => opt.MapFrom(y => y.Longitude));                
            }
            );
            _mapper = config.CreateMapper();
        }

        public async Task<PaisDTO> GetPaisInfo(string pais)
        {
            PaisExistente(pais);
            PaisAutorizado(pais);
            return (await GetPaisInfoFromApi(pais));
            
        }

        private void PaisAutorizado(string pais)
        {
            return;
        }

        private void PaisExistente(string pais)
        {
            return;
        }

        private async Task<PaisDTO> GetPaisInfoFromApi(string pais)
        {
            string url = "https://api.mercadolibre.com/classified_locations/countries/" + pais;
            string parameters = "";
            return _mapper.Map<Country, PaisDTO>(await RestApiCaller.GetRequest <Country>(url, parameters));
        }
    }
}
