using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Restro.Exceptions;
using Restro.Models;
using Restro.Services;

namespace Restro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableBookingsController : ControllerBase
    {
        private readonly ITableBookingService _tableBookingService;

        public TableBookingsController(ITableBookingService tableBookingService)
        {
            _tableBookingService = tableBookingService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TableBooking>>> GetTableBookings()
        {
            var tableBookings = await _tableBookingService.GetAllTableBookingsAsync();
            return Ok(tableBookings);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TableBooking>> GetTableBooking(int id)
        {
            try
            {
                var tableBooking = await _tableBookingService.GetTableBookingByIdAsync(id);
                if (tableBooking == null)
                {
                    return NotFound($"Table booking with ID {id} not found.");
                }
                return Ok(tableBooking);
            }
            catch (TableBookingNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<TableBooking>> CreateTableBooking(TableBooking tableBooking)
        {
            try
            {
                var createdTableBooking = await _tableBookingService.CreateTableBookingAsync(tableBooking);
                return CreatedAtAction(nameof(GetTableBooking), new { id = createdTableBooking.TableBookingId }, createdTableBooking);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTableBooking(int id, TableBooking tableBooking)
        {
            try
            {
                if (id != tableBooking.TableBookingId)
                {
                    return BadRequest("Table booking ID mismatch.");
                }

                await _tableBookingService.UpdateTableBookingAsync(tableBooking);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTableBooking(int id)
        {
            try
            {
                await _tableBookingService.DeleteTableBookingAsync(id);
                return NoContent();
            }
            catch (TableBookingNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}

