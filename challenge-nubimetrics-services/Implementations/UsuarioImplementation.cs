using AutoMapper;
using challenge_nubimetrics_data.Repositories;
using challenge_nubimetrics_models.Entities;
using challenge_nubimetrics_services.DTOs;
using challenge_nubimetrics_services.Services;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace challenge_nubimetrics_services.Implementations
{
    public class UsuarioImplementation : UsuarioService
    {
        private readonly IMapper _mapper;        
        private IPasswordHasher<UsuarioEntity> _passwordHasher;
        private UsuarioRepository _repositorty;

        public UsuarioImplementation(
            IPasswordHasher<UsuarioEntity> passwordHasher, UsuarioRepository repositorty)
        {
            _repositorty = repositorty;
            _passwordHasher = passwordHasher;
                        
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UsuarioDTO, UsuarioEntity>().ReverseMap();                
            });
            _mapper = config.CreateMapper();
            
        }
        public async Task<int> Add(UsuarioDTO entry)
        {
            try
            {
                var usuario = _mapper.Map<UsuarioDTO, UsuarioEntity>(entry);                
                usuario.Validar();
                // falta validación de mail válido y existencia de usuario con mismo mail
                usuario.Password = _passwordHasher.HashPassword(usuario, usuario.Password);
                return await _repositorty.Create(usuario);
            }
            catch (Exception)
            {
                throw new ArgumentException("No se pudo dar de alta el usuario. Verifique los datos ingresados.");
            }
            
        }

        public async Task<IList<UsuarioDTO>> GetAsync()
        {
            return _mapper.Map< IList<UsuarioEntity>, IList<UsuarioDTO>>(await _repositorty.GetAll());            
        }

        public async Task<UsuarioDTO> GetById(int id)
        {
            var usuario = await _repositorty.GetById(id);
            if (usuario == null)
                throw new ArgumentException("No existe el usuario con id: " + id);
            return _mapper.Map<UsuarioEntity, UsuarioDTO>(usuario);
        }

        public async Task Remove(int id)
        {
            try
            {
                await _repositorty.Delete(id);
            }
            catch (Exception)
            {
                throw new ArgumentException("No se pudo eliminar el usuario.");
            }
            
        }

        public async Task Update(UsuarioDTO entry)
        {
            try
            {
                var usuario = _mapper.Map<UsuarioDTO, UsuarioEntity>(entry);
                // falta validación de mail válido y existencia de usuario con mismo mail
                usuario.Password = _passwordHasher.HashPassword(usuario, usuario.Password);
                await _repositorty.Update(usuario);
            }
            catch (Exception)
            {
                throw new ArgumentException("No se pudo modificar el usuario. Verifique los datos ingresados.");
            }
            
        }
    }
}
