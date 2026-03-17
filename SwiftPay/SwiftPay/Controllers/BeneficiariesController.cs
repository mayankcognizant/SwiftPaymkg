using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using SwiftPay.Services.Interfaces;
using SwiftPay.DTOs.UserCustomerDTO;
using SwiftPay.Domain.Remittance.Entities;

namespace SwiftPay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeneficiariesController : ControllerBase
    {
        private readonly IBeneficiaryService _service;

        public BeneficiariesController(IBeneficiaryService service)
        {
            _service = service;
        }

        /// <summary>
        /// Create a new beneficiary
        /// </summary>
        /// <param name="dto">Beneficiary creation data</param>
        /// <returns>Created beneficiary object</returns>
        /// <response code="200">Beneficiary created successfully</response>
        /// <response code="400">Invalid request data</response>
        /// <response code="500">Server error</response>
        [HttpPost]
        [ProducesResponseType(typeof(Beneficiary), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] CreateBeneficiaryDto dto)
        {
            if (dto == null)
                return BadRequest(new { message = "Request body is required." });

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var created = await _service.CreateAsync(dto);
                return Ok(new { message = "Beneficiary created successfully.", data = created });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while creating the beneficiary.", error = ex.Message });
            }
        }

        /// <summary>
        /// Get beneficiary by ID
        /// </summary>
        /// <param name="beneficiaryId">Beneficiary ID</param>
        /// <returns>Beneficiary object</returns>
        /// <response code="200">Beneficiary found</response>
        /// <response code="404">Beneficiary not found</response>
        /// <response code="500">Server error</response>
        [HttpGet("{beneficiaryId}")]
        [ProducesResponseType(typeof(Beneficiary), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(int beneficiaryId)
        {
            try
            {
                var beneficiary = await _service.GetByIdAsync(beneficiaryId);
                if (beneficiary == null)
                    return NotFound(new { message = $"Beneficiary with ID {beneficiaryId} not found." });

                return Ok(new { message = "Beneficiary retrieved successfully.", data = beneficiary });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while retrieving the beneficiary.", error = ex.Message });
            }
        }

        /// <summary>
        /// Get all beneficiaries for a customer
        /// </summary>
        /// <param name="customerId">Customer ID</param>
        /// <returns>List of beneficiaries for the customer</returns>
        /// <response code="200">Beneficiaries retrieved successfully</response>
        /// <response code="500">Server error</response>
        [HttpGet("customer/{customerId}")]
        [ProducesResponseType(typeof(IEnumerable<Beneficiary>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByCustomerId(int customerId)
        {
            try
            {
                var beneficiaries = await _service.GetByCustomerIdAsync(customerId);
                return Ok(new { message = "Beneficiaries retrieved successfully.", data = beneficiaries });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while retrieving beneficiaries.", error = ex.Message });
            }
        }

        /// <summary>
        /// Get all beneficiaries
        /// </summary>
        /// <returns>List of all active beneficiaries</returns>
        /// <response code="200">Beneficiaries retrieved successfully</response>
        /// <response code="500">Server error</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Beneficiary>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var beneficiaries = await _service.GetAllAsync();
                return Ok(new { message = "Beneficiaries retrieved successfully.", data = beneficiaries });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while retrieving beneficiaries.", error = ex.Message });
            }
        }

        /// <summary>
        /// Update beneficiary information
        /// </summary>
        /// <param name="beneficiaryId">Beneficiary ID</param>
        /// <param name="dto">Beneficiary update data</param>
        /// <returns>Updated beneficiary object</returns>
        /// <response code="200">Beneficiary updated successfully</response>
        /// <response code="404">Beneficiary not found</response>
        /// <response code="400">Invalid request data</response>
        /// <response code="500">Server error</response>
        [HttpPut("{beneficiaryId}")]
        [ProducesResponseType(typeof(Beneficiary), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int beneficiaryId, [FromBody] UpdateBeneficiaryDto dto)
        {
            if (dto == null)
                return BadRequest(new { message = "Request body is required." });

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var updated = await _service.UpdateAsync(beneficiaryId, dto);
                return Ok(new { message = "Beneficiary updated successfully.", data = updated });
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("not found"))
                    return NotFound(new { message = ex.Message });
                
                return StatusCode(500, new { message = "An error occurred while updating the beneficiary.", error = ex.Message });
            }
        }

        /// <summary>
        /// Delete (soft delete) a beneficiary
        /// </summary>
        /// <param name="beneficiaryId">Beneficiary ID</param>
        /// <returns>Success or failure message</returns>
        /// <response code="200">Beneficiary deleted successfully</response>
        /// <response code="404">Beneficiary not found</response>
        /// <response code="500">Server error</response>
        [HttpDelete("{beneficiaryId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int beneficiaryId)
        {
            try
            {
                var result = await _service.DeleteAsync(beneficiaryId);
                if (!result)
                    return NotFound(new { message = $"Beneficiary with ID {beneficiaryId} not found." });

                return Ok(new { message = "Beneficiary deleted successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while deleting the beneficiary.", error = ex.Message });
            }
        }
    }
}
