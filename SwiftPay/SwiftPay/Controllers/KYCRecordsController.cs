using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SwiftPay.Services.Interfaces;
using SwiftPay.DTOs.UserCustomerDTO;
using SwiftPay.Domain.Remittance.Entities;

namespace SwiftPay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KYCRecordsController : ControllerBase
    {
        private readonly IKYCRecordService _service;

        public KYCRecordsController(IKYCRecordService service)
        {
            _service = service;
        }

        /// <summary>
        /// Create a new KYC record
        /// </summary>
        /// <param name="dto">KYC record creation data</param>
        /// <returns>Created KYC record object</returns>
        /// <response code="200">KYC record created successfully</response>
        /// <response code="400">Invalid request data</response>
        /// <response code="500">Server error</response>
        [HttpPost]
        [ProducesResponseType(typeof(KYCRecord), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] CreateKYCRecordDto dto)
        {
            if (dto == null)
                return BadRequest(new { message = "Request body is required." });

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var created = await _service.CreateAsync(dto);
                return Ok(new { message = "KYC record created successfully.", data = created });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while creating the KYC record.", error = ex.Message });
            }
        }

        /// <summary>
        /// Get KYC record by ID
        /// </summary>
        /// <param name="kycId">KYC record ID</param>
        /// <returns>KYC record object</returns>
        /// <response code="200">KYC record found</response>
        /// <response code="404">KYC record not found</response>
        /// <response code="500">Server error</response>
        [HttpGet("{kycId}")]
        [ProducesResponseType(typeof(KYCRecord), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(int kycId)
        {
            try
            {
                var kyc = await _service.GetByIdAsync(kycId);
                if (kyc == null)
                    return NotFound(new { message = $"KYC record with ID {kycId} not found." });

                return Ok(new { message = "KYC record retrieved successfully.", data = kyc });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while retrieving the KYC record.", error = ex.Message });
            }
        }

        /// <summary>
        /// Get KYC record by user ID
        /// </summary>
        /// <param name="userId">User ID</param>
        /// <returns>KYC record object</returns>
        /// <response code="200">KYC record found</response>
        /// <response code="404">KYC record not found</response>
        /// <response code="500">Server error</response>
        [HttpGet("user/{userId}")]
        [ProducesResponseType(typeof(KYCRecord), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByUserId(int userId)
        {
            try
            {
                var kyc = await _service.GetByUserIdAsync(userId);
                if (kyc == null)
                    return NotFound(new { message = $"No KYC record found for user with ID {userId}." });

                return Ok(new { message = "KYC record retrieved successfully.", data = kyc });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while retrieving the KYC record.", error = ex.Message });
            }
        }

        /// <summary>
        /// Get all KYC records
        /// </summary>
        /// <returns>List of all KYC records</returns>
        /// <response code="200">KYC records retrieved successfully</response>
        /// <response code="500">Server error</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<KYCRecord>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var kycRecords = await _service.GetAllAsync();
                return Ok(new { message = "KYC records retrieved successfully.", data = kycRecords });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while retrieving KYC records.", error = ex.Message });
            }
        }

        /// <summary>
        /// Update KYC record
        /// </summary>
        /// <param name="kycId">KYC record ID</param>
        /// <param name="dto">Update data</param>
        /// <returns>Updated KYC record</returns>
        /// <response code="200">KYC record updated successfully</response>
        /// <response code="400">Invalid request data</response>
        /// <response code="404">KYC record not found</response>
        /// <response code="500">Server error</response>
        [HttpPut("{kycId}")]
        [ProducesResponseType(typeof(KYCRecord), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int kycId, [FromBody] UpdateKYCRecordDto dto)
        {
            if (dto == null)
                return BadRequest(new { message = "Request body is required." });

            try
            {
                var updated = await _service.UpdateAsync(kycId, dto);
                if (updated == null)
                    return NotFound(new { message = $"KYC record with ID {kycId} not found." });

                return Ok(new { message = "KYC record updated successfully.", data = updated });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while updating the KYC record.", error = ex.Message });
            }
        }

        /// <summary>
        /// Mark KYC record as verified
        /// </summary>
        /// <param name="kycId">KYC record ID</param>
        /// <returns>Updated KYC record with verified status</returns>
        /// <response code="200">KYC record marked as verified</response>
        /// <response code="404">KYC record not found</response>
        /// <response code="500">Server error</response>
        [HttpPut("{kycId}/verify")]
        [ProducesResponseType(typeof(KYCRecord), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> MarkAsVerified(int kycId)
        {
            try
            {
                var verified = await _service.MarkAsVerifiedAsync(kycId);
                if (verified == null)
                    return NotFound(new { message = $"KYC record with ID {kycId} not found." });

                return Ok(new { message = "KYC record marked as verified.", data = verified });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while verifying the KYC record.", error = ex.Message });
            }
        }

        /// <summary>
        /// Delete KYC record
        /// </summary>
        /// <param name="kycId">KYC record ID</param>
        /// <returns>Deletion result</returns>
        /// <response code="200">KYC record deleted successfully</response>
        /// <response code="404">KYC record not found</response>
        /// <response code="500">Server error</response>
        [HttpDelete("{kycId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int kycId)
        {
            try
            {
                var deleted = await _service.DeleteAsync(kycId);
                if (!deleted)
                    return NotFound(new { message = $"KYC record with ID {kycId} not found." });

                return Ok(new { message = "KYC record deleted successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while deleting the KYC record.", error = ex.Message });
            }
        }
    }
}
