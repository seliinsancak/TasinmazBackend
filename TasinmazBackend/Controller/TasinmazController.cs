using Microsoft.AspNetCore.Mvc;
using TasinmazBackend.Interfaces;
using TasinmazBackend.DTO.Request;

namespace TasinmazBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasinmazController : ControllerBase
    {
        private readonly ITasinmazService _tasinmazService;

        public TasinmazController(ITasinmazService tasinmazService)
        {
            _tasinmazService = tasinmazService;
        }

        // GET api/tasinmaz
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _tasinmazService.GetAllAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Problem(
                    title: "Sunucu hatası",
                    detail: ex.Message,
                    statusCode: 500
                );
            }
        }

        // GET api/tasinmaz/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await _tasinmazService.GetByIdAsync(id);

                if (result == null)
                    return NotFound(new { message = "Taşınmaz bulunamadı" });

                return Ok(result);
            }
            catch (Exception ex)
            {
                return Problem(
                    title: "Sunucu hatası",
                    detail: ex.Message,
                    statusCode: 500
                );
            }
        }

        // POST api/tasinmaz
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] TasinmazEkleRequestDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var success = await _tasinmazService.AddAsync(dto);

                if (!success)
                    return BadRequest(new { message = "Ekleme işlemi başarısız" });

                return Ok(new { message = "Taşınmaz başarıyla eklendi" });
            }
            catch (Exception ex)
            {
                return Problem(
                    title: "Sunucu hatası",
                    detail: ex.Message,
                    statusCode: 500
                );
            }
        }

        // PUT api/tasinmaz/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TasinmazEkleRequestDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var success = await _tasinmazService.UpdateAsync(id, dto);
                if (!success) return NotFound(new { message = "Taşınmaz bulunamadı" });

                return Ok(new { message = "Taşınmaz başarıyla güncellendi" });
            }
            catch (Exception ex)
            {
                return Problem(
                    title: "Sunucu hatası",
                    detail: ex.Message,
                    statusCode: 500
                );
            }
        }

        // DELETE api/tasinmaz/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var success = await _tasinmazService.DeleteAsync(id);
                if (!success) return NotFound(new { message = "Taşınmaz bulunamadı" });

                return Ok(new { message = "Taşınmaz başarıyla silindi" });
            }
            catch (Exception ex)
            {
                return Problem(
                    title: "Sunucu hatası",
                    detail: ex.Message,
                    statusCode: 500
                );
            }
        }
    }
}
