using AutoMapper;
using DigitalWareBackEnd.Models;
using DigitalWareBackEnd.Models.Dto;

namespace DigitalWareBackEnd
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<PersonaDto, PersonaModel>();
                config.CreateMap<PersonaModel, PersonaDto>();

                config.CreateMap<ProductoDto, ProductoModel>();
                config.CreateMap<ProductoModel, ProductoDto>();

                config.CreateMap<FacturaDto, FacturaModel>();
                config.CreateMap<FacturaModel, FacturaDto>();

                config.CreateMap<DetFacturaDto, DetFacturaModel>();
                config.CreateMap<DetFacturaModel, DetFacturaDto>();
            });
            return mappingConfig;
        }
    }
}
