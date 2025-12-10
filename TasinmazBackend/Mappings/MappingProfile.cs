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
            // --- RESPONSE MAPS ---
            CreateMap<Il, IlResponseDTO>();
            CreateMap<Ilce, IlceResponseDTO>();
            CreateMap<Mahalle, MahalleResponseDTO>();

            // Tasinmaz -> Response DTO
            // Burada manuel string map gerekmiyor,
            // AutoMapper nesneleri otomatik dönüştürecek.
            CreateMap<Tasinmaz, TasinmazResponseDTO>()
                .ForMember(dest => dest.Mahalle, opt => opt.MapFrom(src => src.Mahalle))
                .ForMember(dest => dest.Ilce, opt => opt.MapFrom(src => src.Mahalle.Ilce))
                .ForMember(dest => dest.Il, opt => opt.MapFrom(src => src.Mahalle.Ilce.Il));

            // --- REQUEST MAPS ---
            CreateMap<IlRequestDTO, Il>();
            CreateMap<IlceRequestDTO, Ilce>();
            CreateMap<MahalleRequestDTO, Mahalle>();

            // Tasinmaz Ekle Request -> Entity
            CreateMap<TasinmazEkleRequestDTO, Tasinmaz>();
        }
    }
}
