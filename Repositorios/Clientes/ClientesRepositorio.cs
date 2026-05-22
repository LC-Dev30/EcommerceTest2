using EcommerceTest2.Data;
using EcommerceTest2.DTOs;
using Microsoft.EntityFrameworkCore;

namespace EcommerceTest2.Repositorios.Clientes
{
    public class ClientesRepositorio : IClientesRepositorio
    {
        private EcommercePracticeContext _context;

        public ClientesRepositorio(EcommercePracticeContext context)
        {
            _context = context;
        }

        public async Task<ResponseResult> RegistrarUsuario(CrearCliente cliente)
        {

            var find = await _context.Clientes.FirstOrDefaultAsync(e => e.Email == cliente.Email);

            if (find != null)
                return new ResponseResult { StatusCode = 400, Message = "El Cliente ya existe" };

            var mapping = new Cliente
            {
                Nombre = cliente.Nombre,
                Email = cliente.Email,
                Password = cliente.Password
            };

            await _context.Clientes.AddAsync(mapping);
            await _context.SaveChangesAsync();
            return new ResponseResult { StatusCode = 201, Message = "Cliente creado satisfactoriamente" };
        }
    }
}
