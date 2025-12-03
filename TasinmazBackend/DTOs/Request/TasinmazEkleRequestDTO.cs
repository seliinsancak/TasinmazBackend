using System.ComponentModel.DataAnnotations;

namespace TasinmazBackend.DTO.Request
{
    public class TasinmazEkleRequestDTO
    {
        [Required]
        public string Ada { get; set; }

        [Required]
        public string Parsel { get; set; }

        [Required]
        public string Nitelik { get; set; }

        [Required]
        public string Adres { get; set; }

        [Required]
        public int MahalleId { get; set; }
    }
}
