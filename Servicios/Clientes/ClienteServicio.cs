using EcommerceTest2.DTOs;
using EcommerceTest2.Repositorios.Clientes;

namespace EcommerceTest2.Servicios.Clientes
{
    public class ClienteServicio : IServicioCliente
    {
        private IClientesRepositorio _repo;

        public ClienteServicio(IClientesRepositorio repo)
        {
            _repo = repo;
        }

        public async Task<ResponseResult> RegistarClienteUseCase(CrearCliente cliente)
        {
           return await _repo.RegistrarUsuario(cliente);
        }
    }
}
