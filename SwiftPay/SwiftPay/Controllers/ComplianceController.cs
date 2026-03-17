using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using SwiftPay.Services.Interfaces;
using SwiftPay.DTOs.ComplianceDTO; // Ensure this matches your DTO namespace

namespace SwiftPay.Controllers
{
    [Route("api/[controller]")] // This makes your URL: api/Compliance
    [ApiController]             // This tells ASP.NET this is a Web API
    public class ComplianceController : ControllerBase // ": ControllerBase" is essential
    {
        private readonly IComplianceCheckService _service;

        // Constructor: This is where you "inject" your service
        public ComplianceController(IComplianceCheckService service)
        {
            _service = service;
        }

        [HttpPost] // This allows the "Create" action via an HTTP POST request
        public async Task<IActionResult> Create([FromBody] CreateComplianceCheckDto dto)
        {
            // Matching your friend's null check pattern
            if (dto == null)
                return BadRequest("Request body is required.");

            var created = await _service.CreateAsync(dto);

            // Returns the result to the user with a 200 OK status
            return Ok(created);
        }
    }
}