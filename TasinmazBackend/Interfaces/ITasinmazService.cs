using Microsoft.EntityFrameworkCore;
using TasinmazBackend.Entities;
using TasinmazBackend.DTO.Request;
using TasinmazBackend.DTO.Response;

namespace TasinmazBackend.Interfaces
{
    public interface ITasinmazService
    {
        Task<List<TasinmazResponseDTO>> GetAllAsync();
        Task<TasinmazResponseDTO> GetByIdAsync(int id);
        Task<bool> AddAsync(TasinmazEkleRequestDTO dto);
    }
}

