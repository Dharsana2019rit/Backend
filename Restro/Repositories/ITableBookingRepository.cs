using System.Collections.Generic;
using System.Threading.Tasks;
using Restro.Models;

namespace Restro.Repositories
{
    public interface ITableBookingRepository
    {
        Task<IEnumerable<TableBooking>> GetAllTableBookingsAsync();
        Task<TableBooking> GetTableBookingByIdAsync(int id);
        Task<TableBooking> CreateTableBookingAsync(TableBooking tableBooking);
        Task UpdateTableBookingAsync(TableBooking tableBooking);
        Task DeleteTableBookingAsync(TableBooking tableBooking);
    }
}
