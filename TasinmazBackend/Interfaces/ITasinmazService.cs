using System.Threading.Tasks;
using System.Collections.Generic;
using TasinmazBackend.DTO.Request;
using TasinmazBackend.DTO.Response;

namespace TasinmazBackend.Interfaces
{
    public interface ITasinmazService
    {
        Task<List<TasinmazResponseDTO>> GetAllAsync();
        Task<TasinmazResponseDTO> GetByIdAsync(int id);
        Task<bool> AddAsync(TasinmazEkleRequestDTO dto);

       
        Task<bool> UpdateAsync(int id, TasinmazEkleRequestDTO dto);
        Task<bool> DeleteAsync(int id);
    }
}
