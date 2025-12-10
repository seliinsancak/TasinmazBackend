using AutoMapper;
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
        private readonly IMapper _mapper;

        public TasinmazService(TasinmazDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<TasinmazResponseDTO>> GetAllAsync()
        {
            var data = await _context.Tasinmazlar
                .Include(t => t.Mahalle)
                    .ThenInclude(m => m.Ilce)
                        .ThenInclude(i => i.Il)
                .ToListAsync();

            return _mapper.Map<List<TasinmazResponseDTO>>(data);
        }

        public async Task<TasinmazResponseDTO?> GetByIdAsync(int id)
        {
            var entity = await _context.Tasinmazlar
                .Include(t => t.Mahalle)
                    .ThenInclude(m => m.Ilce)
                        .ThenInclude(i => i.Il)
                .FirstOrDefaultAsync(t => t.Id == id);

            return _mapper.Map<TasinmazResponseDTO>(entity);
        }

        public async Task<bool> AddAsync(TasinmazEkleRequestDTO dto)
        {
            try
            {
                var entity = _mapper.Map<Tasinmaz>(dto);

                await _context.Tasinmazlar.AddAsync(entity);
                await _context.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        
        public async Task<bool> UpdateAsync(int id, TasinmazEkleRequestDTO dto)
        {
            var tasinmaz = await _context.Tasinmazlar.FindAsync(id);
            if (tasinmaz == null) return false;

            tasinmaz.Ada = dto.Ada;
            tasinmaz.Parsel = dto.Parsel;
            tasinmaz.Nitelik = dto.Nitelik;
            tasinmaz.Adres = dto.Adres;
            tasinmaz.MahalleId = dto.MahalleId;

            await _context.SaveChangesAsync();
            return true;
        }

        
        public async Task<bool> DeleteAsync(int id)
        {
            var tasinmaz = await _context.Tasinmazlar.FindAsync(id);
            if (tasinmaz == null) return false;

            _context.Tasinmazlar.Remove(tasinmaz);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
