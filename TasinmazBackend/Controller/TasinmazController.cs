using Microsoft.AspNetCore.Mvc;
using TasinmazBackend.DTO.Request;
using TasinmazBackend.Interfaces;
using Microsoft.EntityFrameworkCore;
using TasinmazBackend.Entities;

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
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null) return NotFound();
            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> Add([FromBody] TasinmazEkleRequestDTO dto)
        {
            var success = await _service.AddAsync(dto);
            if (!success) return BadRequest("Ekleme başarısız oldu.");
            return Ok("Ekleme başarılı.");
        }
    }
}
