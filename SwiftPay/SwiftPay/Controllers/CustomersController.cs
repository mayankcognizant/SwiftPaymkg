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
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _service;

        public CustomersController(ICustomerService service)
        {
            _service = service;
        }

        /// <summary>
        /// Create a new customer profile
        /// </summary>
        /// <param name="dto">Customer creation data</param>
        /// <returns>Created customer object</returns>
        /// <response code="200">Customer created successfully</response>
        /// <response code="400">Invalid request data</response>
        /// <response code="500">Server error</response>
        [HttpPost]
        [ProducesResponseType(typeof(CustomerProfile), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] CreateCustomerDto dto)
        {
            if (dto == null)
                return BadRequest(new { message = "Request body is required." });

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var created = await _service.CreateAsync(dto);
                return Ok(new { message = "Customer created successfully.", data = created });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while creating the customer.", error = ex.Message });
            }
        }

        /// <summary>
        /// Get customer by ID
        /// </summary>
        /// <param name="customerId">Customer ID</param>
        /// <returns>Customer object</returns>
        /// <response code="200">Customer found</response>
        /// <response code="404">Customer not found</response>
        /// <response code="500">Server error</response>
        [HttpGet("{customerId}")]
        [ProducesResponseType(typeof(CustomerProfile), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(int customerId)
        {
            try
            {
                var customer = await _service.GetByIdAsync(customerId);
                if (customer == null)
                    return NotFound(new { message = $"Customer with ID {customerId} not found." });

                return Ok(new { message = "Customer retrieved successfully.", data = customer });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while retrieving the customer.", error = ex.Message });
            }
        }

        /// <summary>
        /// Get customer by User ID
        /// </summary>
        /// <param name="userId">User ID</param>
        /// <returns>Customer object</returns>
        /// <response code="200">Customer found</response>
        /// <response code="404">Customer not found</response>
        /// <response code="500">Server error</response>
        [HttpGet("user/{userId}")]
        [ProducesResponseType(typeof(CustomerProfile), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByUserId(int userId)
        {
            try
            {
                var customer = await _service.GetByUserIdAsync(userId);
                if (customer == null)
                    return NotFound(new { message = $"Customer with User ID {userId} not found." });

                return Ok(new { message = "Customer retrieved successfully.", data = customer });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while retrieving the customer.", error = ex.Message });
            }
        }

        /// <summary>
        /// Get all customers
        /// </summary>
        /// <returns>List of all active customers</returns>
        /// <response code="200">Customers retrieved successfully</response>
        /// <response code="500">Server error</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CustomerProfile>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var customers = await _service.GetAllAsync();
                return Ok(new { message = "Customers retrieved successfully.", data = customers });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while retrieving customers.", error = ex.Message });
            }
        }

        /// <summary>
        /// Update customer information
        /// </summary>
        /// <param name="customerId">Customer ID</param>
        /// <param name="dto">Customer update data</param>
        /// <returns>Updated customer object</returns>
        /// <response code="200">Customer updated successfully</response>
        /// <response code="404">Customer not found</response>
        /// <response code="400">Invalid request data</response>
        /// <response code="500">Server error</response>
        [HttpPut("{customerId}")]
        [ProducesResponseType(typeof(CustomerProfile), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int customerId, [FromBody] UpdateCustomerDto dto)
        {
            if (dto == null)
                return BadRequest(new { message = "Request body is required." });

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var updated = await _service.UpdateAsync(customerId, dto);
                return Ok(new { message = "Customer updated successfully.", data = updated });
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("not found"))
                    return NotFound(new { message = ex.Message });
                
                return StatusCode(500, new { message = "An error occurred while updating the customer.", error = ex.Message });
            }
        }

        /// <summary>
        /// Delete (soft delete) a customer
        /// </summary>
        /// <param name="customerId">Customer ID</param>
        /// <returns>Success or failure message</returns>
        /// <response code="200">Customer deleted successfully</response>
        /// <response code="404">Customer not found</response>
        /// <response code="500">Server error</response>
        [HttpDelete("{customerId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int customerId)
        {
            try
            {
                var result = await _service.DeleteAsync(customerId);
                if (!result)
                    return NotFound(new { message = $"Customer with ID {customerId} not found." });

                return Ok(new { message = "Customer deleted successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while deleting the customer.", error = ex.Message });
            }
        }
    }
}
