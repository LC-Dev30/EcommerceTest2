using AutoMapper;
using BackEcommerce.Data;
using BackEcommerce.DTOs;

namespace BackEcommerce.Mapper.Profiles
{
    public class ClienteProfile : Profile
    {
        public ClienteProfile()
        {
            CreateMap<CrearClienteDto, Cliente>();
        }
    }
}
