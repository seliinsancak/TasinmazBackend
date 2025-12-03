namespace TasinmazBackend.Entities
{
    public class Tasinmaz
    {
        public int Id { get; set; }
        public string Ada { get; set; }
        public string Parsel { get; set; }
        public string Nitelik { get; set; }
        public string Adres { get; set; }

        public int MahalleId { get; set; }
        public Mahalle Mahalle { get; set; }

   
        public string Ad { get; set; } = string.Empty;
        public int Fiyat { get; set; } = 0;
    }
}
