using TasinmazBackend.Entities;

namespace TasinmazBackend.DTO.Response
{
    public class TasinmazResponseDTO
    {
        public int Id { get; set; }
        public string Ada { get; set; }
        public string Parsel { get; set; }
        public string Nitelik { get; set; }
        public string Adres { get; set; }

        // Mahalle, Ilce, Il DTO türünde olacak
        public MahalleResponseDTO Mahalle { get; set; }
        public IlceResponseDTO Ilce { get; set; }
        public IlResponseDTO Il { get; set; }
    }
}
