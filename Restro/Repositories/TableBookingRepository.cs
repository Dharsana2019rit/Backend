using System.Collections.Generic;
using System.Threading.Tasks;
using Restro.Data;
using Microsoft.EntityFrameworkCore;
using Restro.Models;
using Restro.Repositories;

namespace Restro.Repositories
{
    public class TableBookingRepository : ITableBookingRepository
    {
        private readonly RestroDbContext _context;

        public TableBookingRepository(RestroDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TableBooking>> GetAllTableBookingsAsync()
        {
            return await _context.TableBookings.ToListAsync();
        }

        public async Task<TableBooking> GetTableBookingByIdAsync(int id)
        {
            return await _context.TableBookings.FindAsync(id);
        }

        public async Task<TableBooking> CreateTableBookingAsync(TableBooking tableBooking)
        {
            _context.TableBookings.Add(tableBooking);
            await _context.SaveChangesAsync();
            return tableBooking;
        }

        public async Task UpdateTableBookingAsync(TableBooking tableBooking)
        {
            _context.Entry(tableBooking).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTableBookingAsync(TableBooking tableBooking)
        {
            _context.TableBookings.Remove(tableBooking);
            await _context.SaveChangesAsync();
        }
    }
}

