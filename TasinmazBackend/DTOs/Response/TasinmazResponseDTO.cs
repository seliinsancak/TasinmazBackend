using Microsoft.EntityFrameworkCore;
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
        public string Mahalle { get; set; }
        public string Ilce { get; set; }
        public string Il { get; set; }

    }
}
