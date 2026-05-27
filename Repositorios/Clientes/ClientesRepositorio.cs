using AutoMapper;
using BackEcommerce.Data;
using BackEcommerce.DTOs;
using Microsoft.EntityFrameworkCore;

namespace BackEcommerce.Repositorios.Clientes
{
    public class ClientesRepositorio : IClientesRepositorio
    {
        private EcommercePracticeContext _context;
       

        public ClientesRepositorio(EcommercePracticeContext context)
        {
            _context = context;
        }

        public async Task<InformacionCliente?> ObtenerClientePorEmail(string email)
        {
            var cliente = await _context.Clientes
                .AsNoTracking()
                .Where(e => e.Email == email)
                .Select(e => new InformacionCliente
                {
                    Nombre = e.Nombre,
                    Email = e.Email
                }).FirstOrDefaultAsync();

            if (cliente == null) return null;

            return cliente;
        }

        public async Task<ResponseResult> RegistrarCliente(Cliente cliente)
        {
            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();
            return new ResponseResult { StatusCode = 201, Message = "Cliente creado satisfactoriamente" };
        }
    }
}
