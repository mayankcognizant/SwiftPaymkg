using Microsoft.AspNetCore.Mvc;
using SwiftPay.Services.Interfaces;
using SwiftPay.DTOs.AmendmentDTO;

namespace SwiftPay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmendmentController : ControllerBase
    {
        private readonly IAmendmentService _amendmentService;

        public AmendmentController(IAmendmentService amendmentService)
        {
            _amendmentService = amendmentService;
        }

        [HttpPost]
        public async Task<IActionResult> RequestAmendment([FromBody] CreateAmendmentDto dto)
        {
            if (dto == null) return BadRequest("Amendment data is required.");

            var result = await _amendmentService.CreateAsync(dto);
            return Ok(result);
        }
    }
}