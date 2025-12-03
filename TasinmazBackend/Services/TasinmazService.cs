using Microsoft.EntityFrameworkCore;
using TasinmazBackend.Data;
using TasinmazBackend.DTO.Request;
using TasinmazBackend.DTO.Response;
using TasinmazBackend.Entities;
using TasinmazBackend.Interfaces;
using AutoMapper;

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
            var tasinmazlar = await _context.Tasinmazlar
                .Include(t => t.Mahalle)
                    .ThenInclude(m => m.Ilce)
                        .ThenInclude(i => i.Il)
                .ToListAsync();

            return _mapper.Map<List<TasinmazResponseDTO>>(tasinmazlar);
        }

        
        public async Task<TasinmazResponseDTO> GetByIdAsync(int id)
        {
            var t = await _context.Tasinmazlar
                .Include(t => t.Mahalle)
                    .ThenInclude(m => m.Ilce)
                        .ThenInclude(i => i.Il)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (t == null) return null;

            return _mapper.Map<TasinmazResponseDTO>(t);
        }

        
        public async Task<bool> AddAsync(TasinmazEkleRequestDTO dto)
        {
            var entity = _mapper.Map<Tasinmaz>(dto);

            await _context.Tasinmazlar.AddAsync(entity);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
