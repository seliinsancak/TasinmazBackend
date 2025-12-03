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
            // Response DTO’ları
            CreateMap<Il, IlResponseDTO>();
            CreateMap<Ilce, IlceResponseDTO>();
            CreateMap<Mahalle, MahalleResponseDTO>();
            CreateMap<Tasinmaz, TasinmazResponseDTO>();

            // Request DTO’ları
            CreateMap<IlRequestDTO, Il>();
            CreateMap<IlceRequestDTO, Ilce>();
            CreateMap<MahalleRequestDTO, Mahalle>();

            // Tasinmaz ekleme DTO mapping (case-sensitive düzeltildi)
            CreateMap<TasinmazEkleRequestDTO, Tasinmaz>()
                .ForMember(dest => dest.Ada, opt => opt.MapFrom(src => src.Ada))
                .ForMember(dest => dest.Parsel, opt => opt.MapFrom(src => src.Parsel))
                .ForMember(dest => dest.Nitelik, opt => opt.MapFrom(src => src.Nitelik))
                .ForMember(dest => dest.Adres, opt => opt.MapFrom(src => src.Adres))
                .ForMember(dest => dest.MahalleId, opt => opt.MapFrom(src => src.MahalleId));
        }
    }
}
