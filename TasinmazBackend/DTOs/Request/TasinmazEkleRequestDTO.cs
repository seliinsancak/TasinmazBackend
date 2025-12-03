using Microsoft.EntityFrameworkCore;
using TasinmazBackend.Entities;

namespace TasinmazBackend.DTO.Request

{
    public class TasinmazEkleRequestDTO
    {
        public string Ada { get; set; }
        public string Parsel { get; set; }
        public string Nitelik { get; set; }
        public string Adres { get; set; }
        public int MahalleId { get; set; }
    }
}
