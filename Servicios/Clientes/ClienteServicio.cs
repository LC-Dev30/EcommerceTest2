using AutoMapper;
using BackEcommerce.Data;
using BackEcommerce.DTOs;
using BackEcommerce.Repositorios.Clientes;

namespace BackEcommerce.Servicios.Clientes
{
    public class ClienteServicio : IServicioCliente
    {
        private IClientesRepositorio _repo;
        private IMapper _mapper;

        public ClienteServicio(IClientesRepositorio repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        public async Task<ResponseResult> RegistarClienteUseCase(CrearClienteDto dto)
        {
            var clientePorEmail = await _repo.ObtenerClientePorEmail(dto.Email);

            if (clientePorEmail != null)
                return new ResponseResult { StatusCode = 400, Message = "El Cliente ya existe" };

            dto.Password = BCrypt.Net.BCrypt.HashPassword(dto.Password);
            var cliente = _mapper.Map<CrearClienteDto, Cliente>(dto);
            return await _repo.RegistrarCliente(cliente);
        }
    }
}
