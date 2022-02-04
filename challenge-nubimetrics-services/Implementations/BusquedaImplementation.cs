using AutoMapper;
using challenge_nubimetrics_services.DTOs;
using challenge_nubimetrics_services.ExternalModels.ML.Search;
using challenge_nubimetrics_services.Services;
using challenge_nubimetrics_services.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace challenge_nubimetrics_services.Implementations
{
    public class BusquedaImplementation : BusquedaService
    {
        private readonly IMapper _mapper;
        public BusquedaImplementation()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap <Search, BusquedaDTO>();
                cfg.CreateMap<Result, ResultadoDTO>();
                cfg.CreateMap<AvailableFilter, FiltroDisponibleDTO>();
                cfg.CreateMap<AvailableSort, OrdenDisponibleDTO>();
                cfg.CreateMap<Filter, FiltroDTO>();
                cfg.CreateMap<Paging, PaginacionDTO>();
                cfg.CreateMap<Seller, VendedorDTO>();
                cfg.CreateMap<Sort, OrdenDTO>();
                cfg.CreateMap<Struct, EstructuraDTO>();
                cfg.CreateMap<Value, ValorDTO>();
                cfg.CreateMap<ValueFilter, ValorFiltroDTO>();
            }
            );
            _mapper = config.CreateMapper();
        }

        private async Task<BusquedaDTO> GetResultFromApi(string termino)
        {
            string url = "https://api.mercadolibre.com/sites/MLA/search" ;
            string parameters = "?q=" + termino;
            return _mapper.Map<Search, BusquedaDTO>(await RestApiCaller.GetRequest <Search>(url, parameters));
        }

        public async Task<BusquedaDTO> Buscar(string termino)
        {
            return await GetResultFromApi(termino);
        }
    }
}
