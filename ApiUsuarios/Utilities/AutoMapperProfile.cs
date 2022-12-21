using AutoMapper;
using ApiUsuarios.Models;
using ApiUsuarios.DTOs;

namespace ApiUsuarios.Utilities
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<Personas, PersonaUsuarioDTO>()
                .ForMember(dest => dest.Nombres, opt => opt.MapFrom(source => source.Nombres))
                .ForMember(dest => dest.Apellidos, opt => opt.MapFrom(source => source.Apellidos))
                .ForMember(dest => dest.NumeroIdentificacion, opt => opt.MapFrom(source => source.NumeroIdentificacion))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(source => source.Email))
                .ForMember(dest => dest.TipoIdentificacion, opt => opt.MapFrom(source => source.TipoIdentificacion));

            CreateMap<Usuarios, PersonaUsuarioDTO>()
                .ForMember(dest => dest.Usuario, opt => opt.MapFrom(source => source.Usuario))
                .ForMember(dest => dest.Pass, opt => opt.MapFrom(source => source.Pass));

            CreateMap<Usuarios, LoginDTO>()
               .ForMember(dest => dest.Usuario, opt => opt.MapFrom(source => source.Usuario))
               .ForMember(dest => dest.Pass, opt => opt.MapFrom(source => source.Pass));
        }
    }
}
