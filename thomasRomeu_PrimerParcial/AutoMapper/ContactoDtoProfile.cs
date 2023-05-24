using AutoMapper;
using thomasRomeu_PrimerParcial.Entities;
using thomasRomeu_PrimerParcial.Dto;

namespace thomasRomeu_PrimerParcial.AutoMapper
{
    public class ContactoDtoProfile : Profile
    {
        public ContactoDtoProfile() 
        {

            CreateMap<UsuarioDto, Usuario>().ReverseMap();
            CreateMap<Usuario, UsuarioDto>().ReverseMap();

            CreateMap<ContactoDto, Contacto>().ReverseMap();
            CreateMap<Contacto, ContactoDto>().ReverseMap();

            CreateMap<TelefonoDto, Telefono>().ReverseMap();
            CreateMap<Telefono, TelefonoDto>().ReverseMap();


        }
    }
}
