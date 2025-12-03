using Microsoft.AspNetCore.Mvc;
using TasinmazBackend.DTO.Request;
using TasinmazBackend.Interfaces;

namespace TasinmazBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasinmazController : ControllerBase
    {
        private readonly ITasinmazService _service;

        public TasinmazController(ITasinmazService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _service.GetAllAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Taşınmazlar alınırken bir hata oluştu.", detail = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await _service.GetByIdAsync(id);
                if (result == null)
                    return NotFound(new { message = $"ID {id} ile taşınmaz bulunamadı." });

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"ID {id} ile taşınmaz alınırken bir hata oluştu.", detail = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] TasinmazEkleRequestDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var success = await _service.AddAsync(dto);
                if (!success)
                    return BadRequest(new { message = "Ekleme işlemi başarısız oldu." });

                return Ok(new { message = "Ekleme başarılı." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Taşınmaz eklenirken bir hata oluştu.", detail = ex.Message });
            }
        }
    }
}
