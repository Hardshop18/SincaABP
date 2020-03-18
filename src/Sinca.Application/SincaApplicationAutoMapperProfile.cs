using AutoMapper;

namespace Sinca
{
    public class SincaApplicationAutoMapperProfile : Profile
    {
        public SincaApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateMap<Cliente, ClienteDto>();
            CreateMap<CreateUpdateClienteDto, Cliente>();
            CreateMap<CreateUpdateClienteDto, ClienteDto>();
        }
    }
}
