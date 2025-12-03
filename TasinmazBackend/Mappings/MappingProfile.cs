using AutoMapper;
using TasinmazBackend.DTO.Response;
using TasinmazBackend.DTO.Request;
using TasinmazBackend.Entities;

namespace TasinmazBackend.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Il, IlResponseDTO>();
            CreateMap<Ilce, IlceResponseDTO>();
            CreateMap<Mahalle, MahalleResponseDTO>();
            CreateMap<Tasinmaz, TasinmazResponseDTO>();

            CreateMap<IlRequestDTO, Il>();
            CreateMap<IlceRequestDTO, Ilce>();
            CreateMap<MahalleRequestDTO, Mahalle>();
            CreateMap<TasinmazRequestDTO, Tasinmaz>();
        }
    }
}
