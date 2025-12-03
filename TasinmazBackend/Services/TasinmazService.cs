using Microsoft.EntityFrameworkCore;
using TasinmazBackend.Data;
using TasinmazBackend.DTO.Request;
using TasinmazBackend.DTO.Response;
using TasinmazBackend.Entities;
using TasinmazBackend.Interfaces;

namespace TasinmazBackend.Services
{
    public class TasinmazService : ITasinmazService
    {
        private readonly TasinmazDbContext _context;

        public TasinmazService(TasinmazDbContext context)
        {
            _context = context;
        }

        
        public async Task<List<TasinmazResponseDTO>> GetAllAsync()
        {
            var tasinmazlar = await _context.Tasinmazlar
                .Include(t => t.Mahalle)
                    .ThenInclude(m => m.Ilce)
                        .ThenInclude(i => i.Il)
                .ToListAsync();

            var result = tasinmazlar.Select(t => new TasinmazResponseDTO
            {
                Id = t.Id,
                Ada = t.Ada,
                Parsel = t.Parsel,
                Nitelik = t.Nitelik,
                Adres = t.Adres,
                Mahalle = t.Mahalle?.Ad,
                Ilce = t.Mahalle?.Ilce?.Ad,
                Il = t.Mahalle?.Ilce?.Il?.Ad
            }).ToList();

            return result;
        }

       
        public async Task<TasinmazResponseDTO> GetByIdAsync(int id)
        {
            var t = await _context.Tasinmazlar
                .Include(t => t.Mahalle)
                    .ThenInclude(m => m.Ilce)
                        .ThenInclude(i => i.Il)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (t == null) return null;

            return new TasinmazResponseDTO
            {
                Id = t.Id,
                Ada = t.Ada,
                Parsel = t.Parsel,
                Nitelik = t.Nitelik,
                Adres = t.Adres,
                Mahalle = t.Mahalle?.Ad,
                Ilce = t.Mahalle?.Ilce?.Ad,
                Il = t.Mahalle?.Ilce?.Il?.Ad
            };
        }

        public async Task<bool> AddAsync(TasinmazEkleRequestDTO dto)
        {
            var entity = new Tasinmaz
            {
                Ada = dto.Ada,
                Parsel = dto.Parsel,
                Nitelik = dto.Nitelik,
                Adres = dto.Adres,
                MahalleId = dto.MahalleId
            };

            await _context.Tasinmazlar.AddAsync(entity);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
